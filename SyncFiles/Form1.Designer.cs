namespace SyncFiles
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
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Only source");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Only destination");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("File size");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("Last timestamp");
            this.fldSynch = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMainControls = new System.Windows.Forms.Panel();
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
            this.treeDestination = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.treeSource = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlMainControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.treeSource, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.treeDestination, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlMainControls, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(959, 561);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // pnlMainControls
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pnlMainControls, 3);
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
            this.pnlMainControls.Location = new System.Drawing.Point(3, 3);
            this.pnlMainControls.Name = "pnlMainControls";
            this.pnlMainControls.Size = new System.Drawing.Size(890, 114);
            this.pnlMainControls.TabIndex = 12;
            // 
            // lstFilter
            // 
            this.lstFilter.CheckBoxes = true;
            this.lstFilter.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listViewItem9.StateImageIndex = 0;
            listViewItem9.Tag = "1";
            listViewItem10.StateImageIndex = 0;
            listViewItem10.Tag = "2";
            listViewItem11.StateImageIndex = 0;
            listViewItem11.Tag = "4";
            listViewItem12.StateImageIndex = 0;
            listViewItem12.Tag = "8";
            this.lstFilter.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12});
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
            this.lblStatus.Location = new System.Drawing.Point(11, 90);
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
            this.btnCompare.Text = "Compare";
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
            this.txtFolder2.Text = "F:\\Hector\\DATA\\Public";
            // 
            // txtFolder1
            // 
            this.txtFolder1.Location = new System.Drawing.Point(85, 9);
            this.txtFolder1.Name = "txtFolder1";
            this.txtFolder1.Size = new System.Drawing.Size(413, 20);
            this.txtFolder1.TabIndex = 13;
            this.txtFolder1.Text = "M:\\Public";
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
            this.lblFolder1.Size = new System.Drawing.Size(68, 13);
            this.lblFolder1.TabIndex = 11;
            this.lblFolder1.Text = "Root folder 1";
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
            // treeDestination
            // 
            this.treeDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDestination.Location = new System.Drawing.Point(242, 123);
            this.treeDestination.Name = "treeDestination";
            this.treeDestination.Size = new System.Drawing.Size(233, 435);
            this.treeDestination.TabIndex = 22;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(481, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(475, 435);
            this.dataGridView1.TabIndex = 24;
            // 
            // treeSource
            // 
            this.treeSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSource.Location = new System.Drawing.Point(3, 123);
            this.treeSource.Name = "treeSource";
            this.treeSource.Size = new System.Drawing.Size(233, 435);
            this.treeSource.TabIndex = 25;
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlMainControls.ResumeLayout(false);
            this.pnlMainControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TreeView treeDestination;
    }
}

