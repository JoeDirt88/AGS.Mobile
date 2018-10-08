using System;

namespace AGS.Mobile.ViewModel
{
    internal class ConversionHelper
    {
        /// <summary>
        /// Description:    Quick converter to condition data before POST
        /// </summary>
        /// <param name="tick">Boolean answer from SwitchCell</param>
        /// <returns>string(true = "1", false = "0")</returns>
        public static string Bool2Bin(bool tick)
        {
            return tick == true ? "1" : "0";
        }

        /// <summary>
        /// Description:    Covert PatientInfoModel Said into an age
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>Patient age this year</returns>
        public static string GetAge(PatientInfoModel patient)
        {
            var id = patient.Said;
            var yyyy = Convert.ToInt16(id.Substring(0, 2)) + 1900;
            var mm = Convert.ToInt16(id.Substring(2, 2));
            var dd = Convert.ToInt16(id.Substring(4, 2));
            var birthday = new DateTime(yyyy, mm, dd);
            return (DateTime.Now.Year - birthday.Year).ToString();
        }

        public static string ScreenConvert(string screening)
        {
            switch (screening)
            {
                case "True":
                {
                    return "Consult M.D.";
                }
                case "False":
                {
                    return "Healthy";
                }
                case "Null":
                {
                    return "Not enough information";
                }
                default:
                    throw new Exception("Screening result conversion error");

            }
        }
    }
}
