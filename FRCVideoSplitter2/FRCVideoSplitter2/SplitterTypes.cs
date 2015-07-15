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
            private DateTime _autoStartTime;
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

            public DateTime AutoStartTime
            {
                get { return _autoStartTime; }
                set
                {
                    _autoStartTime = value;
                    this.NotifyPropertyChanged("AutoStartTime");
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
                this.AutoStartTime = frcMatch.autoStartTime;
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
                    this.Description = "F" + frcMatch.description.Substring(7);
                }

                this.RedAlliance = String.Join(", ", frcMatch.teams.Where(team => team.station.StartsWith("Red")).Select(n => n.teamNumber.ToString()).ToList());
                this.BlueAlliance = String.Join(", ", frcMatch.teams.Where(team => team.station.StartsWith("Blue")).Select(n => n.teamNumber.ToString()).ToList());

                this.RedScore = Convert.ToInt16(frcMatch.scoreRedFinal);
                this.BlueScore = Convert.ToInt16(frcMatch.scoreBlueFinal);
                this.VideoPath = "";
                this.YouTubeId = "";
                this.MatchNumber = frcMatch.matchNumber;
                this.Level = frcMatch.level;
            }

            private void NotifyPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
