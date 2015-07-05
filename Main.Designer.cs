using System.Drawing;
using System;
namespace SortImage
{
    partial class SortImg
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SortImg));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByMD5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderImageMergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertBmpToPngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLastErrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pContainer = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonLoadMore = new System.Windows.Forms.Button();
            this.skipButton = new System.Windows.Forms.Button();
            this.trackBarSize = new System.Windows.Forms.TrackBar();
            this.textBox7 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addFolders = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.name = new System.Windows.Forms.TextBox();
            this.butOrignText = new System.Windows.Forms.Button();
            this.tagList = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.addTag = new System.Windows.Forms.Button();
            this.newName = new System.Windows.Forms.TextBox();
            this.tag = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.toDupButton = new System.Windows.Forms.Button();
            this.Undo = new System.Windows.Forms.Button();
            this.foldAdd = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bwSortImageFolder = new System.ComponentModel.BackgroundWorker();
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.flowLayoutPanelMain = new SortImage.ThumbnailFlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1101, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.configToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortFolderToolStripMenuItem,
            this.sortByMD5ToolStripMenuItem,
            this.folderImageMergeToolStripMenuItem,
            this.convertBmpToPngToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // sortFolderToolStripMenuItem
            // 
            this.sortFolderToolStripMenuItem.Name = "sortFolderToolStripMenuItem";
            this.sortFolderToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.sortFolderToolStripMenuItem.Text = "Sort Folder...";
            this.sortFolderToolStripMenuItem.Click += new System.EventHandler(this.sortFolderToolStripMenuItem_Click);
            // 
            // sortByMD5ToolStripMenuItem
            // 
            this.sortByMD5ToolStripMenuItem.Name = "sortByMD5ToolStripMenuItem";
            this.sortByMD5ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.sortByMD5ToolStripMenuItem.Text = "Sort By MD5...";
            this.sortByMD5ToolStripMenuItem.Click += new System.EventHandler(this.sortByMD5ToolStripMenuItem_Click);
            // 
            // folderImageMergeToolStripMenuItem
            // 
            this.folderImageMergeToolStripMenuItem.Name = "folderImageMergeToolStripMenuItem";
            this.folderImageMergeToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.folderImageMergeToolStripMenuItem.Text = "Merge Image Folders...";
            this.folderImageMergeToolStripMenuItem.Click += new System.EventHandler(this.folderImageMergeToolStripMenuItem_Click);
            // 
            // convertBmpToPngToolStripMenuItem
            // 
            this.convertBmpToPngToolStripMenuItem.Name = "convertBmpToPngToolStripMenuItem";
            this.convertBmpToPngToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.convertBmpToPngToolStripMenuItem.Text = "Convert Bmp to...";
            this.convertBmpToPngToolStripMenuItem.Click += new System.EventHandler(this.convertBmpToPngToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem,
            this.showLastErrorToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click_1);
            // 
            // showLastErrorToolStripMenuItem
            // 
            this.showLastErrorToolStripMenuItem.Name = "showLastErrorToolStripMenuItem";
            this.showLastErrorToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.showLastErrorToolStripMenuItem.Text = "Show Last Error";
            this.showLastErrorToolStripMenuItem.Click += new System.EventHandler(this.showLastErrorToolStripMenuItem_Click);
            // 
            // pContainer
            // 
            this.pContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pContainer.AutoScroll = true;
            this.pContainer.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pContainer.Location = new System.Drawing.Point(754, 44);
            this.pContainer.Name = "pContainer";
            this.pContainer.Size = new System.Drawing.Size(344, 508);
            this.pContainer.TabIndex = 31;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.buttonLoadMore);
            this.splitContainer1.Panel1.Controls.Add(this.skipButton);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanelMain);
            this.splitContainer1.Panel1.Controls.Add(this.trackBarSize);
            this.splitContainer1.Panel1.Controls.Add(this.textBox7);
            this.splitContainer1.Panel1.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.addFolders);
            this.splitContainer1.Panel1MinSize = 145;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Size = new System.Drawing.Size(745, 593);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 39;
            // 
            // buttonLoadMore
            // 
            this.buttonLoadMore.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonLoadMore.Enabled = false;
            this.buttonLoadMore.Image = global::SortImage.Properties.Resources.next;
            this.buttonLoadMore.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLoadMore.Location = new System.Drawing.Point(116, 504);
            this.buttonLoadMore.Name = "buttonLoadMore";
            this.buttonLoadMore.Size = new System.Drawing.Size(97, 34);
            this.buttonLoadMore.TabIndex = 45;
            this.buttonLoadMore.Text = "Load More";
            this.buttonLoadMore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLoadMore.UseVisualStyleBackColor = true;
            this.buttonLoadMore.Click += new System.EventHandler(this.buttonLoadMore_Click);
            // 
            // skipButton
            // 
            this.skipButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.skipButton.Enabled = false;
            this.skipButton.Image = global::SortImage.Properties.Resources.redo;
            this.skipButton.Location = new System.Drawing.Point(69, 504);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(41, 34);
            this.skipButton.TabIndex = 44;
            this.skipButton.UseVisualStyleBackColor = true;
            this.skipButton.Click += new System.EventHandler(this.skipbut_Click);
            // 
            // trackBarSize
            // 
            this.trackBarSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSize.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarSize.Enabled = false;
            this.trackBarSize.LargeChange = 1;
            this.trackBarSize.Location = new System.Drawing.Point(3, 3);
            this.trackBarSize.Maximum = 2;
            this.trackBarSize.Name = "trackBarSize";
            this.trackBarSize.Size = new System.Drawing.Size(214, 45);
            this.trackBarSize.TabIndex = 5;
            this.trackBarSize.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarSize.ValueChanged += new System.EventHandler(this.trackBarSize_ValueChanged);
            // 
            // textBox7
            // 
            this.textBox7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox7.AutoSize = true;
            this.textBox7.Location = new System.Drawing.Point(58, 574);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(13, 13);
            this.textBox7.TabIndex = 40;
            this.textBox7.Text = "0";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(22, 544);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(191, 23);
            this.progressBar1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 574);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 574);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "OF";
            // 
            // addFolders
            // 
            this.addFolders.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.addFolders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addFolders.Image = global::SortImage.Properties.Resources.add;
            this.addFolders.Location = new System.Drawing.Point(22, 504);
            this.addFolders.Name = "addFolders";
            this.addFolders.Size = new System.Drawing.Size(41, 34);
            this.addFolders.TabIndex = 39;
            this.addFolders.UseVisualStyleBackColor = true;
            this.addFolders.Click += new System.EventHandler(this.addFolders_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(-3, -1);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.Silver;
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.name);
            this.splitContainer2.Panel2.Controls.Add(this.butOrignText);
            this.splitContainer2.Panel2.Controls.Add(this.tagList);
            this.splitContainer2.Panel2.Controls.Add(this.label8);
            this.splitContainer2.Panel2.Controls.Add(this.addTag);
            this.splitContainer2.Panel2.Controls.Add(this.newName);
            this.splitContainer2.Panel2.Controls.Add(this.tag);
            this.splitContainer2.Size = new System.Drawing.Size(521, 595);
            this.splitContainer2.SplitterDistance = 488;
            this.splitContainer2.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(514, 485);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox_Info);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox_Infor_remove);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(6, 8);
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Size = new System.Drawing.Size(251, 20);
            this.name.TabIndex = 14;
            // 
            // butOrignText
            // 
            this.butOrignText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butOrignText.Enabled = false;
            this.butOrignText.Location = new System.Drawing.Point(326, 37);
            this.butOrignText.Name = "butOrignText";
            this.butOrignText.Size = new System.Drawing.Size(46, 57);
            this.butOrignText.TabIndex = 18;
            this.butOrignText.Text = "Name?";
            this.butOrignText.UseVisualStyleBackColor = true;
            this.butOrignText.Click += new System.EventHandler(this.butOrignText_Click);
            // 
            // tagList
            // 
            this.tagList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tagList.CheckOnClick = true;
            this.tagList.Enabled = false;
            this.tagList.FormattingEnabled = true;
            this.tagList.Items.AddRange(new object[] {
            "Example_tag"});
            this.tagList.Location = new System.Drawing.Point(6, 32);
            this.tagList.MultiColumn = true;
            this.tagList.Name = "tagList";
            this.tagList.Size = new System.Drawing.Size(314, 64);
            this.tagList.TabIndex = 10;
            this.tagList.SelectedValueChanged += new System.EventHandler(this.tagList_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("DejaVu Sans", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(263, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 19);
            this.label8.TabIndex = 16;
            this.label8.Text = "->";
            // 
            // addTag
            // 
            this.addTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addTag.Enabled = false;
            this.addTag.Image = global::SortImage.Properties.Resources.notes;
            this.addTag.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addTag.Location = new System.Drawing.Point(378, 63);
            this.addTag.Name = "addTag";
            this.addTag.Size = new System.Drawing.Size(139, 31);
            this.addTag.TabIndex = 11;
            this.addTag.Text = "Add Tag";
            this.addTag.UseVisualStyleBackColor = true;
            this.addTag.Click += new System.EventHandler(this.addTag_Click);
            // 
            // newName
            // 
            this.newName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.newName.Location = new System.Drawing.Point(296, 8);
            this.newName.Name = "newName";
            this.newName.ReadOnly = true;
            this.newName.Size = new System.Drawing.Size(221, 20);
            this.newName.TabIndex = 15;
            // 
            // tag
            // 
            this.tag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tag.Location = new System.Drawing.Point(378, 37);
            this.tag.Name = "tag";
            this.tag.Size = new System.Drawing.Size(140, 20);
            this.tag.TabIndex = 12;
            this.tag.Text = "Enter a new tag...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 483);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 13;
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.SystemColors.Window;
            this.mainPanel.Controls.Add(this.toDupButton);
            this.mainPanel.Controls.Add(this.Undo);
            this.mainPanel.Controls.Add(this.foldAdd);
            this.mainPanel.Controls.Add(this.Delete);
            this.mainPanel.Controls.Add(this.pContainer);
            this.mainPanel.Controls.Add(this.splitContainer1);
            this.mainPanel.Location = new System.Drawing.Point(0, 27);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1101, 599);
            this.mainPanel.TabIndex = 40;
            // 
            // toDupButton
            // 
            this.toDupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toDupButton.Enabled = false;
            this.toDupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDupButton.Image = global::SortImage.Properties.Resources.remove;
            this.toDupButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toDupButton.Location = new System.Drawing.Point(1000, 558);
            this.toDupButton.Name = "toDupButton";
            this.toDupButton.Size = new System.Drawing.Size(98, 38);
            this.toDupButton.TabIndex = 19;
            this.toDupButton.Text = "To Dup";
            this.toDupButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toDupButton.UseVisualStyleBackColor = true;
            this.toDupButton.Click += new System.EventHandler(this.toDupButton_Click);
            // 
            // Undo
            // 
            this.Undo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Undo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Undo.Enabled = false;
            this.Undo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Undo.Image = global::SortImage.Properties.Resources.undo1;
            this.Undo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Undo.Location = new System.Drawing.Point(1000, 3);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(98, 38);
            this.Undo.TabIndex = 1;
            this.Undo.Text = "Undo";
            this.Undo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Undo.UseVisualStyleBackColor = true;
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // foldAdd
            // 
            this.foldAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.foldAdd.BackColor = System.Drawing.Color.Transparent;
            this.foldAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.foldAdd.Enabled = false;
            this.foldAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foldAdd.Image = global::SortImage.Properties.Resources.folder_new;
            this.foldAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.foldAdd.Location = new System.Drawing.Point(750, 558);
            this.foldAdd.Name = "foldAdd";
            this.foldAdd.Size = new System.Drawing.Size(130, 38);
            this.foldAdd.TabIndex = 0;
            this.foldAdd.Text = " Add Folder";
            this.foldAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.foldAdd.UseVisualStyleBackColor = false;
            this.foldAdd.Click += new System.EventHandler(this.foldAdd_Click);
            // 
            // Delete
            // 
            this.Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Delete.Enabled = false;
            this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.Image = global::SortImage.Properties.Resources.bin;
            this.Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Delete.Location = new System.Drawing.Point(754, 3);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(130, 38);
            this.Delete.TabIndex = 25;
            this.Delete.Text = "Delete";
            this.Delete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.flashBut);
            // 
            // bwSortImageFolder
            // 
            this.bwSortImageFolder.WorkerReportsProgress = true;
            this.bwSortImageFolder.WorkerSupportsCancellation = true;
            this.bwSortImageFolder.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSortImageFolder_DoWork);
            this.bwSortImageFolder.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwSortImageFolder_ProgressChanged);
            this.bwSortImageFolder.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSortImageFolder_RunWorkerCompleted);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.changeToolStripMenuItem.Text = "Change";
            this.changeToolStripMenuItem.Click += new System.EventHandler(this.changeToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 26);
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(-1, 40);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(221, 456);
            this.flowLayoutPanelMain.TabIndex = 43;
            this.flowLayoutPanelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelMain_Paint);
            this.flowLayoutPanelMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flowLayoutPanelMain_MouseDown);
            this.flowLayoutPanelMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.flowLayoutPanelMain_MouseMove);
            this.flowLayoutPanelMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.flowLayoutPanelMain_MouseUp);
            // 
            // SortImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 628);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(700, 648);
            this.Name = "SortImg";
            this.Text = "SortImg";
            this.Load += new System.EventHandler(this.SortImg_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button foldAdd;
        private System.Windows.Forms.Button Undo;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pContainer;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button toDupButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tag;
        private System.Windows.Forms.Button addTag;
        private System.Windows.Forms.CheckedListBox tagList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox newName;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button butOrignText;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLastErrorToolStripMenuItem;
        private System.Windows.Forms.Button addFolders;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label textBox7;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByMD5ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem folderImageMergeToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bwSortImageFolder;
        private System.Windows.Forms.ToolStripMenuItem convertBmpToPngToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBarSize;
        private ThumbnailFlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.Button skipButton;
        private System.Windows.Forms.Button buttonLoadMore;
        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

