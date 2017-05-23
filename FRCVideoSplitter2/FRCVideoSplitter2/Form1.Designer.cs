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
            this.manualTimestampCheckbox = new System.Windows.Forms.CheckBox();
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.outroClearButton = new System.Windows.Forms.Button();
            this.outroPathTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.outroBrowseButton = new System.Windows.Forms.Button();
            this.watermarkClearButton = new System.Windows.Forms.Button();
            this.watermarkPathTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.watermarkBrowseButton = new System.Windows.Forms.Button();
            this.titleCardClearButton = new System.Windows.Forms.Button();
            this.titleCardPathTextBox = new System.Windows.Forms.TextBox();
            this.importVideosButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.titleCardBrowseButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tbaSecret = new System.Windows.Forms.TextBox();
            this.tbaAuthId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.notifyTbaButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchesDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1392, 24);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolstripMenu_Click);
            // 
            // yearBox
            // 
            this.yearBox.Location = new System.Drawing.Point(94, 19);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(38, 20);
            this.yearBox.TabIndex = 1;
            this.yearBox.Text = "2017";
            this.yearBox.TextChanged += new System.EventHandler(this.yearBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Year";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Event Name";
            // 
            // eventsComboBox
            // 
            this.eventsComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.eventsComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.eventsComboBox.FormattingEnabled = true;
            this.eventsComboBox.Location = new System.Drawing.Point(94, 45);
            this.eventsComboBox.Name = "eventsComboBox";
            this.eventsComboBox.Size = new System.Drawing.Size(283, 21);
            this.eventsComboBox.TabIndex = 5;
            this.eventsComboBox.SelectedIndexChanged += new System.EventHandler(this.eventsComboBox_SelectedIndexChanged);
            this.eventsComboBox.SelectedValueChanged += new System.EventHandler(this.eventsComboBox_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Event Code";
            // 
            // eventCodeBox
            // 
            this.eventCodeBox.Location = new System.Drawing.Point(94, 73);
            this.eventCodeBox.Name = "eventCodeBox";
            this.eventCodeBox.ReadOnly = true;
            this.eventCodeBox.Size = new System.Drawing.Size(60, 20);
            this.eventCodeBox.TabIndex = 6;
            this.eventCodeBox.TextChanged += new System.EventHandler(this.eventCodeBox_TextChanged);
            // 
            // getMatchDataButton
            // 
            this.getMatchDataButton.Location = new System.Drawing.Point(161, 71);
            this.getMatchDataButton.Name = "getMatchDataButton";
            this.getMatchDataButton.Size = new System.Drawing.Size(150, 23);
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
            this.matchesDataGridView.Location = new System.Drawing.Point(410, 33);
            this.matchesDataGridView.Name = "matchesDataGridView";
            this.matchesDataGridView.Size = new System.Drawing.Size(970, 699);
            this.matchesDataGridView.TabIndex = 9;
            this.matchesDataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.matchesDataGridView_CellMouseDown);
            this.matchesDataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.matchesDataGridView_CellMouseUp);
            this.matchesDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.matchesDataGridView_CellValueChanged);
            this.matchesDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.matchesDataGridView_DataError);
            this.matchesDataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.matchesDataGridView_MouseClick);
            this.matchesDataGridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.matchesDataGridView_MouseUp);
            // 
            // manualTimestampCheckbox
            // 
            this.manualTimestampCheckbox.AutoSize = true;
            this.manualTimestampCheckbox.Location = new System.Drawing.Point(245, 28);
            this.manualTimestampCheckbox.Name = "manualTimestampCheckbox";
            this.manualTimestampCheckbox.Size = new System.Drawing.Size(142, 17);
            this.manualTimestampCheckbox.TabIndex = 10;
            this.manualTimestampCheckbox.Text = "Use Manual Timestamps";
            this.manualTimestampCheckbox.UseVisualStyleBackColor = true;
            this.manualTimestampCheckbox.CheckedChanged += new System.EventHandler(this.manualTimestampCheckbox_CheckedChanged);
            // 
            // getTimestampButton
            // 
            this.getTimestampButton.Location = new System.Drawing.Point(10, 19);
            this.getTimestampButton.Name = "getTimestampButton";
            this.getTimestampButton.Size = new System.Drawing.Size(225, 34);
            this.getTimestampButton.TabIndex = 11;
            this.getTimestampButton.Text = "Calculate Timestamps";
            this.getTimestampButton.UseVisualStyleBackColor = true;
            this.getTimestampButton.Click += new System.EventHandler(this.getTimestampButton_Click);
            // 
            // matchVideoBrowseButton
            // 
            this.matchVideoBrowseButton.Location = new System.Drawing.Point(284, 19);
            this.matchVideoBrowseButton.Name = "matchVideoBrowseButton";
            this.matchVideoBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.matchVideoBrowseButton.TabIndex = 16;
            this.matchVideoBrowseButton.Text = "Browse";
            this.matchVideoBrowseButton.UseVisualStyleBackColor = true;
            this.matchVideoBrowseButton.Click += new System.EventHandler(this.matchVideoBrowseButton_Click);
            // 
            // sourceVideoBrowseButton
            // 
            this.sourceVideoBrowseButton.Location = new System.Drawing.Point(284, 16);
            this.sourceVideoBrowseButton.Name = "sourceVideoBrowseButton";
            this.sourceVideoBrowseButton.Size = new System.Drawing.Size(52, 23);
            this.sourceVideoBrowseButton.TabIndex = 17;
            this.sourceVideoBrowseButton.Text = "Browse";
            this.sourceVideoBrowseButton.UseVisualStyleBackColor = true;
            this.sourceVideoBrowseButton.Click += new System.EventHandler(this.sourceVideoBrowseButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Source Video";
            // 
            // matchVideoDestinationPathTextBox
            // 
            this.matchVideoDestinationPathTextBox.Location = new System.Drawing.Point(80, 20);
            this.matchVideoDestinationPathTextBox.Name = "matchVideoDestinationPathTextBox";
            this.matchVideoDestinationPathTextBox.ReadOnly = true;
            this.matchVideoDestinationPathTextBox.Size = new System.Drawing.Size(198, 20);
            this.matchVideoDestinationPathTextBox.TabIndex = 12;
            this.matchVideoDestinationPathTextBox.Text = "Click Browse...";
            // 
            // sourceVideoPathTextBox
            // 
            this.sourceVideoPathTextBox.Location = new System.Drawing.Point(90, 18);
            this.sourceVideoPathTextBox.Name = "sourceVideoPathTextBox";
            this.sourceVideoPathTextBox.ReadOnly = true;
            this.sourceVideoPathTextBox.Size = new System.Drawing.Size(189, 20);
            this.sourceVideoPathTextBox.TabIndex = 13;
            this.sourceVideoPathTextBox.Text = "Click Browse...";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "sourceFileDialog";
            // 
            // splitVideosButton
            // 
            this.splitVideosButton.BackColor = System.Drawing.Color.LimeGreen;
            this.splitVideosButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitVideosButton.ForeColor = System.Drawing.Color.White;
            this.splitVideosButton.Location = new System.Drawing.Point(12, 450);
            this.splitVideosButton.Name = "splitVideosButton";
            this.splitVideosButton.Size = new System.Drawing.Size(390, 34);
            this.splitVideosButton.TabIndex = 18;
            this.splitVideosButton.Text = "Split Videos";
            this.splitVideosButton.UseVisualStyleBackColor = false;
            this.splitVideosButton.Click += new System.EventHandler(this.splitVideosButton_Click);
            // 
            // uploadToYouTubeButton
            // 
            this.uploadToYouTubeButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.uploadToYouTubeButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.uploadToYouTubeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadToYouTubeButton.ForeColor = System.Drawing.Color.White;
            this.uploadToYouTubeButton.Location = new System.Drawing.Point(12, 490);
            this.uploadToYouTubeButton.Name = "uploadToYouTubeButton";
            this.uploadToYouTubeButton.Size = new System.Drawing.Size(390, 34);
            this.uploadToYouTubeButton.TabIndex = 18;
            this.uploadToYouTubeButton.Text = "Upload Included Videos To YouTube";
            this.uploadToYouTubeButton.UseVisualStyleBackColor = false;
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
            this.tbaSpreadsheetButton.Location = new System.Drawing.Point(12, 598);
            this.tbaSpreadsheetButton.Name = "tbaSpreadsheetButton";
            this.tbaSpreadsheetButton.Size = new System.Drawing.Size(390, 34);
            this.tbaSpreadsheetButton.TabIndex = 18;
            this.tbaSpreadsheetButton.Text = "Write TBA Upload File";
            this.tbaSpreadsheetButton.UseVisualStyleBackColor = true;
            this.tbaSpreadsheetButton.Click += new System.EventHandler(this.tbaSpreadsheetButton_Click);
            // 
            // saveScoreDetailsButton
            // 
            this.saveScoreDetailsButton.Enabled = false;
            this.saveScoreDetailsButton.Location = new System.Drawing.Point(14, 659);
            this.saveScoreDetailsButton.Name = "saveScoreDetailsButton";
            this.saveScoreDetailsButton.Size = new System.Drawing.Size(390, 34);
            this.saveScoreDetailsButton.TabIndex = 18;
            this.saveScoreDetailsButton.Text = "Save Score Details";
            this.saveScoreDetailsButton.UseVisualStyleBackColor = true;
            this.saveScoreDetailsButton.Click += new System.EventHandler(this.saveScoreDetailsButton_Click);
            // 
            // getAllTheDataButton
            // 
            this.getAllTheDataButton.Enabled = false;
            this.getAllTheDataButton.Location = new System.Drawing.Point(14, 699);
            this.getAllTheDataButton.Name = "getAllTheDataButton";
            this.getAllTheDataButton.Size = new System.Drawing.Size(390, 34);
            this.getAllTheDataButton.TabIndex = 18;
            this.getAllTheDataButton.Text = "Get ALL THE DATA";
            this.getAllTheDataButton.UseVisualStyleBackColor = true;
            this.getAllTheDataButton.Click += new System.EventHandler(this.getAllTheDataButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.yearBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.eventsComboBox);
            this.groupBox1.Controls.Add(this.eventCodeBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.getMatchDataButton);
            this.groupBox1.Location = new System.Drawing.Point(14, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 102);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Your Event";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Refresh Events";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.updateEventList_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.outroClearButton);
            this.groupBox2.Controls.Add(this.outroPathTextBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.outroBrowseButton);
            this.groupBox2.Controls.Add(this.watermarkClearButton);
            this.groupBox2.Controls.Add(this.watermarkPathTextBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.watermarkBrowseButton);
            this.groupBox2.Controls.Add(this.titleCardClearButton);
            this.groupBox2.Controls.Add(this.titleCardPathTextBox);
            this.groupBox2.Controls.Add(this.sourceVideoPathTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.sourceVideoBrowseButton);
            this.groupBox2.Controls.Add(this.importVideosButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.titleCardBrowseButton);
            this.groupBox2.Location = new System.Drawing.Point(14, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 124);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Options";
            // 
            // outroClearButton
            // 
            this.outroClearButton.Location = new System.Drawing.Point(338, 93);
            this.outroClearButton.Name = "outroClearButton";
            this.outroClearButton.Size = new System.Drawing.Size(51, 23);
            this.outroClearButton.TabIndex = 29;
            this.outroClearButton.Text = "Clear";
            this.outroClearButton.UseVisualStyleBackColor = true;
            this.outroClearButton.Click += new System.EventHandler(this.outroClearButton_Click);
            // 
            // outroPathTextBox
            // 
            this.outroPathTextBox.Location = new System.Drawing.Point(90, 95);
            this.outroPathTextBox.Name = "outroPathTextBox";
            this.outroPathTextBox.ReadOnly = true;
            this.outroPathTextBox.Size = new System.Drawing.Size(189, 20);
            this.outroPathTextBox.TabIndex = 26;
            this.outroPathTextBox.Text = "Click Browse to Use...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Outro Video";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // outroBrowseButton
            // 
            this.outroBrowseButton.Location = new System.Drawing.Point(285, 93);
            this.outroBrowseButton.Name = "outroBrowseButton";
            this.outroBrowseButton.Size = new System.Drawing.Size(51, 23);
            this.outroBrowseButton.TabIndex = 28;
            this.outroBrowseButton.Text = "Browse";
            this.outroBrowseButton.UseVisualStyleBackColor = true;
            this.outroBrowseButton.Click += new System.EventHandler(this.outroBrowseButton_Click);
            // 
            // watermarkClearButton
            // 
            this.watermarkClearButton.Location = new System.Drawing.Point(338, 67);
            this.watermarkClearButton.Name = "watermarkClearButton";
            this.watermarkClearButton.Size = new System.Drawing.Size(51, 23);
            this.watermarkClearButton.TabIndex = 25;
            this.watermarkClearButton.Text = "Clear";
            this.watermarkClearButton.UseVisualStyleBackColor = true;
            this.watermarkClearButton.Click += new System.EventHandler(this.watermarkClearButton_Click);
            // 
            // watermarkPathTextBox
            // 
            this.watermarkPathTextBox.Location = new System.Drawing.Point(90, 69);
            this.watermarkPathTextBox.Name = "watermarkPathTextBox";
            this.watermarkPathTextBox.ReadOnly = true;
            this.watermarkPathTextBox.Size = new System.Drawing.Size(189, 20);
            this.watermarkPathTextBox.TabIndex = 22;
            this.watermarkPathTextBox.Text = "Click Browse to Use...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Watermark";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // watermarkBrowseButton
            // 
            this.watermarkBrowseButton.Location = new System.Drawing.Point(285, 67);
            this.watermarkBrowseButton.Name = "watermarkBrowseButton";
            this.watermarkBrowseButton.Size = new System.Drawing.Size(51, 23);
            this.watermarkBrowseButton.TabIndex = 24;
            this.watermarkBrowseButton.Text = "Browse";
            this.watermarkBrowseButton.UseVisualStyleBackColor = true;
            this.watermarkBrowseButton.Click += new System.EventHandler(this.watermarkBrowseButton_Click);
            // 
            // titleCardClearButton
            // 
            this.titleCardClearButton.Location = new System.Drawing.Point(338, 41);
            this.titleCardClearButton.Name = "titleCardClearButton";
            this.titleCardClearButton.Size = new System.Drawing.Size(51, 23);
            this.titleCardClearButton.TabIndex = 21;
            this.titleCardClearButton.Text = "Clear";
            this.titleCardClearButton.UseVisualStyleBackColor = true;
            this.titleCardClearButton.Click += new System.EventHandler(this.titleCardClearButton_Click);
            // 
            // titleCardPathTextBox
            // 
            this.titleCardPathTextBox.Location = new System.Drawing.Point(90, 44);
            this.titleCardPathTextBox.Name = "titleCardPathTextBox";
            this.titleCardPathTextBox.ReadOnly = true;
            this.titleCardPathTextBox.Size = new System.Drawing.Size(189, 20);
            this.titleCardPathTextBox.TabIndex = 18;
            this.titleCardPathTextBox.Text = "Click Browse to Use...";
            // 
            // importVideosButton
            // 
            this.importVideosButton.Location = new System.Drawing.Point(338, 16);
            this.importVideosButton.Name = "importVideosButton";
            this.importVideosButton.Size = new System.Drawing.Size(51, 23);
            this.importVideosButton.TabIndex = 16;
            this.importVideosButton.Text = "Import";
            this.importVideosButton.UseVisualStyleBackColor = true;
            this.importVideosButton.Click += new System.EventHandler(this.importVideosButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Title Card";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // titleCardBrowseButton
            // 
            this.titleCardBrowseButton.Location = new System.Drawing.Point(285, 41);
            this.titleCardBrowseButton.Name = "titleCardBrowseButton";
            this.titleCardBrowseButton.Size = new System.Drawing.Size(51, 23);
            this.titleCardBrowseButton.TabIndex = 20;
            this.titleCardBrowseButton.Text = "Browse";
            this.titleCardBrowseButton.UseVisualStyleBackColor = true;
            this.titleCardBrowseButton.Click += new System.EventHandler(this.titleCardBrowseButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.getTimestampButton);
            this.groupBox3.Controls.Add(this.manualTimestampCheckbox);
            this.groupBox3.Location = new System.Drawing.Point(14, 273);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(390, 65);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Prepare Input File";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.tbaSecret);
            this.groupBox4.Controls.Add(this.tbaAuthId);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.matchVideoDestinationPathTextBox);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.matchVideoBrowseButton);
            this.groupBox4.Location = new System.Drawing.Point(14, 344);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(390, 100);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Output Options";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(284, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.notifyTbaClear_Click);
            // 
            // tbaSecret
            // 
            this.tbaSecret.Location = new System.Drawing.Point(80, 72);
            this.tbaSecret.Name = "tbaSecret";
            this.tbaSecret.Size = new System.Drawing.Size(198, 20);
            this.tbaSecret.TabIndex = 19;
            this.tbaSecret.Text = "Secret";
            this.tbaSecret.TextChanged += new System.EventHandler(this.tbaAuthSecret_Changed);
            // 
            // tbaAuthId
            // 
            this.tbaAuthId.Location = new System.Drawing.Point(80, 46);
            this.tbaAuthId.Name = "tbaAuthId";
            this.tbaAuthId.Size = new System.Drawing.Size(198, 20);
            this.tbaAuthId.TabIndex = 18;
            this.tbaAuthId.Text = "Auth ID";
            this.tbaAuthId.TextChanged += new System.EventHandler(this.tbaAuthId_Changed);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Notify TBA?";
            // 
            // notifyTbaButton
            // 
            this.notifyTbaButton.Location = new System.Drawing.Point(13, 557);
            this.notifyTbaButton.Name = "notifyTbaButton";
            this.notifyTbaButton.Size = new System.Drawing.Size(390, 34);
            this.notifyTbaButton.TabIndex = 23;
            this.notifyTbaButton.Text = "Notify TBA of Uploaded Videos";
            this.notifyTbaButton.UseVisualStyleBackColor = true;
            this.notifyTbaButton.Click += new System.EventHandler(this.notifyTba_Clicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 745);
            this.Controls.Add(this.notifyTbaButton);
            this.Controls.Add(this.groupBox4);
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
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.CheckBox manualTimestampCheckbox;
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox titleCardPathTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button titleCardBrowseButton;
        private System.Windows.Forms.Button watermarkClearButton;
        private System.Windows.Forms.TextBox watermarkPathTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button watermarkBrowseButton;
        private System.Windows.Forms.Button titleCardClearButton;
        private System.Windows.Forms.Button outroClearButton;
        private System.Windows.Forms.TextBox outroPathTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button outroBrowseButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbaSecret;
        private System.Windows.Forms.TextBox tbaAuthId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button notifyTbaButton;
    }
}

