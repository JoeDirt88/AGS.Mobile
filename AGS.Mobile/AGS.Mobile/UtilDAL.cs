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

        public static string GetSurvey()
        {
            var content = string.Empty;
            //var result = await client.GetStringAsync(@"http://10.0.0.2:49805/api/values/5");
            var response = client.GetAsync(@"http://192.168.1.2:49805/api/values/5").Result;
            //var response = client.GetAsync(@"http://192.168.1.9/api/values/5").Result;
            if (response.IsSuccessStatusCode)
            {
                // This is where i can check if i have an error with connection issues again

                content = response.Content.ReadAsStringAsync().Result;
            }

            return content;
        }

    }


}
