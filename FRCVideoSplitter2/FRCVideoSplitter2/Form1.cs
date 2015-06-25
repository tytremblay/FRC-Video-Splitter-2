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
using System.IO;
using System.Diagnostics;
using System.Reflection;
using Google.Apis.YouTube.v3.Data;

namespace FRCVideoSplitter2
{
    public partial class Form1 : Form
    {
        private List<FRCApi.Event> eventsList = new List<FRCApi.Event>();
        BindingList<SplitterTypes.Match> matchesList = new BindingList<SplitterTypes.Match>();
        FRCApi api = new FRCApi();
        ProgressDialog progress;
        YouTubeApi.VideoUploader uploader = new YouTubeApi.VideoUploader();
        int videoUploadIndex = 0;
        string currentPlaylistId = "";

        DataGridViewSelectedRowCollection selectedMatches;

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

            uploader.Upload_ProgressChanged += new EventHandler<long>(vid_ProgressChanged);
            uploader.UploadCompleted += new EventHandler<string>(vid_UploadCompleted);
            uploader.Upload_Failed += new EventHandler<string>(vid_UploadFailed);
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
            this.matchesDataGridView.AutoResizeColumns();

            Properties.Settings.Default.useManualTimeStamps = checkBox1.Checked;
            Properties.Settings.Default.Save();
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
            Properties.Settings.Default.eventName = eventsComboBox.Text;
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
            this.matchesDataGridView.DataSource = null;
            matchesList.Clear();

            List<FRCApi.MatchResult> frcMatches = api.getMatchResults(Properties.Settings.Default.year, Properties.Settings.Default.eventCode);
            
            foreach (FRCApi.MatchResult frcMatch in frcMatches)
            {
                matchesList.Add(new SplitterTypes.Match(frcMatch));
            }

            this.matchesDataGridView.DataSource = matchesList;
            this.SetDataGridViewFormatting();
        }

        /// <summary>
        /// Fortmats the DataGridView appropriately
        /// </summary>
        private void SetDataGridViewFormatting()
        {
            this.matchesDataGridView.Columns["TimeStamp"].DefaultCellStyle.Format = "HH:mm:ss.fff";
            this.matchesDataGridView.Columns["AutoStartTime"].DefaultCellStyle.Format = "M/dd HH:mm:ss.fff";

            foreach (DataGridViewColumn col in matchesDataGridView.Columns)
            {
                if (col.HeaderText != "TimeStamp" && col.HeaderText != "Include")
                {
                    col.ReadOnly = true;
                    col.DefaultCellStyle.BackColor = Color.LightGray;
                }
                
            }

            foreach (DataGridViewRow row in matchesDataGridView.Rows)
            {
                row.Cells["TimeStamp"].ReadOnly = !(Properties.Settings.Default.useManualTimeStamps && (bool) row.Cells["Include"].Value);

                if (row.Cells["TimeStamp"].ReadOnly)
                {
                    row.Cells["TimeStamp"].Style.BackColor = Color.LightGray;
                }
                else
                {
                    row.Cells["TimeStamp"].Style.BackColor = Color.White;
                }
            }
            this.matchesDataGridView.AutoResizeColumns();
            enableFirstIncludedTimeStamp();
        }

        /// <summary>
        /// Context menu on right click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void matchesDataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                
                MenuItem excludeMenuItem = new MenuItem("Exclude");
                excludeMenuItem.Click += new EventHandler(item_Click);

                MenuItem includeMenuItem = new MenuItem("Include");
                includeMenuItem.Click += new EventHandler(item_Click);

                m.MenuItems.Add(excludeMenuItem);
                m.MenuItems.Add(includeMenuItem);

                int currentMouseOverRow = matchesDataGridView.HitTest(e.X, e.Y).RowIndex;

