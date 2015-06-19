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
            this.SuspendLayout();
            // 
            // RefreshFRCDataButton
            // 
            this.RefreshFRCDataButton.Location = new System.Drawing.Point(12, 86);
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
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Year";
            // 
            // yearBox
            // 
            this.yearBox.Location = new System.Drawing.Point(49, 12);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(39, 20);
            this.yearBox.TabIndex = 3;
            this.yearBox.Text = "2015";
            this.yearBox.TextChanged += new System.EventHandler(this.yearBox_TextChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 496);
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
    }
}