using SyncFiles.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncFiles
{
    public partial class frmWorkSpace : Form
    {
        internal Workspace workspace = null;

        public frmWorkSpace()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            switch (openFileDialog1.ShowDialog())
            {
                case DialogResult.OK:
                case DialogResult.Yes:
                    workspace = Workspace.FromFile(openFileDialog1.FileName);
                    txtFolder1.Text = workspace.Folder1;
                    txtFolder2.Text = workspace.Folder2;
                    foreach (var item in workspace.Exclusions)
                    {
                        lstExclusions.Items.Add(item);
                    }                   
                    break;
                default:
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolder1.Text))
                MessageBox.Show("The folder in Folder1 does not exist", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (!Directory.Exists(txtFolder2.Text))
                MessageBox.Show("The folder in Folder2 does not exist", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            workspace = new Workspace()
            {
                Folder1 = txtFolder1.Text,
                Folder2 = txtFolder2.Text,
                Exclusions = new List<string>()
            };
            foreach (var item in lstExclusions.Items)
            {
                workspace.Exclusions.Add(item.ToString());
            }

            saveFileDialog1.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            switch (saveFileDialog1.ShowDialog())
            {
                case DialogResult.OK:
                case DialogResult.Yes:
                    workspace.ToFile(saveFileDialog1.FileName);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        private void btnSaveUse_Click(object sender, EventArgs e)
        {

        }

        private void txtExclusion_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\r':
                    lstExclusions.Items.Add(txtExclusion.Text);
                    txtExclusion.Text = string.Empty;
                    break;
                default:
                    break;
            }
        }

        private void lstExclusions_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\b':
                    lstExclusions.Items.Remove(lstExclusions.SelectedItem);
                    break;
                default:
                    break;
            }
        }

    }
}
