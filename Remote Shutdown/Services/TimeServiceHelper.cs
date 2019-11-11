using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Remote_Shutdown.Services
{
    public class TimeServiceHelper
    {
        // Uses the WorldClockAPI to fetch the GMT DateTime
        private static string TimeServiceURL => "http://worldclockapi.com/api/json/utc/now";

        private static string GetTimeFromRemote()
        {
            string clockAPI = TimeServiceURL;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(clockAPI);
            WebResponse response = request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8);

            using JsonDocument document = JsonDocument.Parse(readStream.ReadToEnd(), 
                new JsonDocumentOptions { AllowTrailingCommas = true });

            string formattedReturn = document.RootElement.GetProperty("currentDateTime").GetString();

            // Removes special characters from the string
            return formattedReturn.Replace("T", " ").Replace("Z", "");
        }

        public static DateTime GetDateTimeSPFromRemote()
        {
            // Converts the remote time to local Time
            return DateTime
                .ParseExact(GetTimeFromRemote(), "yyyy-MM-dd HH:mm", null)
                .ToLocalTime();
        }

    }

}
