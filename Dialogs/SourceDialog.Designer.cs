namespace SortImage
{
    partial class SourceDialog
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
            this.help4 = new System.Windows.Forms.Button();
            this.help3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.inputFolderTextBox = new System.Windows.Forms.TextBox();
            this.pickImageFolder = new System.Windows.Forms.Button();
            this.pickDupFolder = new System.Windows.Forms.Button();
            this.outputFolderTextBox = new System.Windows.Forms.TextBox();
            this.SourceDialogDone = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // help4
            // 
            this.help4.Location = new System.Drawing.Point(777, 239);
            this.help4.Name = "help4";
            this.help4.Size = new System.Drawing.Size(30, 22);
            this.help4.TabIndex = 33;
            this.help4.Text = "?";
            this.help4.UseVisualStyleBackColor = true;
            // 
            // help3
            // 
            this.help3.Location = new System.Drawing.Point(777, 44);
            this.help3.Name = "help3";
            this.help3.Size = new System.Drawing.Size(30, 22);
            this.help3.TabIndex = 32;
            this.help3.Text = "?";
            this.help3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(396, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "2: Please pick folder to store possible duplicates";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(302, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "1: Please pick image folder(s) to sort";
            // 
            // inputFolderTextBox
            // 
            this.inputFolderTextBox.Location = new System.Drawing.Point(252, 46);
            this.inputFolderTextBox.Multiline = true;
            this.inputFolderTextBox.Name = "inputFolderTextBox";
            this.inputFolderTextBox.ReadOnly = true;
            this.inputFolderTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputFolderTextBox.Size = new System.Drawing.Size(519, 128);
            this.inputFolderTextBox.TabIndex = 27;
            // 
            // pickImageFolder
            // 
            this.pickImageFolder.Location = new System.Drawing.Point(98, 44);
            this.pickImageFolder.Name = "pickImageFolder";
            this.pickImageFolder.Size = new System.Drawing.Size(138, 23);
            this.pickImageFolder.TabIndex = 26;
            this.pickImageFolder.Text = "Choose";
            this.pickImageFolder.UseVisualStyleBackColor = true;
            this.pickImageFolder.Click += new System.EventHandler(this.pickImageFolder_Click);
            // 
            // pickDupFolder
            // 
            this.pickDupFolder.Enabled = false;
            this.pickDupFolder.Location = new System.Drawing.Point(98, 240);
            this.pickDupFolder.Name = "pickDupFolder";
            this.pickDupFolder.Size = new System.Drawing.Size(138, 23);
            this.pickDupFolder.TabIndex = 28;
            this.pickDupFolder.Text = "Choose";
            this.pickDupFolder.UseVisualStyleBackColor = true;
            this.pickDupFolder.Click += new System.EventHandler(this.pickDupFolder_Click);
            // 
            // outputFolderTextBox
            // 
            this.outputFolderTextBox.Location = new System.Drawing.Point(252, 242);
            this.outputFolderTextBox.Name = "outputFolderTextBox";
            this.outputFolderTextBox.ReadOnly = true;
            this.outputFolderTextBox.Size = new System.Drawing.Size(519, 20);
            this.outputFolderTextBox.TabIndex = 29;
            // 
            // SourceDialogDone
            // 
            this.SourceDialogDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SourceDialogDone.Enabled = false;
            this.SourceDialogDone.Location = new System.Drawing.Point(399, 301);
            this.SourceDialogDone.Name = "SourceDialogDone";
            this.SourceDialogDone.Size = new System.Drawing.Size(75, 23);
            this.SourceDialogDone.TabIndex = 34;
            this.SourceDialogDone.Text = "OK";
            this.SourceDialogDone.UseVisualStyleBackColor = true;
            this.SourceDialogDone.Click += new System.EventHandler(this.SourceDialogDone_Click);
            // 
            // SourceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 345);
            this.ControlBox = false;
            this.Controls.Add(this.SourceDialogDone);
            this.Controls.Add(this.help4);
            this.Controls.Add(this.help3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputFolderTextBox);
            this.Controls.Add(this.pickImageFolder);
            this.Controls.Add(this.pickDupFolder);
            this.Controls.Add(this.outputFolderTextBox);
            this.Name = "SourceDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button help4;
        private System.Windows.Forms.Button help3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputFolderTextBox;
        private System.Windows.Forms.Button pickImageFolder;
        private System.Windows.Forms.Button pickDupFolder;
        private System.Windows.Forms.TextBox outputFolderTextBox;
        private System.Windows.Forms.Button SourceDialogDone;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}