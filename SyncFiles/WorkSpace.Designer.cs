namespace SyncFiles
{
    partial class frmWorkSpace
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtFolder2 = new System.Windows.Forms.TextBox();
            this.txtFolder1 = new System.Windows.Forms.TextBox();
            this.lblFolder2 = new System.Windows.Forms.Label();
            this.lblFolder1 = new System.Windows.Forms.Label();
            this.lblExclusions = new System.Windows.Forms.Label();
            this.lstExclusions = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.txtExclusion = new System.Windows.Forms.TextBox();
            this.btnSaveUse = new System.Windows.Forms.Button();
            this.lstPatterns = new System.Windows.Forms.ListBox();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.lblPattern = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(216, 298);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(90, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(312, 298);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save As";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFolder2
            // 
            this.txtFolder2.Location = new System.Drawing.Point(85, 38);
            this.txtFolder2.Name = "txtFolder2";
            this.txtFolder2.Size = new System.Drawing.Size(413, 20);
            this.txtFolder2.TabIndex = 18;
            this.txtFolder2.Text = "C:\\";
            // 
            // txtFolder1
            // 
            this.txtFolder1.Location = new System.Drawing.Point(85, 12);
            this.txtFolder1.Name = "txtFolder1";
            this.txtFolder1.Size = new System.Drawing.Size(413, 20);
            this.txtFolder1.TabIndex = 17;
            this.txtFolder1.Text = "C:\\";
            // 
            // lblFolder2
            // 
            this.lblFolder2.AutoSize = true;
            this.lblFolder2.Location = new System.Drawing.Point(11, 41);
            this.lblFolder2.Name = "lblFolder2";
            this.lblFolder2.Size = new System.Drawing.Size(71, 13);
            this.lblFolder2.TabIndex = 16;
            this.lblFolder2.Text = "Root Folder 2";
            // 
            // lblFolder1
            // 
            this.lblFolder1.AutoSize = true;
            this.lblFolder1.Location = new System.Drawing.Point(11, 15);
            this.lblFolder1.Name = "lblFolder1";
            this.lblFolder1.Size = new System.Drawing.Size(71, 13);
            this.lblFolder1.TabIndex = 15;
            this.lblFolder1.Text = "Root Folder 1";
            // 
            // lblExclusions
            // 
            this.lblExclusions.AutoSize = true;
            this.lblExclusions.Location = new System.Drawing.Point(11, 67);
            this.lblExclusions.Name = "lblExclusions";
            this.lblExclusions.Size = new System.Drawing.Size(73, 13);
            this.lblExclusions.TabIndex = 19;
            this.lblExclusions.Text = "Add exclusion";
            // 
            // lstExclusions
            // 
            this.lstExclusions.FormattingEnabled = true;
            this.lstExclusions.Location = new System.Drawing.Point(17, 96);
            this.lstExclusions.Name = "lstExclusions";
            this.lstExclusions.Size = new System.Drawing.Size(481, 82);
            this.lstExclusions.TabIndex = 20;
            this.lstExclusions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstExclusions_KeyPress);
            // 
            // txtExclusion
            // 
            this.txtExclusion.Location = new System.Drawing.Point(85, 64);
            this.txtExclusion.Name = "txtExclusion";
            this.txtExclusion.Size = new System.Drawing.Size(413, 20);
            this.txtExclusion.TabIndex = 21;
            this.txtExclusion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExclusion_KeyPress);
            // 
            // btnSaveUse
            // 
            this.btnSaveUse.Location = new System.Drawing.Point(408, 298);
            this.btnSaveUse.Name = "btnSaveUse";
            this.btnSaveUse.Size = new System.Drawing.Size(90, 23);
            this.btnSaveUse.TabIndex = 22;
            this.btnSaveUse.Text = "Save and Use";
            this.btnSaveUse.UseVisualStyleBackColor = true;
            this.btnSaveUse.Click += new System.EventHandler(this.btnSaveUse_Click);
            // 
            // lstPatterns
            // 
            this.lstPatterns.FormattingEnabled = true;
            this.lstPatterns.Location = new System.Drawing.Point(17, 210);
            this.lstPatterns.Name = "lstPatterns";
            this.lstPatterns.Size = new System.Drawing.Size(481, 82);
            this.lstPatterns.TabIndex = 23;
            this.lstPatterns.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstPatterns_KeyPress);
            // 
            // txtPattern
            // 
            this.txtPattern.Location = new System.Drawing.Point(85, 184);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(413, 20);
            this.txtPattern.TabIndex = 25;
            this.txtPattern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPattern_KeyPress);
            // 
            // lblPattern
            // 
            this.lblPattern.AutoSize = true;
            this.lblPattern.Location = new System.Drawing.Point(8, 187);
            this.lblPattern.Name = "lblPattern";
            this.lblPattern.Size = new System.Drawing.Size(62, 13);
            this.lblPattern.TabIndex = 24;
            this.lblPattern.Text = "Add pattern";
            // 
            // frmWorkSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 329);
            this.Controls.Add(this.txtPattern);
            this.Controls.Add(this.lblPattern);
            this.Controls.Add(this.lstPatterns);
            this.Controls.Add(this.btnSaveUse);
            this.Controls.Add(this.txtExclusion);
            this.Controls.Add(this.lstExclusions);
            this.Controls.Add(this.lblExclusions);
            this.Controls.Add(this.txtFolder2);
            this.Controls.Add(this.txtFolder1);
            this.Controls.Add(this.lblFolder2);
            this.Controls.Add(this.lblFolder1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWorkSpace";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Workspaces";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtFolder2;
        private System.Windows.Forms.TextBox txtFolder1;
        private System.Windows.Forms.Label lblFolder2;
        private System.Windows.Forms.Label lblFolder1;
        private System.Windows.Forms.Label lblExclusions;
        private System.Windows.Forms.ListBox lstExclusions;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txtExclusion;
        private System.Windows.Forms.Button btnSaveUse;
        private System.Windows.Forms.ListBox lstPatterns;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Label lblPattern;
    }
}