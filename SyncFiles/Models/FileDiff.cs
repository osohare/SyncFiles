using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncFiles.Models
{
    public enum DiffType
    {
        ExistInSourceOnly,
        ExistInDestinationOnly,
        LastWritten,
        Lenght
    }

    public enum ItemType
    {
        File,
        Folder
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
