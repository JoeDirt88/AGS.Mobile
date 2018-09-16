using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AGS.Mobile
{
    public static class UtilDAL
    {
        private static HttpClient client = new HttpClient();

        public static string GetSurvey(string id)
        {
            var content = string.Empty;
            var response = client.GetAsync($@"http://192.168.7.12:49805/api/values/{id}").Result;

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
            var response = client.GetAsync(@"http://192.168.7.12:49805/api/values").Result;

            if (response.IsSuccessStatusCode)
            {
                // This is where i can check if i have an error with connection issues again

                content = response.Content.ReadAsStringAsync().Result;
            }
            return content;
        }


    }


}
