using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AGS.Mobile
{
    public static class UtilDal
    {
        public static string Route(string controller)
        {
            const string ip = @"196.252.75.110";
            const string port = "49805";
            var route = $@"/AGSoft/{controller}/";
            return @"http://" + ip + ":" + port + route;
        }

        private static HttpClient client = new HttpClient();

        public static string GetSurvey(string id)
        {
            var content = string.Empty;
            var response = client.GetAsync(Route("Module") + $"{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                content = response.Content.ReadAsStringAsync().Result;
            }
            return content;
        }

        public static string GetSurvey()
        {
            var content = string.Empty;
            var response = client.GetAsync(Route("Module")).Result;

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
            var response = client.PostAsync(Route("Module"), postData).Result;
        }

        public static bool queryClient(List<string> lData)
        {
            var content = string.Empty;
            var responseGet = client.GetAsync(Route("Patient") + $"{lData[2]}").Result;
            
            if (responseGet.IsSuccessStatusCode)
            {
                // This is where i can check if i have an error with connection issues again

                content = JsonConvert.DeserializeObject<string>(responseGet.Content.ReadAsStringAsync().Result);
            }

            if (content == "New")
            {
                var Pdata = new CModel
                {
                    Said = lData[2],
                    Name = lData[0],
                    Surname = lData[1]
                };
                
                var jsonOb = JsonConvert.SerializeObject(Pdata, Formatting.Indented);

                const string medType = "application/json";
                var postData = new StringContent(jsonOb, System.Text.Encoding.UTF8, medType);
                var response = client.PostAsync(Route("Patient"), postData).Result;
                return true;
            }
            else
            {
                return false;
            }

            
        }
    }
}
