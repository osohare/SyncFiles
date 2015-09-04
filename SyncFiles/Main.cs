using Equin.ApplicationFramework;
using SyncFiles.Checksum;
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

            treeSource.Nodes.Add(MakeTreeFromPaths(differences, "Source Files", source: true));
            treeSource.Sort();
            //treeSource.ExpandAll();

            treeDestination.Nodes.Add(MakeTreeFromPaths(differences, "Destination Files", source: false));
            treeDestination.Sort();
            //treeDestination.ExpandAll();
        }

        private TreeNode MakeTreeFromPaths(List<FileDiff> paths, string rootNodeName = "", char separator = '\\', bool source = true)
        {
            var rootNode = new TreeNode(rootNodeName);
            var allpaths = source ? paths.Where(x => x.Source != null) : paths.Where(x => x.Destination != null);

            foreach (var path in allpaths)
            {
                var currentNode = rootNode;
                var pathItems = source ? path.Source.FullName.Split(separator) : path.Destination.FullName.Split(separator);
                var lastItem = pathItems.Last();
                foreach (var item in pathItems)
                {
                    var tmp = currentNode.Nodes.Cast<TreeNode>().Where(x => x.Text.Equals(item));
                    currentNode = tmp.Count() > 0 ? tmp.Single() : currentNode.Nodes.Add(item);
                    if (lastItem.Equals(item))
                    {
                        if(path.DifferenceType.HasFlag( DiffType.ExistInSourceOnly | DiffType.ExistInDestinationOnly))
                            currentNode.ForeColor = Color.Red;
                        if (path.DifferenceType == DiffType.LastWritten)
                            currentNode.ForeColor = Color.Blue;
                    }
                }
            }
            return rootNode;
        }

        private void ReportScanProgress(string value)
        {
            //Update the UI to reflect the progress value that is passed back.
            if (lblStatus.InvokeRequired)
                lblStatus.BeginInvoke((MethodInvoker) delegate () { lblStatus.Text = value; });
            else
                lblStatus.Text = value;
        }

        private void lstFilter_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            DiffType selection = 0;
            foreach (var item in lstFilter.Items)
            {
                var viewItem = item as ListViewItem;
                if (viewItem.Checked)
                    selection = selection | (DiffType)int.Parse(viewItem.Tag.ToString());
            }

            view.ApplyFilter(delegate (FileDiff diff) { return selection.HasFlag(diff.DifferenceType); });
        }

        private void btnSync_Click(object sender, EventArgs e)
        {

        }

        private void btnWorkspace_Click(object sender, EventArgs e)
        {
            frmWorkSpace workspaceForm = new frmWorkSpace();
            switch (workspaceForm.ShowDialog())
            {
                case DialogResult.OK:
                case DialogResult.Yes:

                    break;
                default:
                    break;
            }
        }
    }
}
