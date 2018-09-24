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
    public partial class ListViewXaml : ContentPage
    {
        private ObservableCollection<SurveyModel> ExampleSurvey { get; set; }
        public ListViewXaml()
        {
            ExampleSurvey = new ObservableCollection<SurveyModel>();
            InitializeComponent();
            lstView.ItemsSource = ExampleSurvey;
           
            var qSurvey = UtilDal.GetSurvey();

            var list = new List<Symptom>();

            var questionContentRegex = new Regex(@"Question\\\"": \\""(.*?)\\\""", RegexOptions.Multiline);
            foreach (Match matches in questionContentRegex.Matches(qSurvey))
            {
                list.Add(new Symptom(matches.Groups[1].Value));
            }

            if (!list.Any())
                throw new Exception("API connection issue :/");

            foreach (var que in list)
            {
                ExampleSurvey.Add(new SurveyModel() { Mquestion = que.Question, MisTrue = false });
            }
        }

        private void Button_Clicked_VAD_save(object sender, EventArgs e)
        {
            // THIS IS WHERE THE STATE WILL BE SAVED AND THE ANSWER BE SENT BACK TO THE WEBAPI
            var sAnswer = string.Empty;
            foreach (var ans in ExampleSurvey)
            {

                sAnswer = sAnswer + Bool2Bin(ans.MisTrue);
                sAnswer = sAnswer + " ";
            }
            sAnswer = sAnswer.Substring(0, sAnswer.Length - 1);
            Console.WriteLine(sAnswer);
            UtilDal.PostAnswer(sAnswer);
            Navigation.PopModalAsync();
        }

        private static string Bool2Bin(bool tick)
        {
            return tick == true ? "1" : "0";
        }
    }
}
