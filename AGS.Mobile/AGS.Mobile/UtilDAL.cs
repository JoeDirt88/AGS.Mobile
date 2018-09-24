using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AGS.Mobile
{
    public static class UtilDal
    {
        private static HttpClient client = new HttpClient();

        public static string GetSurvey(string id)
        {
            const string ipPort = @"http://192.168.0.9:49805";
            const string getRoute = @"/AGsoft/Module/";
            var content = string.Empty;
            var response = client.GetAsync(ipPort + getRoute + $"{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                // This is where i can check if i have an error with connection issues again

                content = response.Content.ReadAsStringAsync().Result;
            }
            return content;
        }

        public static string GetSurvey()
        {
            var content = string.Empty;
            var response = client.GetAsync(@"http://192.168.0.9:49805/AGsoft/values").Result;

            if (response.IsSuccessStatusCode)
            {
                // This is where i can check if i have an error with connection issues again

                content = response.Content.ReadAsStringAsync().Result;
            }
            return content;
        }

        public static void PostAnswer(string aData)
        {
            //var postData = new StringContent(aData);
            const string medType = "application/json";
            var postData = new StringContent(JsonConvert.SerializeObject(aData), Encoding.UTF8, medType);
            const string url = @"http://192.168.0.9:49805/AGsoft/values/";
            var response = client.PostAsync(url, postData).Result;
        }
    }
}
