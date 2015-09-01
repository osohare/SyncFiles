﻿using SyncFiles.Checksum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncFiles.Infrastructure
{
    // This implementation defines a very simple comparison 
    // between two FileInfo objects. It only compares the name 
    // of the files being compared and their length in bytes. 
    public class FileCompare : IEqualityComparer<FileInfo>
    {
        public FileCompare() { }

        public bool Equals(FileInfo f1, FileInfo f2)
        {
            return (f1.Name == f2.Name 
                    && f1.Length == f2.Length
                    && f1.LastWriteTimeUtc == f2.LastWriteTimeUtc);
        }

        public bool ExternalCompare(FileInfo f1, FileInfo f2)
        {
            return this.Equals(f1, f2);
        }

        public bool ExternalCompareByHash(FileInfo f1, FileInfo f2)
        {
            FileHasher hasher = new FileHasher();
            var hash1 = hasher.HashFile(f1.FullName);
            var hash2 = hasher.HashFile(f2.FullName);
            return hash1.Equals(hash2);
        }

        // Return a hash that reflects the comparison criteria. According to the  
        // rules for IEqualityComparer<T>, if Equals is true, then the hash codes must 
        // also be equal. Because equality as defined here is a simple value equality, not 
        // reference identity, it is possible that two or more objects will produce the same 
        // hash code. 
        public int GetHashCode(FileInfo fi)
        {
            string s = String.Format("{0}{1}{2}", fi.Name, fi.Length, fi.LastWriteTimeUtc);
            return s.GetHashCode();
        }
    }
}
