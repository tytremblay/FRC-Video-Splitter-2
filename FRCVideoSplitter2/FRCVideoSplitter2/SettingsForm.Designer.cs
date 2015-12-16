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
            this.SuspendLayout();
            // 
            // RefreshFRCDataButton
            // 
            this.RefreshFRCDataButton.Location = new System.Drawing.Point(12, 78);
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
            this.yearBox.Location = new System.Drawing.Point(12, 12);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(51, 20);
            this.yearBox.TabIndex = 3;
            this.yearBox.Text = "2015";
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
            this.matchLengthBox.Location = new System.Drawing.Point(12, 38);
            this.matchLengthBox.Name = "matchLengthBox";
            this.matchLengthBox.Size = new System.Drawing.Size(51, 20);
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
            this.useScoreDisplayedTimeCheckbox.Location = new System.Drawing.Point(252, 40);
            this.useScoreDisplayedTimeCheckbox.Name = "useScoreDisplayedTimeCheckbox";
            this.useScoreDisplayedTimeCheckbox.Size = new System.Drawing.Size(166, 17);
            this.useScoreDisplayedTimeCheckbox.TabIndex = 8;
            this.useScoreDisplayedTimeCheckbox.Text = "Use Post Result Time Instead";
            this.useScoreDisplayedTimeCheckbox.UseVisualStyleBackColor = true;
            this.useScoreDisplayedTimeCheckbox.CheckedChanged += new System.EventHandler(this.useScoreDisplayedTimeCheckbox_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 496);
            this.Controls.Add(this.useScoreDisplayedTimeCheckbox);
            this.Controls.Add(this.saveButton);
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
    }
}