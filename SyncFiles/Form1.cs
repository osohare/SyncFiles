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
        public Form1()
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

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolder1.Text))
                throw new ApplicationException("Directory does not exist");

            if (!Directory.Exists(txtFolder2.Text))
                throw new ApplicationException("Directory does not exist");

            TraverseTree traverse = new TraverseTree();
            traverse.Compare(txtFolder1.Text, txtFolder2.Text);
        }
    }
}
