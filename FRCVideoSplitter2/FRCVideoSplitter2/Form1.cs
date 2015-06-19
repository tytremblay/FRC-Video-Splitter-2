using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace FRCVideoSplitter2
{
    public partial class Form1 : Form
    {
        private List<FRCApi.Event> eventsList = new List<FRCApi.Event>();
        FRCApi api = new FRCApi();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Runs while the form is loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            updateObjects();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Launch the settings form and then update objects after its closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();

            //after the form is closed, update your objects from the settings file
            updateObjects();
        }

        /// <summary>
        /// Pulls from settings and updates the objects in this class
        /// </summary>
        private void updateObjects()
        {
            string eventsJsonStr = Properties.Settings.Default.eventsJsonString;

            this.eventsList = JsonConvert.DeserializeObject<FRCApi.EventsList>(eventsJsonStr).Events.OrderBy(o=>o.name).ToList();
            
            this.yearBox.Text = Properties.Settings.Default.year.ToString();

            List<string> eventNames = this.eventsList.Select(x => x.name).ToList();

            this.eventsComboBox.DataSource = eventNames;
        }
        
        /// <summary>
        /// Save the year if they change it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// When the user selects the event name, update the event code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eventsComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            eventCodeBox.Text = eventsList.Find(i => i.name == eventsComboBox.Text).code;
            Properties.Settings.Default.eventCode = eventCodeBox.Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Get the match data for the specified year and event and display it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getMatchDataButton_Click(object sender, EventArgs e)
        {
            List<FRCApi.MatchResult> frcMatches = api.getMatchResults(Properties.Settings.Default.year, Properties.Settings.Default.eventCode);

            List<SplitterTypes.Match> matches = new List<SplitterTypes.Match>();

            foreach (FRCApi.MatchResult frcMatch in frcMatches)
            {
                matches.Add(new SplitterTypes.Match(frcMatch));
            }

            matchesDataGridView.DataSource = matches;
        }
    }
}
