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
            this.SuspendLayout();
            // 
            // RefreshFRCDataButton
            // 
            this.RefreshFRCDataButton.Location = new System.Drawing.Point(18, 195);
            this.RefreshFRCDataButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RefreshFRCDataButton.Name = "RefreshFRCDataButton";
            this.RefreshFRCDataButton.Size = new System.Drawing.Size(248, 35);
            this.RefreshFRCDataButton.TabIndex = 0;
            this.RefreshFRCDataButton.Text = "Refresh FRC Data";
            this.RefreshFRCDataButton.UseVisualStyleBackColor = true;
            this.RefreshFRCDataButton.Click += new System.EventHandler(this.RefreshFRCDataButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Year";
            // 
            // yearBox
            // 
            this.yearBox.Location = new System.Drawing.Point(18, 18);
            this.yearBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(74, 26);
            this.yearBox.TabIndex = 3;
            this.yearBox.Text = "2015";
            this.yearBox.TextChanged += new System.EventHandler(this.yearBox_TextChanged);
            // 
            // overrideHelperLabel
            // 
            this.overrideHelperLabel.AutoSize = true;
            this.overrideHelperLabel.Enabled = false;
            this.overrideHelperLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overrideHelperLabel.Location = new System.Drawing.Point(104, 63);
            this.overrideHelperLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.overrideHelperLabel.Name = "overrideHelperLabel";
            this.overrideHelperLabel.Size = new System.Drawing.Size(261, 20);
            this.overrideHelperLabel.TabIndex = 6;
            this.overrideHelperLabel.Text = "Match Video Length (HH:MM:SS)";
            // 
            // matchLengthBox
            // 
            this.matchLengthBox.Location = new System.Drawing.Point(18, 58);
            this.matchLengthBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.matchLengthBox.Name = "matchLengthBox";
            this.matchLengthBox.Size = new System.Drawing.Size(74, 26);
            this.matchLengthBox.TabIndex = 5;
            this.matchLengthBox.Text = "00:03:00";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(717, 709);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(138, 35);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save and Exit";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // useScoreDisplayedTimeCheckbox
            // 
            this.useScoreDisplayedTimeCheckbox.AutoSize = true;
            this.useScoreDisplayedTimeCheckbox.Location = new System.Drawing.Point(378, 62);
            this.useScoreDisplayedTimeCheckbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.useScoreDisplayedTimeCheckbox.Name = "useScoreDisplayedTimeCheckbox";
            this.useScoreDisplayedTimeCheckbox.Size = new System.Drawing.Size(246, 24);
            this.useScoreDisplayedTimeCheckbox.TabIndex = 8;
            this.useScoreDisplayedTimeCheckbox.Text = "Use Post Result Time Instead";
            this.useScoreDisplayedTimeCheckbox.UseVisualStyleBackColor = true;
            this.useScoreDisplayedTimeCheckbox.CheckedChanged += new System.EventHandler(this.useScoreDisplayedTimeCheckbox_CheckedChanged);
            // 
            // endOfVideoPaddingBox
            // 
            this.endOfVideoPaddingBox.Location = new System.Drawing.Point(18, 102);
            this.endOfVideoPaddingBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.endOfVideoPaddingBox.Name = "endOfVideoPaddingBox";
            this.endOfVideoPaddingBox.Size = new System.Drawing.Size(74, 26);
            this.endOfVideoPaddingBox.TabIndex = 5;
            this.endOfVideoPaddingBox.Text = "00:00:15";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(104, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "End Of Video Padding (HH:MM:SS)";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 763);
            this.Controls.Add(this.useScoreDisplayedTimeCheckbox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endOfVideoPaddingBox);
            this.Controls.Add(this.overrideHelperLabel);
            this.Controls.Add(this.matchLengthBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yearBox);
            this.Controls.Add(this.RefreshFRCDataButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
    }
}