namespace FileSplitter.Controls
{
    partial class UCSplitByFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectOutputDirectory = new System.Windows.Forms.Button();
            this.btnSelectSourceFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSplit = new System.Windows.Forms.Button();
            this.tSource = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tOutputDirectory = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tDelimiter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbExtended = new System.Windows.Forms.CheckBox();
            this.tMaxFileSize = new System.Windows.Forms.TextBox();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.folderDLG = new System.Windows.Forms.FolderBrowserDialog();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnSelectOutputDirectory
            // 
            this.btnSelectOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectOutputDirectory.Location = new System.Drawing.Point(602, 108);
            this.btnSelectOutputDirectory.Name = "btnSelectOutputDirectory";
            this.btnSelectOutputDirectory.Size = new System.Drawing.Size(31, 23);
            this.btnSelectOutputDirectory.TabIndex = 20;
            this.btnSelectOutputDirectory.Text = "...";
            this.btnSelectOutputDirectory.UseVisualStyleBackColor = true;
            this.btnSelectOutputDirectory.Click += new System.EventHandler(this.btnSelectOutputDirectory_Click);
            // 
            // btnSelectSourceFile
            // 
            this.btnSelectSourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectSourceFile.Location = new System.Drawing.Point(602, 45);
            this.btnSelectSourceFile.Name = "btnSelectSourceFile";
            this.btnSelectSourceFile.Size = new System.Drawing.Size(31, 23);
            this.btnSelectSourceFile.TabIndex = 19;
            this.btnSelectSourceFile.Text = "...";
            this.btnSelectSourceFile.UseVisualStyleBackColor = true;
            this.btnSelectSourceFile.Click += new System.EventHandler(this.btnSelectSourceFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Source File";
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(15, 320);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(75, 23);
            this.btnSplit.TabIndex = 18;
            this.btnSplit.Text = "Split!";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // tSource
            // 
            this.tSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tSource.Location = new System.Drawing.Point(15, 47);
            this.tSource.Name = "tSource";
            this.tSource.Size = new System.Drawing.Size(581, 20);
            this.tSource.TabIndex = 9;
            this.tSource.Text = "d:\\T2\\GeniusSales_201912131303.sql";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Max File Size (bytes)";
            // 
            // tOutputDirectory
            // 
            this.tOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tOutputDirectory.Location = new System.Drawing.Point(15, 110);
            this.tOutputDirectory.Name = "tOutputDirectory";
            this.tOutputDirectory.Size = new System.Drawing.Size(581, 20);
            this.tOutputDirectory.TabIndex = 10;
            this.tOutputDirectory.Text = "d:\\T2\\O\\";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Delimiter";
            // 
            // tDelimiter
            // 
            this.tDelimiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tDelimiter.Location = new System.Drawing.Point(15, 166);
            this.tDelimiter.Name = "tDelimiter";
            this.tDelimiter.Size = new System.Drawing.Size(449, 20);
            this.tDelimiter.TabIndex = 11;
            this.tDelimiter.Text = ")\\r\\n;";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Destination Folder";
            // 
            // cbExtended
            // 
            this.cbExtended.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExtended.AutoSize = true;
            this.cbExtended.Checked = true;
            this.cbExtended.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbExtended.Location = new System.Drawing.Point(479, 167);
            this.cbExtended.Name = "cbExtended";
            this.cbExtended.Size = new System.Drawing.Size(78, 19);
            this.cbExtended.TabIndex = 12;
            this.cbExtended.Text = "Extended";
            this.cbExtended.UseVisualStyleBackColor = true;
            // 
            // tMaxFileSize
            // 
            this.tMaxFileSize.Location = new System.Drawing.Point(15, 236);
            this.tMaxFileSize.Name = "tMaxFileSize";
            this.tMaxFileSize.Size = new System.Drawing.Size(100, 20);
            this.tMaxFileSize.TabIndex = 13;
            this.tMaxFileSize.Text = "10485760";
            // 
            // openFileDlg
            // 
            this.openFileDlg.FileName = "openFileDialog1";
            this.openFileDlg.Filter = "All Files|*.*";
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(18, 280);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(615, 23);
            this.pb.TabIndex = 21;
            // 
            // UCSplitByFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pb);
            this.Controls.Add(this.btnSelectOutputDirectory);
            this.Controls.Add(this.btnSelectSourceFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.tSource);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tOutputDirectory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tDelimiter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbExtended);
            this.Controls.Add(this.tMaxFileSize);
            this.Name = "UCSplitByFilter";
            this.Size = new System.Drawing.Size(645, 587);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectOutputDirectory;
        private System.Windows.Forms.Button btnSelectSourceFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.TextBox tSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tOutputDirectory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tDelimiter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbExtended;
        private System.Windows.Forms.TextBox tMaxFileSize;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.FolderBrowserDialog folderDLG;
        private System.Windows.Forms.ProgressBar pb;
    }
}
