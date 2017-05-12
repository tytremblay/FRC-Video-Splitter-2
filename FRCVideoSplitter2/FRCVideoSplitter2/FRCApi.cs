using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using System.Net;
using System.IO;

namespace FRCVideoSplitter2
{
    class FRCApi
    {
        private string baseUrl = "https://frc-api.firstinspires.org/v2.0";
        private string apiToken = "aherreid:F37A9A1E-F115-4A88-B92B-0F284B3C21E9";

        public static string QualificationMatchesString = "qualification";
        public static string PlayoffMatchesString = "playoff";
        private Dictionary<string, DateTime> requestTimesDict = new Dictionary<string, DateTime>();

        public FRCApi() { }

        public bool saveRequestTimes()
        {
            try
            {
                HelperDataStructures.WriteObjectToFile<Dictionary<string, DateTime>>("requestTimes.bin", requestTimesDict);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool loadRequestTimes()
        {
            try
            {
                this.requestTimesDict = HelperDataStructures.ReadObjectFromFile<Dictionary<string, DateTime>>("requestTimes.bin");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static void deleteRequestTimes()
        {
            try
            {
                File.Delete("requestTimes.bin");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// Generic API request for generic objects
        /// </summary>
        /// <typeparam name="T">Object type to return</typeparam>
        /// <param name="uri">FRC API endpoint</param>
        /// <param name="useIfModifiedSince">boolean for whether or not to use the If-Modified-Since header</param>
        /// <returns></returns>
        private T handleAPIRequest<T>(string uri, bool useIfModifiedSince = true)
        {
            T apiObj;

            try
            {
                if (!System.IO.File.Exists(HelperDataStructures.convertUriToFileName(uri, ".bin")))
                {
                    //if there isn't a cached file, we need to force an API update to create one.
                    useIfModifiedSince = false;
                }
                string api_response = sendAndGetRawResponse(uri, useIfModifiedSince);

                if (api_response != null)
                {
                    apiObj = JsonConvert.DeserializeObject<T>(api_response);
                    HelperDataStructures.WriteObjectToFile<T>(HelperDataStructures.convertUriToFileName(uri, ".bin"), apiObj);
                    return apiObj;
                }
                else
                {
                    return default(T);
                }
            }
            catch (WebException ex)
            {
                if (((HttpWebResponse)((WebException)ex.InnerException).Response).StatusCode == HttpStatusCode.NotModified)
                {
                    //no changes were made, so load from cache
                    try
                    {
                        Console.WriteLine("No API changes, pulling from cache.");
                        apiObj = HelperDataStructures.ReadObjectFromFile<T>(HelperDataStructures.convertUriToFileName(uri, ".bin"));
                        return apiObj;
                    }
                    catch (System.IO.FileNotFoundException fnfe)
                    {
                        throw new Exception("No cached object found.", fnfe);
                    }
                }
                else
                {
                    throw ex;
                }
            }
        }

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

        public List<TeamRanking2016> get2016EventRankings(int season, string eventKey, bool useIfModifiedSince = true)
        {
            string uri = baseUrl + "/" + season.ToString() + "/rankings/" + eventKey;
            EventRankings2016 results = handleAPIRequest<EventRankings2016>(uri, useIfModifiedSince);
            if (results != null)
            {
                return results.Rankings;
            }
            else
            {
                return default(List<TeamRanking2016>);
            }
        }

        /// <summary>
        /// Get a list of match results from the FRC API
        /// </summary>
        /// <param name="season">Year</param>
        /// <param name="eventKey">FRC event code</param>
        /// <returns></returns>
        public List<T> getMatchResults<T>(int season, string eventKey, bool useIfModifiedSince = true)
        {
            string uri = baseUrl + "/" + season.ToString() + "/matches/" + eventKey;
            MatchResultsList<T> results = handleAPIRequest<MatchResultsList<T>>(uri, useIfModifiedSince);
            if (results != null)
            {
                return results.Matches;
            }
            else
            {
                return default(List<T>);
            }
            /*
            try
            {
                string api_response = communicator.sendAndGetRawResponse(uri, useIfModifiedSince);
                results = JsonConvert.DeserializeObject<MatchResultsList<T>>(api_response).Matches;
                HelperDataStructures.WriteObjectToFile<List<T>>(HelperDataStructures.convertUriToFileName(uri, ".bin"), results);

                return results;
            }
            catch (Exception ex)
            {
                if (((HttpWebResponse)((WebException)ex.InnerException).Response).StatusCode == HttpStatusCode.NotModified)
                {
                    //no changes were made, so load from cache
                    results = HelperDataStructures.ReadObjectFromFile<List<T>>(HelperDataStructures.convertUriToFileName(uri, ".bin"));
                    return results;
                }
                else
                {
                    throw ex;
                }
            }
             * */
        }


        /// <summary>
        /// Gets a list of events
        /// </summary>
        /// <param name="season">Year</param>
        /// <returns></returns>
        public List<Event> getEvents(int season, bool useIfModifiedSince = true)
        {
            string uri = baseUrl + "/" + season.ToString() + "/events";

            EventsList eventsList = handleAPIRequest<EventsList>(uri, useIfModifiedSince);

            if (eventsList != null)
            {
                return eventsList.Events;
            }
            else
            {
                return default(List<Event>);
            }

            /*
            List<Event> events;

            try
            {
                string api_response = communicator.sendAndGetRawResponse(uri, useIfModifiedSince);

                events = JsonConvert.DeserializeObject<EventsList>(api_response).Events;
                HelperDataStructures.WriteObjectToFile<List<Event>>(HelperDataStructures.convertUriToFileName(uri, ".bin"), events);
                return events;
            }
            catch (Exception ex)
            {
                if (((HttpWebResponse)((WebException)ex.InnerException).Response).StatusCode == HttpStatusCode.NotModified)
                {
                    //no changes were made, so load from cache
                    events = HelperDataStructures.ReadObjectFromFile<List<Event>>(HelperDataStructures.convertUriToFileName(uri, ".bin"));
                    return events;
                }
                else
                {
                    throw ex;
                }
            }            
             * */
        }



        /// <summary>
        /// Gets the raw JSON string for events lists from the FRC API
        /// </summary>
        /// <param name="season">Year</param>
        /// <returns></returns>
        public string getEventsListJsonString(int season, bool useIfModifiedSince = true)
        {
            string uri = baseUrl + "/" + season.ToString() + "/events";
            string api_response = sendAndGetRawResponse(uri);

            return api_response;
        }

        /// <summary>
        /// Gets the score details for the given season, event, and tournament level
        /// </summary>
        /// <param name="season">Season</param>
        /// <param name="eventCode">Event</param>
        /// <param name="tournamentLevel">Level</param>
        /// <returns></returns>
        public List<T> getScoreDetails<T>(int season, string eventCode, string tournamentLevel, bool useIfModifiedSince = true)
        {
            string uri = baseUrl + "/" + season.ToString() + "/scores/" + eventCode + "/" + tournamentLevel;
            ScoreDetailsList<T> details = handleAPIRequest<ScoreDetailsList<T>>(uri, useIfModifiedSince);

            if (details != null)
            {
                return details.MatchScores;
            }
            else
            {
                return default(List<T>);
            }
            /*
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
             * */

        }

        public List<ScheduleMatch> getSchedule(int season, string eventCode, string tournamentLevel, bool useIfModifiedSince = true)
        {
            string uri = baseUrl + "/" + season.ToString() + "/schedule/" + eventCode + "/" + tournamentLevel;
            string api_response = sendAndGetRawResponse(uri);
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

        public List<HybridScheduleMatch> getHybridSchedule(int season, string eventCode, string tournamentLevel, bool useIfModifiedSince = true)
        {
            string uri = baseUrl + "/" + season.ToString() + "/schedule/" + eventCode + "/" + tournamentLevel + "/hybrid";
            HybridSchedule sheduleContainer = handleAPIRequest<HybridSchedule>(uri, useIfModifiedSince);

            if (sheduleContainer != null)
            {
                return sheduleContainer.Schedule;
            }
            else
            {
                return default(List<HybridScheduleMatch>);
            }
        }


        /// <summary>
        /// Gets the full rankings for an event
        /// </summary>
        /// <param name="season"></param>
        /// <param name="eventCode"></param>
        /// <returns></returns>
        public List<T> getEventRankings<T>(int season, string eventCode, bool useIfModifiedSince = true)
        {
            string uri = baseUrl + "/" + season.ToString() + "/rankings/" + eventCode;
            string api_response = sendAndGetRawResponse(uri);
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

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
                {
                    if (propertyInfo.Name != "teams")
                    {
                        sb.AppendFormat("{0},", propertyInfo.GetValue(this, null));
                    }
                    else
                    {
                        foreach (MatchResultsTeam t in this.teams)
                        {
                            sb.AppendFormat("{0},", t.ToString());
                        }
                    }
                }

                return sb.ToString();
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

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                
                sb.AppendFormat("{0},{1},{2}", this.teamNumber, this.station, this.dq);
                
                return sb.ToString();
            }
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


        [Serializable]
        /// <summary>
        /// FRC model for a team ranking for 2016
        /// </summary>
        public class TeamRanking2016
        {
            public int? dq { get; set; }
            public int? losses { get; set; }
            public int? matchesPlayed { get; set; }
            public double? qualAverage { get; set; }
            public int? rank { get; set; }
            public int? teamNumber { get; set; }
            public int? ties { get; set; }
            public int? wins { get; set; }
            public double? sortOrder1 { get; set; }
            public double? sortOrder2 { get; set; }
            public double? sortOrder3 { get; set; }
            public double? sortOrder4 { get; set; }
            public double? sortOrder5 { get; set; }
            public double? sortOrder6 { get; set; }

            public TeamRanking2016() { }
        }


        [Serializable]
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


        public string sendAndGetRawResponse(string uri, bool useIfModifiedSince = true)
        {
            var request = System.Net.WebRequest.Create(uri) as System.Net.HttpWebRequest;
            request.KeepAlive = true;

            ///REMOVE AFTER FRC FIXES IT?
            //request.ServerCertificateValidationCallback += (o, c, ch, er) => true;

            string token = apiToken;

            string encodedToken = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(token));

            request.Headers.Add("Authorization: Basic " + encodedToken);

            if (useIfModifiedSince)
            {
                DateTime lastApiRequestDateTime;
                if (requestTimesDict.TryGetValue(uri, out lastApiRequestDateTime))
                {
                    request.IfModifiedSince = lastApiRequestDateTime;
                }
                else
                {
                    //we haven't done a request for this yet, so add the current time for later use.
                    requestTimesDict.Add(uri, DateTime.Now);
                }
                //DateTime lastApiRequestDateTime = Properties.Settings.Default.lastApiRequestDateTime;

            }

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
            catch (WebException ex)
            {
                if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotModified)
                {
                    //no changes have been made
                    throw new WebException("API Not Modified", ex);
                }
                if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new WebException("Invalid API Token", ex);
                }
            }

            return null;
        }
    }
}
