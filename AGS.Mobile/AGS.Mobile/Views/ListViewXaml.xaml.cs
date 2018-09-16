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
    //public partial class ListViewXaml : ContentPage
    public partial class ListViewXaml : ContentPage
    {
        private ObservableCollection<SurveyModel> survey { get; set; }
        public ListViewXaml()
        {
            survey = new ObservableCollection<SurveyModel>();
            InitializeComponent();
            lstView.ItemsSource = survey;
            //Note that survey is an observable collection, so the ListView will update in real time as items are added

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
                survey.Add(new SurveyModel() { question = que.Question, isTrue = false });
            }

        }

        private void Button_Clicked_VAD_save(object sender, EventArgs e)
        {
            // THIS IS WHERE THE STATE WILL BE SAVED AND THE ANSWER BE SENT BACK TO THE WEBAPI

        }
    }
}
