namespace SortImage
{
    partial class FolderMergeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderMergeDialog));
            this.goBut = new System.Windows.Forms.Button();
            this.sourceText = new System.Windows.Forms.TextBox();
            this.destText = new System.Windows.Forms.TextBox();
            this.sourceBut = new System.Windows.Forms.Button();
            this.destBut = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // goBut
            // 
            this.goBut.Location = new System.Drawing.Point(346, 234);
            this.goBut.Name = "goBut";
            this.goBut.Size = new System.Drawing.Size(75, 23);
            this.goBut.TabIndex = 0;
            this.goBut.Text = "GO!";
            this.goBut.UseVisualStyleBackColor = true;
            this.goBut.Click += new System.EventHandler(this.goBut_Click);
            // 
            // sourceText
            // 
            this.sourceText.Location = new System.Drawing.Point(53, 53);
            this.sourceText.Name = "sourceText";
            this.sourceText.Size = new System.Drawing.Size(437, 20);
            this.sourceText.TabIndex = 1;
            // 
            // destText
            // 
            this.destText.Location = new System.Drawing.Point(53, 111);
            this.destText.Name = "destText";
            this.destText.Size = new System.Drawing.Size(437, 20);
            this.destText.TabIndex = 2;
            // 
            // sourceBut
            // 
            this.sourceBut.Location = new System.Drawing.Point(538, 53);
            this.sourceBut.Name = "sourceBut";
            this.sourceBut.Size = new System.Drawing.Size(75, 23);
            this.sourceBut.TabIndex = 3;
            this.sourceBut.Text = "Source";
            this.sourceBut.UseVisualStyleBackColor = true;
            this.sourceBut.Click += new System.EventHandler(this.sourceBut_Click);
            // 
            // destBut
            // 
            this.destBut.Location = new System.Drawing.Point(538, 109);
            this.destBut.Name = "destBut";
            this.destBut.Size = new System.Drawing.Size(75, 23);
            this.destBut.TabIndex = 4;
            this.destBut.Text = "Destination";
            this.destBut.UseVisualStyleBackColor = true;
            this.destBut.Click += new System.EventHandler(this.destBut_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(90, 300);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(583, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "File Size",
            "MD5 Checksum"});
            this.comboBox1.Location = new System.Drawing.Point(279, 161);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Check files with equivalent filenames against?";
            // 
            // FolderMergeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 358);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.destBut);
            this.Controls.Add(this.sourceBut);
            this.Controls.Add(this.destText);
            this.Controls.Add(this.sourceText);
            this.Controls.Add(this.goBut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FolderMergeDialog";
            this.ShowIcon = false;
            this.Text = "FolderMerger";
            this.Load += new System.EventHandler(this.BmpToPngDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goBut;
        private System.Windows.Forms.TextBox sourceText;
        private System.Windows.Forms.TextBox destText;
        private System.Windows.Forms.Button sourceBut;
        private System.Windows.Forms.Button destBut;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}

