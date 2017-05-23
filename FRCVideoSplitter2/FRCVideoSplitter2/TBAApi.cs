using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FRCVideoSplitter2
{
    class TBAApi
    {
        string tbaEndpoint = "https://www.thebluealliance.com/api/v3";
        string tbaEndpointTrusted = "https://www.thebluealliance.com/api/trusted/v1";

        public List<Event> getEventsList(int year)
        {
            string uri = String.Format("{0}/{1}/{2}", tbaEndpoint, "events", year);
            string response = getTbaJsonStringPublic(uri);
            Properties.Settings.Default.eventsJsonString = response;
            Properties.Settings.Default.Save();
            return JsonConvert.DeserializeObject<List<Event>>(getTbaJsonStringPublic(uri));
        }

        // ################# WRITE API ################# \\
        public async Task<bool> writeTbaMatchVideo(string tbaAuth, string tbaSecret, string eventCode, string matchTbaCode, string youtubeUrlKey)
        {
            ///////For Development Use
            //eventCode = "arc";
            //tbaEndpointTrusted = "http://tba.lopreiato.me/api/trusted/v1";
            ///////////
            string url = String.Format("{0}/event/{1}/match_videos/add", tbaEndpointTrusted, Properties.Settings.Default.year + eventCode.ToLower());
            string body = @"{""" + matchTbaCode.ToLower() + @""":""" + youtubeUrlKey + @"""}";//we have to do a dumb custom format thing because TBA has dunamically changing key:value naming
            bool result = await writeTbaOperatonTrusted(tbaAuth, tbaSecret, url, body);
            return result;
        }
        private static readonly HttpClient client = new HttpClient();
        private async Task<bool> writeTbaOperatonTrusted(string tbaAuth, string tbaSecret, string url, string body)
        {
            var RequestUriParsed = new Uri(url);
            string source2Hash = tbaSecret + RequestUriParsed.AbsolutePath + body;//X-TBA-Auth-Sig: md5_hexdigest(<secret><request_path_no_domain><request_body>) << target format
            string resultHash = GetMd5Hash(source2Hash);
            client.DefaultRequestHeaders.Add("X-TBA-Auth-Id", tbaAuth);
            client.DefaultRequestHeaders.Add("X-TBA-Auth-Sig", resultHash);

            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }
        private string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        // ################# READ API ################# \\
        /// <summary>
        /// Returns a string fetched from the TBA API at the specified url
        /// </summary>
        /// <param name="url">The constructed url.</param>
        /// <returns>A JSON parsable string</returns>
        public string getTbaJsonStringPublic(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            //Add the necessary security headers.
            request.Headers.Add("X-TBA-Auth-Key", Properties.Settings.Default.tbaApiKey);

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
            public string type { get; set; }
            public string key { get; set; }
        }
    }
}