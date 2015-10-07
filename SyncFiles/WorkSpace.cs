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
        public Workspace CurrentWorkspace = null;

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
                    CurrentWorkspace = Workspace.FromFile(openFileDialog1.FileName);
                    txtFolder1.Text = CurrentWorkspace.Folder1;
                    txtFolder2.Text = CurrentWorkspace.Folder2;
                    foreach (var item in CurrentWorkspace.Exclusions)
                    {
                        lstExclusions.Items.Add(item);
                    }
                    foreach (var item in CurrentWorkspace.ExclusionPatterns)
                    {
                        lstPatterns.Items.Add(item);
                    }
                    break;
                default:
                    break;
            }
        }

        private void SaveWorkspace(bool prompt)
        {
            if (!Directory.Exists(txtFolder1.Text))
                MessageBox.Show("The folder in Folder1 does not exist", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (!Directory.Exists(txtFolder2.Text))
                MessageBox.Show("The folder in Folder2 does not exist", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            CurrentWorkspace = new Workspace()
            {
                Folder1 = txtFolder1.Text,
                Folder2 = txtFolder2.Text,
                Exclusions = new List<string>(),
                ExclusionPatterns = new List<string>()
            };
            foreach (var item in lstExclusions.Items)
            {
                CurrentWorkspace.Exclusions.Add(item.ToString());
            }
            foreach (var item in lstPatterns.Items)
            {
                CurrentWorkspace.ExclusionPatterns.Add(item.ToString());
            }

            if (prompt)
            {
                saveFileDialog1.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                switch (saveFileDialog1.ShowDialog())
                {
                    case DialogResult.OK:
                    case DialogResult.Yes:
                        CurrentWorkspace.ToFile(saveFileDialog1.FileName);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                CurrentWorkspace.ToFile(openFileDialog1.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveWorkspace(true);
            this.DialogResult = DialogResult.Ignore;
            this.Close();
        }

        private void btnSaveUse_Click(object sender, EventArgs e)
        {
            SaveWorkspace(false);
            this.DialogResult = DialogResult.OK;
            this.Close();
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

        private void txtPattern_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\r':
                    lstPatterns.Items.Add(txtPattern.Text);
                    txtPattern.Text = string.Empty;
                    break;
                default:
                    break;
            }
        }

        private void lstPatterns_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\b':
                    lstPatterns.Items.Remove(lstPatterns.SelectedItem);
                    break;
                default:
                    break;
            }
        }
    }
}
