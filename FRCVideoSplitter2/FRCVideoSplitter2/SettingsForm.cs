using System;
using System.IO;
using System.Windows.Forms;

namespace FRCVideoSplitter2
{
    public partial class SettingsForm : Form
    {
        FRCApi api = new FRCApi();
        public SettingsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pull the events list from FRC for the given year.
        /// </summary>
        private void RefreshFRCDataButton_Click(object sender, EventArgs e)
        {
            string events = api.getEventsListJsonString(Properties.Settings.Default.year);
            Properties.Settings.Default.eventsJsonString = events;
            Properties.Settings.Default.Save();
            MessageBox.Show("Data successfully refreshed.");
        }

        /// <summary>
        /// Save the year if they change it
        /// </summary>
        private void yearBox_TextChanged(object sender, EventArgs e)
        {
            //if they've entered 4 digits
            int year;
            if (this.yearBox.Text.Length == 4 && int.TryParse(this.yearBox.Text, out year))
            {
                Properties.Settings.Default.year = year;
                Properties.Settings.Default.Save();
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.yearBox.Text = Properties.Settings.Default.year.ToString();
            this.matchLengthBox.Text = Properties.Settings.Default.matchLength;
            this.endOfVideoPaddingBox.Text = Properties.Settings.Default.endOfVideoPadTime;
            this.frcApiToken.Text = Properties.Settings.Default.frcApiToken;
            this.tbaAuthKey.Text = Properties.Settings.Default.tbaApiKey;
            this.useScoreDisplayedTimeCheckbox.Checked = Properties.Settings.Default.useScoreDisplayedTime;
            this.youtubePrivate.Checked = Properties.Settings.Default.uploadYoutubeAsPrivate;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.tbaApiKey = tbaAuthKey.Text;
            if (Properties.Settings.Default.frcApiToken != frcApiToken.Text)
            {
                File.Delete("requestTimes.bin");//delete requests, so we restart fresh without cache
                Properties.Settings.Default.frcApiToken = frcApiToken.Text;
            }
            Properties.Settings.Default.matchLength = matchLengthBox.Text;
            Properties.Settings.Default.endOfVideoPadTime = endOfVideoPaddingBox.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.useScoreDisplayedTime = this.useScoreDisplayedTimeCheckbox.Checked;
            Properties.Settings.Default.uploadYoutubeAsPrivate = this.youtubePrivate.Checked;
            this.Close();
        }

        private void useScoreDisplayedTimeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            overrideHelperLabel.Enabled = !useScoreDisplayedTimeCheckbox.Checked;
            matchLengthBox.Enabled = !useScoreDisplayedTimeCheckbox.Checked;
        }

        private void ClearSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            FRCApi.deleteRequestTimes();
        }
    }
}