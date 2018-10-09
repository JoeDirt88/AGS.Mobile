using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using AGS.Mobile.Pages;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AGS.Mobile.Utilities
{
    public static class UtilDal
    {
        private static HttpClient client = new HttpClient();

        #region Route() URL Builder
        /// <summary>
        /// Description:    Shortcut string builder for the full route of the request
        /// Status:         Implemented
        /// </summary>
        /// <param name="controller">Receives the controller name where request is aimed
        /// Current controllers:
        ///     "Module"
        ///     "Patient"
        ///     "Values"
        ///     "Python"
        /// </param>
        /// <returns>Full string of requestUri</returns>
        public static string Route(string controller)
        {
            const string ip = @"196.252.75.110";
            const string port = "49805";
            var route = $@"/AGSoft/{controller}/";
            return @"http://" + ip + ":" + port + route;
        }
        #endregion

        #region Controllers
        // All the different controller regions are nested here
        #region MODULE AGSoft/Module/
        // GET()
        #region GetSurvey() /

        public static string GetSurvey()
        {
            var response = client.GetAsync(Route("Module")).Result;
            var content = response.IsSuccessStatusCode
                ? response.Content.ReadAsStringAsync().Result
                : null;
            return content;
        }
        #endregion
        // GET(id)
        #region GetSurvey() /{id}

        public static List<QuestionInfoModel> GetSurvey(string id)
        {
            var response = client.GetAsync(Route("Module") + $"{id}").Result;
            var content = response.IsSuccessStatusCode
                ? response.Content.ReadAsStringAsync().Result
                : null;
            return JsonConvert.DeserializeObject<List<QuestionInfoModel>>(content);
        }
        #endregion
        // POST(value)
        #region QueryModule() /{value}

        public static string QueryModule(string module)
        {
            const string medType = "application/json";
            var postData = new StringContent(JsonConvert.SerializeObject(module), Encoding.UTF8, medType);
            var response = client.PostAsync(Route("Module"), postData).Result;
            if (response.IsSuccessStatusCode != true)
            {
                throw new Exception($"Response from server API Failed for POST {Route("Module")} no id, check IP config");
            }
            return JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
        }
        #endregion
        // PUT(value)

        // Delete(id)

        #endregion

        #region PATIENT AGSoft/Patient
        // GET()
        #region Get() /

        #endregion
        // GET(id)
        #region QueryClient() /{id}

        public static PatientInfoModel QueryClient(PatientInfoModel patient)
        {
            var responseGet = client.GetAsync(Route("Patient") + $"{patient.Said}").Result;
            var content = responseGet.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<PatientInfoModel>(responseGet.Content.ReadAsStringAsync().Result)
                : throw new Exception($"Response from server API Failed for GET {Route("Patient")}{patient.Said}, check IP config");

            return content;
        }
        #endregion
        // POST(value)
        #region PostNewClient() /{value}

        public static bool PostNewClient(PatientInfoModel patient)
        {
            var content = QueryClient(patient);
            // If an ID is found on the db it will return "false"
            if (content.Said != "0") return false;
            // Serialize PatientInfo model for POST
            var jsonOb = JsonConvert.SerializeObject(patient, Formatting.Indented);
            // Create connection and send patient info
            const string medType = "application/json";
            var postData = new StringContent(jsonOb, Encoding.UTF8, medType);
            var response = client.PostAsync(Route("Patient"), postData).Result;
            return response.IsSuccessStatusCode != true
                ? throw new Exception(
                    $"Response from server API Failed for POST {Route("Patient")} {patient.Said}, check IP config")
                : true;
        }
        #endregion
        // PUT(value)

        // Delete(id)

        #endregion

        #region PYTHON AGSoft/Python
        // GET()
        #region Get() /

        #endregion
        // GET(id)

        // POST(value)
        #region PostAnswer() /{value}

        public static void PostAnswer(AnswerModel data)
        {
            const string medType = "application/json";
            var postData = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, medType);
            var response = client.PostAsync(Route("Python"), postData).Result;
            if (response.IsSuccessStatusCode != true)
            {
                throw new Exception($"Response from server API Failed for POST {Route("Python")} no id, check IP config");
            }
        }
        #endregion
        // PUT(value)

        // Delete(id)

        #endregion

        #region VALUES AGSoft/Values
        // GET()
        #region Get() /
            
        #endregion
        // GET(id)
        #region GetResultList() /{id}

        public static List<ResultModel> GetResultList(string id)
        {
            var response = client.GetAsync(Route("Values") + $"{id}").Result;
            var content = response.IsSuccessStatusCode
                ? response.Content.ReadAsStringAsync().Result
                : throw new Exception($"Response from server API Failed for GET {Route("Values")}{id}, check IP config");

            return JsonConvert.DeserializeObject<List<ResultModel>>(content);
        }
        #endregion
        // POST(value)

        // PUT(value)

        // Delete(id)

        #endregion

        #endregion

        #region ErrorHandler



        #endregion









    }
}
