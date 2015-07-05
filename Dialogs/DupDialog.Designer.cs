namespace SortImage
{
    partial class DupDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dupDialogDelete = new System.Windows.Forms.Button();
            this.dupDialogRename = new System.Windows.Forms.Button();
            this.dupDialogDupFold = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Duplicate found!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Files named...";
            // 
            // dupDialogDelete
            // 
            this.dupDialogDelete.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.dupDialogDelete.Location = new System.Drawing.Point(12, 187);
            this.dupDialogDelete.Name = "dupDialogDelete";
            this.dupDialogDelete.Size = new System.Drawing.Size(106, 23);
            this.dupDialogDelete.TabIndex = 4;
            this.dupDialogDelete.Text = "Delete?";
            this.dupDialogDelete.UseVisualStyleBackColor = true;
            this.dupDialogDelete.Click += new System.EventHandler(this.dupDialogDelete_Click);
            // 
            // dupDialogRename
            // 
            this.dupDialogRename.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.dupDialogRename.Location = new System.Drawing.Point(124, 187);
            this.dupDialogRename.Name = "dupDialogRename";
            this.dupDialogRename.Size = new System.Drawing.Size(106, 23);
            this.dupDialogRename.TabIndex = 5;
            this.dupDialogRename.Text = "AutoRename";
            this.dupDialogRename.UseVisualStyleBackColor = true;
            this.dupDialogRename.Click += new System.EventHandler(this.dupDialogRename_Click);
            // 
            // dupDialogDupFold
            // 
            this.dupDialogDupFold.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.dupDialogDupFold.Location = new System.Drawing.Point(236, 187);
            this.dupDialogDupFold.Name = "dupDialogDupFold";
            this.dupDialogDupFold.Size = new System.Drawing.Size(106, 23);
            this.dupDialogDupFold.TabIndex = 6;
            this.dupDialogDupFold.Text = "To Duplicate folder";
            this.dupDialogDupFold.UseVisualStyleBackColor = true;
            this.dupDialogDupFold.Click += new System.EventHandler(this.dupDialogDupFold_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(358, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 227);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Size...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "label5";
            // 
            // DupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 252);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dupDialogDupFold);
            this.Controls.Add(this.dupDialogRename);
            this.Controls.Add(this.dupDialogDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DupDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Duplicate file found";
            this.Load += new System.EventHandler(this.DupDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button dupDialogDelete;
        private System.Windows.Forms.Button dupDialogRename;
        private System.Windows.Forms.Button dupDialogDupFold;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}