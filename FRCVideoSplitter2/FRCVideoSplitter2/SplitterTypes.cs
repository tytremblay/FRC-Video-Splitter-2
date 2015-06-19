using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRCVideoSplitter2
{
    class SplitterTypes
    {
        public class Match
        {
            public DateTime AutoStartTime { get; set; }
            public string Description { get; set; }
            public string RedAlliance { get; set; }
            public string BlueAlliance { get; set; }
            public string RedScore { get; set; }
            public string BlueScore { get; set; }

            public Match(FRCApi.MatchResult frcMatch)
            {
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

                this.RedScore = frcMatch.scoreRedFinal;
                this.BlueScore = frcMatch.scoreBlueFinal;
               
            }
        }

    }
}
