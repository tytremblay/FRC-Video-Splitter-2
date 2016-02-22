using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;

namespace FRCVideoSplitter2
{
    class FRCApi
    {
        private string baseUrl = "https://frc-api.firstinspires.org/v2.0";
        Communicator communicator = new Communicator();

        public FRCApi() { }

        public List<int?> getTeamsAtEvent(int season, string eventCode)
        {
            List<int?> teams = new List<int?>();

            List<ScheduleMatch> schedule = getSchedule(season, eventCode, "qual");

            foreach (ScheduleMatch sm in schedule)
            {
                foreach (ScheduleTeam st in sm.teams)
                {
                    if (!teams.Contains(st.teamNumber))
                    {
                        teams.Add(st.teamNumber);
                    }
                }
            }

            return teams;
        }

        /// <summary>
        /// Get a list of match results from the FRC API
        /// </summary>
        /// <param name="season">Year</param>
        /// <param name="eventKey">FRC event code</param>
        /// <returns></returns>
        public List<T> getMatchResults<T>(int season, string eventKey)
        {
            string uri = baseUrl + "/" + season.ToString() + "/matches/" + eventKey;
            string api_response = communicator.sendAndGetRawResponse(uri);

            List<T> results = JsonConvert.DeserializeObject<MatchResultsList<T>>(api_response).Matches;

            return results;
        }


        /// <summary>
        /// Gets a list of events
        /// </summary>
        /// <param name="season">Year</param>
        /// <returns></returns>
        public List<Event> getEvents(int season)
        {
            string uri = baseUrl + "/" + season.ToString() + "/events";
            string api_response = communicator.sendAndGetRawResponse(uri);

            List<Event> events = JsonConvert.DeserializeObject<EventsList>(api_response).Events;

            return events;
        }

        /// <summary>
        /// Gets the raw JSON string for events lists from the FRC API
        /// </summary>
        /// <param name="season">Year</param>
        /// <returns></returns>
        public string getEventsListJsonString(int season)
        {
            string uri = baseUrl + "/" + season.ToString() + "/events";
            string api_response = communicator.sendAndGetRawResponse(uri);

            return api_response;
        }

        /// <summary>
        /// Gets the score details for the given season, event, and tournament level
        /// </summary>
        /// <param name="season">Season</param>
        /// <param name="eventCode">Event</param>
        /// <param name="tournamentLevel">Level</param>
        /// <returns></returns>
        public List<T> getScoreDetails<T>(int season, string eventCode, string tournamentLevel)
        {
            string uri = baseUrl + "/" + season.ToString() + "/scores/" + eventCode + "/" + tournamentLevel;
            string api_response = communicator.sendAndGetRawResponse(uri);

            if (api_response != null)
            {
                List<T> details = JsonConvert.DeserializeObject<ScoreDetailsList<T>>(api_response).MatchScores;
                return details;
            }
            else
            {
                return null;
            }

        }

        public List<ScheduleMatch> getSchedule(int season, string eventCode, string tournamentLevel)
        {
            string uri = baseUrl + "/" + season.ToString() + "/schedule/" + eventCode + "/" + tournamentLevel;
            string api_response = communicator.sendAndGetRawResponse(uri);
            //Console.WriteLine(api_response);
            if (api_response != null)
            {
                List<ScheduleMatch> schedule = JsonConvert.DeserializeObject<ScheduleMatchList>(api_response).Schedule;
                return schedule;
            }
            else
            {
                return null;
            }
        }

