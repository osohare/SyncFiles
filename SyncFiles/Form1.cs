using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncFiles
{
    public partial class Form1 : Form
    {

        internal string SourceFolder { get; set; }
        internal string DestinationFolder { get; set; }
        internal ConcurrentBag<FileDiff> AllDifferences { get; set; }


        public Form1()
        {
            InitializeComponent();
            AllDifferences = new ConcurrentBag<FileDiff>();
        }

        private void btnFolder1_Click(object sender, EventArgs e)
        {
            fldSynch.Description = "Choose a source folder";
            fldSynch.RootFolder = Environment.SpecialFolder.Desktop;
            var result = fldSynch.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                case DialogResult.Yes:
                    txtFolder1.Text = fldSynch.SelectedPath;
                    break;
                default:
                    break;
            }   
        }

        private void btnFolder2_Click(object sender, EventArgs e)
        {
            fldSynch.Description = "Choose a dest folder";
            fldSynch.RootFolder = Environment.SpecialFolder.Desktop;
            var result = fldSynch.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                case DialogResult.Yes:
                    txtFolder2.Text = fldSynch.SelectedPath;
                    break;
                default:
                    break;
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtFolder1.Text))
                SourceFolder = txtFolder1.Text;
            else
                throw new ApplicationException("Directory does not exist");

            if (Directory.Exists(txtFolder2.Text))
                DestinationFolder = txtFolder2.Text;
            else
                throw new ApplicationException("Directory does not exist");

            CompareFolder(this.SourceFolder, this.DestinationFolder);
        }

        private void CompareFolder(string sourcePath, string destPath)
        {
            DirectoryInfo sourceInfo = new DirectoryInfo(sourcePath);
            DirectoryInfo destInfo = new DirectoryInfo(destPath);

            var allSourceDirChilds = sourceInfo.GetDirectories().ToList();
            var allSourceFileChilds = sourceInfo.GetFiles().ToList();

            var allDestDirChilds = destInfo.GetDirectories().ToList();
            var allDestFileChilds = destInfo.GetFiles().ToList();

            FileDiff diff = null;

            ////////////////////////////
            //File vs file
            ////////////////////////////
            foreach (var sourceFile in allSourceFileChilds)
            {
                //We have at least one match of name at the same level
                if (allDestFileChilds.Exists(f => f.Name == sourceFile.Name))
                {
                    var destFile = allDestFileChilds.FirstOrDefault(f => f.Name == sourceFile.Name);

                    //Check first last write criteria
                    if (sourceFile.LastWriteTimeUtc != destFile.LastWriteTimeUtc)
                    {
                        diff = new FileDiff() { Source = sourceFile, Destination = destFile, DifferenceType = DiffType.DifferentLastModified, ItemType = ItemType.File };
                        AllDifferences.Add(diff);
                        allDestFileChilds.Remove(destFile); //Remove as it was accounted for
                    }
                    else if (sourceFile.Length != destFile.Length)
                    {
                        diff = new FileDiff() { Source = sourceFile, Destination = destFile, DifferenceType = DiffType.DifferentSize, ItemType = ItemType.File };
                        AllDifferences.Add(diff);
                        allDestFileChilds.Remove(destFile); //Remove as it was accounted for
                    }
                    else //files match do not add an continue
                    {
                        allDestFileChilds.Remove(destFile); //Remove as it was accounted for
                        continue;
                    }
                }
                else //file with same name does not exist
                {
                    //No match means only exists at source, no need to remove from dest as it does not exist
                    diff = new FileDiff() { Source = sourceFile, DifferenceType = DiffType.ExistInSourceOnly, ItemType = ItemType.File };
                    AllDifferences.Add(diff);
                }
            }

            //All the rest that exist in Destination means they do not exist in source
            foreach (var destFile in allDestFileChilds)
            {
                diff = new FileDiff() { Destination = destFile, DifferenceType = DiffType.ExistInDestinationOnly, ItemType = ItemType.File };
                AllDifferences.Add(diff);
            }

            ////////////////////////////
            //Folder vs folder
            ////////////////////////////

            foreach (var sourceDir in allSourceDirChilds)
            {
                //We have at least one match of name at the same level
                if (allDestDirChilds.Exists(f => f.Name == sourceDir.Name))
                {
                    var destFolder = allDestDirChilds.FirstOrDefault(f => f.Name == sourceDir.Name);
                    CompareFolder(sourceDir.FullName, destFolder.FullName);
                    allDestDirChilds.Remove(destFolder);
                }
                else //file with same name does not exist
                {
                    //No match means only exists at source, no need to remove from dest as it does not exist
                    diff = new FileDiff() { Source = sourceDir, DifferenceType = DiffType.ExistInSourceOnly, ItemType = ItemType.Folder };
                    AllDifferences.Add(diff);
                }
            }

            //All the rest that exist in Destination means they do not exist in source
            foreach (var destFolder in allDestDirChilds)
            {
                diff = new FileDiff() { Destination = destFolder, DifferenceType = DiffType.ExistInDestinationOnly, ItemType = ItemType.Folder };
                AllDifferences.Add(diff);
            }
        }
    }
}
