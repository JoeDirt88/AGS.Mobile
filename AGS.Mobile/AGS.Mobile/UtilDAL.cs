using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AGS.Mobile
{
    public static class UtilDAL
    {
        private static HttpClient client = new HttpClient();

        public static string GetLocalIPAddress()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address.ToString();
            }
        }

        public static string GetSurvey()
        {
            var content = string.Empty;
            var ipAddress = GetLocalIPAddress();

            try
            {
                var response = client.GetAsync(@"http://" + ipAddress + ":49805/api/values/5").Result;
                if (response.IsSuccessStatusCode)
                {
                    // This is where i can check if i have an error with connection issues again

                    content = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                // Create error Page for App that tells them to fix connection issues
            }
            return content;
            
        }
    }
}