                m.Show(matchesDataGridView, new Point(e.X, e.Y));

            }
        }

        /// <summary>
        /// Handle context menu item clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void item_Click(object sender, EventArgs e)
        {
            MenuItem clickedItem = sender as MenuItem;

            if (clickedItem.Text == "Exclude")
            {
                foreach (DataGridViewRow row in selectedMatches)
                {
                    row.Cells["Include"].Value = false;
                    row.Cells["Include"].ReadOnly = true;
                }
            }
            else if (clickedItem.Text == "Include")
            {
                foreach (DataGridViewRow row in selectedMatches)
                {
                    row.Cells["Include"].Value = true;
                    row.Cells["Include"].ReadOnly = false;
                }
            }
        }

        /// <summary>
        /// Handle the manual time stamps checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.useManualTimeStamps = checkBox1.Checked;
            Properties.Settings.Default.Save();

            try
            {
                SetDataGridViewFormatting();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please get match data first.");
                return;
            }
            
        }

        /// <summary>
        /// Update all selected matches accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void matchesDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in selectedMatches)
            {
                row.Cells["Include"].Value = matchesDataGridView.Rows[e.RowIndex].Cells["Include"].Value;
            }

            if (e.ColumnIndex == matchesDataGridView.Columns["Include"].Index && e.RowIndex != -1)
            {
                if ((bool)matchesDataGridView.Rows[e.RowIndex].Cells["Include"].Value == false)
                {
                    matchesDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                }
                else
                {
                    matchesDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }                
            }

            enableFirstIncludedTimeStamp();
        }

        /// <summary>
        /// If the user clicked a checkbox, trigger the CellValueChangedEvent.
        /// Also, keep track of selected matches.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void matchesDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // End of edition on each click on column of checkbox
            if (e.ColumnIndex == matchesDataGridView.Columns["Include"].Index && e.RowIndex != -1)
            {
                matchesDataGridView.EndEdit();
            }

            this.selectedMatches = matchesDataGridView.SelectedRows;
        }

        /// <summary>
        /// If the user drags the mouse off the cells, still make sure you track what they selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void matchesDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            this.selectedMatches = matchesDataGridView.SelectedRows;
        }

        /// <summary>
        /// Iterate through the list of matches and calculate the timestamps in the video based off 
        /// the first included match.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getTimestampButton_Click(object sender, EventArgs e)
        {
            DateTime previousMatchTime = new DateTime();
            DateTime currentMatchTime = new DateTime();
            DateTime previousMatchStamp = new DateTime();

            int firstIncludedIndex = 0;

            //find the index of the first included match
            for (int i = 0; i < matchesList.Count; i++)
            {
                if (matchesList[i].Include == true)
                {
                    firstIncludedIndex = i;
                    break;
                }
            }

            //calculate all the time stamps
            for (int i = firstIncludedIndex + 1; i < matchesList.Count; i++)
            {
                if (matchesList[i].Include == true)
                {
                    previousMatchTime = matchesList[i - 1].AutoStartTime;
                    currentMatchTime = matchesList[i].AutoStartTime;
                    previousMatchStamp = matchesList[i - 1].TimeStamp;

                    matchesList[i].TimeStamp = previousMatchStamp + (currentMatchTime - previousMatchTime);
                }
            }            
        }

        /// <summary>
        /// Get the first row with an include checkbox that is checked.
        /// </summary>
        /// <returns></returns>
        private DataGridViewRow getFirstIncludedMatchRow()
        {
            foreach (DataGridViewRow row in matchesDataGridView.Rows)
            {
                if ((bool) row.Cells["Include"].Value == true)
                {
                    return row;
                }
            }
            return null;
        }

        /// <summary>
        /// Make sure selected rows are updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void matchesDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.selectedMatches = matchesDataGridView.SelectedRows;
        }

        /// <summary>
        /// Allows the user to enter the timestamp of the first match in the video
        /// </summary>
        private void enableFirstIncludedTimeStamp()
        {
            if (!Properties.Settings.Default.useManualTimeStamps)
            {
                foreach (DataGridViewRow row in matchesDataGridView.Rows) 
                {
                    row.Cells["TimeStamp"].ReadOnly = true;
                    row.Cells["TimeStamp"].Style.BackColor = Color.LightGray;
                }
            }

            DataGridViewRow firstRow = getFirstIncludedMatchRow();
            firstRow.Cells["TimeStamp"].ReadOnly = false;
            firstRow.Cells["TimeStamp"].Style.BackColor = Color.White;
        }

        /// <summary>
        /// Find the source video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sourceVideoBrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                sourceVideoPathTextBox.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Where to save the split videos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void matchVideoBrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                matchVideoDestinationPathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        /// <summary>
        /// Split out the match videos based on the timestamps in the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitVideosButton_Click(object sender, EventArgs e)
        {
            string sourceFile = sourceVideoPathTextBox.Text;
            progress = new ProgressDialog();
            progress.SetText("Splitting videos");
            int chunks = matchesList.Where(i => i.Include == true).ToList().Count;
            progress.Chunks = chunks;
            progress.Show();
            int completed = 0;

            List<SplitterTypes.Match> includedMatches = matchesList.Where(i => i.Include == true).ToList();

            foreach (SplitterTypes.Match match in includedMatches)
            {
                progress.SetText("Splitting video " + (completed + 1) + " of " + matchesDataGridView.Rows.Count);
                string startTime = match.TimeStamp.ToString("HH:mm:ss.fff");
                string videoName = match.Description.ToString() + " - " + eventsComboBox.Text + Path.GetExtension(sourceFile);
                string destinationFile = Path.Combine(matchVideoDestinationPathTextBox.Text, videoName);
                string command = "ffmpeg.exe";
                string args = "-ss " + startTime + " -i \"" + sourceFile + "\" -t " + Properties.Settings.Default.matchLength + " -c:v copy -c:a copy \"" + destinationFile + "\"";

                Console.WriteLine(args);

                Process process = new Process();
                process.StartInfo.FileName = command;
                process.StartInfo.Arguments = args;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
                progress.SetCompletedChunks(++completed);

                //save the video path in the match object
                match.VideoPath = destinationFile;
            }
            progress.Close();
        }

        /// <summary>
        /// Handle incorrect entries in the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="anError"></param>
        private void matchesDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            if (anError.Exception.GetType() == typeof(System.FormatException))
            {
                MessageBox.Show("Invalid TimeStamp Format. Check your entry and try again, or press Esc to cancel.\n\nDetails:\n" + anError.Exception.Message, "Invalid TimeStamp Format",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Error happened " + anError.Context.ToString());

                if (anError.Context == DataGridViewDataErrorContexts.Commit)
                {
                    MessageBox.Show("Commit error");
                }
                if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
                {
                    MessageBox.Show("Cell change");
                }
                if (anError.Context == DataGridViewDataErrorContexts.Parsing)
                {
                    MessageBox.Show("parsing error");
                }
                if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
                {
                    MessageBox.Show("leave control error");
                }

                if ((anError.Exception) is ConstraintException)
                {
                    DataGridView view = (DataGridView)sender;
                    view.Rows[anError.RowIndex].ErrorText = "an error";
                    view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                    anError.ThrowException = false;
                }
            }
        }


        private async void uploadToYouTubeButton_Click(object sender, EventArgs e)
        {
            try
            {
                await uploader.SetCredentials();
            }
            catch (Exception)
            {
                MessageBox.Show("Error setting Youtube credentials. If running/building from source, make sure to get and embed a client_secrets.json file for the Google Developers API. Otherwise "
                    + "make sure that you have a working internet connection and that this application is allowed through your firewall.");
                return;
            }
            if (!backgroundWorker1.IsBusy)
            {
                progress = new ProgressDialog();
                progress.Canceled += new EventHandler<EventArgs>(cancelAsyncButton_Click);
                progress.Show();
                backgroundWorker1.RunWorkerAsync();
            }            
        }

        private void vid_ProgressChanged(object sender, long bytes)
        {
            progress.SetChunkProgress(bytes);
        }

        private void vid_UploadFailed(object sender, String error)
        {

        }

        private void vid_UploadCompleted(object sender, string id)
        {
            matchesList[videoUploadIndex].YouTubeId = id;
            uploader.AddToPlaylist(currentPlaylistId, id);
        }

        private void cancelAsyncButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            FRCApi.Event evt = eventsList.Find(i => i.name == Properties.Settings.Default.eventName);
            String playlistName = Properties.Settings.Default.year.ToString() + " " + evt.name;
            int chunks = 0;

            /*Build the description
             * example:
             * Reading High School, Reading, MA, USA
             * 3/6/2015 - 3/8/2015
             * http://www.thebluealliance.com/event/2015marea
             */

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(playlistName);
            sb.AppendLine(String.Join(", ", new String[] { evt.venue, evt.city, evt.stateProv, evt.country }));
            sb.AppendLine(String.Join(" - ", new String[] { evt.dateStart.ToString("MM/dd/yyyy"), evt.dateEnd.ToString("MM/dd/yyyy") }));
            sb.AppendLine("http://www.thebluealliance.com/event/" + Properties.Settings.Default.year.ToString() + evt.code.ToLower());
            sb.AppendLine("Created by FRC Video Splitter (https://github.com/tytremblay/FRC-Video-Splitter-2)");

            String playlistDesc = sb.ToString();

            List<Playlist> playlists = uploader.GetPlaylists();

            int index = playlists.FindIndex(f => f.Snippet.Title == playlistName);

            if (index >= 0)
            {
                DialogResult result = MessageBox.Show("The playlist \"" + playlistName + "\" already exists.  Use the existing playlist?", "Playlist Already Exists", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    currentPlaylistId = uploader.CreatePlaylist(playlistName, playlistDesc, true);
                }
                else
                {
                    currentPlaylistId = playlists[index].Id;
                }
            }
            else
            {
                currentPlaylistId = uploader.CreatePlaylist(playlistName, playlistDesc, true);
            }


            for (videoUploadIndex = 0; videoUploadIndex < matchesList.Count; videoUploadIndex++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else if (matchesList[videoUploadIndex].VideoPath != "")
                {
                    String videoTitle = matchesList[videoUploadIndex].Description + " - " + Properties.Settings.Default.year.ToString() + " " + evt.name;

                    sb = new StringBuilder();
                    sb.AppendLine(videoTitle);
                    sb.AppendLine("Red (" + matchesList[videoUploadIndex].RedAlliance + ") - " + matchesList[videoUploadIndex].RedScore.ToString());
                    sb.AppendLine("Blue (" + matchesList[videoUploadIndex].BlueAlliance + ") - " + matchesList[videoUploadIndex].BlueScore.ToString());
                    sb.AppendLine("Uploaded by FRC Video Splitter (https://github.com/tytremblay/FRC-Video-Splitter-2)");
                    String videoDesc = sb.ToString();

                    progress.Chunks = 

                    uploader.UploadVideo(videoTitle, videoDesc, matchesList[videoUploadIndex].VideoPath);
                    progress.SetCompletedChunks(++chunks);
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progress.Close();
        }      
    }
}
