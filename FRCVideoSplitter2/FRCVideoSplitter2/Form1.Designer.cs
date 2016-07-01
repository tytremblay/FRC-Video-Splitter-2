namespace FRCVideoSplitter2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.eventsComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.eventCodeBox = new System.Windows.Forms.TextBox();
            this.getMatchDataButton = new System.Windows.Forms.Button();
            this.matchesDataGridView = new System.Windows.Forms.DataGridView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.getTimestampButton = new System.Windows.Forms.Button();
            this.matchVideoBrowseButton = new System.Windows.Forms.Button();
            this.sourceVideoBrowseButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.matchVideoDestinationPathTextBox = new System.Windows.Forms.TextBox();
            this.sourceVideoPathTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.splitVideosButton = new System.Windows.Forms.Button();
            this.uploadToYouTubeButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tbaSpreadsheetButton = new System.Windows.Forms.Button();
            this.saveScoreDetailsButton = new System.Windows.Forms.Button();
            this.getAllTheDataButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.importVideosButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchesDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(2088, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(159, 30);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(159, 30);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(159, 30);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(159, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(161, 30);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(147, 30);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // yearBox
            // 
            this.yearBox.Location = new System.Drawing.Point(142, 29);
            this.yearBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(56, 26);
            this.yearBox.TabIndex = 1;
            this.yearBox.Text = "2015";
            this.yearBox.TextChanged += new System.EventHandler(this.yearBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Year";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 75);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Event Name";
            // 
            // eventsComboBox
            // 
            this.eventsComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.eventsComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.eventsComboBox.FormattingEnabled = true;
            this.eventsComboBox.Location = new System.Drawing.Point(142, 69);
            this.eventsComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.eventsComboBox.Name = "eventsComboBox";
            this.eventsComboBox.Size = new System.Drawing.Size(422, 28);
            this.eventsComboBox.TabIndex = 5;
            this.eventsComboBox.SelectedValueChanged += new System.EventHandler(this.eventsComboBox_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Event Code";
            // 
            // eventCodeBox
            // 
            this.eventCodeBox.Location = new System.Drawing.Point(142, 112);
            this.eventCodeBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.eventCodeBox.Name = "eventCodeBox";
            this.eventCodeBox.Size = new System.Drawing.Size(88, 26);
            this.eventCodeBox.TabIndex = 6;
            // 
            // getMatchDataButton
            // 
            this.getMatchDataButton.Location = new System.Drawing.Point(242, 109);
            this.getMatchDataButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.getMatchDataButton.Name = "getMatchDataButton";
            this.getMatchDataButton.Size = new System.Drawing.Size(225, 35);
            this.getMatchDataButton.TabIndex = 8;
            this.getMatchDataButton.Text = "Get Match Data";
            this.getMatchDataButton.UseVisualStyleBackColor = true;
            this.getMatchDataButton.Click += new System.EventHandler(this.getMatchDataButton_Click);
            // 
            // matchesDataGridView
            // 
            this.matchesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.matchesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matchesDataGridView.Location = new System.Drawing.Point(614, 51);
            this.matchesDataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.matchesDataGridView.Name = "matchesDataGridView";
            this.matchesDataGridView.Size = new System.Drawing.Size(1456, 872);
            this.matchesDataGridView.TabIndex = 9;
            this.matchesDataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.matchesDataGridView_CellMouseDown);
            this.matchesDataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.matchesDataGridView_CellMouseUp);
            this.matchesDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.matchesDataGridView_CellValueChanged);
            this.matchesDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.matchesDataGridView_DataError);
            this.matchesDataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.matchesDataGridView_MouseClick);
            this.matchesDataGridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.matchesDataGridView_MouseUp);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(368, 44);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(217, 24);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Use Manual Time Stamps";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // getTimestampButton
            // 
            this.getTimestampButton.Location = new System.Drawing.Point(15, 29);
            this.getTimestampButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.getTimestampButton.Name = "getTimestampButton";
            this.getTimestampButton.Size = new System.Drawing.Size(338, 52);
            this.getTimestampButton.TabIndex = 11;
            this.getTimestampButton.Text = "Get Timestamps";
            this.getTimestampButton.UseVisualStyleBackColor = true;
            this.getTimestampButton.Click += new System.EventHandler(this.getTimestampButton_Click);
            // 
            // matchVideoBrowseButton
            // 
            this.matchVideoBrowseButton.Location = new System.Drawing.Point(441, 72);
            this.matchVideoBrowseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.matchVideoBrowseButton.Name = "matchVideoBrowseButton";
            this.matchVideoBrowseButton.Size = new System.Drawing.Size(112, 35);
            this.matchVideoBrowseButton.TabIndex = 16;
            this.matchVideoBrowseButton.Text = "Browse";
            this.matchVideoBrowseButton.UseVisualStyleBackColor = true;
            this.matchVideoBrowseButton.Click += new System.EventHandler(this.matchVideoBrowseButton_Click);
            // 
            // sourceVideoBrowseButton
            // 
            this.sourceVideoBrowseButton.Location = new System.Drawing.Point(441, 32);
            this.sourceVideoBrowseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sourceVideoBrowseButton.Name = "sourceVideoBrowseButton";
            this.sourceVideoBrowseButton.Size = new System.Drawing.Size(112, 35);
            this.sourceVideoBrowseButton.TabIndex = 17;
            this.sourceVideoBrowseButton.Text = "Browse";
            this.sourceVideoBrowseButton.UseVisualStyleBackColor = true;
            this.sourceVideoBrowseButton.Click += new System.EventHandler(this.sourceVideoBrowseButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Match Videos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Source Video";
            // 
            // matchVideoDestinationPathTextBox
            // 
            this.matchVideoDestinationPathTextBox.Location = new System.Drawing.Point(135, 75);
            this.matchVideoDestinationPathTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.matchVideoDestinationPathTextBox.Name = "matchVideoDestinationPathTextBox";
            this.matchVideoDestinationPathTextBox.Size = new System.Drawing.Size(295, 26);
            this.matchVideoDestinationPathTextBox.TabIndex = 12;
            this.matchVideoDestinationPathTextBox.Text = "Click Browse...";
            // 
            // sourceVideoPathTextBox
            // 
            this.sourceVideoPathTextBox.Location = new System.Drawing.Point(135, 35);
            this.sourceVideoPathTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sourceVideoPathTextBox.Name = "sourceVideoPathTextBox";
            this.sourceVideoPathTextBox.Size = new System.Drawing.Size(295, 26);
            this.sourceVideoPathTextBox.TabIndex = 13;
            this.sourceVideoPathTextBox.Text = "Click Browse...";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitVideosButton
            // 
            this.splitVideosButton.Location = new System.Drawing.Point(21, 521);
            this.splitVideosButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitVideosButton.Name = "splitVideosButton";
            this.splitVideosButton.Size = new System.Drawing.Size(585, 52);
            this.splitVideosButton.TabIndex = 18;
            this.splitVideosButton.Text = "Split Videos";
            this.splitVideosButton.UseVisualStyleBackColor = true;
            this.splitVideosButton.Click += new System.EventHandler(this.splitVideosButton_Click);
            // 
            // uploadToYouTubeButton
            // 
            this.uploadToYouTubeButton.Location = new System.Drawing.Point(21, 586);
            this.uploadToYouTubeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uploadToYouTubeButton.Name = "uploadToYouTubeButton";
            this.uploadToYouTubeButton.Size = new System.Drawing.Size(585, 52);
            this.uploadToYouTubeButton.TabIndex = 18;
            this.uploadToYouTubeButton.Text = "Upload Included Videos To YouTube";
            this.uploadToYouTubeButton.UseVisualStyleBackColor = true;
            this.uploadToYouTubeButton.Click += new System.EventHandler(this.uploadToYouTubeButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // tbaSpreadsheetButton
            // 
            this.tbaSpreadsheetButton.Location = new System.Drawing.Point(21, 651);
            this.tbaSpreadsheetButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbaSpreadsheetButton.Name = "tbaSpreadsheetButton";
            this.tbaSpreadsheetButton.Size = new System.Drawing.Size(585, 52);
            this.tbaSpreadsheetButton.TabIndex = 18;
            this.tbaSpreadsheetButton.Text = "Write TBA Upload File";
            this.tbaSpreadsheetButton.UseVisualStyleBackColor = true;
            this.tbaSpreadsheetButton.Click += new System.EventHandler(this.tbaSpreadsheetButton_Click);
            // 
            // saveScoreDetailsButton
            // 
            this.saveScoreDetailsButton.Location = new System.Drawing.Point(21, 716);
            this.saveScoreDetailsButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveScoreDetailsButton.Name = "saveScoreDetailsButton";
            this.saveScoreDetailsButton.Size = new System.Drawing.Size(585, 52);
            this.saveScoreDetailsButton.TabIndex = 18;
            this.saveScoreDetailsButton.Text = "Save Score Details";
            this.saveScoreDetailsButton.UseVisualStyleBackColor = true;
            this.saveScoreDetailsButton.Click += new System.EventHandler(this.saveScoreDetailsButton_Click);
            // 
            // getAllTheDataButton
            // 
            this.getAllTheDataButton.Location = new System.Drawing.Point(21, 781);
            this.getAllTheDataButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.getAllTheDataButton.Name = "getAllTheDataButton";
            this.getAllTheDataButton.Size = new System.Drawing.Size(585, 52);
            this.getAllTheDataButton.TabIndex = 18;
            this.getAllTheDataButton.Text = "Get ALL THE DATA";
            this.getAllTheDataButton.UseVisualStyleBackColor = true;
            this.getAllTheDataButton.Click += new System.EventHandler(this.getAllTheDataButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.yearBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.eventsComboBox);
            this.groupBox1.Controls.Add(this.eventCodeBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.getMatchDataButton);
            this.groupBox1.Location = new System.Drawing.Point(21, 51);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(585, 158);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Your Event";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sourceVideoPathTextBox);
            this.groupBox2.Controls.Add(this.matchVideoDestinationPathTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.sourceVideoBrowseButton);
            this.groupBox2.Controls.Add(this.importVideosButton);
            this.groupBox2.Controls.Add(this.matchVideoBrowseButton);
            this.groupBox2.Location = new System.Drawing.Point(21, 235);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(585, 166);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Video Locations";
            // 
            // importVideosButton
            // 
            this.importVideosButton.Location = new System.Drawing.Point(135, 111);
            this.importVideosButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.importVideosButton.Name = "importVideosButton";
            this.importVideosButton.Size = new System.Drawing.Size(185, 35);
            this.importVideosButton.TabIndex = 16;
            this.importVideosButton.Text = "Import Videos";
            this.importVideosButton.UseVisualStyleBackColor = true;
            this.importVideosButton.Click += new System.EventHandler(this.importVideosButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.getTimestampButton);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Location = new System.Drawing.Point(21, 411);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(585, 100);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Generate Video Timestamps";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(249, 543);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer1.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2088, 942);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.getAllTheDataButton);
            this.Controls.Add(this.saveScoreDetailsButton);
            this.Controls.Add(this.tbaSpreadsheetButton);
            this.Controls.Add(this.uploadToYouTubeButton);
            this.Controls.Add(this.splitVideosButton);
            this.Controls.Add(this.matchesDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "FRC Video Splitter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchesDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.TextBox yearBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox eventsComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox eventCodeBox;
        private System.Windows.Forms.Button getMatchDataButton;
        private System.Windows.Forms.DataGridView matchesDataGridView;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button getTimestampButton;
        private System.Windows.Forms.Button matchVideoBrowseButton;
        private System.Windows.Forms.Button sourceVideoBrowseButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox matchVideoDestinationPathTextBox;
        private System.Windows.Forms.TextBox sourceVideoPathTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button splitVideosButton;
        private System.Windows.Forms.Button uploadToYouTubeButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button tbaSpreadsheetButton;
        private System.Windows.Forms.Button saveScoreDetailsButton;
        private System.Windows.Forms.Button getAllTheDataButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Button importVideosButton;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}

