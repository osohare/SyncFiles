using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncFiles.Models
{
    [Flags] public enum DiffType
    {
        None = 0,
        ExistInSourceOnly = 1,
        ExistInDestinationOnly = 2,
        Lenght = 4,
        LastWritten = 8
    }

    [Flags] public enum ItemType
    {
        None = 0,
        File = 1,
        Folder = 2
    }

    [DebuggerDisplay("Source = {Source} Destination = {Destination} DifferenceType = {DifferenceType} Type = {ItemType}")]
    public class FileDiff
    {
        public FileSystemInfo Source { get; set; }
        public FileSystemInfo Destination { get; set; }
        public DiffType DifferenceType { get; set; }
        public  ItemType ItemType { get; set; }
        public string Resolution { get; set; }
    }

}
