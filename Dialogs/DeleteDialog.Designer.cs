namespace SortImage
{
    partial class DeleteDialog
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
            this.toBinAll = new System.Windows.Forms.Button();
            this.toBinThis = new System.Windows.Forms.Button();
            this.deleteCancel = new System.Windows.Forms.Button();
            this.markDeleteThis = new System.Windows.Forms.Button();
            this.markDeleteAll = new System.Windows.Forms.Button();
            this.deleteInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // toBinAll
            // 
            this.toBinAll.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.toBinAll.Location = new System.Drawing.Point(37, 231);
            this.toBinAll.Name = "toBinAll";
            this.toBinAll.Size = new System.Drawing.Size(80, 25);
            this.toBinAll.TabIndex = 0;
            this.toBinAll.Text = "All to Bin";
            this.toBinAll.UseVisualStyleBackColor = true;
            this.toBinAll.Click += new System.EventHandler(this.toBinAll_Click);
            // 
            // toBinThis
            // 
            this.toBinThis.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.toBinThis.Location = new System.Drawing.Point(37, 193);
            this.toBinThis.Name = "toBinThis";
            this.toBinThis.Size = new System.Drawing.Size(80, 25);
            this.toBinThis.TabIndex = 1;
            this.toBinThis.Text = "This to Bin";
            this.toBinThis.UseVisualStyleBackColor = true;
            this.toBinThis.Click += new System.EventHandler(this.toBinThis_Click);
            // 
            // deleteCancel
            // 
            this.deleteCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.deleteCancel.Location = new System.Drawing.Point(190, 276);
            this.deleteCancel.Name = "deleteCancel";
            this.deleteCancel.Size = new System.Drawing.Size(127, 26);
            this.deleteCancel.TabIndex = 2;
            this.deleteCancel.Text = "Cancel";
            this.deleteCancel.UseVisualStyleBackColor = true;
            this.deleteCancel.Click += new System.EventHandler(this.deleteCancel_Click);
            // 
            // markDeleteThis
            // 
            this.markDeleteThis.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.markDeleteThis.Location = new System.Drawing.Point(37, 93);
            this.markDeleteThis.Name = "markDeleteThis";
            this.markDeleteThis.Size = new System.Drawing.Size(80, 25);
            this.markDeleteThis.TabIndex = 3;
            this.markDeleteThis.Text = "This Mark";
            this.markDeleteThis.UseVisualStyleBackColor = true;
            this.markDeleteThis.Click += new System.EventHandler(this.markDeleteThis_Click);
            // 
            // markDeleteAll
            // 
            this.markDeleteAll.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.markDeleteAll.Location = new System.Drawing.Point(37, 59);
            this.markDeleteAll.Name = "markDeleteAll";
            this.markDeleteAll.Size = new System.Drawing.Size(80, 25);
            this.markDeleteAll.TabIndex = 4;
            this.markDeleteAll.Text = "All Mark";
            this.markDeleteAll.UseVisualStyleBackColor = true;
            this.markDeleteAll.Click += new System.EventHandler(this.markDeleteAll_Click);
            // 
            // deleteInfo
            // 
            this.deleteInfo.AutoSize = true;
            this.deleteInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteInfo.Location = new System.Drawing.Point(19, 9);
            this.deleteInfo.Name = "deleteInfo";
            this.deleteInfo.Size = new System.Drawing.Size(487, 24);
            this.deleteInfo.TabIndex = 5;
            this.deleteInfo.Text = "What would you like to do with this file and following files?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "(This and all files after are deleted to recycling bin)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(315, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "(This and all files after are marked for deletion to duplicates folder)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(373, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "(This file is marked to duplicates folder. Choice will be given again next delete" +
                ")";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(346, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "(This file is sent the recycling bin. Choice will be given again next delete)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(352, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Note: You can\'t undo deletes to bin with program";
            // 
            // DeleteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.deleteCancel;
            this.ClientSize = new System.Drawing.Size(530, 339);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteInfo);
            this.Controls.Add(this.markDeleteAll);
            this.Controls.Add(this.markDeleteThis);
            this.Controls.Add(this.deleteCancel);
            this.Controls.Add(this.toBinThis);
            this.Controls.Add(this.toBinAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DeleteDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Delete Options";
            this.Load += new System.EventHandler(this.DeleteDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button toBinAll;
        private System.Windows.Forms.Button toBinThis;
        private System.Windows.Forms.Button deleteCancel;
        private System.Windows.Forms.Button markDeleteThis;
        private System.Windows.Forms.Button markDeleteAll;
        private System.Windows.Forms.Label deleteInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}