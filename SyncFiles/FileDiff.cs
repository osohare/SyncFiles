using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncFiles
{
    public enum DiffType
    {
        ExistInSourceOnly,
        ExistInDestinationOnly,
        DifferentSize,
        DifferentLastModified
    }

    public class FileDiff
    {
        public FileSystemInfo Source { get; set; }
        public FileSystemInfo Destination { get; set; }
        public DiffType DifferenceType { get; set; }
    }
}