        public List<HybridScheduleMatch> getHybridSchedule(int season, string eventCode, string tournamentLevel)
        {
            string uri = baseUrl + "/" + season.ToString() + "/schedule/" + eventCode + "/" + tournamentLevel + "/hybrid";
            string api_response = communicator.sendAndGetRawResponse(uri);
            //Console.WriteLine(api_response);
            if (api_response != null)
            {
                List<HybridScheduleMatch> hybridSchedule = JsonConvert.DeserializeObject<HybridSchedule>(api_response).Schedule;
                return hybridSchedule;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Gets the full rankings for an event
        /// </summary>
        /// <param name="season"></param>
        /// <param name="eventCode"></param>
        /// <returns></returns>
        public List<T> getEventRankings<T>(int season, string eventCode)
        {
            string uri = baseUrl + "/" + season.ToString() + "/rankings/" + eventCode;
            string api_response = communicator.sendAndGetRawResponse(uri);
            if (api_response != null)
            {
                List<T> rankings = JsonConvert.DeserializeObject<EventRankings<T>>(api_response).Rankings;
                return rankings;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Event model for the FRC API
        /// </summary>
        [Serializable]
        public class Event
        {
            public string code { get; set; }
            public string divisionCode { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string districtCode { get; set; }
            public string venue { get; set; }
            public string city { get; set; }
            public string stateProv { get; set; }
            public string country { get; set; }
            public DateTime dateStart { get; set; }
            public DateTime dateEnd { get; set; }

            public Event() { }
        }

        /// <summary>
        /// a list of events from the FRC API
        /// </summary>

        [Serializable]
        public class EventsList
        {
            public List<Event> Events { get; set; }
            public int eventCount { get; set; }

            public EventsList() { }
        }

        /// <summary>
        /// Holder for the hybrid schedule for the FRC API
        /// </summary>

        [Serializable]
        public class HybridSchedule
        {
            public List<HybridScheduleMatch> Schedule { get; set; }

            public HybridSchedule() { }
        }

        /// <summary>
        /// A hybrid schedule model for the FRC API
        /// </summary>
        [Serializable]
        public class HybridScheduleMatch
        {
            public DateTime actualStartTime { get; set; }
            public string description { get; set; }
            public int matchNumber { get; set; }
            public int scoreRedFinal { get; set; }
            public int scoreRedFoul { get; set; }
            public int scoreRedAuto { get; set; }
            public int scoreBlueFinal { get; set; }
            public int scoreBlueFoul { get; set; }
            public int scoreBlueAuto { get; set; }
            public DateTime startTime { get; set; }
            public string tournamentLevel { get; set; }
            public List<ScheduleTeam> Teams { get; set; }

            public HybridScheduleMatch() { }

            public string RedAllianceString
            {
                get
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (ScheduleTeam t in Teams)
                    {
                        if (t.station.StartsWith("R"))
                        {
                            sb.AppendFormat("{0},", t.teamNumber);
                        }
                    }
                    string alliance = sb.ToString();
                    return alliance.Substring(0, alliance.Length - 1);
                }
            }

            public string BlueAllianceString
            {
                get
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (ScheduleTeam t in Teams)
                    {
                        if (t.station.StartsWith("B"))
                        {
                            sb.AppendFormat("{0},", t.teamNumber);
                        }
                    }
                    string alliance = sb.ToString();
                    return alliance.Substring(0, alliance.Length - 1);
                }
            }
        }

        [Serializable]
        public class ScheduleMatchList
        {
            public List<ScheduleMatch> Schedule { get; set; }

            public ScheduleMatchList() { }
        }

        [Serializable]
        public class ScheduleMatch
        {
            public string description { get; set; }
            public string field { get; set; }
            public string tournamentLevel { get; set; }
            public int? matchNumber { get; set; }
            public DateTime startTime { get; set; }
            public List<ScheduleTeam> teams { get; set; }

            public ScheduleMatch() { }

            public string RedAllianceString
            {
                get
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (ScheduleTeam t in teams)
                    {
                        if (t.station.StartsWith("R"))
                        {
                            sb.AppendFormat("{0},", t.teamNumber);
                        }
                    }
                    string alliance = sb.ToString();
                    return alliance.Substring(0, alliance.Length - 1);
                }
            }

            public string BlueAllianceString
            {
                get
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (ScheduleTeam t in teams)
                    {
                        if (t.station.StartsWith("B"))
                        {
                            sb.AppendFormat("{0},", t.teamNumber);
                        }
                    }
                    string alliance = sb.ToString();
                    return alliance.Substring(0, alliance.Length - 1);
                }
            }
        }

        /// <summary>
        /// Team model for hybrid schedule from the FRC API
        /// </summary>
        [Serializable]
        public class ScheduleTeam
        {
            public int? teamNumber { get; set; }
            public string station { get; set; }
            public bool surrogate { get; set; }
            public bool dq { get; set; }

            public ScheduleTeam() { }
        }

        /// <summary>
        /// A list of match results from the FRC API
        /// </summary>
        [Serializable]
        public class MatchResultsList<T>
        {
            public List<T> Matches { get; set; }

            public MatchResultsList() { }
        }

        /// <summary>
        /// Match result model for the FRC API
        /// </summary>
        [Serializable]
        public class MatchResult
        {
            public DateTime actualStartTime { get; set; }
            public string description { get; set; }
            public string tournamentLevel { get; set; }
            public int matchNumber { get; set; }
            public DateTime? postResultTime { get; set; }
            public string scoreRedFinal { get; set; }
            public string scoreRedFoul { get; set; }
            public string scoreRedAuto { get; set; }
            public string scoreBlueFinal { get; set; }
            public string scoreBlueFoul { get; set; }
            public string scoreBlueAuto { get; set; }
            public List<MatchResultsTeam> teams { get; set; }

            public MatchResult() { }

            public string RedAllianceString
            {
                get
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (MatchResultsTeam t in teams)
                    {
                        if (t.station.StartsWith("R"))
                        {
                            sb.AppendFormat("{0},", t.teamNumber);
                        }
                    }
                    string alliance = sb.ToString();
                    return alliance.Substring(0, alliance.Length - 1);
                }
            }

            public string BlueAllianceString
            {
                get
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (MatchResultsTeam t in teams)
                    {
                        if (t.station.StartsWith("B"))
                        {
                            sb.AppendFormat("{0},", t.teamNumber);
                        }
                    }
                    string alliance = sb.ToString();
                    return alliance.Substring(0, alliance.Length - 1);
                }
            }
        }

