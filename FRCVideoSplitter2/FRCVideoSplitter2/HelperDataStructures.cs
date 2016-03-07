using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace FRCVideoSplitter2
{
    class HelperDataStructures
    {
        [Serializable]
        public class TeamEventStats
        {
            public int Team { get; set; }
            public DateTime Date { get; set; }
            public double Opr { get; set; }
            public double Dpr { get; set; }
            public double Ccwm { get; set; }

            public TeamEventStats() { }

            public TeamEventStats(int team, DateTime date, double opr, double dpr, double ccwm)
            {
                Team = team;
                Date = date;
                Opr = opr;
                Dpr = dpr;
                Ccwm = ccwm;
            }
        }

        [Serializable]
        public class IntermittentRankings
        {
            public int matchNumber {get; set;}
            public List<FRCApi.TeamRanking2015> ranksAfterMatch { get; set; }

            public IntermittentRankings() { }
        }

        [Serializable]
        public class MatchData2016
        {
            public FRCApi.MatchResult result { get; set; }
            public FRCApi.ScoreDetails2016 details { get; set; }

            public MatchData2016() { }

            public MatchData2016(FRCApi.MatchResult result, FRCApi.ScoreDetails2016 details)
            {
                this.result = result;
                this.details = details;
            }
        }

        public static void WriteObjectToFile<T>(string fileName, T objectToWrite)
        {
            WriteToBinaryFile<T>(Path.Combine(Directory.GetCurrentDirectory(), fileName), objectToWrite);
        }

        public static T ReadObjectFromFile<T>(string fileName)
        {
            return ReadFromBinaryFile<T>(Path.Combine(Directory.GetCurrentDirectory(), fileName));

        }

        /// <summary>
        /// Writes the given object instance to a binary file.
        /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
        /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the XML file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the XML file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        /// <summary>
        /// Reads an object instance from a binary file.
        /// </summary>
        /// <typeparam name="T">The type of object to read from the XML.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the binary file.</returns>
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }


        public static Color ligtenColor(Color color, float correctionFactor)
        {
            float red = (255 - color.R) * correctionFactor + color.R;
            float green = (255 - color.G) * correctionFactor + color.G;
            float blue = (255 - color.B) * correctionFactor + color.B;
            Color lighterColor = Color.FromArgb(color.A, (int)red, (int)green, (int)blue);

            return lighterColor;

        }

        public static string convertUriToFileName(string uri, string fileExtension)
        {
            return uri.Replace("/","").Replace(":","").Replace(".","") + fileExtension;
        }
    }
}
