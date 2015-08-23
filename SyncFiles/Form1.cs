using Equin.ApplicationFramework;
using SyncFiles.Models;
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
    public partial class frmMain : Form
    {
        private TraverseTree traverse = new TraverseTree();
        private BindingListView<FileDiff> view = new BindingListView<FileDiff>(new string[] { });

        public frmMain()
        {
            InitializeComponent();
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

        private async void btnCompare_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolder1.Text))
                throw new ApplicationException("Directory does not exist");

            if (!Directory.Exists(txtFolder2.Text))
                throw new ApplicationException("Directory does not exist");

            traverse.ExcludeFolders.Add(@"F:\_Western");
            traverse.ExcludeFolders.Add(@"M:\.Trash-1000");
            traverse.ExcludeFolders.Add(@"M:\Natallia\Photos\Lightroom\catalog");

            var progressIndicator = new Progress<string>(ReportScanProgress);
            await traverse.Compare(txtFolder1.Text, txtFolder2.Text, progressIndicator);

            List<FileDiff> differences = traverse.Differences;
            view = new BindingListView<FileDiff>(differences);
            dataGridView1.DataSource = view;

            lblStatus.Text = string.Format("Scanned {0} directories, {1} differences", traverse.TotalDirectories, traverse.Differences.Count());
        }

        private void ReportScanProgress(string value)
        {
            //Update the UI to reflect the progress value that is passed back.
            if (lblStatus.InvokeRequired)
                lblStatus.BeginInvoke((MethodInvoker) delegate () { lblStatus.Text = value; });
            else
                lblStatus.Text = value;
        }

        private void chkDiffType_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    view.ApplyFilter(delegate (FileDiff diff) { return diff.DifferenceType == DiffType.ExistInSourceOnly; });
                    break;
                case 1:
                    view.ApplyFilter(delegate (FileDiff diff) { return diff.DifferenceType == DiffType.ExistInDestinationOnly; });
                    break;
                case 2:
                    view.ApplyFilter(delegate (FileDiff diff) { return diff.DifferenceType == DiffType.Lenght; });
                    break;
                case 3:
                    view.ApplyFilter(delegate (FileDiff diff) { return diff.DifferenceType == DiffType.LastWritten; });
                    break;
            }
        }
    }
}
