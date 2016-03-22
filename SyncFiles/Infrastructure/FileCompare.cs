using SyncFiles.Checksum;
using System;
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
    public class FileCompare : IEqualityComparer<FileInfo>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public FileCompare() { }

        /// <summary>
        /// From IEqualityComparer
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        public bool Equals(FileInfo f1, FileInfo f2)
        {
            return (f1.Name == f2.Name 
                    && f1.Length == f2.Length
                    && f1.LastWriteTimeUtc.ToString("yyyyMMMddHHmmss").Equals(f2.LastWriteTimeUtc.ToString("yyyyMMMddHHmmss")));
        }

        /// <summary>
        /// The compiler will mix up ObjectEquality itself for one instance of FileCompare with another, this function facilitates explicitly calling comparison from FileInfo to another
        /// </summary>
        /// <param name="f1">Instance 1</param>
        /// <param name="f2">Instance 2</param>
        /// <returns>If instance1 is the equivalent to instance2</returns>
        public bool ExternalCompare(FileInfo f1, FileInfo f2)
        {
            return this.Equals(f1, f2);
        }

        /// <summary>
        /// The compiler will mix up ObjectEquality itself for one instance of FileCompare with another, this function facilitates explicitly calling comparison from FileInfo to another. This version will calculate a hash for two files and compare them.
        /// </summary>
        /// <param name="f1">Instance 1</param>
        /// <param name="f2">Instance 2</param>
        /// <returns>If instance1 is the equivalent to instance2</returns>
        public bool ExternalCompareByHash(FileInfo f1, FileInfo f2)
        {
            FileHasher hasher = new FileHasher();
            var hash1 = hasher.HashFile(f1.FullName);
            var hash2 = hasher.HashFile(f2.FullName);
            return hash1.Equals(hash2);
        }

        /// <summary>
        /// Return a hash that reflects the comparison criteria.According to the rules for IEqualityComparer<T>, if Equals is true, then the hash codes must also be equal.
        /// Because equality as defined here is a simple value equality, not reference identity, it is possible that two or more objects will produce the same hash code. 
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public int GetHashCode(FileInfo fi)
        {
            string s = String.Format("{0}{1}{2}", fi.Name, fi.Length, fi.LastWriteTimeUtc.ToString("yyyyMMMddHHmmss"));
            return s.GetHashCode();
        }
    }
}
