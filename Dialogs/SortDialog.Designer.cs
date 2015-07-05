namespace SortImage
{
    partial class SortDialog
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
            this.sortNAME = new System.Windows.Forms.Button();
            this.sortDATE = new System.Windows.Forms.Button();
            this.sortSize = new System.Windows.Forms.Button();
            this.deleteInfo = new System.Windows.Forms.Label();
            this.logCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // sortNAME
            // 
            this.sortNAME.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sortNAME.Location = new System.Drawing.Point(31, 98);
            this.sortNAME.Name = "sortNAME";
            this.sortNAME.Size = new System.Drawing.Size(75, 23);
            this.sortNAME.TabIndex = 0;
            this.sortNAME.Text = "Name";
            this.sortNAME.UseVisualStyleBackColor = true;
            this.sortNAME.Click += new System.EventHandler(this.sortNAME_Click);
            // 
            // sortDATE
            // 
            this.sortDATE.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sortDATE.Location = new System.Drawing.Point(112, 98);
            this.sortDATE.Name = "sortDATE";
            this.sortDATE.Size = new System.Drawing.Size(75, 23);
            this.sortDATE.TabIndex = 1;
            this.sortDATE.Text = "Date";
            this.sortDATE.UseVisualStyleBackColor = true;
            this.sortDATE.Click += new System.EventHandler(this.sortDATE_Click);
            // 
            // sortSize
            // 
            this.sortSize.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sortSize.Location = new System.Drawing.Point(198, 98);
            this.sortSize.Name = "sortSize";
            this.sortSize.Size = new System.Drawing.Size(75, 23);
            this.sortSize.TabIndex = 2;
            this.sortSize.Text = "Size";
            this.sortSize.UseVisualStyleBackColor = true;
            this.sortSize.Click += new System.EventHandler(this.sortSize_Click);
            // 
            // deleteInfo
            // 
            this.deleteInfo.AutoSize = true;
            this.deleteInfo.Location = new System.Drawing.Point(57, 68);
            this.deleteInfo.Name = "deleteInfo";
            this.deleteInfo.Size = new System.Drawing.Size(192, 13);
            this.deleteInfo.TabIndex = 6;
            this.deleteInfo.Text = "How would you like files to be ordered?";
            // 
            // logCheckBox
            // 
            this.logCheckBox.AutoSize = true;
            this.logCheckBox.Checked = true;
            this.logCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logCheckBox.Location = new System.Drawing.Point(112, 28);
            this.logCheckBox.Name = "logCheckBox";
            this.logCheckBox.Size = new System.Drawing.Size(70, 17);
            this.logCheckBox.TabIndex = 7;
            this.logCheckBox.Text = "Logging?";
            this.logCheckBox.UseVisualStyleBackColor = true;
            // 
            // SortDialog
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 168);
            this.ControlBox = false;
            this.Controls.Add(this.logCheckBox);
            this.Controls.Add(this.deleteInfo);
            this.Controls.Add(this.sortSize);
            this.Controls.Add(this.sortDATE);
            this.Controls.Add(this.sortNAME);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SortDialog";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.SortDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sortNAME;
        private System.Windows.Forms.Button sortDATE;
        private System.Windows.Forms.Button sortSize;
        private System.Windows.Forms.Label deleteInfo;
        private System.Windows.Forms.CheckBox logCheckBox;
    }
}