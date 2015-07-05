namespace SortImage
{
    partial class ErrorDialog
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
            this.loadLastError = new System.Windows.Forms.Button();
            this.statusBarPanelStatus = new System.Windows.Forms.TextBox();
            this.info_Text_1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loadLastError
            // 
            this.loadLastError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadLastError.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.loadLastError.Location = new System.Drawing.Point(538, 19);
            this.loadLastError.Name = "loadLastError";
            this.loadLastError.Size = new System.Drawing.Size(116, 23);
            this.loadLastError.TabIndex = 18;
            this.loadLastError.Text = "OK";
            this.loadLastError.UseVisualStyleBackColor = true;
            this.loadLastError.Click += new System.EventHandler(this.loadLastError_Click);
            // 
            // statusBarPanelStatus
            // 
            this.statusBarPanelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.statusBarPanelStatus.Location = new System.Drawing.Point(12, 48);
            this.statusBarPanelStatus.Multiline = true;
            this.statusBarPanelStatus.Name = "statusBarPanelStatus";
            this.statusBarPanelStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusBarPanelStatus.Size = new System.Drawing.Size(642, 241);
            this.statusBarPanelStatus.TabIndex = 14;
            // 
            // info_Text_1
            // 
            this.info_Text_1.AutoSize = true;
            this.info_Text_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info_Text_1.Location = new System.Drawing.Point(12, 9);
            this.info_Text_1.Name = "info_Text_1";
            this.info_Text_1.Size = new System.Drawing.Size(133, 31);
            this.info_Text_1.TabIndex = 15;
            this.info_Text_1.Text = "Last Error";
            // 
            // ErrorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(675, 309);
            this.Controls.Add(this.loadLastError);
            this.Controls.Add(this.statusBarPanelStatus);
            this.Controls.Add(this.info_Text_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ErrorDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ErrorDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadLastError;
        private System.Windows.Forms.TextBox statusBarPanelStatus;
        private System.Windows.Forms.Label info_Text_1;
    }
}