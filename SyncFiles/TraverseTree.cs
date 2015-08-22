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
        private string SourceRootFolder { get; set; }
        private string DestinationRootFolder { get; set; }
        private ConcurrentBag<FileDiff> AllDifferences { get; set; }

        public IEnumerable<FileDiff> Differences
        {
            get { return AllDifferences; }
        }

        public int TotalDirectories { get; private set; }

        public TraverseTree()
        {
            AllDifferences = new ConcurrentBag<FileDiff>();
        }

        public void Compare(string source, string destination)
        {
            SourceRootFolder = source;
            DestinationRootFolder = destination;
            try
            {
                TraverseTreeParallelForEach(
                    (sourceDirectory, destinationDirectory) =>
                    {
                        try
                        {
                            var sourceFiles = sourceDirectory.EnumerateFiles();
                            var destinationFiles = destinationDirectory.EnumerateFiles();

                            FileSystemCompare compareByName = new FileSystemCompare();
                            FileCompare comparer = new FileCompare();

                            var onlyInSource = sourceFiles.Except(destinationFiles, compareByName);
                            var onlyInDest = destinationFiles.Except(sourceFiles, compareByName);
                            var inBothLists = sourceFiles.Intersect(destinationFiles, compareByName);

                            foreach (var item in onlyInSource)
                            {
                                AllDifferences.Add(new FileDiff() {
                                    Source = item,
                                    Destination = null,
                                    DifferenceType = DiffType.ExistInSourceOnly,
                                    ItemType = ItemType.File
                                });
                            }
                            foreach (var item in onlyInDest)
                            {
                                AllDifferences.Add(new FileDiff()
                                {
                                    Source = null,
                                    Destination = item,
                                    DifferenceType = DiffType.ExistInDestinationOnly,
                                    ItemType = ItemType.File
                                });
                            }
                            foreach (var item in inBothLists)
                            {
                                FileInfo destItem = destinationFiles.FirstOrDefault(x => x.Name == item.Name);
                                if (!comparer.ExternalCompare(item as FileInfo, destItem))
                                { 
                                    AllDifferences.Add(new FileDiff()
                                    {
                                        Source = item,
                                        Destination = destItem,
                                        DifferenceType = DiffType.Other,
                                        ItemType = ItemType.File
                                    });
                                }
                            }
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

        private string TranslateDirectoryPath(string path)
        {
            var fileUri = new Uri(path);
            var referenceUri = new Uri(SourceRootFolder);
            var sourceRelativePath = referenceUri.MakeRelativeUri(fileUri).ToString();
            var destPath = new Uri(new Uri(DestinationRootFolder), sourceRelativePath);

            var destinationFullPath = destPath.LocalPath;
            return destinationFullPath;
        }

        /// <summary>
        /// https://msdn.microsoft.com/en-us/library/ff477033(v=vs.110).aspx
        /// </summary>
        /// <param name="directoryCompareAction"></param>
        private void TraverseTreeParallelForEach(Action<DirectoryInfo, DirectoryInfo> directoryCompareAction)
        {
            //Count of files traversed and timer for diagnostic output 
            int directoryCount = 0;
            var sw = Stopwatch.StartNew();

            // Determine whether to parallelize file processing on each folder based on processor count. 
            int procCount = Environment.ProcessorCount;

            // Data structure to hold names of subfolders to be examined for files.
            Stack<DirectoryInfo> sourceDirectories = new Stack<DirectoryInfo>();

            if (!Directory.Exists(SourceRootFolder))
            {
                throw new ArgumentException();
            }
            if (!Directory.Exists(DestinationRootFolder))
            {
                throw new ArgumentException();
            }

            directoryCompareAction(new DirectoryInfo(SourceRootFolder), new DirectoryInfo(DestinationRootFolder));
            sourceDirectories.Push(new DirectoryInfo(SourceRootFolder));

            while (sourceDirectories.Count > 0)
            {
                DirectoryInfo sourceDir = sourceDirectories.Pop();
                DirectoryInfo destinationDir = null;
                IEnumerable<DirectoryInfo> sourceSubDirs = null;
                IEnumerable<DirectoryInfo> destinationSubDirs = null;
                FileSystemCompare compareByName = new FileSystemCompare();

                try
                {
                    var destinationDirString = TranslateDirectoryPath(sourceDir.FullName);
                    if (Directory.Exists(destinationDirString))
                    {
                        destinationDir = new DirectoryInfo(destinationDirString);
                        sourceSubDirs = sourceDir.EnumerateDirectories();
                        destinationSubDirs = destinationDir.EnumerateDirectories();
                        //extract source and dest and compare
                        var onlyInSource = sourceSubDirs.Except(destinationSubDirs, compareByName);
                        var onlyInDest = destinationSubDirs.Except(sourceSubDirs, compareByName);
                        //all exceptions add to list TODO


                        //only navigate what exists in both
                        var inBothLists = sourceSubDirs.Intersect(destinationSubDirs, compareByName);
                        foreach (var item in inBothLists)
                        {
                            sourceDirectories.Push(item as DirectoryInfo);
                        }
                    }
                    else
                    {
                        //add to exceptions, destination folder does not exist
                    }
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
                    Parallel.ForEach(sourceSubDirs, () => 0, (sourceSubDir, loopState, localCount) =>
                    {
                        var destinationSubDir = TranslateDirectoryPath(sourceSubDir.FullName);
                        directoryCompareAction(sourceSubDir, new DirectoryInfo(destinationSubDir));
                        return (int)++localCount;
                    },
                    (c) =>
                    {
                        Interlocked.Add(ref directoryCount, c);
                    });
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
            }
            TotalDirectories = directoryCount;
        }

    }
}
