namespace SortImage
{
    partial class ConfigDialog
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
            this.keyList = new System.Windows.Forms.ComboBox();
            this.currentKey = new System.Windows.Forms.TextBox();
            this.pickKey = new System.Windows.Forms.Button();
            this.configDone = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.infoYell = new System.Windows.Forms.Label();
            this.dupCheckType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // keyList
            // 
            this.keyList.FormattingEnabled = true;
            this.keyList.Location = new System.Drawing.Point(12, 59);
            this.keyList.Name = "keyList";
            this.keyList.Size = new System.Drawing.Size(159, 21);
            this.keyList.TabIndex = 0;
            this.keyList.SelectedIndexChanged += new System.EventHandler(this.keyList_SelectedIndexChanged);
            // 
            // currentKey
            // 
            this.currentKey.Location = new System.Drawing.Point(199, 59);
            this.currentKey.Name = "currentKey";
            this.currentKey.ReadOnly = true;
            this.currentKey.Size = new System.Drawing.Size(100, 20);
            this.currentKey.TabIndex = 1;
            // 
            // pickKey
            // 
            this.pickKey.Location = new System.Drawing.Point(96, 97);
            this.pickKey.Name = "pickKey";
            this.pickKey.Size = new System.Drawing.Size(159, 35);
            this.pickKey.TabIndex = 2;
            this.pickKey.Text = "Pick Key";
            this.pickKey.UseVisualStyleBackColor = true;
            this.pickKey.Click += new System.EventHandler(this.pickKey_Click);
            // 
            // configDone
            // 
            this.configDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.configDone.Location = new System.Drawing.Point(199, 209);
            this.configDone.Name = "configDone";
            this.configDone.Size = new System.Drawing.Size(100, 44);
            this.configDone.TabIndex = 4;
            this.configDone.Text = "Done";
            this.configDone.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Operation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Key Code";
            // 
            // infoYell
            // 
            this.infoYell.AutoSize = true;
            this.infoYell.Location = new System.Drawing.Point(48, 21);
            this.infoYell.Name = "infoYell";
            this.infoYell.Size = new System.Drawing.Size(261, 13);
            this.infoYell.TabIndex = 7;
            this.infoYell.Text = "PRESS A KEY TO MATCH SELECTED OPERATION";
            this.infoYell.Visible = false;
            // 
            // dupCheckType
            // 
            this.dupCheckType.FormattingEnabled = true;
            this.dupCheckType.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.dupCheckType.Location = new System.Drawing.Point(6, 25);
            this.dupCheckType.Name = "dupCheckType";
            this.dupCheckType.Size = new System.Drawing.Size(121, 21);
            this.dupCheckType.TabIndex = 18;
            this.dupCheckType.Text = "No";
            this.dupCheckType.SelectedIndexChanged += new System.EventHandler(this.dupCheckType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Auto Matching?";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dupCheckType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 184);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 69);
            this.panel1.TabIndex = 20;
            // 
            // ConfigDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 274);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.infoYell);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.configDone);
            this.Controls.Add(this.pickKey);
            this.Controls.Add(this.currentKey);
            this.Controls.Add(this.keyList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "ConfigDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.Config_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox keyList;
        private System.Windows.Forms.TextBox currentKey;
        private System.Windows.Forms.Button pickKey;
        private System.Windows.Forms.Button configDone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label infoYell;
        private System.Windows.Forms.ComboBox dupCheckType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
    }
}