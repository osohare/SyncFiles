using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncFiles.Models
{
    /// <summary>
    /// A workspace is the concept of mapping a folder area in the source to a folder area in a destination, you can serialize and deserialize this to disk so you can work different previously defined worspaces
    /// </summary>
    public class Workspace
    {
        /// <summary>
        /// Source to start mapping a folder hierarchy
        /// </summary>
        public string Folder1 { get; set; }
        /// <summary>
        /// Destination to a folder hierarchy from Folder1
        /// </summary>
        public string Folder2 { get; set; }
        /// <summary>
        /// If there are any folders we should not compare, define here
        /// </summary>
        public List<string> Exclusions { get; set; }
        /// <summary>
        /// Exclude items by regex match instead of fullname
        /// </summary>
        public List<string> ExclusionPatterns { get; set; }
        /// <summary>
        /// Name of this workspace
        /// </summary>
        public string WorkspaceName { get; set; }

        /// <summary>
        /// Method to read a file and load a previously saved workspace
        /// </summary>
        /// <param name="fileName">Config fileName</param>
        /// <returns>Workspace object</returns>
        public static Workspace FromFile(string fileName)
        {
            if (!File.Exists(fileName))
                return null;
            var workspace = JsonConvert.DeserializeObject<Workspace>(File.ReadAllText(fileName));
            workspace.WorkspaceName = Path.GetFileName(fileName);
            return workspace;
        }

        /// <summary>
        /// Serialize back to disk this workspace
        /// </summary>
        /// <param name="fileName">Config fileName</param>
        public void ToFile(string fileName)
        {
            this.WorkspaceName = Path.GetFileName(fileName);
            File.WriteAllText(fileName, JsonConvert.SerializeObject(this));
        }
    }
}
