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
            this.autoMatchingLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fileSortLabel = new System.Windows.Forms.Label();
            this.enableLoggingLabel = new System.Windows.Forms.Label();
            this.enableLoggingCheckbox = new System.Windows.Forms.CheckBox();
            this.fileSortComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // keyList
            // 
            this.keyList.FormattingEnabled = true;
            this.keyList.Location = new System.Drawing.Point(15, 65);
            this.keyList.Name = "keyList";
            this.keyList.Size = new System.Drawing.Size(159, 21);
            this.keyList.TabIndex = 0;
            this.keyList.SelectedIndexChanged += new System.EventHandler(this.keyList_SelectedIndexChanged);
            // 
            // currentKey
            // 
            this.currentKey.Location = new System.Drawing.Point(202, 65);
            this.currentKey.Name = "currentKey";
            this.currentKey.ReadOnly = true;
            this.currentKey.Size = new System.Drawing.Size(100, 20);
            this.currentKey.TabIndex = 1;
            // 
            // pickKey
            // 
            this.pickKey.Location = new System.Drawing.Point(322, 38);
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
            this.configDone.Location = new System.Drawing.Point(202, 297);
            this.configDone.Name = "configDone";
            this.configDone.Size = new System.Drawing.Size(100, 44);
            this.configDone.TabIndex = 4;
            this.configDone.Text = "Done";
            this.configDone.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Operation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Key Code";
            // 
            // infoYell
            // 
            this.infoYell.AutoSize = true;
            this.infoYell.Location = new System.Drawing.Point(29, 27);
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
            this.dupCheckType.Location = new System.Drawing.Point(121, 36);
            this.dupCheckType.Name = "dupCheckType";
            this.dupCheckType.Size = new System.Drawing.Size(121, 21);
            this.dupCheckType.TabIndex = 18;
            this.dupCheckType.Text = "No";
            this.dupCheckType.SelectedIndexChanged += new System.EventHandler(this.dupCheckType_SelectedIndexChanged);
            // 
            // autoMatchingLabel
            // 
            this.autoMatchingLabel.AutoSize = true;
            this.autoMatchingLabel.Location = new System.Drawing.Point(12, 36);
            this.autoMatchingLabel.Name = "autoMatchingLabel";
            this.autoMatchingLabel.Size = new System.Drawing.Size(79, 13);
            this.autoMatchingLabel.TabIndex = 19;
            this.autoMatchingLabel.Text = "Auto Matching:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.infoYell);
            this.groupBox1.Controls.Add(this.keyList);
            this.groupBox1.Controls.Add(this.currentKey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pickKey);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 108);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shortcuts";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fileSortComboBox);
            this.groupBox2.Controls.Add(this.enableLoggingCheckbox);
            this.groupBox2.Controls.Add(this.enableLoggingLabel);
            this.groupBox2.Controls.Add(this.fileSortLabel);
            this.groupBox2.Controls.Add(this.dupCheckType);
            this.groupBox2.Controls.Add(this.autoMatchingLabel);
            this.groupBox2.Location = new System.Drawing.Point(12, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 152);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // fileSortLabel
            // 
            this.fileSortLabel.AutoSize = true;
            this.fileSortLabel.Location = new System.Drawing.Point(12, 77);
            this.fileSortLabel.Name = "fileSortLabel";
            this.fileSortLabel.Size = new System.Drawing.Size(48, 13);
            this.fileSortLabel.TabIndex = 20;
            this.fileSortLabel.Text = "File Sort:";
            // 
            // enableLoggingLabel
            // 
            this.enableLoggingLabel.AutoSize = true;
            this.enableLoggingLabel.Location = new System.Drawing.Point(12, 113);
            this.enableLoggingLabel.Name = "enableLoggingLabel";
            this.enableLoggingLabel.Size = new System.Drawing.Size(84, 13);
            this.enableLoggingLabel.TabIndex = 21;
            this.enableLoggingLabel.Text = "Enable Logging:";
            // 
            // enableLoggingCheckbox
            // 
            this.enableLoggingCheckbox.AutoSize = true;
            this.enableLoggingCheckbox.Location = new System.Drawing.Point(121, 113);
            this.enableLoggingCheckbox.Name = "enableLoggingCheckbox";
            this.enableLoggingCheckbox.Size = new System.Drawing.Size(15, 14);
            this.enableLoggingCheckbox.TabIndex = 22;
            this.enableLoggingCheckbox.UseVisualStyleBackColor = false;
            this.enableLoggingCheckbox.CheckedChanged += new System.EventHandler(this.enableLoggingCheckbox_CheckedChanged);
            // 
            // fileSortComboBox
            // 
            this.fileSortComboBox.FormattingEnabled = true;
            this.fileSortComboBox.Items.AddRange(new object[] {
            "Name",
            "Size",
            "Date"});
            this.fileSortComboBox.Location = new System.Drawing.Point(121, 74);
            this.fileSortComboBox.Name = "fileSortComboBox";
            this.fileSortComboBox.Size = new System.Drawing.Size(121, 21);
            this.fileSortComboBox.TabIndex = 23;
            this.fileSortComboBox.Text = "Name";
            this.fileSortComboBox.SelectedIndexChanged += new System.EventHandler(this.fileSortComboBox_SelectedIndexChanged);
            // 
            // ConfigDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 353);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.configDone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "ConfigDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.Config_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label autoMatchingLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox enableLoggingCheckbox;
        private System.Windows.Forms.Label enableLoggingLabel;
        private System.Windows.Forms.Label fileSortLabel;
        private System.Windows.Forms.ComboBox fileSortComboBox;
    }
}