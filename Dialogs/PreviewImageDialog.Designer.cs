namespace SortImage
{
    partial class PreviewImageDialog
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
            this.pictureBoxGif = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGif)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGif
            // 
            this.pictureBoxGif.Location = new System.Drawing.Point(12, 31);
            this.pictureBoxGif.Name = "pictureBoxGif";
            this.pictureBoxGif.Size = new System.Drawing.Size(453, 347);
            this.pictureBoxGif.TabIndex = 0;
            this.pictureBoxGif.TabStop = false;
            this.pictureBoxGif.Click += new System.EventHandler(this.pictureBoxGif_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GifDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(477, 394);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBoxGif);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.Name = "GifDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Full View Image";
           // this.Load += new System.EventHandler(this.GifDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGif)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGif;
        private System.Windows.Forms.Button button1;
    }
}