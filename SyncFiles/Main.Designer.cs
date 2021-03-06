﻿namespace SyncFiles
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("Only source");
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("Only destination");
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem("File size");
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem("Last timestamp");
            this.fldSynch = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeSource = new System.Windows.Forms.TreeView();
            this.treeDestination = new System.Windows.Forms.TreeView();
            this.pnlMainControls = new System.Windows.Forms.Panel();
            this.btnWorkspace = new System.Windows.Forms.Button();
            this.lstFilter = new System.Windows.Forms.ListView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnFolder2 = new System.Windows.Forms.Button();
            this.txtFolder2 = new System.Windows.Forms.TextBox();
            this.txtFolder1 = new System.Windows.Forms.TextBox();
            this.lblFolder2 = new System.Windows.Forms.Label();
            this.lblFolder1 = new System.Windows.Forms.Label();
            this.btnFolder1 = new System.Windows.Forms.Button();
            this.lblCurrentWorkspace = new System.Windows.Forms.Label();
            this.txtWorkspace = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlMainControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.treeSource, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.treeDestination, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlMainControls, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(959, 561);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // treeSource
            // 
            this.treeSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSource.Location = new System.Drawing.Point(3, 143);
            this.treeSource.Name = "treeSource";
            this.treeSource.Size = new System.Drawing.Size(377, 415);
            this.treeSource.TabIndex = 25;
            this.treeSource.DoubleClick += new System.EventHandler(this.treeSource_DoubleClick);
            // 
            // treeDestination
            // 
            this.treeDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDestination.Location = new System.Drawing.Point(386, 143);
            this.treeDestination.Name = "treeDestination";
            this.treeDestination.Size = new System.Drawing.Size(377, 415);
            this.treeDestination.TabIndex = 22;
            this.treeDestination.DoubleClick += new System.EventHandler(this.treeDestination_DoubleClick);
            // 
            // pnlMainControls
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pnlMainControls, 3);
            this.pnlMainControls.Controls.Add(this.txtWorkspace);
            this.pnlMainControls.Controls.Add(this.lblCurrentWorkspace);
            this.pnlMainControls.Controls.Add(this.btnWorkspace);
            this.pnlMainControls.Controls.Add(this.lstFilter);
            this.pnlMainControls.Controls.Add(this.lblStatus);
            this.pnlMainControls.Controls.Add(this.btnSync);
            this.pnlMainControls.Controls.Add(this.btnCompare);
            this.pnlMainControls.Controls.Add(this.btnFolder2);
            this.pnlMainControls.Controls.Add(this.txtFolder2);
            this.pnlMainControls.Controls.Add(this.txtFolder1);
            this.pnlMainControls.Controls.Add(this.lblFolder2);
            this.pnlMainControls.Controls.Add(this.lblFolder1);
            this.pnlMainControls.Controls.Add(this.btnFolder1);
            this.pnlMainControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainControls.Location = new System.Drawing.Point(3, 3);
            this.pnlMainControls.Name = "pnlMainControls";
            this.pnlMainControls.Size = new System.Drawing.Size(953, 134);
            this.pnlMainControls.TabIndex = 12;
            // 
            // btnWorkspace
            // 
            this.btnWorkspace.Location = new System.Drawing.Point(342, 62);
            this.btnWorkspace.Name = "btnWorkspace";
            this.btnWorkspace.Size = new System.Drawing.Size(75, 23);
            this.btnWorkspace.TabIndex = 20;
            this.btnWorkspace.Text = "Workspaces";
            this.btnWorkspace.UseVisualStyleBackColor = true;
            this.btnWorkspace.Click += new System.EventHandler(this.btnWorkspace_Click);
            // 
            // lstFilter
            // 
            this.lstFilter.CheckBoxes = true;
            this.lstFilter.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listViewItem17.StateImageIndex = 0;
            listViewItem17.Tag = "1";
            listViewItem18.StateImageIndex = 0;
            listViewItem18.Tag = "2";
            listViewItem19.StateImageIndex = 0;
            listViewItem19.Tag = "4";
            listViewItem20.StateImageIndex = 0;
            listViewItem20.Tag = "8";
            this.lstFilter.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem17,
            listViewItem18,
            listViewItem19,
            listViewItem20});
            this.lstFilter.Location = new System.Drawing.Point(586, 4);
            this.lstFilter.Name = "lstFilter";
            this.lstFilter.Size = new System.Drawing.Size(107, 81);
            this.lstFilter.TabIndex = 19;
            this.lstFilter.UseCompatibleStateImageBehavior = false;
            this.lstFilter.View = System.Windows.Forms.View.List;
            this.lstFilter.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstFilter_ItemChecked);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(11, 104);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Status";
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(504, 62);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 23);
            this.btnSync.TabIndex = 17;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(423, 62);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 16;
            this.btnCompare.Text = "Scan";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnFolder2
            // 
            this.btnFolder2.Location = new System.Drawing.Point(504, 34);
            this.btnFolder2.Name = "btnFolder2";
            this.btnFolder2.Size = new System.Drawing.Size(75, 23);
            this.btnFolder2.TabIndex = 15;
            this.btnFolder2.Text = "Folder 2";
            this.btnFolder2.UseVisualStyleBackColor = true;
            this.btnFolder2.Click += new System.EventHandler(this.btnFolder2_Click);
            // 
            // txtFolder2
            // 
            this.txtFolder2.Location = new System.Drawing.Point(85, 36);
            this.txtFolder2.Name = "txtFolder2";
            this.txtFolder2.Size = new System.Drawing.Size(413, 20);
            this.txtFolder2.TabIndex = 14;
            this.txtFolder2.Text = "C:\\";
            // 
            // txtFolder1
            // 
            this.txtFolder1.Location = new System.Drawing.Point(85, 9);
            this.txtFolder1.Name = "txtFolder1";
            this.txtFolder1.Size = new System.Drawing.Size(413, 20);
            this.txtFolder1.TabIndex = 13;
            this.txtFolder1.Text = "C:\\";
            // 
            // lblFolder2
            // 
            this.lblFolder2.AutoSize = true;
            this.lblFolder2.Location = new System.Drawing.Point(11, 39);
            this.lblFolder2.Name = "lblFolder2";
            this.lblFolder2.Size = new System.Drawing.Size(71, 13);
            this.lblFolder2.TabIndex = 12;
            this.lblFolder2.Text = "Root Folder 2";
            // 
            // lblFolder1
            // 
            this.lblFolder1.AutoSize = true;
            this.lblFolder1.Location = new System.Drawing.Point(11, 12);
            this.lblFolder1.Name = "lblFolder1";
            this.lblFolder1.Size = new System.Drawing.Size(71, 13);
            this.lblFolder1.TabIndex = 11;
            this.lblFolder1.Text = "Root Folder 1";
            // 
            // btnFolder1
            // 
            this.btnFolder1.Location = new System.Drawing.Point(504, 4);
            this.btnFolder1.Name = "btnFolder1";
            this.btnFolder1.Size = new System.Drawing.Size(75, 23);
            this.btnFolder1.TabIndex = 10;
            this.btnFolder1.Text = "Folder 1";
            this.btnFolder1.UseVisualStyleBackColor = true;
            this.btnFolder1.Click += new System.EventHandler(this.btnFolder1_Click);
            // 
            // lblCurrentWorkspace
            // 
            this.lblCurrentWorkspace.AutoSize = true;
            this.lblCurrentWorkspace.Location = new System.Drawing.Point(11, 67);
            this.lblCurrentWorkspace.Name = "lblCurrentWorkspace";
            this.lblCurrentWorkspace.Size = new System.Drawing.Size(101, 13);
            this.lblCurrentWorkspace.TabIndex = 21;
            this.lblCurrentWorkspace.Text = "Current WorkSpace";
            // 
            // txtWorkspace
            // 
            this.txtWorkspace.Location = new System.Drawing.Point(118, 64);
            this.txtWorkspace.Name = "txtWorkspace";
            this.txtWorkspace.ReadOnly = true;
            this.txtWorkspace.Size = new System.Drawing.Size(218, 20);
            this.txtWorkspace.TabIndex = 22;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Natallias backup";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlMainControls.ResumeLayout(false);
            this.pnlMainControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationDataGridViewTextBoxColumn;
        private System.Windows.Forms.FolderBrowserDialog fldSynch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlMainControls;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnFolder2;
        private System.Windows.Forms.TextBox txtFolder2;
        private System.Windows.Forms.TextBox txtFolder1;
        private System.Windows.Forms.Label lblFolder2;
        private System.Windows.Forms.Label lblFolder1;
        private System.Windows.Forms.Button btnFolder1;
        private System.Windows.Forms.ListView lstFilter;
        private System.Windows.Forms.TreeView treeSource;
        private System.Windows.Forms.TreeView treeDestination;
        private System.Windows.Forms.Button btnWorkspace;
        private System.Windows.Forms.TextBox txtWorkspace;
        private System.Windows.Forms.Label lblCurrentWorkspace;
    }
}

