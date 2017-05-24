using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace FRCVideoSplitter2
{
    class SplitterTypes
    {
        [Serializable]
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
            private string _TbaDescription;
            private string _FIRSTDescription;
            private string _redAlliance;
            private string _blueAlliance;
            private int _redScore;
            private int _blueScore;
            private string _videoPath;
            private string _youtubeId;
            private string _level;
            private int _matchNumber;
            private bool _reportedToTba;
            private bool _reportedToFIRST;

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
            public string FIRSTDescription
            {
                get { return _FIRSTDescription; }
                set
                {
                    _FIRSTDescription = value;
                    this.NotifyPropertyChanged("FIRSTDescription");
                }
            }
            public string TbaDescription
            {
                get { return _TbaDescription; }
                set
                {
                    _TbaDescription = value;
                    this.NotifyPropertyChanged("TbaDescription");
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

            public bool ReportedToTBA
            {
                get { return _reportedToTba; }
                set
                {
                    _reportedToTba = value;
                    this.NotifyPropertyChanged("ReportedToTBA");
                }
            }

            public bool ReportedToFIRST
            {
                get { return _reportedToFIRST; }
                set
                {
                    _reportedToFIRST = value;
                    this.NotifyPropertyChanged("ReportedToFIRST");
                }
            }

            public Match(FRCApi.MatchResult frcMatch)
            {
                this.Include = true;
                this.TimeStamp = new DateTime();
                this.ActualStartTime = frcMatch.actualStartTime;
                this.PostResultTime = frcMatch.postResultTime;
                Dictionary<int, string> TBAmatchKeys = new Dictionary<int, string>();
                TBAmatchKeys.Add(1, "QF1M1");
                TBAmatchKeys.Add(2, "QF2M1");
                TBAmatchKeys.Add(3, "QF3M1");
                TBAmatchKeys.Add(4, "QF4M1");
                TBAmatchKeys.Add(5, "QF1M2");
                TBAmatchKeys.Add(6, "QF2M2");
                TBAmatchKeys.Add(7, "QF3M2");
                TBAmatchKeys.Add(8, "QF4M2");
                TBAmatchKeys.Add(9, "QF1M3");
                TBAmatchKeys.Add(10, "QF2M3");
                TBAmatchKeys.Add(11, "QF3M3");
                TBAmatchKeys.Add(12, "QF4M3");
                TBAmatchKeys.Add(13, "SF1M1");
                TBAmatchKeys.Add(14, "SF2M1");
                TBAmatchKeys.Add(15, "SF1M2");
                TBAmatchKeys.Add(16, "SF2M2");
                TBAmatchKeys.Add(17, "SF1M3");
                TBAmatchKeys.Add(18, "SF2M3");
                TBAmatchKeys.Add(19, "F1M1");
                TBAmatchKeys.Add(20, "F1M2");
                TBAmatchKeys.Add(21, "F1M3");
                if (frcMatch.tournamentLevel == "Qualification")
                {
                    this.TbaDescription = "QM" + frcMatch.matchNumber;
                }
                else
                {
                    this.TbaDescription = TBAmatchKeys[frcMatch.matchNumber];
                }


                if (frcMatch.description.StartsWith("Qualification "))
                {
                    this.FIRSTDescription = "Qual " + frcMatch.description.Substring(14);
                }
                else
                {
                    //playoffs
                    if (frcMatch.matchNumber >= 9 && frcMatch.matchNumber <= 12)
                    {
                        this.FIRSTDescription = "Quarterfinal " + frcMatch.description;
                    }
                    else if (frcMatch.matchNumber >= 17 && frcMatch.matchNumber <= 18)
                    {
                        this.FIRSTDescription = "Semifinal " + frcMatch.description;
                    }
                    else if (frcMatch.matchNumber == 21 && Properties.Settings.Default.year == 2016)//only need to add for this season
                    {
                        this.FIRSTDescription = "Final " + frcMatch.description;
                    }
                    else
                    {
                        this.FIRSTDescription = frcMatch.description;
                    }
                }

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