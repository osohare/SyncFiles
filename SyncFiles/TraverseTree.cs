using SyncFiles.Infrastructure;
using SyncFiles.Models;
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
    /// <summary>
    /// This class helps to traverse a folder structure in a non-recursive fashion; if hierarchy is too big the memory usage will be too high.
    /// While the SourceFolder is traversed it will find the differences with the destination folder, trying to match files by name and adding to an exception list when differences are found.
    /// </summary>
    public class TraverseTree
    {
        /// <summary>
        /// Source folder from where to start comparison
        /// </summary>
        private string SourceRootFolder { get; set; }
        /// <summary>
        /// Destination folder to compare to
        /// </summary>
        private string DestinationRootFolder { get; set; }
        /// <summary>
        /// Concurrent collection where all differences are stored
        /// </summary>
        private ConcurrentBag<FileDiff> AllDifferences { get; set; }
        /// <summary>
        /// Public interface that will convert to IEnumerable/List the list of differences collected
        /// </summary>
        public List<FileDiff> Differences
        {
            get { return AllDifferences.ToList(); }
        }

        /// <summary>
        /// Total number of directories traversed
        /// </summary>
        public int TotalDirectories { get; private set; }
        /// <summary>
        /// Folder exclusions configured for the run
        /// </summary>
        public List<string> ExcludeFolders { get; set; }
        /// <summary>
        /// Exclude items by patterns
        /// </summary>
        public List<string> ExcludePatterns { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        public TraverseTree()
        {
            AllDifferences = new ConcurrentBag<FileDiff>();
            ExcludeFolders = new List<string>();
            ExcludePatterns = new List<string>();
        }

        /// <summary>
        /// Entry point to start traversing and comparing files
        /// </summary>
        /// <param name="source">Source folder</param>
        /// <param name="destination">Destination folder</param>
        /// <param name="startDirScan">IProgress to indicate number of folders scanned so far and the name of the folder being currently inspected</param>
        /// <returns></returns>
        public async Task Compare(string source, string destination, IProgress<string> startDirScan)
        {
            await Task.Run(() =>
            {
                AllDifferences = new ConcurrentBag<FileDiff>();
                SourceRootFolder = source;
                DestinationRootFolder = destination;
                try
                {
                    TraverseTreeParallelForEach(
                        (sourceDirectory, destinationDirectory) =>
                        {
                            try
                            {
                                startDirScan.Report(string.Format("Comparing {0} :: {1}", TotalDirectories, sourceDirectory.FullName));

                                var sourceFiles = sourceDirectory.EnumerateFiles();
                                var destinationFiles = destinationDirectory.EnumerateFiles();

                                FileSystemCompare compareByName = new FileSystemCompare();
                                FileCompare comparer = new FileCompare();

                                var onlyInSource = sourceFiles.Except(destinationFiles, compareByName);
                                var onlyInDest = destinationFiles.Except(sourceFiles, compareByName);
                                var inBothLists = sourceFiles.Intersect(destinationFiles, compareByName);

                                foreach (var item in onlyInSource)
                                {
                                    if (!isExclusion(item.FullName))
                                        AllDifferences.Add(new FileDiff()
                                        {
                                            Source = item,
                                            Destination = null,
                                            DifferenceType = DiffType.ExistInSourceOnly,
                                            ItemType = ItemType.File
                                        });
                                }
                                foreach (var item in onlyInDest)
                                {
                                    if (!isExclusion(item.FullName))
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
                                    if (!isExclusion(item.FullName) && !comparer.ExternalCompare(item as FileInfo, destItem))
                                    {
                                        var itemFile = item as FileInfo;
                                        DiffType type = DiffType.None;

                                        if (!itemFile.LastWriteTimeUtc.ToString("yyyyMMMddHHmmss").Equals(destItem.LastWriteTimeUtc.ToString("yyyyMMMddHHmmss")))
                                            type = DiffType.LastWritten;

                                        if (!itemFile.Length.Equals(destItem.Length))
                                            type = DiffType.Lenght;

                                        AllDifferences.Add(new FileDiff()
                                        {
                                            Source = item,
                                            Destination = destItem,
                                            DifferenceType = type,
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
            });
        }

        /// <summary>
        /// This will translate a location from source and destination, used to verify if a file exists in a relative path from one another
        /// </summary>
        /// <param name="path">Full path to translate starting from SourceRootFolder as relative path</param>
        /// <returns>Full path transalted to DestinationRootFolder</returns>
        private string TranslateDirectoryPath(string path)
        {
            var fileUri = new Uri(path);
            var referenceUri = new Uri(SourceRootFolder);
            var sourceRelativePath = referenceUri.MakeRelativeUri(fileUri).ToString();
            var destPath = new Uri(new Uri(DestinationRootFolder), sourceRelativePath);
            var destinationFullPath = Uri.UnescapeDataString(destPath.LocalPath);
            return destinationFullPath;
        }

        /// <summary>
        /// Traverse routine using TPL, for each directory spawn a thread and compare the files in it against the source folder (if a matching file exists).
        /// https://msdn.microsoft.com/en-us/library/ff477033(v=vs.110).aspx
        /// </summary>
        /// <param name="directoryCompareAction">Delegated action of what to do for comparing files in a direcotry level</param>
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
                    if (isExclusion(destinationDirString) || isExclusion(sourceDir.FullName))
                    {
                        //This only prevents passing through the directory, but does not prevent adding the item to the list
                        continue;
                    }
                    else if (Directory.Exists(destinationDirString))
                    {
                        destinationDir = new DirectoryInfo(destinationDirString);
                        sourceSubDirs = sourceDir.EnumerateDirectories();
                        destinationSubDirs = destinationDir.EnumerateDirectories();
                        //extract source and dest and compare
                        var onlyInSource = sourceSubDirs.Except(destinationSubDirs, compareByName);
                        var onlyInDest = destinationSubDirs.Except(sourceSubDirs, compareByName);
                        //all exceptions add to list TODO
                        foreach (var item in onlyInSource)
                        {
                            if (!isExclusion(item.FullName))
                                AllDifferences.Add(new FileDiff()
                                {
                                    Source = item,
                                    Destination = null,
                                    DifferenceType = DiffType.ExistInSourceOnly,
                                    ItemType = ItemType.Folder
                                });
                        }
                        foreach (var item in onlyInDest)
                        {
                            if (!isExclusion(item.FullName))
                                AllDifferences.Add(new FileDiff()
                                {
                                    Source = null,
                                    Destination = item,
                                    DifferenceType = DiffType.ExistInDestinationOnly,
                                    ItemType = ItemType.Folder
                                });
                        }

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
                        AllDifferences.Add(new FileDiff()
                        {
                            Source = sourceDir,
                            Destination = null,
                            DifferenceType = DiffType.ExistInSourceOnly,
                            ItemType = ItemType.Folder
                        });
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
                    TotalDirectories = directoryCount;
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

        private bool isExclusion(string path)
        {
            if (ExcludeFolders.Contains(path))
                return true;
            foreach (var item in ExcludePatterns)
            {
                if (path.Contains(item))
                    return true;
            }
            return false;
        }

    }
}