        /// <summary>
        /// Team model for match results from the FRC API
        /// </summary>
        [Serializable]
        public class MatchResultsTeam
        {
            public int? teamNumber { get; set; }
            public string station { get; set; }
            public bool dq { get; set; }

            public MatchResultsTeam() { }
        }

        public class MatchScore2016
        {
            public string matchLevel { get; set; }
            public int matchNumber { get; set; }
            public string audienceGroup { get; set; }
            public List<AllianceScoreDetails2016> alliances { get; set; }

        }

        /// <summary>
        /// A model for the breakdown of an alliance's score in the 2016 game.
        /// </summary>
        [Serializable]
        public class AllianceScoreDetails2016
        {
            public string alliance { get; set; }
            public string robot1Auto { get; set; }
            public string robot2Auto { get; set; }
            public string robot3Auto { get; set; }
            public int autoBouldersLow { get; set; }
            public int autoBouldersHigh { get; set; }
            public int teleopBouldersLow { get; set; }
            public int teleopBouldersHigh { get; set; }
            public string towerFaceA { get; set; }
            public string towerFaceB { get; set; }
            public string towerFaceC { get; set; }
            public int towerEndStrength { get; set; }
            public bool teleopTowerCaptured { get; set; }
            public bool teleopDefensesBreached { get; set; }
            public int position1crossings { get; set; }
            public string position2 { get; set; }
            public int position2crossings { get; set; }
            public string position3 { get; set; }
            public int position3crossings { get; set; }
            public string position4 { get; set; }
            public int position4crossings { get; set; }
            public string position5 { get; set; }
            public int position5crossings { get; set; }
            public int foulCount { get; set; }
            public int techFoulCount { get; set; }
            public int autoPoints { get; set; }
            public int autoReachPoints { get; set; }
            public int autoCrossingPoints { get; set; }
            public int autoBoulderPoints { get; set; }
            public int teleopPoints { get; set; }
            public int teleopCrossingPoints { get; set; }
            public int teleopBoulderPoints { get; set; }
            public int teleopChallengePoints { get; set; }
            public int teleopScalePoints { get; set; }
            public int breachPoints { get; set; }
            public int capturePoints { get; set; }
            public int adjustPoints { get; set; }
            public int foulPoints { get; set; }
            public int totalPoints { get; set; }

            public AllianceScoreDetails2016() { }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
                {
                    sb.AppendFormat("{0},", propertyInfo.GetValue(this, null));
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// A model for the breakdown of an alliance's score in the 2015 game.
        /// </summary>
        [Serializable]
        public class AllianceScoreDetails2015
        {
            public int adjustPoints { get; set; }
            public string alliance { get; set; }
            public int autoPoints { get; set; }
            public int containerCountLevel1 { get; set; }
            public int containerCountLevel2 { get; set; }
            public int containerCountLevel3 { get; set; }
            public int containerCountLevel4 { get; set; }
            public int containerCountLevel5 { get; set; }
            public int containerCountLevel6 { get; set; }
            public int containerPoints { get; set; }
            public bool containerSet { get; set; }
            public int foulCount { get; set; }
            public int litterCountContainer { get; set; }
            public int litterCountLandfill { get; set; }
            public int litterCountUnprocessed { get; set; }
            public int litterPoints { get; set; }
            public bool robotSet { get; set; }
            public int teleopPoints { get; set; }
            public int totalPoints { get; set; }
            public bool toteSet { get; set; }
            public bool toteStack { get; set; }

            public AllianceScoreDetails2015() { }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
                {
                    sb.AppendFormat("{0},", propertyInfo.GetValue(this, null));
                }

                return sb.ToString();
            }
        }

