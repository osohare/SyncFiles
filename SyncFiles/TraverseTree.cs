using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncFiles
{
    public class TraverseTree
    {
        private ConcurrentBag<FileDiff> AllDifferences { get; set; }

        public TraverseTree()
        {
            AllDifferences = new ConcurrentBag<FileDiff>();
        }

        public void Compare(string source, string destination)
        {
            try
            {
                TraverseTreeParallelForEach(source, 
                    (fileCompareAction) =>
                    {
                        try
                        {
                            // Do nothing with the data except read it. 
                            Console.WriteLine(f);
                        }
                        catch (FileNotFoundException) { }
                        catch (IOException) { }
                        catch (UnauthorizedAccessException) { }
                        catch (SecurityException) { }
                    },
                    (fileCompareAction) =>
                    {
                    try
                    {
                        // Do nothing with the data except read it. 
                        Console.WriteLine(f);
                    }
                    catch (FileNotFoundException) { }
                    catch (IOException) { }
                    catch (UnauthorizedAccessException) { }
                    catch (SecurityException) { }
                }
                );
            }
            catch (ArgumentException)
            {
                Console.WriteLine(string.Format("The directory {0} does not exist", source));
            }
        }

        private void TraverseTreeParallelForEach(string root, Action<string> fileCompareAction, Action<string> directoryCompareAction)
        {
            //Count of files traversed and timer for diagnostic output 
            int fileCount = 0;
            var sw = Stopwatch.StartNew();

            // Determine whether to parallelize file processing on each folder based on processor count. 
            int procCount = Environment.ProcessorCount;

            // Data structure to hold names of subfolders to be examined for files.
            Stack<string> dirs = new Stack<string>();

            if (!Directory.Exists(root))
            {
                throw new ArgumentException();
            }

            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs = { };
                string[] files = { };

                try
                {
                    subDirs = Directory.GetDirectories(currentDir);
                }
                // Thrown if we do not have discovery permission on the directory. 
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                // Thrown if another process has deleted the directory after we retrieved its name. 
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                try
                {
                    files = Directory.GetFiles(currentDir);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                // Execute in parallel if there are enough files in the directory. 
                // Otherwise, execute sequentially.Files are opened and processed 
                // synchronously but this could be modified to perform async I/O. 
                try
                {
                    if (files.Length < procCount)
                    {
                        foreach (var file in files)
                        {
                            fileCompareAction(file);
                            fileCount++;
                        }
                    }
                    else
                    {
                        Parallel.ForEach(files, () => 0, (file, loopState, localCount) =>
                        {
                            fileCompareAction(file);
                            return (int)++localCount;
                        },
                                         (c) => {
                                             Interlocked.Add(ref fileCount, c);
                                         });
                    }
                }
                catch (AggregateException ae)
                {
                    ae.Handle((ex) => {
                        if (ex is UnauthorizedAccessException)
                        {
                            // Here we just output a message and go on.
                            Console.WriteLine(ex.Message);
                            return true;
                        }
                        // Handle other exceptions here if necessary... 

                        return false;
                    });
                }

                // Push the subdirectories onto the stack for traversal. 
                // This could also be done before handing the files. 
                foreach (string str in subDirs)
                    dirs.Push(str);
            }

            // For diagnostic purposes.
            //Console.WriteLine("Processed {0} files in {1} milleseconds", fileCount, sw.ElapsedMilliseconds);
        }
    }
}
