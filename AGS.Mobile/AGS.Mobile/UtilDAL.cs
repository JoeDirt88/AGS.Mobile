using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using AGS.Mobile.ViewModel;

namespace AGS.Mobile
{
    public static class UtilDal
    {
        private static HttpClient client = new HttpClient();
        
        #region RequestUriBuilder_IP_cfg
        /// <summary>
        /// Description:    Shortcut string builder for the full route of the request
        /// Status:         Implemented
        /// </summary>
        /// <param name="controller">Receives the controller name where request is aimed
        /// Current controllers:
        ///     "Module"
        ///     "Patient"
        ///     "Values"
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
        #region SurveyListBuilder_GET_Module_id
        /// <summary>
        /// Description:    Request Python module specific question lists for display
        /// Status:         Implemented
        /// </summary>
        /// <param name="id">Python module ID
        /// Current list of Module ID's:
        ///     "Vad" = Vitamin A Deficiency questionnaire
        ///     "Met" = Metabolic Syndrome questionnaire
        ///     "Bit" = Bitot's Spots questionnaire
        ///     "Cnt" = Client Information questionnaire
        /// </param>
        /// <returns>List of questions as Json from db containing updated questions</returns>
        public static List<QuestionInfoModel> GetSurvey(string id)
        {
            var response = client.GetAsync(Route("Module") + $"{id}").Result;
            var content = response.IsSuccessStatusCode
                ? response.Content.ReadAsStringAsync().Result
                : throw new Exception($"Response from server API Failed for GET {Route("Module")} {id}, check IP config");

            return JsonConvert.DeserializeObject<List<QuestionInfoModel>>(content);
        }
        #endregion
        #region ModuleInfoListRequest_GET_Module
        /// <summary>
        /// Description:    Returns the values for all modules currently in db
        /// Status:         Implemented
        /// </summary>
        /// <returns>List of all current screening modules</returns>
        public static string GetSurvey()
        {
            var response = client.GetAsync(Route("Module")).Result;
            var content = response.IsSuccessStatusCode
                ? response.Content.ReadAsStringAsync().Result
                : throw new Exception($"Response from server API Failed for GET {Route("Module")} no id, check IP config");
            return content;
        }
        #endregion
        #region SurveyDataSender_POST_Module_aData
        /// <summary>
        /// Description:    TEST CODE FOR POSTING ANSWER TO API WORKS
        /// Status:         NEED TO CREATE NEW CODE
        /// </summary>
        /// <param name="data"></param>
        public static void PostAnswer(AnswerModel data)
        {
            const string medType = "application/json";
            var postData = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, medType);
            var response = client.PostAsync(Route("Module"), postData).Result;
            if (response.IsSuccessStatusCode != true)
            {
                throw new Exception($"Response from server API Failed for POST {Route("Module")} no id, check IP config");
            }
        }
        #endregion
        #region CreateNewClient_GET_Patient_id_POST_Patient

        /// <summary>
        /// Description:    Compact GET, and POST method to query the existence of an ID number
        ///                 in the client db, and add the entry if it doesn't exist.
        /// Status:         Implemented
        /// </summary>
        /// <param name="patient">Patient South African ID number</param>
        /// <returns>bool "true" for new patient created, or "false" if patient already exists</returns>
        public static bool QueryNewClient(PatientInfoModel patient)
        {
            var responseGet = client.GetAsync(Route("Patient") + $"{patient.Said}").Result;
            var content = responseGet.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<string>(responseGet.Content.ReadAsStringAsync().Result)
                : throw new Exception($"Response from server API Failed for GET {Route("Patient")} {patient.Said}, check IP config");

            if (content != "New") return false;
            
            var jsonOb = JsonConvert.SerializeObject(patient, Formatting.Indented);

            const string medType = "application/json";
            var postData = new StringContent(jsonOb, Encoding.UTF8, medType);
            var response = client.PostAsync(Route("Patient"), postData).Result;
            return response.IsSuccessStatusCode != true
                ? throw new Exception(
                    $"Response from server API Failed for POST {Route("Patient")} {patient.Said}, check IP config")
                : true;

        }
        #endregion
        #region QueryClient_GET_Patient_id

        /// <summary>
        /// Description:    Compact GET, and POST method to query the existence of an ID number
        ///                 in the client db, and add the entry if it doesn't exist.
        /// Status:         Implemented
        /// </summary>
        /// <param name="patient">Patient South African ID number</param>
        /// <returns>bool "true" for new patient created, or "false" if patient already exists</returns>
        public static PatientInfoModel QueryClient(PatientInfoModel patient)
        {
            var responseGet = client.GetAsync(Route("Patient") + $"{patient.Said}").Result;
            var content = responseGet.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<string>(responseGet.Content.ReadAsStringAsync().Result)
                : throw new Exception($"Response from server API Failed for GET {Route("Patient")} {patient.Said}, check IP config");

            if (content != "New")
            {
                //get proper patient data from API to ensure no garbage
                var ApiClientData = new PatientInfoModel(); //implement this
                return patient;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