        [Serializable]
        public class ScoreDetails2016
        {
            public string matchLevel { get; set; }
            public int matchNumber { get; set; }
            public string audienceGroup { get; set; }
            public List<AllianceScoreDetails2016> alliances { get; set; }

            //There's 2 alliances, so let's just add them.
            public ScoreDetails2016() { }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
                {
                    if (propertyInfo.Name != "alliances")
                    {
                        sb.AppendFormat("{0},", propertyInfo.GetValue(this, null));
                    }
                    else
                    {
                        foreach (AllianceScoreDetails2016 alliance in alliances)
                        {
                            sb.AppendFormat("{0}", alliance.ToString());
                        }
                    }
                }

                return sb.ToString();
            }
        }

        [Serializable]
        public class ScoreDetails2015
        {
            public string coopertition { get; set; }
            public int coopertitionPoints { get; set; }
            public string matchLevel { get; set; }
            public int matchNumber { get; set; }
            public List<AllianceScoreDetails2015> alliances { get; set; }

            //There's 2 alliances, so let's just add them.
            public ScoreDetails2015() { }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
                {
                    if (propertyInfo.Name != "alliances")
                    {
                        sb.AppendFormat("{0},", propertyInfo.GetValue(this, null));
                    }
                    else
                    {
                        foreach (AllianceScoreDetails2015 alliance in alliances)
                        {
                            sb.AppendFormat("{0}", alliance.ToString());
                        }
                    }
                }

                return sb.ToString();
            }
        }

        [Serializable]
        public class ScoreDetailsList<T>
        {
            public List<T> MatchScores { get; set; }

            public ScoreDetailsList() { }
        }


        /// <summary>
        /// FRC model for a team ranking for 2016
        /// </summary>
        public class TeamRanking2016
        {
            public int? dq { get; set; }
            public int? losses { get; set; }
            public int? matchesPlayed { get; set; }
            public int? qualAverage { get; set; }
            public int? rank { get; set; }
            public int? teamNumber { get; set; }
            public int? ties { get; set; }
            public int? wins { get; set; }
            public int? sortOrder1 { get; set; }
            public int? sortOrder2 { get; set; }
            public int? sortOrder3 { get; set; }
            public int? sortOrder4 { get; set; }
            public int? sortOrder5 { get; set; }
            public int? sortOrder6 { get; set; }

            public TeamRanking2016() { }
        }

        /// <summary>
        /// FRC model for rankings at an event in 2016
        /// </summary>
        public class EventRankings2016
        {
            public List<TeamRanking2016> Rankings { get; set; }

            public EventRankings2016() { }
        }

        /// <summary>
        /// FRC Model for a team ranking for 2015
        /// 
        /// </summary>
        public class TeamRanking2015
        {
            public int? autoPoints { get; set; }
            public int? containerPoints { get; set; }
            public int? coopertitionPoints { get; set; }
            public int? dq { get; set; }
            public int? litterPoints { get; set; }
            public int? matchesPlayed { get; set; }
            public double? qualAverage { get; set; }
            public int? rank { get; set; }
            public int? teamNumber { get; set; }
            public int? ties { get; set; }
            public int? totePoints { get; set; }
            public int? wins { get; set; }

            public TeamRanking2015() { }
        }

        /// <summary>
        /// FRC model for rankings at an event in 2015
        /// </summary>
        public class EventRankings<T>
        {
            public List<T> Rankings { get; set; }

            public EventRankings() { }
        }


        /// <summary>
        /// Communicates with the FRC API
        /// </summary>
        private class Communicator
        {
            public string sendAndGetRawResponse(string uri)
            {
                var request = System.Net.WebRequest.Create(uri) as System.Net.HttpWebRequest;
                request.KeepAlive = true;

                ///REMOVE AFTER FRC FIXES IT?
                //request.ServerCertificateValidationCallback += (o, c, ch, er) => true;

                string token = "TYTREMBLAY:C272D991-944E-49D7-B10E-27BA5EBB598B";

                string encodedToken = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(token));

                request.Headers.Add("Authorization: Basic " + encodedToken);

                request.Method = "GET";

                request.Accept = "application/json";
                request.ContentLength = 0;

                string responseContent = null;

                try
                {
                    using (var response = request.GetResponse() as System.Net.HttpWebResponse)
                    {
                        using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                        {
                            responseContent = reader.ReadToEnd();
                        }
                    }

                    return responseContent;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                return responseContent;
            }
        }
    }
}
