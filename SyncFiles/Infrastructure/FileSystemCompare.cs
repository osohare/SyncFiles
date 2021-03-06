﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncFiles.Infrastructure
{
    /// <summary>
    /// This implementation defines a very simple comparison between two FileInfo objects.It only compares the name of the files being compared and their length in bytes.
    /// </summary>
    public class FileSystemCompare : IEqualityComparer<FileSystemInfo>
    {
        public FileSystemCompare() { }

        public bool Equals(FileSystemInfo f1, FileSystemInfo f2)
        {
            return (f1.Name == f2.Name);
        }

        /// <summary>
        /// Return a hash that reflects the comparison criteria. According to the  
        /// rules for IEqualityComparer<T>, if Equals is true, then the hash codes must
        /// also be equal.Because equality as defined here is a simple value equality, not
        /// reference identity, it is possible that two or more objects will produce the same
        /// hash code. 
        /// </summary>
        /// <param name="fi">FileSystemInfo object to get hash from</param>
        /// <returns>Hash code from this object</returns>
        public int GetHashCode(FileSystemInfo fi)
        {
            string s = String.Format("{0}", fi.Name);
            return s.GetHashCode();
        }
    }
}
