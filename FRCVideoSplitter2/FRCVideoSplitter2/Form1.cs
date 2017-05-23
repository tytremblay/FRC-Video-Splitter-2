﻿using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FRCVideoSplitter2
{
    public partial class Form1 : Form
    {
        // ################# INITIALIZE ################# \\
        bool initialLoadComplete = false;
        private List<FRCApi.Event> eventsList = new List<FRCApi.Event>();
        BindingList<SplitterTypes.Match> matchesList = new BindingList<SplitterTypes.Match>();
        List<SplitterTypes.SplitVideo> splitVideos = new List<SplitterTypes.SplitVideo>();
        FRCApi api = new FRCApi();
        TBAApi tbaApi = new TBAApi();
        ProgressDialog progress;
        YouTubeApi.VideoUploader uploader = new YouTubeApi.VideoUploader();
        int videoUploadIndex = 0;
        string currentPlaylistId = "";
        DataGridViewSelectedRowCollection selectedMatches;
        static string defaultOptionalFeatureString = "Click Browse to Use...";

        // ################# FORM CONTROL ################# \\
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
            if (Properties.Settings.Default.firstTimeRunning)
            {
                MessageBox.Show("Welcome to FRC Video Splitter 2! In order to use this program, we'll need to download some data from FIRST. Please go to the settings menu and enter your API access info, then click \"Refresh\" next to the event selection box to get the event list.", "Welcome");
                Properties.Settings.Default.firstTimeRunning = false;
                Properties.Settings.Default.Save();
            }

            Properties.Settings.Default.currentFileName = "";
            Properties.Settings.Default.Save();

            updateObjects();

            uploader.Upload_ProgressChanged += new EventHandler<long>(vid_ProgressChanged);
            uploader.UploadCompleted += new EventHandler<string>(vid_UploadCompleted);
            uploader.Upload_Failed += new EventHandler<string>(vid_UploadFailed);

            api.loadRequestTimes();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            api.saveRequestTimes();
        }
        //Close program
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = ".splt";
            openFileDialog1.Filter = "Splitter files (*.splt) | *.splt";
            openFileDialog1.FileName = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    matchesList = HelperDataStructures.ReadObjectFromFile<BindingList<SplitterTypes.Match>>(openFileDialog1.FileName);
                    Properties.Settings.Default.currentFileName = openFileDialog1.FileName;
                    Properties.Settings.Default.Save();
                    this.matchesDataGridView.DataSource = matchesList;
                    this.SetDataGridViewFormatting();
                    MessageBox.Show("Make sure to change the event dropdown to match the file you just loaded! No need to hit Get Match Data since you're opening a file.");
                }
                catch
                {
                    MessageBox.Show("Could not load Splitter file.");
                }
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.currentFileName == "")
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                writeEventFileToDisk();
            }
        }
        private void writeEventFileToDisk()
        {
            string path = null;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.currentFileName))
            {
                path = Properties.Settings.Default.currentFileName;
            }
            else if (!string.IsNullOrEmpty(matchVideoDestinationPathTextBox.Text))
            {
                path = Path.Combine(matchVideoDestinationPathTextBox.Text, Properties.Settings.Default.eventName + ".splt");
            }
            else
            {
                MessageBox.Show("Could not determine where to save. Using Desktop. Set save location by using File menu or setting the Video destination folder.");
                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), eventsComboBox.Text + ".splt");
            }
            HelperDataStructures.WriteObjectToFile<BindingList<SplitterTypes.Match>>(path, matchesList);
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Splitter files (*.splt) | *.splt|All Files (*.*)|*.*";
            saveFileDialog1.FileName = Properties.Settings.Default.year + " " + eventsComboBox.Text + ".splt";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                HelperDataStructures.WriteObjectToFile<BindingList<SplitterTypes.Match>>(saveFileDialog1.FileName, matchesList);
                Properties.Settings.Default.currentFileName = saveFileDialog1.FileName;
                Properties.Settings.Default.Save();
            }
        }
        private void aboutToolstripMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("FRCVideoSplitter2\nCopyright {0}\nThis program is not affiliated with FIRST Robotics", DateTime.Now.Year), "About");
        }
        /// <summary>
        /// Handle context menu item clicks
        /// </summary>
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
        /// Launch the settings form and then update objects after its closed
        /// </summary>
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();

            //after the form is closed, update your objects from the settings file
            api.loadRequestTimes();
            updateObjects();
        }
        /// <summary>
        /// Pulls from settings and updates the objects in this class
        /// </summary>
        private void updateObjects()
        {
            string eventsJsonStr = Properties.Settings.Default.eventsJsonString;
            if (!string.IsNullOrEmpty(eventsJsonStr))
            {
                this.eventsList = JsonConvert.DeserializeObject<FRCApi.EventsList>(eventsJsonStr).Events.OrderBy(o => o.name).ToList();
            }
            this.yearBox.Text = Properties.Settings.Default.year.ToString();
            List<string> eventNames = this.eventsList.Select(x => x.name).ToList();
            this.eventsComboBox.DataSource = eventNames;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.eventName))
            {
                string abc = Properties.Settings.Default.eventName;
                this.eventsComboBox.Text = Properties.Settings.Default.eventName;
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.eventCode))
            {
                this.eventCodeBox.Text = Properties.Settings.Default.eventCode;
            }
            this.matchesDataGridView.AutoResizeColumns();
            this.matchVideoDestinationPathTextBox.Text = Properties.Settings.Default.matchVideoDestination;
            this.sourceVideoPathTextBox.Text = Properties.Settings.Default.sourceVideoLocation;
            this.titleCardPathTextBox.Text = Properties.Settings.Default.titleCardLocation;
            this.watermarkPathTextBox.Text = Properties.Settings.Default.watermarkLocation;
            this.outroPathTextBox.Text = Properties.Settings.Default.outroLocation;
            this.tbaAuthId.Text = Properties.Settings.Default.tbaAuthId;
            this.tbaSecret.Text = Properties.Settings.Default.tbaAuthSecret;
            Properties.Settings.Default.useManualTimeStamps = manualTimestampCheckbox.Checked;
            Properties.Settings.Default.Save();
            initialLoadComplete = true;
        }
        private void CheckAndUpdateEventList(int season)
        {
            try
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.eventsJsonString))
                {
                    //don't have the event list, so delete last request time to make sure we get it all
                    FRCApi.deleteRequestTimes();
                }
                string events = api.getEventsListJsonString(season);
                Properties.Settings.Default.eventsJsonString = events;
                Properties.Settings.Default.Save();
            }
            catch (WebException ex)
            {
                if (((HttpWebResponse)ex.Response).StatusCode != HttpStatusCode.NotModified) //all except this code would be bad
                {
                    MessageBox.Show("Unable to get Event List. Have you added your access key in Settings? Detail:\n\n" + ex.ToString());
                }
            }

            updateObjects();
        }
        private bool HasEventSelected()
        {
            if (string.IsNullOrEmpty(this.eventCodeBox.Text))
            {
                MessageBox.Show("A Select Event is Required to Use This", "Error");
                return false;
            }
            return true;
        }

        // ################# CHOOSE YOUR EVENT ################# \\
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
        /// <summary>
        /// Go look for new events to use, based on API
        /// </summary>
        private void updateEventList_Click(object sender, EventArgs e)
        {
            CheckAndUpdateEventList(Properties.Settings.Default.year);
        }
        /// <summary>
        /// When the user selects the event name, update the event code
        /// </summary>
        private void eventsComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            eventCodeBox.Text = eventsList.Find(i => i.name == eventsComboBox.Text).code;
            if (initialLoadComplete)
            {
                Properties.Settings.Default.eventName = eventsComboBox.Text;
                Properties.Settings.Default.eventCode = eventCodeBox.Text;
                Properties.Settings.Default.Save();
            }
        }
        private void eventsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void eventCodeBox_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Get the match data for the specified year and event and display it.
        /// </summary>
        private void getMatchDataButton_Click(object sender, EventArgs e)
        {
            if (!HasEventSelected())
            {
                return;
            }

            this.matchesDataGridView.DataSource = null;
            matchesList.Clear();

            int year = Properties.Settings.Default.year;

            List<FRCApi.MatchResult> rawMatches = new List<FRCApi.MatchResult>();

            rawMatches = api.getMatchResults<FRCApi.MatchResult>(Properties.Settings.Default.year, Properties.Settings.Default.eventCode);

            foreach (FRCApi.MatchResult frcMatch in rawMatches)
            {
                matchesList.Add(new SplitterTypes.Match(frcMatch));

                /*
                if (frcMatch.tournamentLevel != "Qualification")
                {
                    Console.WriteLine(frcMatch.tournamentLevel);
                }
                */
            }

            this.matchesDataGridView.DataSource = matchesList;
            this.SetDataGridViewFormatting();
        }

        // ################# INPUT OPTIONS ################# \\
        /// <summary>
        /// Find the source video
        /// </summary>
        private void sourceVideoBrowseButton_Click(object sender, EventArgs e)
        {
            if (!HasEventSelected())
            {
                return;
            }

            openFileDialog1.FileName = null;
            openFileDialog1.Filter = "Video Files|*.avi;*.mp4;*.flv;*.mpeg;*.mov;*.mpg;*.mpeg4;";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                sourceVideoPathTextBox.Text = openFileDialog1.FileName;
                Properties.Settings.Default.sourceVideoLocation = sourceVideoPathTextBox.Text;
                Properties.Settings.Default.Save();
            }
        }
        private void importVideosButton_Click(object sender, EventArgs e)
        {
            if (!HasEventSelected())
            {
                return;
            }
            try
            {
                openFileDialog1.FileName = null;
                openFileDialog1.Multiselect = true;
                openFileDialog1.Filter = null;
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    List<FileInfo> selectedFiles = new List<FileInfo>();

                    foreach (String file in openFileDialog1.FileNames)
                    {
                        selectedFiles.Add(new FileInfo(file));
                    }
                    List<FileInfo> remainingFiles = selectedFiles.ToList();//operate on the copy
                    foreach (SplitterTypes.Match match in matchesList.Where(x => x.Include == true))
                    {
                        foreach (FileInfo file in selectedFiles)
                        {
                            if (file.Name.StartsWith(match.FIRSTDescription + " "))//match desc and the space (to prevent matching QM1 to QM19, etc)
                            {
                                match.VideoPath = file.FullName;
                                remainingFiles.Remove(file);
                            }
                        }
                    }
                    writeEventFileToDisk();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to complete the Import. Details:\n\n" + ex.ToString());
            }
        }
        private void titleCardBrowseButton_Click(object sender, EventArgs e)
        {
            if (!HasEventSelected())
            {
                return;
            }

            openFileDialog1.FileName = null;
            openFileDialog1.Filter = "Image Files| *.jpg;*.jpeg;*.jpe;*.png";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                titleCardPathTextBox.Text = openFileDialog1.FileName;
                Properties.Settings.Default.titleCardLocation = titleCardPathTextBox.Text;
                Properties.Settings.Default.Save();
            }
        }
        private void titleCardClearButton_Click(object sender, EventArgs e)
        {
            titleCardPathTextBox.Text = defaultOptionalFeatureString;
            Properties.Settings.Default.titleCardLocation = titleCardPathTextBox.Text;
            Properties.Settings.Default.Save();
        }
        private void watermarkBrowseButton_Click(object sender, EventArgs e)
        {
            if (!HasEventSelected())
            {
                return;
            }

            openFileDialog1.FileName = null;
            openFileDialog1.Filter = "PNG Images|*.png";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                watermarkPathTextBox.Text = openFileDialog1.FileName;
                Properties.Settings.Default.watermarkLocation = watermarkPathTextBox.Text;
                Properties.Settings.Default.Save();
            }
        }
        private void watermarkClearButton_Click(object sender, EventArgs e)
        {
            watermarkPathTextBox.Text = defaultOptionalFeatureString;
            Properties.Settings.Default.watermarkLocation = watermarkPathTextBox.Text;
            Properties.Settings.Default.Save();
        }
        private void outroBrowseButton_Click(object sender, EventArgs e)
        {
            if (!HasEventSelected())
            {
                return;
            }

            openFileDialog1.FileName = null;
            openFileDialog1.Filter = "Video Files|*.avi;*.mp4;*.flv;*.mpeg;*.mov;*.mpg;*.mpeg4;";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                outroPathTextBox.Text = openFileDialog1.FileName;
                Properties.Settings.Default.outroLocation = outroPathTextBox.Text;
                Properties.Settings.Default.Save();
            }
        }
        private void outroClearButton_Click(object sender, EventArgs e)
        {
            outroPathTextBox.Text = defaultOptionalFeatureString;
            Properties.Settings.Default.outroLocation = outroPathTextBox.Text;
            Properties.Settings.Default.Save();
        }

        // ################# PREPARE INPUT FILE ################# \\
        /// <summary>
        /// Handle the manual time stamps checkbox
        /// </summary>
        private void manualTimestampCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.useManualTimeStamps = manualTimestampCheckbox.Checked;
            Properties.Settings.Default.Save();

            try
            {
                SetDataGridViewFormatting();
            }
            catch (NullReferenceException)
            {
                HasEventSelected();//pop the message
                return;
            }
        }

        /// <summary>
        /// Iterate through the list of matches and calculate the timestamps in the video based off 
        /// the first included match.
        /// </summary>
        private void getTimestampButton_Click(object sender, EventArgs e)
        {
            if (!HasEventSelected())
            {
                return;
            }

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
                    previousMatchTime = matchesList[i - 1].ActualStartTime;
                    currentMatchTime = matchesList[i].ActualStartTime;
                    previousMatchStamp = matchesList[i - 1].TimeStamp;

                    matchesList[i].TimeStamp = previousMatchStamp + (currentMatchTime - previousMatchTime);
                }
            }
        }

        // ################# OUTPUT CONTROL ################# \\
        /// <summary>
        /// Where to save the split videos
        /// </summary>
        private void matchVideoBrowseButton_Click(object sender, EventArgs e)
        {
            if (!HasEventSelected())
            {
                return;
            }

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                matchVideoDestinationPathTextBox.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.matchVideoDestination = matchVideoDestinationPathTextBox.Text;
                Properties.Settings.Default.Save();

                // Might as well go through that directory and see if someone has already split some of the matches out.
                DirectoryInfo di = new DirectoryInfo(Properties.Settings.Default.matchVideoDestination);
                FileInfo[] fiArr = di.GetFiles();

                string[] stringSeparators = new string[] { " - " };

                foreach (FileInfo f in fiArr)
                {
                    string[] splitArr = f.Name.Split(stringSeparators, StringSplitOptions.None);
                    if (splitArr.Count() > 1)
                    {
                        if (splitArr[1].StartsWith(Properties.Settings.Default.eventName))
                        {
                            matchesList.First(m => m.FIRSTDescription == splitArr[0]).VideoPath = f.FullName;
                        }
                    }
                }
            }
        }
        private void notifyTbaClear_Click(object sender, EventArgs e)
        {
            tbaAuthId.Text = "Auth ID";
            tbaSecret.Text = "Secret";
        }
        private void tbaAuthId_Changed(object sender, EventArgs e)
        {
            Properties.Settings.Default.tbaAuthId = tbaAuthId.Text;
            Properties.Settings.Default.Save();
        }
        private void tbaAuthSecret_Changed(object sender, EventArgs e)
        {
            Properties.Settings.Default.tbaAuthSecret = tbaSecret.Text;
            Properties.Settings.Default.Save();
        }

        // ################# ACTION BUTTONS ################# \\
        /// <summary>
        /// Split out the match videos based on the timestamps in the datagridview
        /// </summary>
        private void splitVideosButton_Click(object sender, EventArgs e)
        {
            if (!HasEventSelected() || !File.Exists(sourceVideoPathTextBox.Text))//put pre-reqs here
            {
                MessageBox.Show("Please complete missing steps above before splitting.", "Unavailable");
                return;
            }
            if (File.Exists("intermediate4.ts")) //delete outro if exists
            {
                File.Delete("intermediate4.ts");
            }

            string renderedTitleCard = null;
            string renderedOutro = null;
            string sourceVideoLocation = null;
            string postResultVideoLocation = null;

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
                renderedTitleCard = null;//reset
                sourceVideoLocation = null;
                postResultVideoLocation = null;

                progress.SetText("Splitting video " + (completed + 1) + " of " + matchesList.Where(i => i.Include == true).ToList().Count);
                string startTime = match.TimeStamp.ToString("HH:mm:ss.fff");
                string videoName = match.FIRSTDescription.ToString() + " - " + yearBox.Text + " " + eventsComboBox.Text + Path.GetExtension(sourceFile);
                string destinationFile = Path.Combine(matchVideoDestinationPathTextBox.Text, videoName);
                string matchLengthString = null;
                string watermarkFileLocation = null;
                bool doSplitMatchVideos = false;

                TimeSpan padTime = TimeSpan.Parse(Properties.Settings.Default.endOfVideoPadTime);
                TimeSpan matchLength = (((DateTime)match.PostResultTime - match.ActualStartTime).Add(padTime)); //pad time covers the post-result, normal case

                if (Properties.Settings.Default.useScoreDisplayedTime && match.PostResultTime.HasValue)
                {
                    TimeSpan timeBeforePost = match.PostResultTime.Value - match.ActualStartTime;
                    if (timeBeforePost > new TimeSpan(0, 2, 45)) //if it's more than 15 second to post (2m30s for match plus a little more), cut that extra out.
                    {
                        doSplitMatchVideos = true;
                    }
                    if (doSplitMatchVideos)
                    {
                        matchLength = new TimeSpan(0, 2, 40);//tiny bit longer than normal match
                    }
                    matchLengthString = matchLength.ToString(@"hh\:mm\:ss");
                }
                if (File.Exists(Properties.Settings.Default.watermarkLocation))
                {
                    watermarkFileLocation = Properties.Settings.Default.watermarkLocation;
                }

                string args = BuildFfmpegControlScript(startTime, sourceFile, destinationFile, matchLengthString, watermarkFileLocation);
                sourceVideoLocation = destinationFile;
                RunFfmpegCommand(args); //run original split video

                if (doSplitMatchVideos) //post-result separate from match video
                {
                    TimeSpan postResultShowTime = new TimeSpan(0, 0, 15);
                    string postResultFileName = "postresultportion.mp4";

                    TimeSpan timeBetweenStartAndPost = (((DateTime)match.PostResultTime - match.ActualStartTime));
                    DateTime postResultStart = match.TimeStamp + timeBetweenStartAndPost + new TimeSpan(0, 0, 3);

                    string argsPostResult = BuildFfmpegControlScript(postResultStart.ToString(@"HH\:mm\:ss"), sourceFile, postResultFileName, postResultShowTime.ToString(@"hh\:mm\:ss"), watermarkFileLocation);
                    RunFfmpegCommand(argsPostResult); //run post-result
                    postResultVideoLocation = postResultFileName;
                }

                if (File.Exists(Properties.Settings.Default.titleCardLocation))
                {
                    //Add title card
                    string argTitle = "-y -loop 1 -framerate 30 -t 3 -i \"" + Properties.Settings.Default.titleCardLocation + "\""; //assumes 30 fps videos
                    argTitle += " -vf \"[in]drawtext=fontfile=FreeSerif.ttf:text='" + eventsComboBox.Text + "':x=(w-text_w)/2:y=(h-(2.5*text_h)):fontcolor=white:fontsize=40:box=1:boxcolor=black@0.65,";
                    argTitle += " drawtext=fontfile=FreeSerif.ttf:text='" + match.FIRSTDescription + "':x=(w-text_w)/2:y=(h-(1.25*text_h)):fontcolor=white:fontsize=40:box=1:boxcolor=black@0.65[out]\"";
                    argTitle += " \"renderedintroFRCSPLIT.mp4\"";
                    RunFfmpegCommand(argTitle);
                    renderedTitleCard = "renderedintroFRCSPLIT.mp4";
                }
                if (File.Exists(Properties.Settings.Default.outroLocation) && renderedOutro == null)
                {
                    renderedOutro = Properties.Settings.Default.outroLocation;//no additional processing is done to the outro file. But that could be done here if needed.
                }

                //Now render the final version based on title card, count of match videos portion (1 or 2), outro settings

                //If a title card, post result or outro exist, we need to re-render the output
                if (renderedTitleCard != null || postResultVideoLocation != null || renderedOutro != null)
                {
                    List<string> toRender = new List<string>();
                    if (renderedTitleCard != null)
                    {
                        string argsTitle = "-y -i \"renderedintroFRCSPLIT.mp4\" -c copy -bsf:v h264_mp4toannexb -f mpegts intermediate1.ts";
                        RunFfmpegCommand(argsTitle);
                        toRender.Add("intermediate1.ts");
                    }

                    string argsSource = "-y -i \"" + sourceVideoLocation + "\" -c copy -bsf:v h264_mp4toannexb -f mpegts intermediate2.ts";
                    RunFfmpegCommand(argsSource);
                    toRender.Add("intermediate2.ts");

                    if (postResultVideoLocation != null)
                    {
                        string argsPostResult = "-y -i \"postresultportion.mp4\" -c copy -bsf:v h264_mp4toannexb -f mpegts intermediate3.ts";
                        RunFfmpegCommand(argsPostResult);
                        toRender.Add("intermediate3.ts");
                    }
                    if (renderedOutro != null)
                    {
                        string argsOutro = "-y -i \"" + renderedOutro + "\" -c copy -bsf:v h264_mp4toannexb -f mpegts intermediate4.ts";
                        RunFfmpegCommand(argsOutro);
                        toRender.Add("intermediate4.ts");
                    }

                    //Now merge them all
                    string videoPipe = null;
                    foreach (string rend in toRender)
                    {
                        if (videoPipe != null) //only add bar between, not before first video
                        {
                            videoPipe += "|";
                        }
                        videoPipe += rend;
                    }

                    string args4 = "-y -i \"concat:" + videoPipe + "\" -c copy -bsf:a aac_adtstoasc \"" + destinationFile + "\"";
                    RunFfmpegCommand(args4); //override original split with concat split
                }

                progress.SetCompletedChunks(++completed);

                //save the video path in the match object
                match.VideoPath = destinationFile;
                splitVideos.Add(new SplitterTypes.SplitVideo(eventCodeBox.Text, match.FIRSTDescription.ToString(), destinationFile));

                if (File.Exists("intermediate1.ts")) //cleanup
                {
                    File.Delete("intermediate1.ts");
                }
                if (File.Exists("intermediate2.ts"))
                {
                    File.Delete("intermediate2.ts");
                }
                if (File.Exists("intermediate3.ts"))
                {
                    File.Delete("intermediate3.ts");
                }
                if (File.Exists("postresultportion.mp4"))
                {
                    File.Delete("postresultportion.mp4");
                }
                //No need to delete outro/intermediate4, it can be rendered once and re-used
            }

            string importFilePath = Path.Combine(matchVideoDestinationPathTextBox.Text, eventsComboBox.Text + ".splt");

            HelperDataStructures.WriteObjectToFile<BindingList<SplitterTypes.Match>>(importFilePath, matchesList);
            progress.Close();
        }
        private string BuildFfmpegControlScript(string StartTime, string SourceFile, string DestinationFile, string MatchLength = null, string WatermarkSourceFile = null)
        {
            if (MatchLength == null)
            {
                MatchLength = Properties.Settings.Default.matchLength;
            }

            string controlScript = "-y ";

            controlScript += "-ss " + StartTime + " -i \"" + SourceFile + "\"";

            if (WatermarkSourceFile != null)
            {
                controlScript += " -i \"" + WatermarkSourceFile + "\" -filter_complex \'overlay\'";
            }

            controlScript += " -t " + MatchLength;

            controlScript += " -threads 3";//this will limit the CPU usage

            if (WatermarkSourceFile == null) //can't use this copy option if we're going watermark
            {
                controlScript += " -c:v copy -c:a copy ";//this will skip re-encoding (faster), but can't use with filter
            }

            controlScript += " \"" + DestinationFile + "\"";

            return controlScript;
        }
        private void RunFfmpegCommand(string command)
        {
            Console.WriteLine(command);
            Process process = new Process();
            process.StartInfo.FileName = "ffmpeg.exe";
            process.StartInfo.Arguments = command;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
        }

        /// <summary>
        /// Fire up the backgroundworker
        /// </summary>
        private async void uploadToYouTubeButton_Click(object sender, EventArgs e)
        {
            try
            {
                await uploader.SetCredentials();
            }
            catch (Exception ex)
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
        /// <summary>
        /// Write all matches with a YouTube ID in this session to a file in the mathes destination folder.
        /// </summary>
        private void tbaSpreadsheetButton_Click(object sender, EventArgs e)
        {
            if (!HasEventSelected())
            {
                return;
            }

            FRCApi.Event evt = eventsList.Find(i => i.name == Properties.Settings.Default.eventName);
            String fileName = "TBA - " + Properties.Settings.Default.year.ToString() + " " + evt.name + ".csv";

            String filePath = Path.Combine(Properties.Settings.Default.matchVideoDestination, fileName);

            StringBuilder sb = new StringBuilder();

            foreach (SplitterTypes.Match match in matchesList)
            {
                if (match.YouTubeId != "")
                {
                    sb.AppendFormat("{0},", Properties.Settings.Default.year.ToString());
                    sb.AppendFormat("{0},", evt.code.ToLower());
                    if (match.TbaDescription.StartsWith("QF"))
                    {
                        sb.AppendFormat("{0},", "qf");
                        sb.AppendFormat("{0},", match.TbaDescription.Substring(2));
                    }
                    else if (match.TbaDescription.StartsWith("SF"))
                    {
                        sb.AppendFormat("{0},", "sf");
                        sb.AppendFormat("{0},", match.TbaDescription.Substring(2));
                    }
                    else if (match.TbaDescription.StartsWith("F"))
                    {
                        sb.AppendFormat("{0},", "f");
                        sb.AppendFormat("{0},", match.TbaDescription.Substring(1));
                    }
                    else
                    {
                        sb.AppendFormat("{0},", "q");
                        sb.AppendFormat("{0},", match.TbaDescription.Substring(1));
                    }
                    sb.AppendFormat("{0}{1}{2}", "http://www.youtube.com/watch?v=", match.YouTubeId, Environment.NewLine);
                }
            }

            File.WriteAllText(filePath, sb.ToString());
            MessageBox.Show("TBA .csv file written to:\n" + filePath, "SUCCESS", MessageBoxButtons.OK);
        }
        private async void notifyTba_Clicked(object sender, EventArgs e)
        {
            progress = new ProgressDialog();
            progress.SetText("Please Wait...");
            progress.Show();
            bool failures = false;
            foreach(SplitterTypes.Match m in matchesList.Where(x => x.Include == true && x.ReportedToTBA == false)) //for each one we've uploaded, but not told TBA about
            {
                bool tbaResult = await tbaApi.writeTbaMatchVideo(tbaAuthId.Text, tbaSecret.Text, eventCodeBox.Text, m.TbaDescription, m.YouTubeId);
                if (tbaResult)
                {
                    m.ReportedToTBA = true;
                }
                else
                {
                    failures = true;
                }
            }
            progress.Close();
            if (failures)
            {
                MessageBox.Show("One or more notifications failed. Please see markers in grid for which videos succeeded.");
            }
            else
            {
                writeEventFileToDisk();
            }
        }
        private void saveScoreDetailsButton_Click(object sender, EventArgs e)
        {

            List<SplitterTypes.Match> includedMatches = matchesList.Where(i => i.Include == true).ToList();

            int year = Properties.Settings.Default.year;

            string filePath;

            if (year == 2016)
            {
                filePath = save2016ScoreDetails(includedMatches);

            }
            else
            {
                filePath = save2015ScoreDetails(includedMatches);
            }


            MessageBox.Show("Score details .csv file written to:\n" + filePath, "SUCCESS", MessageBoxButtons.OK);
        }
        private void getAllTheDataButton_Click(object sender, EventArgs e)
        {
            int year = Properties.Settings.Default.year;
            string filePath;
            if (year == 2016)
            {
                filePath = getAll2016Data();
            }
            else
            {
                filePath = getAll2015Data();
            }

            MessageBox.Show("Score details .csv file written to:\n" + filePath, "SUCCESS", MessageBoxButtons.OK);
        }

        private string save2016ScoreDetails(List<SplitterTypes.Match> includedMatches)
        {
            List<FRCApi.ScoreDetails2016> scores = api.getScoreDetails<FRCApi.ScoreDetails2016>(Properties.Settings.Default.year, Properties.Settings.Default.eventCode.ToLower(), "qual");

            scores.AddRange(api.getScoreDetails<FRCApi.ScoreDetails2016>(Properties.Settings.Default.year, Properties.Settings.Default.eventCode.ToLower(), "playoff"));

            FRCApi.Event evt = eventsList.Find(i => i.name == Properties.Settings.Default.eventName);
            String fileName = "Score Details - " + Properties.Settings.Default.year.ToString() + " " + evt.name + ".csv";

            String filePath = Path.Combine(Properties.Settings.Default.matchVideoDestination, fileName);

            StringBuilder sb = new StringBuilder();

            foreach (PropertyInfo p in scores[0].GetType().GetProperties())
            {
                if (p.Name != "alliances")
                {
                    sb.AppendFormat("{0},", p.Name);
                }
                else
                {
                    foreach (FRCApi.AllianceScoreDetails2016 alliance in scores[0].alliances)
                    {
                        foreach (PropertyInfo pi in alliance.GetType().GetProperties())
                        {
                            sb.AppendFormat("{0},", pi.Name);
                        }
                    }
                }
            }

            sb.AppendLine();

            foreach (SplitterTypes.Match match in includedMatches)
            {
                FRCApi.ScoreDetails2016 matchedScore = scores.Find(i => i.matchLevel == match.Level && i.matchNumber == match.MatchNumber);

                sb.AppendFormat("{0}{1}", matchedScore.ToString(), Environment.NewLine);
            }

            File.WriteAllText(filePath, sb.ToString());

            return filePath;
        }
        private string save2015ScoreDetails(List<SplitterTypes.Match> includedMatches)
        {
            List<FRCApi.ScoreDetails2015> scores = api.getScoreDetails<FRCApi.ScoreDetails2015>(Properties.Settings.Default.year, Properties.Settings.Default.eventCode.ToLower(), "qual");

            scores.AddRange(api.getScoreDetails<FRCApi.ScoreDetails2015>(Properties.Settings.Default.year, Properties.Settings.Default.eventCode.ToLower(), "playoff"));

            FRCApi.Event evt = eventsList.Find(i => i.name == Properties.Settings.Default.eventName);
            String fileName = "Score Details - " + Properties.Settings.Default.year.ToString() + " " + evt.name + ".csv";

            String filePath = Path.Combine(Properties.Settings.Default.matchVideoDestination, fileName);

            StringBuilder sb = new StringBuilder();

            foreach (PropertyInfo p in scores[0].GetType().GetProperties())
            {
                if (p.Name != "alliances")
                {
                    sb.AppendFormat("{0},", p.Name);
                }
                else
                {
                    foreach (FRCApi.AllianceScoreDetails2015 alliance in scores[0].alliances)
                    {
                        foreach (PropertyInfo pi in alliance.GetType().GetProperties())
                        {
                            sb.AppendFormat("{0},", pi.Name);
                        }
                    }
                }
            }

            sb.AppendLine();

            foreach (SplitterTypes.Match match in includedMatches)
            {
                FRCApi.ScoreDetails2015 matchedScore = scores.Find(i => i.matchLevel == match.Level && i.matchNumber == match.MatchNumber);

                sb.AppendFormat("{0}{1}", matchedScore.ToString(), Environment.NewLine);
            }

            File.WriteAllText(filePath, sb.ToString());

            return filePath;
        }
        private string getAll2016Data()
        {
            String fileName = "Score Details - All Events.csv";
            Dictionary<string, double> captureCounts = new Dictionary<string, double>();
            Dictionary<string, double> matchCounts = new Dictionary<string, double>();
            Dictionary<string, double> capturePercentages = new Dictionary<string, double>();
            Dictionary<string, double> rankingPointsPerMatch = new Dictionary<string, double>();

            String filePath = Path.Combine(Properties.Settings.Default.matchVideoDestination, fileName);

            StringBuilder sb = new StringBuilder();

            FRCApi.AllianceScoreDetails2016 sampleSD = new FRCApi.AllianceScoreDetails2016();

            sb.AppendFormat("{0},{1},{2}", "eventCode", "startDate", "startTime");

            bool firstLoop = true;

            foreach (FRCApi.Event evt in eventsList)
            {
                Console.WriteLine("Getting score detials for: " + evt.code);
                List<FRCApi.ScoreDetails2016> scores = api.getScoreDetails<FRCApi.ScoreDetails2016>(Properties.Settings.Default.year, evt.code.ToLower(), "qual");
                List<FRCApi.MatchResult> results = api.getMatchResults<FRCApi.MatchResult>(Properties.Settings.Default.year, evt.code.ToLower());
                List<FRCApi.TeamRanking2016> rankings = api.get2016EventRankings(Properties.Settings.Default.year, evt.code.ToLower(), false);
                if (rankings != null)
                {
                    foreach (FRCApi.TeamRanking2016 tr in rankings)
                    {
                        if (tr.matchesPlayed >= 8)
                        {
                            rankingPointsPerMatch.Add(tr.teamNumber.ToString() + "@" + evt.code.ToLower(), (double)tr.sortOrder1 / (double)tr.matchesPlayed);
                        }
                    }
                }

                if (scores != null && scores.Count > 0)
                {
                    scores.AddRange(api.getScoreDetails<FRCApi.ScoreDetails2016>(Properties.Settings.Default.year, evt.code.ToLower(), "playoff"));


                    if (firstLoop)
                    {
                        foreach (PropertyInfo p in scores[0].GetType().GetProperties())
                        {
                            if (p.Name != "alliances")
                            {
                                sb.AppendFormat("{0},", p.Name);
                            }
                            else
                            {
                                foreach (FRCApi.AllianceScoreDetails2016 alliance in scores[0].alliances)
                                {
                                    foreach (PropertyInfo pi in alliance.GetType().GetProperties())
                                    {
                                        sb.AppendFormat("{0},", pi.Name);
                                    }
                                }
                            }
                        }
                        foreach (PropertyInfo p in results[0].GetType().GetProperties())
                        {
                            if (p.Name != "teams")
                            {
                                sb.AppendFormat("{0},", p.Name);
                            }
                            else
                            {
                                foreach (FRCApi.MatchResultsTeam team in results[0].teams)
                                {
                                    foreach (PropertyInfo pi in team.GetType().GetProperties())
                                    {
                                        sb.AppendFormat("{0},", pi.Name);
                                    }
                                }
                            }
                        }
                        sb.AppendLine();
                        firstLoop = false;
                    }



                    foreach (FRCApi.ScoreDetails2016 score in scores)
                    {
                        FRCApi.MatchResult mr = results.Find(i => i.matchNumber == score.matchNumber && i.tournamentLevel == score.matchLevel);
                        if (mr != null)
                        {
                            sb.AppendFormat("{0},{1},{2}{3}{4}", evt.code.ToLower(), evt.dateStart.ToShortDateString(), score.ToString(), mr.ToString(), Environment.NewLine);
                            foreach (FRCApi.AllianceScoreDetails2016 asd in score.alliances)
                            {
                                foreach (FRCApi.MatchResultsTeam t in mr.teams.FindAll(i => i.station.Contains(asd.alliance)))
                                {
                                    string key = evt.code + t.teamNumber.ToString();
                                    if (asd.teleopTowerCaptured)
                                    {
                                        if (captureCounts.ContainsKey(key))
                                        {
                                            captureCounts[key] += 1;
                                        }
                                        else
                                        {
                                            captureCounts.Add(key, 1);
                                        }
                                    }
                                    if (matchCounts.ContainsKey(key))
                                    {
                                        matchCounts[key] += 1;
                                    }
                                    else
                                    {
                                        matchCounts.Add(key, 1);
                                    }
                                }

                            }

                        }
                    }





                }
            }

            foreach (KeyValuePair<string, double> entry in captureCounts)
            {
                capturePercentages.Add(entry.Key, captureCounts[entry.Key] / matchCounts[entry.Key]);


            }

            var rankItems = from pair in rankingPointsPerMatch
                            orderby pair.Value descending
                            select pair;

            // Reverse sort.
            // ... Can be looped over in the same way as above.
            var items = from pair in capturePercentages
                        orderby pair.Value descending
                        select pair;


            StringBuilder sb2 = new StringBuilder();


            StringBuilder sb3 = new StringBuilder();

            foreach (KeyValuePair<string, double> entry in rankItems)
            {
                sb3.AppendFormat("{0},{1}{2}", entry.Key, entry.Value, Environment.NewLine);
            }

            File.WriteAllText(Path.Combine(Properties.Settings.Default.matchVideoDestination, "rankingPointsPerMatch.csv"), sb3.ToString());

            File.WriteAllText(filePath, sb.ToString());


            foreach (KeyValuePair<string, double> entry in items)
            {
                sb2.AppendFormat("{0},{1},{2},{3}{4}", entry.Key, captureCounts[entry.Key], matchCounts[entry.Key], entry.Value, Environment.NewLine);
            }
            File.WriteAllText(Path.Combine(Properties.Settings.Default.matchVideoDestination, "capturePercentages.csv"), sb2.ToString());

            File.WriteAllText(filePath, sb.ToString());

            return filePath;


        }
        private string getAll2015Data()
        {
            String fileName = "Score Details - All Events.csv";

            String filePath = Path.Combine(Properties.Settings.Default.matchVideoDestination, fileName);

            StringBuilder sb = new StringBuilder();

            FRCApi.AllianceScoreDetails2015 sampleSD = new FRCApi.AllianceScoreDetails2015();

            sb.AppendFormat("{0},{1},{2}", "eventCode", "startDate", "startTime");

            bool firstLoop = true;

            foreach (FRCApi.Event evt in eventsList)
            {
                Console.WriteLine("Getting score detials for: " + evt.code);
                List<FRCApi.ScoreDetails2015> scores = api.getScoreDetails<FRCApi.ScoreDetails2015>(Properties.Settings.Default.year, evt.code.ToLower(), "qual");
                List<FRCApi.MatchResult> results = api.getMatchResults<FRCApi.MatchResult>(Properties.Settings.Default.year, evt.code.ToLower());

                if (scores != null)
                {
                    scores.AddRange(api.getScoreDetails<FRCApi.ScoreDetails2015>(Properties.Settings.Default.year, evt.code.ToLower(), "playoff"));

                    if (firstLoop)
                    {
                        foreach (PropertyInfo p in scores[0].GetType().GetProperties())
                        {
                            if (p.Name != "alliances")
                            {
                                sb.AppendFormat("{0},", p.Name);
                            }
                            else
                            {
                                foreach (FRCApi.AllianceScoreDetails2015 alliance in scores[0].alliances)
                                {
                                    foreach (PropertyInfo pi in alliance.GetType().GetProperties())
                                    {
                                        sb.AppendFormat("{0},", pi.Name);
                                    }
                                }
                            }
                        }
                        foreach (PropertyInfo p in results[0].GetType().GetProperties())
                        {
                            if (p.Name != "teams")
                            {
                                sb.AppendFormat("{0},", p.Name);
                            }
                            else
                            {
                                foreach (FRCApi.MatchResultsTeam team in results[0].teams)
                                {
                                    foreach (PropertyInfo pi in team.GetType().GetProperties())
                                    {
                                        sb.AppendFormat("{0},", pi.Name);
                                    }
                                }
                            }
                        }
                        sb.AppendLine();
                        firstLoop = false;
                    }



                    foreach (FRCApi.ScoreDetails2015 score in scores)
                    {
                        FRCApi.MatchResult mr = results.Find(i => i.matchNumber == score.matchNumber && i.tournamentLevel == score.matchLevel);
                        sb.AppendFormat("{0},{1},{2}{3}{4}", evt.code.ToLower(), evt.dateStart.ToShortDateString(), score.ToString(), mr.ToString(), Environment.NewLine);
                    }

                }
            }

            File.WriteAllText(filePath, sb.ToString());

            return filePath;
        }

        // ################# VIDEO UPLOADS ################# \\
        /// <summary>
        /// Update the progress window when youtube reports with upload info
        /// </summary>
        private void vid_ProgressChanged(object sender, long bytes)
        {
            Console.WriteLine("Bytes Sent: " + Convert.ToInt32(bytes));
            progress.SetCompletedChunks(Convert.ToInt32(bytes));
        }
        /// <summary>
        /// not implemented yet...
        /// </summary>
        private void vid_UploadFailed(object sender, String error)
        {
        }
        /// <summary>
        /// When a video is done, associate its ID to the given playlist
        /// </summary>
        private async void vid_UploadCompleted(object sender, string id)
        {
            matchesList[videoUploadIndex].YouTubeId = id;
            uploader.AddToPlaylist(currentPlaylistId, id);
            //splitVideos.First(i => i.match == matchesList[videoUploadIndex].FIRSTDescription).youTube = id;            
            if (tbaAuthId.Text != "Auth ID") //try to tell blue alliance about the video
            {
                bool tbaResult = await tbaApi.writeTbaMatchVideo(tbaAuthId.Text, tbaSecret.Text, eventCodeBox.Text, matchesList[videoUploadIndex].TbaDescription, id);
                if (tbaResult)
                {
                    matchesList[videoUploadIndex].ReportedToTBA = true;
                }
            }
            writeEventFileToDisk();
        }
        /// <summary>
        /// Cancel the upload process.
        /// 
        /// TODO:  Make sure this cancels the actual upload that's fired, instead of killing
        /// bgw and letting the upload complete.
        /// </summary>
        private void cancelAsyncButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Cancel Button Clicked");
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                Console.WriteLine("Worker supports cancellation.");
                backgroundWorker1.CancelAsync();
            }
        }
        /// <summary>
        /// Upload the included videos to Youtube in the background and keep track of it in the progress bar.
        /// </summary>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            FRCApi.Event evt = eventsList.Find(i => i.name == Properties.Settings.Default.eventName);
            String playlistName = String.Format("{0}{1}{2}", Properties.Settings.Default.year.ToString(), " ", evt.name);

            /*Build the description
             * example:
             * Event Description
             * Reading High School, Reading, MA, USA
             * 3/6/2015 - 3/8/2015
             * http://www.thebluealliance.com/event/2015marea / https://frc-events.firstinspires.org/2017/MAREA
             * Videos Prepared by FRC Video Splitter (https://github.com/tytremblay/FRC-Video-Splitter-2)"
             */

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("FIRST Robotics Competition");
            sb.AppendLine(playlistName); //event name
            sb.AppendLine(String.Join(", ", new String[] { evt.venue, evt.city, evt.stateProv, evt.country })); //location
            sb.AppendLine(String.Join(" - ", new String[] { evt.dateStart.ToString("MM/dd/yyyy"), evt.dateEnd.ToString("MM/dd/yyyy") }));
            //sb.AppendLine("http://www.thebluealliance.com/event/" + Properties.Settings.Default.year.ToString() + evt.code.ToLower());//TBA Link
            sb.AppendLine("Event Results: https://frc-events.firstinspires.org/" + Properties.Settings.Default.year.ToString() + "/" + evt.code.ToUpper());//FIRST Link
            sb.AppendLine();
            sb.AppendLine("Videos Prepared by FRC Video Splitter");

            String playlistDesc = sb.ToString();

            //Get a list of playlists for the associated YT account
            List<Playlist> playlists = uploader.GetPlaylists();

            //See if the account already has a playlist by this name
            int index = playlists.FindIndex(f => f.Snippet.Title == playlistName);

            //If so, ask them if they want to use that playlist
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
                //If they don't want to use the playlist we found, create a new one.
                currentPlaylistId = uploader.CreatePlaylist(playlistName, playlistDesc, true);
            }

            List<PlaylistItem> itemsInPlaylist = uploader.GetItemsInPlaylist(currentPlaylistId);

            for (videoUploadIndex = 0; videoUploadIndex < matchesList.Count; videoUploadIndex++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else if (!string.IsNullOrEmpty(matchesList[videoUploadIndex].VideoPath) && matchesList[videoUploadIndex].Include == true)//only try if it's "included" and has a video path
                {
                    String videoTitle = matchesList[videoUploadIndex].FIRSTDescription + " - " + Properties.Settings.Default.year.ToString() + " " + evt.name;

                    //If there's already a video in the playlist by this name, grab the id and don't upload this video
                    //If the user wants to upload this video instead, they'll have to remove the other video from the playlist
                    int vIndex = itemsInPlaylist.FindIndex(v => v.Snippet.Title == videoTitle);
                    if (vIndex >= 0)
                    {
                        matchesList[videoUploadIndex].YouTubeId = itemsInPlaylist[vIndex].Snippet.ResourceId.VideoId;
                        continue;
                    }

                    progress.SetText("Uploading:\n" + videoTitle);

                    sb = new StringBuilder();
                    sb.AppendLine(videoTitle);
                    sb.AppendLine("Red (Teams " + matchesList[videoUploadIndex].RedAlliance + ") - " + matchesList[videoUploadIndex].RedScore.ToString());
                    sb.AppendLine("Blue (Teams " + matchesList[videoUploadIndex].BlueAlliance + ") - " + matchesList[videoUploadIndex].BlueScore.ToString());
                    //sb.AppendLine("http://www.thebluealliance.com/match/" + Properties.Settings.Default.year.ToString() + evt.code.ToLower() + "_" + matchesList[videoUploadIndex].TbaDescription.ToLower());//TBA Link
                    sb.AppendLine("https://frc-events.firstinspires.org/" + Properties.Settings.Default.year.ToString() + "/" + evt.code.ToUpper() + "/" + matchesList[videoUploadIndex].Level + "/" + matchesList[videoUploadIndex].MatchNumber);//FIRST Link
                    sb.AppendLine();
                    sb.AppendLine("Uploaded by FRC Video Splitter");
                    String videoDesc = sb.ToString();

                    int vidChunks = Convert.ToInt32(new FileInfo(matchesList[videoUploadIndex].VideoPath).Length);
                    progress.Chunks = vidChunks;
                    Console.WriteLine("vidChunks: " + vidChunks);

                    progress.SetCompletedChunks(0);

                    try
                    {
                        uploader.UploadVideo(videoTitle, videoDesc, matchesList[videoUploadIndex].VideoPath).Wait();
                    }
                    catch (AggregateException ex)
                    {
                        foreach (var err in ex.InnerExceptions)
                        {
                            Console.WriteLine("Error: " + err.Message);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Close the progress dialog when done uploading
        /// </summary>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown. 
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled  
                // the operation. 
                // Note that due to a race condition in  
                // the DoWork event handler, the Cancelled 
                // flag may not have been set, even though 
                // CancelAsync was called.
                progress.SetText("Canceled");
                Console.WriteLine("Worker Sucessfully Cancelled");
            }
            else
            {
                Console.WriteLine("Worker Completed");
                progress.Close();

                foreach (SplitterTypes.Match m in matchesList)
                {
                    string importFilePath = Path.Combine(matchVideoDestinationPathTextBox.Text, eventsComboBox.Text + ".csv");

                    if (!File.Exists(importFilePath))
                    {
                        using (StreamWriter sw = File.CreateText(importFilePath))
                        {
                            foreach (SplitterTypes.SplitVideo vid in splitVideos)
                            {
                                sw.WriteLine(vid.ToString());
                            }
                        }
                    }
                    else
                    {
                        File.Delete(importFilePath);
                        using (StreamWriter sw = File.CreateText(importFilePath))
                        {
                            foreach (SplitterTypes.SplitVideo vid in splitVideos)
                            {
                                sw.WriteLine(vid.ToString());
                            }
                        }
                    }
                }

                MessageBox.Show("Videos uploaded Successfully.  Created a private playlist on the channel.");
                writeEventFileToDisk();
            }
        }

        // ################# MATCH DATA GRID ################# \\
        /// <summary>
        /// Context menu on right click
        /// </summary>
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
        /// Update all selected matches accordingly
        /// </summary>
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
        /// Get the first row with an include checkbox that is checked.
        /// </summary>
        private DataGridViewRow getFirstIncludedMatchRow()
        {
            foreach (DataGridViewRow row in matchesDataGridView.Rows)
            {
                if ((bool)row.Cells["Include"].Value == true)
                {
                    return row;
                }
            }
            return null;
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
            if (firstRow != null)
            {
                firstRow.Cells["TimeStamp"].ReadOnly = false;
                firstRow.Cells["TimeStamp"].Style.BackColor = Color.White;
            }
        }
        /// <summary>
        /// If the user clicked a checkbox, trigger the CellValueChangedEvent.
        /// Also, keep track of selected matches.
        /// </summary>
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
        private void matchesDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            this.selectedMatches = matchesDataGridView.SelectedRows;
        }
        /// <summary>
        /// Make sure selected rows are updated.
        /// </summary>
        private void matchesDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.selectedMatches = matchesDataGridView.SelectedRows;
        }
        /// <summary>
        /// Handle incorrect entries in the datagridview
        /// </summary>
        private void matchesDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            if (anError.Exception.GetType() == typeof(System.FormatException))
            {
                MessageBox.Show("Invalid TimeStamp Format. Check your entry and try again, or press Esc to cancel.\n\nDetails:\n" + anError.Exception.Message, "Invalid TimeStamp Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// <summary>
        /// Fortmats the DataGridView appropriately
        /// </summary>
        private void SetDataGridViewFormatting()
        {
            this.matchesDataGridView.Columns["TimeStamp"].DefaultCellStyle.Format = "HH:mm:ss.fff";
            this.matchesDataGridView.Columns["ActualStartTime"].DefaultCellStyle.Format = "M/dd HH:mm:ss.fff";
            this.matchesDataGridView.Columns["PostResultTime"].DefaultCellStyle.Format = "M/dd HH:mm:ss.fff";
            this.matchesDataGridView.Columns["Level"].Visible = false;
            this.matchesDataGridView.Columns["MatchNumber"].Visible = false;

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
                row.Cells["TimeStamp"].ReadOnly = !(Properties.Settings.Default.useManualTimeStamps && (bool)row.Cells["Include"].Value);

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

        // ----------- unknown / other ------------ \\
        private void getPrevVideosButton_Click(object sender, EventArgs e)
        {
            List<SplitterTypes.SplitVideo> importVids = new List<SplitterTypes.SplitVideo>();
            string filePath = Path.Combine(matchVideoDestinationPathTextBox.Text, eventsComboBox.Text + ".csv");
            if (File.Exists(filePath))
            {
                string[] csvLines = File.ReadAllLines(filePath);
                foreach (string csv in csvLines)
                {
                    importVids.Add(new SplitterTypes.SplitVideo(csv));
                }
            }

            foreach (SplitterTypes.SplitVideo sVid in importVids)
            {
                matchesList.First(i => i.FIRSTDescription == sVid.match).VideoPath = sVid.path;
                matchesList.First(i => i.FIRSTDescription == sVid.match).YouTubeId = sVid.youTube;
                matchesList.First(i => i.FIRSTDescription == sVid.match).Include = true;
            }
        }        
    }
}