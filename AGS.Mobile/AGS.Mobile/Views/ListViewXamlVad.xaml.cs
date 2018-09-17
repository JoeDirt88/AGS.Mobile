using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AGS.Mobile
{
    public partial class ListViewXamlVad : ContentPage
    {
        private ObservableCollection<SurveyModel> Vad_survey { get; set; }
        public ListViewXamlVad()
        {
            Vad_survey = new ObservableCollection<SurveyModel>();
            InitializeComponent();
            lstViewVad.ItemsSource = Vad_survey;
            var qSurvey = UtilDAL.GetSurvey();

            var list = new List<Symptom>();

            Regex QuestionContentRegex = new Regex(@"Question\\\"": \\""(.*?)\\\""", RegexOptions.Multiline);
            foreach (Match matches in QuestionContentRegex.Matches(qSurvey))
            {
                list.Add(new Symptom(matches.Groups[1].Value));
            }

            if (!list.Any())
                throw new Exception("API connection issue :/");

            foreach (var que in list)
            {
                Vad_survey.Add(new SurveyModel() { Mquestion = que.Question, MisTrue = false });
            }
        }

        private void Button_Clicked_VAD_save(object sender, EventArgs e)
        {
            // THIS IS WHERE THE STATE WILL BE SAVED AND THE ANSWER BE SENT BACK TO THE WEBAPI
            string sAnswer = "[{";
            foreach (var ans in Vad_survey)
            {
                sAnswer = sAnswer + Bool2Bin(ans.MisTrue) + ",";
            }
            sAnswer = sAnswer.Substring(0, sAnswer.Length - 1)+"}]";
            Console.WriteLine(sAnswer);
            UtilDAL.PostAnswer(sAnswer);
            Navigation.PopModalAsync();
        }

        /// <summary>
        /// Description:    Quick converter to condition data before POST
        /// </summary>
        /// <param name="tick">Boolean answer from SwitchCell</param>
        /// <returns>string(true = "1", false = "0")</returns>
        private string Bool2Bin(Boolean tick)
        {
            if (tick == true)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
    }
}
