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
        private string baseUrl = "https://frc-api.usfirst.org/v2.0";
        Communicator communicator = new Communicator();

        public FRCApi() { }

        /// <summary>
        /// Get a list of match results from the FRC API
        /// </summary>
        /// <param name="season">Year</param>
        /// <param name="eventKey">FRC event code</param>
        /// <returns></returns>
        public List<MatchResult> getMatchResults(int season, string eventKey)
        {
            string uri = baseUrl + "/" + season.ToString() + "/matches/" + eventKey;
            string api_response = communicator.sendAndGetRawResponse(uri);

            List<MatchResult> results = JsonConvert.DeserializeObject<MatchResultsList>(api_response).Matches;

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

        public List<ScoreDetails> getScoreDetails(int season, string eventCode, string tournamentLevel)
        {
            string uri = baseUrl + "/" + season.ToString() + "/scores/" + eventCode + "/" + tournamentLevel;
            string api_response = communicator.sendAndGetRawResponse(uri);

            if (api_response != null)
            {
                List<ScoreDetails> details = JsonConvert.DeserializeObject<ScoreDetailsList>(api_response).MatchScores;
                return details;
            }
            else
            {
                return null;
            }
            
        }

        /// <summary>
        /// Event model for the FRC API
        /// </summary>
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
        public class EventsList
        {
            public List<Event> Events  { get; set; }
            public int eventCount  { get; set; }

            public EventsList() { }
        }

        /// <summary>
        /// A list of match results from the FRC API
        /// </summary>
        public class MatchResultsList
        {
            public List<MatchResult> Matches { get; set; }

            public MatchResultsList() { }
        }

        /// <summary>
        /// Match result model for the FRC API
        /// </summary>
        public class MatchResult
        {
            public DateTime autoStartTime { get; set; }
            public string description { get; set; }
            public string level { get; set; }
            public int matchNumber { get; set; }
            public string scoreRedFinal { get; set; }
            public string scoreRedFoul { get; set; }
            public string scoreRedAuto { get; set; }
            public string scoreBlueFinal { get; set; }
            public string scoreBlueFoul { get; set; }
            public string scoreBlueAuto { get; set; }
            public List<MatchResultsTeam> teams { get; set; }

            public MatchResult() { }
        }

        /// <summary>
        /// Team model for match results from the FRC API
        /// </summary>
        public class MatchResultsTeam
        {
            public int? teamNumber { get; set; }
            public string station { get; set; }
            public bool dq { get; set; }

            public MatchResultsTeam() { }
        }

        /// <summary>
        /// A model for the breakdown of an alliance's score in the 2015 game.
        /// </summary>
        public class AllianceScoreDetails
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

            public AllianceScoreDetails() { }

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

        public class ScoreDetails
        {
            public string coopertition { get; set; }
            public int coopertitionPoints { get; set; }
            public string matchLevel { get; set; }
            public int matchNumber { get; set; }
            public List<AllianceScoreDetails> alliances { get; set; }

            public ScoreDetails() { }

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
                        foreach (AllianceScoreDetails alliance in alliances)
                        {
                            sb.AppendFormat("{0}", alliance.ToString());
                        }
                    }
                }

                return sb.ToString();
            }
        }

        public class ScoreDetailsList
        {
            public List<ScoreDetails> MatchScores { get; set; }

            public ScoreDetailsList() { }
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
