using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FRCVideoSplitter2
{
    class TBAApi
    {
        string authId = "mALLxV9n2Qa1Jgpd";
        string authSecret = "eMIuCt0PEY9mLO4oUKeHW4N08cCg0Lmrf62H2LyvhTeNOzyW2M11NfVKFzczsnyC";
        string authKey = "sXjuZY8u7prdO1P28JajKn9wOburovQeqkQHkutvSQRo9r4ZDghXoIkYDINkPkxF";

        string tbaEndpoint = "https://www.thebluealliance.com/api/v3";
        //TBA_HEADER = {"X-TBA-Auth-Key": TBA_KEY 


        public List<Event> getEventsList(int year)
        {
            string uri = String.Format("{0}/{1}/{2}", tbaEndpoint, "events", year);
            string response = getTbaJsonString(uri);
            Properties.Settings.Default.eventsJsonString = response;
            Properties.Settings.Default.Save();
            return JsonConvert.DeserializeObject<List<Event>>(getTbaJsonString(uri));

        }


        /// <summary>
        /// Returns a string fetched from the TBA API at the specified url
        /// </summary>
        /// <param name="url">The constructed url.</param>
        /// <returns>A JSON parsable string</returns>
        public string getTbaJsonString(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            //Add the necessary security headers.
            request.Headers.Add("X-TBA-App-Id", "gamesense:gamesensebot:v01");
            request.Headers.Add("X-TBA-Auth-Key", authKey);

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            return reader.ReadToEnd();
        }

        public class Event
        {
            public string address { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public District district { get; set; }
            public string[] division_keys { get; set; }
            public DateTime end_date { get; set; }
            public string event_code { get; set; }
            public int event_type { get; set; }
            public string event_type_string { get; set; }
            public string first_event_id { get; set; }
            public string gmaps_place_id { get; set; }
            public string gmaps_url { get; set; }
            public string key { get; set; }
            public float? lat { get; set; }
            public float? lng { get; set; }
            public string location_name { get; set; }
            public string name { get; set; }
            public string parent_event_key { get; set; }
            public int? playoff_type { get; set; }
            public string playoff_type_string { get; set; }
            public string postal_code { get; set; }
            public string short_name { get; set; }
            public DateTime start_date { get; set; }
            public string state_prov { get; set; }
            public string timezone { get; set; }
            public Webcast[] webcasts { get; set; }
            public string website { get; set; }
            public int? week { get; set; }
            public int year { get; set; }
        }

        public class District
        {
            public string abbreviation { get; set; }
            public string display_name { get; set; }
            public string key { get; set; }
            public int year { get; set; }
        }

        public class Webcast
        {
            public string channel { get; set; }
            public string file { get; set; }
            public string type { get; set; }
            public DateTime date { get; set; }
        }

        public class Match
        {
            public int actual_time { get; set; }
            public Alliances alliances { get; set; }
            public string comp_level { get; set; }
            public string event_key { get; set; }
            public string key { get; set; }
            public int match_number { get; set; }
            public int post_result_time { get; set; }
            public int? predicted_time { get; set; }
            public ScoreBreakdown score_breakdown { get; set; }
            public int set_number { get; set; }
            public int time { get; set; }
            public Video[] videos { get; set; }
            public string winning_alliance { get; set; }
        }

        public class Alliances
        {
            public Blue blue { get; set; }
            public Red red { get; set; }
        }

        public class Blue
        {
            public int score { get; set; }
            public string[] surrogate_team_keys { get; set; }
            public string[] team_keys { get; set; }
        }

        public class Red
        {
            public int score { get; set; }
            public string[] surrogate_team_keys { get; set; }
            public string[] team_keys { get; set; }
        }

        public class ScoreBreakdown
        {
            public ScoreBreakDown blue { get; set; }
            public ScoreBreakDown red { get; set; }
        }

        public class ScoreBreakDown
        {
            public int adjustPoints { get; set; }
            public int autoFuelHigh { get; set; }
            public int autoFuelLow { get; set; }
            public int autoFuelPoints { get; set; }
            public int autoMobilityPoints { get; set; }
            public int autoPoints { get; set; }
            public int autoRotorPoints { get; set; }
            public int foulCount { get; set; }
            public int foulPoints { get; set; }
            public int kPaBonusPoints { get; set; }
            public bool kPaRankingPointAchieved { get; set; }
            public string robot1Auto { get; set; }
            public string robot2Auto { get; set; }
            public string robot3Auto { get; set; }
            public bool rotor1Auto { get; set; }
            public bool rotor1Engaged { get; set; }
            public bool rotor2Auto { get; set; }
            public bool rotor2Engaged { get; set; }
            public bool rotor3Engaged { get; set; }
            public bool rotor4Engaged { get; set; }
            public int rotorBonusPoints { get; set; }
            public bool rotorRankingPointAchieved { get; set; }
            public int? tba_rpEarned { get; set; }
            public int techFoulCount { get; set; }
            public int teleopFuelHigh { get; set; }
            public int teleopFuelLow { get; set; }
            public int teleopFuelPoints { get; set; }
            public int teleopPoints { get; set; }
            public int teleopRotorPoints { get; set; }
            public int teleopTakeoffPoints { get; set; }
            public int totalPoints { get; set; }
            public string touchpadFar { get; set; }
            public string touchpadMiddle { get; set; }
            public string touchpadNear { get; set; }
        }        

        public class Video
        {
            public string key { get; set; }
            public string type { get; set; }
        }

    }


}
