namespace SyncFiles
{
    partial class Form1
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
            this.fldSynch = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFolder1 = new System.Windows.Forms.Button();
            this.lblFolder1 = new System.Windows.Forms.Label();
            this.lblFolder2 = new System.Windows.Forms.Label();
            this.txtFolder1 = new System.Windows.Forms.TextBox();
            this.txtFolder2 = new System.Windows.Forms.TextBox();
            this.btnFolder2 = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFolder1
            // 
            this.btnFolder1.Location = new System.Drawing.Point(516, 8);
            this.btnFolder1.Name = "btnFolder1";
            this.btnFolder1.Size = new System.Drawing.Size(75, 23);
            this.btnFolder1.TabIndex = 0;
            this.btnFolder1.Text = "Folder 1";
            this.btnFolder1.UseVisualStyleBackColor = true;
            this.btnFolder1.Click += new System.EventHandler(this.btnFolder1_Click);
            // 
            // lblFolder1
            // 
            this.lblFolder1.AutoSize = true;
            this.lblFolder1.Location = new System.Drawing.Point(23, 16);
            this.lblFolder1.Name = "lblFolder1";
            this.lblFolder1.Size = new System.Drawing.Size(68, 13);
            this.lblFolder1.TabIndex = 1;
            this.lblFolder1.Text = "Root folder 1";
            // 
            // lblFolder2
            // 
            this.lblFolder2.AutoSize = true;
            this.lblFolder2.Location = new System.Drawing.Point(23, 43);
            this.lblFolder2.Name = "lblFolder2";
            this.lblFolder2.Size = new System.Drawing.Size(71, 13);
            this.lblFolder2.TabIndex = 2;
            this.lblFolder2.Text = "Root Folder 2";
            // 
            // txtFolder1
            // 
            this.txtFolder1.Location = new System.Drawing.Point(97, 13);
            this.txtFolder1.Name = "txtFolder1";
            this.txtFolder1.Size = new System.Drawing.Size(413, 20);
            this.txtFolder1.TabIndex = 3;
            this.txtFolder1.Text = "C:\\Users\\Hector\\Source\\Repos\\ioq3";
            // 
            // txtFolder2
            // 
            this.txtFolder2.Location = new System.Drawing.Point(97, 40);
            this.txtFolder2.Name = "txtFolder2";
            this.txtFolder2.Size = new System.Drawing.Size(413, 20);
            this.txtFolder2.TabIndex = 4;
            this.txtFolder2.Text = "C:\\Users\\Hector\\Desktop\\ioq3";
            // 
            // btnFolder2
            // 
            this.btnFolder2.Location = new System.Drawing.Point(516, 38);
            this.btnFolder2.Name = "btnFolder2";
            this.btnFolder2.Size = new System.Drawing.Size(75, 23);
            this.btnFolder2.TabIndex = 5;
            this.btnFolder2.Text = "Folder 2";
            this.btnFolder2.UseVisualStyleBackColor = true;
            this.btnFolder2.Click += new System.EventHandler(this.btnFolder2_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(435, 66);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 6;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(516, 66);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 23);
            this.btnSync.TabIndex = 7;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 105);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.btnFolder2);
            this.Controls.Add(this.txtFolder2);
            this.Controls.Add(this.txtFolder1);
            this.Controls.Add(this.lblFolder2);
            this.Controls.Add(this.lblFolder1);
            this.Controls.Add(this.btnFolder1);
            this.Name = "Form1";
            this.Text = "Super Natallias backup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fldSynch;
        private System.Windows.Forms.Button btnFolder1;
        private System.Windows.Forms.Label lblFolder1;
        private System.Windows.Forms.Label lblFolder2;
        private System.Windows.Forms.TextBox txtFolder1;
        private System.Windows.Forms.TextBox txtFolder2;
        private System.Windows.Forms.Button btnFolder2;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnSync;
    }
}

