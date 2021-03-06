﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncFiles.Checksum
{
    /// <summary>
    /// Class that calculates a Hash for a file, internally the class will decide if additional threads are required in producer/consumer fashion; for the case of large files this speeds up the process a little bit
    /// </summary>
    public class FileHasher
    {
        /// <summary>
        /// Buffer size is ideal 32K, from many sources current har disks perform better by reading 32K at the time
        /// </summary>
        private const int BUFFER_SIZE = 32768;
        /// <summary>
        /// Any file with a size bigger than this constant is considered a candidate for producer/consumer hashing
        /// </summary>
        private const int FILE_LIMIT = 10485760; //10Mb

        /// <summary>
        /// Calculate a hash for a given file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string HashFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(string.Format("The file {0} was not found", fileName));
            }

            FileInfo i = new FileInfo(fileName);
            if (i.Length > FILE_LIMIT)
            {
                return _HashFileAsync(fileName);
            }
            else
            {
                return _HashFile(fileName);
            }
        }

        /// <summary>
        /// Simple linear hashing for a file, the stream reads and hashes forward for each byte chunk; fast disks with fast CPUs might not notice difference between this and producer/consumer
        /// </summary>
        /// <param name="fileName">File to calculate hash for</param>
        /// <returns>Hash calculated for this file in format XX-XX-XX-XX</returns>
        private string _HashFile(string fileName)
        {
            var adler = new Adler32Managed();
            string retval = string.Empty;

            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                // Read bytes from stream and interpret them as ints
                byte[] buffer = new byte[BUFFER_SIZE];
                int count = 0;
                // Read from the IO stream fewer times.
                while ((count = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (count == BUFFER_SIZE)
                        adler.TransformBlock(buffer, 0, buffer.Length, buffer, 0);
                    else
                        adler.TransformFinalBlock(buffer, 0, buffer.Length);
                }
            }

            return BitConverter.ToString(adler.Hash);
        }

        /// <summary>
        /// Producer/consumer style of hasher, optimized for longer files and non-blocking with threads; consult TPL for .NET 4.5
        /// </summary>
        /// <param name="fileName">File to calculate hash for</param>
        /// <returns>Hash calculated for this file in format XX-XX-XX-XX</returns>
        private string _HashFileAsync(string fileName)
        {
            var adler = new Adler32Managed();
            string retval = string.Empty;

            // A bounded collection. Increase, decrease, or remove the 
            // maximum capacity argument to see how it impacts behavior.
            BlockingCollection<List<byte>> bufferBlocks = new BlockingCollection<List<byte>>(1024);

            // A simple blocking consumer with no cancellation.
            Task consumer = Task.Run(() =>
            {
                List<byte> byteBuffer = null;
                while (!bufferBlocks.IsCompleted)
                {
                    try
                    {
                        int offset = 0;
                        byteBuffer = bufferBlocks.Take();
                        byte[] buffer = byteBuffer.ToArray();
                        if (!bufferBlocks.IsAddingCompleted || bufferBlocks.Count != 0)
                            offset += adler.TransformBlock(buffer, 0, buffer.Length, buffer, 0);
                        else
                            adler.TransformFinalBlock(buffer, 0, buffer.Length);
                    }
                    catch (InvalidOperationException)
                    {
                        //Console.WriteLine("Adding was completed!");
                        break;
                    }
                    //Console.WriteLine("Take:{0} ", bufferBlocks.Count);
                }
            });

            // A simple blocking producer with no cancellation.
            Task producer = Task.Run(() =>
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Open))
                {
                    // Read bytes from stream and interpret them as ints
                    byte[] buffer = new byte[BUFFER_SIZE];
                    int count = 0;
                    // Read from the IO stream fewer times.
                    while ((count = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        bufferBlocks.Add(buffer.ToList());
                        //Console.WriteLine("Add:{0} Count={1}", buffer.LongLength, bufferBlocks.Count);
                    }
                }
                // See documentation for this method.
                bufferBlocks.CompleteAdding();
            });

            Task.WaitAll(new Task[] { producer, consumer });
            return BitConverter.ToString(adler.Hash);
        }
    }
}
