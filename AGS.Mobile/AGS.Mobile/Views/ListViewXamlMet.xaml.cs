using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AGS.Mobile
{
    public partial class ListViewXamlMet : ContentPage
    {
        private ObservableCollection<SurveyModel> Met_survey { get; set; }
        public ListViewXamlMet()
        {
            Met_survey = new ObservableCollection<SurveyModel>();
            InitializeComponent();
            lstViewMet.ItemsSource = Met_survey;
            // This gets the string from the get request (functional)
            var qSurvey = UtilDal.GetSurvey("Met");

            var list = JsonConvert.DeserializeObject<List<QModel>>(qSurvey);
            
            if (!list.Any())
                throw new Exception("API connection issue :/");

            foreach (var que in list)
            {
                Met_survey.Add(new SurveyModel() { Mquestion = que.question, Mdata = string.Empty });
            }
        }

        private void Button_Clicked_MET_save(object sender, EventArgs e)
        {
            // THIS IS WHERE THE STATE WILL BE SAVED AND THE ANSWER BE SENT BACK TO THE WEBAPI
            var sAnswer = "[{";
            foreach (var ans in Met_survey)
            {
                sAnswer = sAnswer + ans.Mdata + ",";
            }
            sAnswer = sAnswer.Substring(0, sAnswer.Length - 1)+"}]";
            Console.WriteLine(sAnswer);
            UtilDal.PostAnswer(sAnswer);
            Navigation.PopModalAsync();
        }
    }
}
