using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncFiles.Models
{
    /// <summary>
    /// Types of differences that a file of could have 
    /// </summary>
    [Flags] public enum DiffType
    {
        None = 0,
        ExistInSourceOnly = 1,
        ExistInDestinationOnly = 2,
        Lenght = 4,
        LastWritten = 8
    }

    /// <summary>
    /// Types of items that a difference could belong to
    /// </summary>
    [Flags] public enum ItemType
    {
        None = 0,
        File = 1,
        Folder = 2
    }

    /// <summary>
    /// Object that holds the concept of a file difference, including source, destination, difference type, item type and how this difference will be resolved
    /// </summary>
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
