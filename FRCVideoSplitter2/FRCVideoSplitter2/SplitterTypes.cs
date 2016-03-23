using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace FRCVideoSplitter2
{
    class SplitterTypes
    {
        /// <summary>
        /// Match model that holds the information we care about in FRC Splitter.
        /// Displays nicely in a datagridview
        /// </summary>
        public class Match : INotifyPropertyChanged
        {
            private bool _include;
            private DateTime _timeStamp;
            private DateTime _actualStartTime;
            private DateTime? _postResultTime;
            private string _description;
            private string _redAlliance;
            private string _blueAlliance;
            private int _redScore;
            private int _blueScore;
            private string _videoPath;
            private string _youtubeId;
            private string _level;
            private int _matchNumber;

            public event PropertyChangedEventHandler PropertyChanged;

            public bool Include
            {
                get { return _include; }
                set
                {
                    _include = value;
                    this.NotifyPropertyChanged("Include");
                }
            }

            public DateTime TimeStamp
            {
                get { return _timeStamp; }
                set
                {
                    _timeStamp = value;
                    this.NotifyPropertyChanged("TimeStamp");
                }
            }

            public DateTime ActualStartTime
            {
                get { return _actualStartTime; }
                set
                {
                    _actualStartTime = value;
                    this.NotifyPropertyChanged("AutoStartTime");
                }
            }

            public DateTime? PostResultTime
            {
                get { return _postResultTime; }
                set
                {
                    _postResultTime = value;
                    this.NotifyPropertyChanged("PostResultsTime");
                }
            }
            public string Description
            {
                get { return _description; }
                set
                {
                    _description = value;
                    this.NotifyPropertyChanged("Description");
                }
            }

            public string RedAlliance
            {
                get { return _redAlliance; }
                set
                {
                    _redAlliance = value;
                    this.NotifyPropertyChanged("RedAlliance");
                }
            }

            public string BlueAlliance
            {
                get { return _blueAlliance; }
                set
                {
                    _blueAlliance = value;
                    this.NotifyPropertyChanged("BlueAlliance");
                }
            }

            public int RedScore
            {
                get { return _redScore; }
                set
                {
                    _redScore = value;
                    this.NotifyPropertyChanged("RedScore");
                }
            }

            public int BlueScore
            {
                get { return _blueScore; }
                set
                {
                    _blueScore = value;
                    this.NotifyPropertyChanged("BlueScore");
                }
            }

            public string VideoPath
            {
                get { return _videoPath; }
                set
                {
                    _videoPath = value;
                    this.NotifyPropertyChanged("VideoPath");
                }
            }

            public string YouTubeId
            {
                get { return _youtubeId; }
                set
                {
                    _youtubeId = value;
                    this.NotifyPropertyChanged("YouTubeId");
                }
            }

            public string Level
            {
                get { return _level; }
                set
                {
                    _level = value;
                    this.NotifyPropertyChanged("Level");
                }
            }

            public int MatchNumber
            {
                get { return _matchNumber; }
                set
                {
                    _matchNumber = value;
                    this.NotifyPropertyChanged("MatchNumber");
                }
            }

            public Match(FRCApi.MatchResult frcMatch)
            {
                this.Include = true;
                this.TimeStamp = new DateTime();
                this.ActualStartTime = frcMatch.actualStartTime;
                this.PostResultTime = frcMatch.postResultTime;
                Dictionary<int, string> matchKeys = new Dictionary<int, string>();
                matchKeys.Add(1, "QF1M1");
                matchKeys.Add(2, "QF2M1");
                matchKeys.Add(3, "QF3M1");
                matchKeys.Add(4, "QF4M1");
                matchKeys.Add(5, "QF1M2");
                matchKeys.Add(6, "QF2M2");
                matchKeys.Add(7, "QF3M2");
                matchKeys.Add(8, "QF4M2");
                matchKeys.Add(9, "QF1M3");
                matchKeys.Add(10, "QF2M3");
                matchKeys.Add(11, "QF3M3");
                matchKeys.Add(12, "QF4M3");
                matchKeys.Add(13, "SF1M1");
                matchKeys.Add(14, "SF2M1");
                matchKeys.Add(15, "SF1M2");
                matchKeys.Add(16, "SF2M2");
                matchKeys.Add(17, "SF1M3");
                matchKeys.Add(18, "SF2M3");
                matchKeys.Add(19, "F1M1");
                matchKeys.Add(20, "F1M2");
                matchKeys.Add(21, "F1M3");
                /*
                if (frcMatch.description.StartsWith("Qualification "))
                {
                    this.Description = "Q" + frcMatch.description.Substring(14);
                }
                else if (frcMatch.description.StartsWith("Quarterfinal "))
                {
                    this.Description = "QF" + frcMatch.description.Substring(13);
                }
                else if (frcMatch.description.StartsWith("Semifinal "))
                {
                    this.Description = "SF" + frcMatch.description.Substring(10);
                }
                else 
                {
                    this.Description = frcMatch.description;
                }
                 * */

                if (frcMatch.tournamentLevel == "Qualification")
                {
                    this.Description = "Q" + frcMatch.matchNumber;
                }
                else
                {
                    this.Description = matchKeys[frcMatch.matchNumber];
                }
                //this.Description = frcMatch.description;
                this.RedAlliance = String.Join(", ", frcMatch.teams.Where(team => team.station.StartsWith("Red")).Select(n => n.teamNumber.ToString()).ToList());
                this.BlueAlliance = String.Join(", ", frcMatch.teams.Where(team => team.station.StartsWith("Blue")).Select(n => n.teamNumber.ToString()).ToList());

                this.RedScore = Convert.ToInt16(frcMatch.scoreRedFinal);
                this.BlueScore = Convert.ToInt16(frcMatch.scoreBlueFinal);
                this.VideoPath = "";
                this.YouTubeId = "";
                this.MatchNumber = frcMatch.matchNumber;
                this.Level = frcMatch.tournamentLevel;
            }

            private void NotifyPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public class SplitVideo
        {
            public string eventCode { get; set; }
            public string match { get; set; }
            public string path { get; set; }
            public string youTube { get; set; }

            public SplitVideo(string eventCode, string match, string path)
            {
                this.eventCode = eventCode;
                this.match = match;
                this.path = path;
                this.youTube = "";
            }

            public SplitVideo(string eventCode, string match, string path, string youTube)
            {
                this.eventCode = eventCode;
                this.match = match;
                this.path = path;
                this.youTube = youTube;
            }

            public SplitVideo(string csv)
            {
                string[] parts = csv.Split(',');
                if (parts.Length > 3)
                {
                    this.eventCode = parts[0];
                    this.match = parts[1];
                    this.path = parts[2];
                    this.youTube = parts[3];
                }
                else if (parts.Length == 3)
                {
                    this.eventCode = parts[0];
                    this.match = parts[1];
                    this.path = parts[2];
                }
            }

            public override string ToString()
            {
                return eventCode + "," + match + "," + path + "," + youTube;
            }
        }


    }
    
}
