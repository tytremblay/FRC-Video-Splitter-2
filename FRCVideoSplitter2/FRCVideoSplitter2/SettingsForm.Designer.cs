namespace FRCVideoSplitter2
{
    partial class SettingsForm
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
            this.RefreshFRCDataButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.yearBox = new System.Windows.Forms.TextBox();
            this.overrideHelperLabel = new System.Windows.Forms.Label();
            this.matchLengthBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.useScoreDisplayedTimeCheckbox = new System.Windows.Forms.CheckBox();
            this.endOfVideoPaddingBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.frcApiToken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbaAuthKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.youtubePrivate = new System.Windows.Forms.CheckBox();
            this.uploadsToFIRST = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // RefreshFRCDataButton
            // 
            this.RefreshFRCDataButton.Location = new System.Drawing.Point(11, 423);
            this.RefreshFRCDataButton.Name = "RefreshFRCDataButton";
            this.RefreshFRCDataButton.Size = new System.Drawing.Size(165, 23);
            this.RefreshFRCDataButton.TabIndex = 0;
            this.RefreshFRCDataButton.Text = "Refresh FRC Data";
            this.RefreshFRCDataButton.UseVisualStyleBackColor = true;
            this.RefreshFRCDataButton.Click += new System.EventHandler(this.RefreshFRCDataButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Year";
            // 
            // yearBox
            // 
            this.yearBox.Location = new System.Drawing.Point(12, 11);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(50, 20);
            this.yearBox.TabIndex = 3;
            this.yearBox.Text = "2017";
            this.yearBox.TextChanged += new System.EventHandler(this.yearBox_TextChanged);
            // 
            // overrideHelperLabel
            // 
            this.overrideHelperLabel.AutoSize = true;
            this.overrideHelperLabel.Enabled = false;
            this.overrideHelperLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overrideHelperLabel.Location = new System.Drawing.Point(69, 41);
            this.overrideHelperLabel.Name = "overrideHelperLabel";
            this.overrideHelperLabel.Size = new System.Drawing.Size(166, 13);
            this.overrideHelperLabel.TabIndex = 6;
            this.overrideHelperLabel.Text = "Match Video Length (HH:MM:SS)";
            // 
            // matchLengthBox
            // 
            this.matchLengthBox.Location = new System.Drawing.Point(12, 37);
            this.matchLengthBox.Name = "matchLengthBox";
            this.matchLengthBox.Size = new System.Drawing.Size(50, 20);
            this.matchLengthBox.TabIndex = 5;
            this.matchLengthBox.Text = "00:03:00";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(478, 461);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(92, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save and Exit";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // useScoreDisplayedTimeCheckbox
            // 
            this.useScoreDisplayedTimeCheckbox.AutoSize = true;
            this.useScoreDisplayedTimeCheckbox.Location = new System.Drawing.Point(252, 41);
            this.useScoreDisplayedTimeCheckbox.Name = "useScoreDisplayedTimeCheckbox";
            this.useScoreDisplayedTimeCheckbox.Size = new System.Drawing.Size(166, 17);
            this.useScoreDisplayedTimeCheckbox.TabIndex = 8;
            this.useScoreDisplayedTimeCheckbox.Text = "Use Post Result Time Instead";
            this.useScoreDisplayedTimeCheckbox.UseVisualStyleBackColor = true;
            this.useScoreDisplayedTimeCheckbox.CheckedChanged += new System.EventHandler(this.useScoreDisplayedTimeCheckbox_CheckedChanged);
            // 
            // endOfVideoPaddingBox
            // 
            this.endOfVideoPaddingBox.Location = new System.Drawing.Point(12, 67);
            this.endOfVideoPaddingBox.Name = "endOfVideoPaddingBox";
            this.endOfVideoPaddingBox.Size = new System.Drawing.Size(50, 20);
            this.endOfVideoPaddingBox.TabIndex = 5;
            this.endOfVideoPaddingBox.Text = "00:00:15";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "End Of Video Padding (HH:MM:SS)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 461);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Clear Saved Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClearSettings_Click);
            // 
            // frcApiToken
            // 
            this.frcApiToken.Location = new System.Drawing.Point(12, 98);
            this.frcApiToken.Name = "frcApiToken";
            this.frcApiToken.Size = new System.Drawing.Size(245, 20);
            this.frcApiToken.TabIndex = 10;
            this.frcApiToken.Text = "username:token";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(263, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "FRC API Token (user : token)";
            // 
            // tbaAuthKey
            // 
            this.tbaAuthKey.Location = new System.Drawing.Point(12, 129);
            this.tbaAuthKey.Name = "tbaAuthKey";
            this.tbaAuthKey.Size = new System.Drawing.Size(245, 20);
            this.tbaAuthKey.TabIndex = 12;
            this.tbaAuthKey.Text = "Auth Key";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(263, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "TBA API Token";
            // 
            // youtubePrivate
            // 
            this.youtubePrivate.AutoSize = true;
            this.youtubePrivate.Location = new System.Drawing.Point(12, 164);
            this.youtubePrivate.Name = "youtubePrivate";
            this.youtubePrivate.Size = new System.Drawing.Size(174, 17);
            this.youtubePrivate.TabIndex = 14;
            this.youtubePrivate.Text = "Make Youtube Uploads Private";
            this.youtubePrivate.UseVisualStyleBackColor = true;
            // 
            // uploadsToFIRST
            // 
            this.uploadsToFIRST.AutoSize = true;
            this.uploadsToFIRST.Location = new System.Drawing.Point(11, 187);
            this.uploadsToFIRST.Name = "uploadsToFIRST";
            this.uploadsToFIRST.Size = new System.Drawing.Size(241, 17);
            this.uploadsToFIRST.TabIndex = 15;
            this.uploadsToFIRST.Text = "Report Uploads to FIRST HQ (Requires Auth)";
            this.uploadsToFIRST.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 496);
            this.Controls.Add(this.uploadsToFIRST);
            this.Controls.Add(this.youtubePrivate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbaAuthKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.frcApiToken);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.useScoreDisplayedTimeCheckbox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endOfVideoPaddingBox);
            this.Controls.Add(this.overrideHelperLabel);
            this.Controls.Add(this.matchLengthBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yearBox);
            this.Controls.Add(this.RefreshFRCDataButton);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RefreshFRCDataButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox yearBox;
        private System.Windows.Forms.Label overrideHelperLabel;
        private System.Windows.Forms.TextBox matchLengthBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox useScoreDisplayedTimeCheckbox;
        private System.Windows.Forms.TextBox endOfVideoPaddingBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox frcApiToken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbaAuthKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox youtubePrivate;
        private System.Windows.Forms.CheckBox uploadsToFIRST;
    }
}