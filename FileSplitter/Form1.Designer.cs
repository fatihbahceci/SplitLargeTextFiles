namespace FileSplitter
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
            this.tSource = new System.Windows.Forms.TextBox();
            this.tOutputDirectory = new System.Windows.Forms.TextBox();
            this.tDelimiter = new System.Windows.Forms.TextBox();
            this.cbExtended = new System.Windows.Forms.CheckBox();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.tMaxFileSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSplit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSelectSourceFile = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tSource
            // 
            this.tSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tSource.Location = new System.Drawing.Point(22, 47);
            this.tSource.Name = "tSource";
            this.tSource.Size = new System.Drawing.Size(523, 20);
            this.tSource.TabIndex = 0;
            this.tSource.Text = "d:\\T2\\GeniusSales_201912131303.sql";
            // 
            // tOutputDirectory
            // 
            this.tOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tOutputDirectory.Location = new System.Drawing.Point(22, 110);
            this.tOutputDirectory.Name = "tOutputDirectory";
            this.tOutputDirectory.Size = new System.Drawing.Size(523, 20);
            this.tOutputDirectory.TabIndex = 1;
            this.tOutputDirectory.Text = "d:\\T2\\O\\";
            // 
            // tDelimiter
            // 
            this.tDelimiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tDelimiter.Location = new System.Drawing.Point(22, 173);
            this.tDelimiter.Name = "tDelimiter";
            this.tDelimiter.Size = new System.Drawing.Size(449, 20);
            this.tDelimiter.TabIndex = 2;
            this.tDelimiter.Text = ")\\r\\n;";
            // 
            // cbExtended
            // 
            this.cbExtended.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExtended.AutoSize = true;
            this.cbExtended.Checked = true;
            this.cbExtended.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbExtended.Location = new System.Drawing.Point(486, 174);
            this.cbExtended.Name = "cbExtended";
            this.cbExtended.Size = new System.Drawing.Size(78, 19);
            this.cbExtended.TabIndex = 3;
            this.cbExtended.Text = "Extended";
            this.cbExtended.UseVisualStyleBackColor = true;
            // 
            // openFileDlg
            // 
            this.openFileDlg.FileName = "openFileDialog1";
            this.openFileDlg.Filter = "All Files|*.*";
            // 
            // tMaxFileSize
            // 
            this.tMaxFileSize.Location = new System.Drawing.Point(22, 236);
            this.tMaxFileSize.Name = "tMaxFileSize";
            this.tMaxFileSize.Size = new System.Drawing.Size(100, 20);
            this.tMaxFileSize.TabIndex = 4;
            this.tMaxFileSize.Text = "10485760";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Source File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Destination Folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Delimiter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Max File Size (bytes)";
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(22, 270);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(75, 23);
            this.btnSplit.TabIndex = 6;
            this.btnSplit.Text = "Split!";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(603, 575);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.btnSelectSourceFile);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnSplit);
            this.tabPage1.Controls.Add(this.tSource);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tOutputDirectory);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tDelimiter);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cbExtended);
            this.tabPage1.Controls.Add(this.tMaxFileSize);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(595, 549);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(595, 549);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSelectSourceFile
            // 
            this.btnSelectSourceFile.Location = new System.Drawing.Point(554, 45);
            this.btnSelectSourceFile.Name = "btnSelectSourceFile";
            this.btnSelectSourceFile.Size = new System.Drawing.Size(31, 23);
            this.btnSelectSourceFile.TabIndex = 7;
            this.btnSelectSourceFile.Text = "...";
            this.btnSelectSourceFile.UseVisualStyleBackColor = true;
            this.btnSelectSourceFile.Click += new System.EventHandler(this.btnSelectSourceFile_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(554, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 575);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tSource;
        private System.Windows.Forms.TextBox tOutputDirectory;
        private System.Windows.Forms.TextBox tDelimiter;
        private System.Windows.Forms.CheckBox cbExtended;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.TextBox tMaxFileSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSelectSourceFile;
    }
}

