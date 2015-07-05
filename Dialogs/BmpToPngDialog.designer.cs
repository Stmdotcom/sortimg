namespace SortImage
{
    partial class BmpToPngDialog
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
            this.goBut = new System.Windows.Forms.Button();
            this.sourceText = new System.Windows.Forms.TextBox();
            this.sourceBut = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.radioButtonJpg = new System.Windows.Forms.RadioButton();
            this.radioButtonPng = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
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
            this.sourceText.Location = new System.Drawing.Point(54, 56);
            this.sourceText.Name = "sourceText";
            this.sourceText.Size = new System.Drawing.Size(437, 20);
            this.sourceText.TabIndex = 1;
            // 
            // sourceBut
            // 
            this.sourceBut.Location = new System.Drawing.Point(538, 53);
            this.sourceBut.Name = "sourceBut";
            this.sourceBut.Size = new System.Drawing.Size(92, 23);
            this.sourceBut.TabIndex = 3;
            this.sourceBut.Text = "Select Source";
            this.sourceBut.UseVisualStyleBackColor = true;
            this.sourceBut.Click += new System.EventHandler(this.sourceBut_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(90, 300);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(583, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // radioButtonJpg
            // 
            this.radioButtonJpg.AutoSize = true;
            this.radioButtonJpg.Location = new System.Drawing.Point(43, 19);
            this.radioButtonJpg.Name = "radioButtonJpg";
            this.radioButtonJpg.Size = new System.Drawing.Size(42, 17);
            this.radioButtonJpg.TabIndex = 7;
            this.radioButtonJpg.Text = "Jpg";
            this.radioButtonJpg.UseVisualStyleBackColor = true;
            // 
            // radioButtonPng
            // 
            this.radioButtonPng.AutoSize = true;
            this.radioButtonPng.Checked = true;
            this.radioButtonPng.Location = new System.Drawing.Point(43, 42);
            this.radioButtonPng.Name = "radioButtonPng";
            this.radioButtonPng.Size = new System.Drawing.Size(44, 17);
            this.radioButtonPng.TabIndex = 8;
            this.radioButtonPng.TabStop = true;
            this.radioButtonPng.Text = "Png";
            this.radioButtonPng.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonPng);
            this.groupBox1.Controls.Add(this.radioButtonJpg);
            this.groupBox1.Location = new System.Drawing.Point(323, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 76);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save as...";
            // 
            // BmpToPngDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 358);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.sourceBut);
            this.Controls.Add(this.sourceText);
            this.Controls.Add(this.goBut);
            this.Name = "BmpToPngDialog";
            this.ShowIcon = false;
            this.Text = "Bmp Converter";
            this.Load += new System.EventHandler(this.FolderMergeDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goBut;
        private System.Windows.Forms.TextBox sourceText;
        private System.Windows.Forms.Button sourceBut;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton radioButtonJpg;
        private System.Windows.Forms.RadioButton radioButtonPng;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

