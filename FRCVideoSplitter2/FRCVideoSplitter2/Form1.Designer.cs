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
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
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
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
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
            // 
            // yearBox
            // 
            this.yearBox.Location = new System.Drawing.Point(87, 30);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(39, 20);
            this.yearBox.TabIndex = 1;
            this.yearBox.Text = "2015";
            this.yearBox.TextChanged += new System.EventHandler(this.yearBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Year";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Event Name";
            // 
            // eventsComboBox
            // 
            this.eventsComboBox.FormattingEnabled = true;
            this.eventsComboBox.Location = new System.Drawing.Point(87, 56);
            this.eventsComboBox.Name = "eventsComboBox";
            this.eventsComboBox.Size = new System.Drawing.Size(283, 21);
            this.eventsComboBox.TabIndex = 5;
            this.eventsComboBox.SelectedValueChanged += new System.EventHandler(this.eventsComboBox_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Event Code";
            // 
            // eventCodeBox
            // 
            this.eventCodeBox.Location = new System.Drawing.Point(87, 84);
            this.eventCodeBox.Name = "eventCodeBox";
            this.eventCodeBox.Size = new System.Drawing.Size(60, 20);
            this.eventCodeBox.TabIndex = 6;
            // 
            // getMatchDataButton
            // 
            this.getMatchDataButton.Location = new System.Drawing.Point(153, 82);
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
            this.matchesDataGridView.Location = new System.Drawing.Point(423, 33);
            this.matchesDataGridView.Name = "matchesDataGridView";
            this.matchesDataGridView.Size = new System.Drawing.Size(957, 567);
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
            this.checkBox1.Location = new System.Drawing.Point(253, 210);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(147, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Use Manual Time Stamps";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // getTimestampButton
            // 
            this.getTimestampButton.Location = new System.Drawing.Point(12, 200);
            this.getTimestampButton.Name = "getTimestampButton";
            this.getTimestampButton.Size = new System.Drawing.Size(225, 34);
            this.getTimestampButton.TabIndex = 11;
            this.getTimestampButton.Text = "Get Timestamps";
            this.getTimestampButton.UseVisualStyleBackColor = true;
            this.getTimestampButton.Click += new System.EventHandler(this.getTimestampButton_Click);
            // 
            // matchVideoBrowseButton
            // 
            this.matchVideoBrowseButton.Location = new System.Drawing.Point(336, 150);
            this.matchVideoBrowseButton.Name = "matchVideoBrowseButton";
            this.matchVideoBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.matchVideoBrowseButton.TabIndex = 16;
            this.matchVideoBrowseButton.Text = "Browse";
            this.matchVideoBrowseButton.UseVisualStyleBackColor = true;
            this.matchVideoBrowseButton.Click += new System.EventHandler(this.matchVideoBrowseButton_Click);
            // 
            // sourceVideoBrowseButton
            // 
            this.sourceVideoBrowseButton.Location = new System.Drawing.Point(336, 124);
            this.sourceVideoBrowseButton.Name = "sourceVideoBrowseButton";
            this.sourceVideoBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.sourceVideoBrowseButton.TabIndex = 17;
            this.sourceVideoBrowseButton.Text = "Browse";
            this.sourceVideoBrowseButton.UseVisualStyleBackColor = true;
            this.sourceVideoBrowseButton.Click += new System.EventHandler(this.sourceVideoBrowseButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Match Video Destination";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Source Video Location";
            // 
            // matchVideoDestinationPathTextBox
            // 
            this.matchVideoDestinationPathTextBox.Location = new System.Drawing.Point(132, 152);
            this.matchVideoDestinationPathTextBox.Name = "matchVideoDestinationPathTextBox";
            this.matchVideoDestinationPathTextBox.Size = new System.Drawing.Size(198, 20);
            this.matchVideoDestinationPathTextBox.TabIndex = 12;
            this.matchVideoDestinationPathTextBox.Text = "Click Browse...";
            // 
            // sourceVideoPathTextBox
            // 
            this.sourceVideoPathTextBox.Location = new System.Drawing.Point(132, 126);
            this.sourceVideoPathTextBox.Name = "sourceVideoPathTextBox";
            this.sourceVideoPathTextBox.Size = new System.Drawing.Size(198, 20);
            this.sourceVideoPathTextBox.TabIndex = 13;
            this.sourceVideoPathTextBox.Text = "Click Browse...";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitVideosButton
            // 
            this.splitVideosButton.Location = new System.Drawing.Point(12, 253);
            this.splitVideosButton.Name = "splitVideosButton";
            this.splitVideosButton.Size = new System.Drawing.Size(399, 34);
            this.splitVideosButton.TabIndex = 18;
            this.splitVideosButton.Text = "Split Videos";
            this.splitVideosButton.UseVisualStyleBackColor = true;
            this.splitVideosButton.Click += new System.EventHandler(this.splitVideosButton_Click);
            // 
            // uploadToYouTubeButton
            // 
            this.uploadToYouTubeButton.Location = new System.Drawing.Point(12, 293);
            this.uploadToYouTubeButton.Name = "uploadToYouTubeButton";
            this.uploadToYouTubeButton.Size = new System.Drawing.Size(399, 34);
            this.uploadToYouTubeButton.TabIndex = 18;
            this.uploadToYouTubeButton.Text = "Upload To YouTube";
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
            this.tbaSpreadsheetButton.Location = new System.Drawing.Point(12, 333);
            this.tbaSpreadsheetButton.Name = "tbaSpreadsheetButton";
            this.tbaSpreadsheetButton.Size = new System.Drawing.Size(399, 34);
            this.tbaSpreadsheetButton.TabIndex = 18;
            this.tbaSpreadsheetButton.Text = "Write TBA Upload File";
            this.tbaSpreadsheetButton.UseVisualStyleBackColor = true;
            this.tbaSpreadsheetButton.Click += new System.EventHandler(this.tbaSpreadsheetButton_Click);
            // 
            // saveScoreDetailsButton
            // 
            this.saveScoreDetailsButton.Location = new System.Drawing.Point(12, 373);
            this.saveScoreDetailsButton.Name = "saveScoreDetailsButton";
            this.saveScoreDetailsButton.Size = new System.Drawing.Size(399, 34);
            this.saveScoreDetailsButton.TabIndex = 18;
            this.saveScoreDetailsButton.Text = "Save Score Details";
            this.saveScoreDetailsButton.UseVisualStyleBackColor = true;
            this.saveScoreDetailsButton.Click += new System.EventHandler(this.saveScoreDetailsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 612);
            this.Controls.Add(this.saveScoreDetailsButton);
            this.Controls.Add(this.tbaSpreadsheetButton);
            this.Controls.Add(this.uploadToYouTubeButton);
            this.Controls.Add(this.splitVideosButton);
            this.Controls.Add(this.matchVideoBrowseButton);
            this.Controls.Add(this.sourceVideoBrowseButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.matchVideoDestinationPathTextBox);
            this.Controls.Add(this.sourceVideoPathTextBox);
            this.Controls.Add(this.getTimestampButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.matchesDataGridView);
            this.Controls.Add(this.getMatchDataButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.eventCodeBox);
            this.Controls.Add(this.eventsComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yearBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Write TBA Upload File";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchesDataGridView)).EndInit();
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
    }
}

