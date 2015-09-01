using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncFiles.Models
{
    public class Workspace
    {
        public string Folder1 { get; set; }
        public string Folder2 { get; set; }
        public List<string> Exclusions { get; set; }

        public static Workspace FromFile(string fileName)
        {
            return JsonConvert.DeserializeObject<Workspace>(File.ReadAllText(fileName));
        }

        public void ToFile(string fileName)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(this));
        }
    }
}
