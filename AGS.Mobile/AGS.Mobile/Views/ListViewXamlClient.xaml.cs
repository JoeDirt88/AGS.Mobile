using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AGS.Mobile
{
    public partial class ListViewXamlCnt : ContentPage
    {
        private ObservableCollection<SurveyModel> Cnt_survey { get; set; }
        public ListViewXamlCnt()
        {
            Cnt_survey = new ObservableCollection<SurveyModel>();
            InitializeComponent();
            lstViewCnt.ItemsSource = Cnt_survey;
            // This gets the string from the get request (functional)
            var qSurvey = UtilDal.GetSurvey("Cnt");

            var list = JsonConvert.DeserializeObject<List<QModel>>(qSurvey);
            
            if (!list.Any())
                throw new Exception("API connection issue :/");

            foreach (var que in list)
            {
                Cnt_survey.Add(new SurveyModel() { Mquestion = que.question, Mdata = string.Empty });
            }
        }

        private async void Button_Clicked_CNT_save(object sender, EventArgs e)
        {
            var list = new List<string>();
            
            foreach (var ans in Cnt_survey)
            {
                list.Add(ans.Mdata);
            }

            // Send the ID number over to the DAL Utility to check the database
            if (UtilDal.queryClient(list) == true)
            {
                // This means that the creation was a success
                await Navigation.PushModalAsync(new SelectionPage());
                // success page needs creation
            }
            else
            {
                // This means a patient with that ID already exists
                var error = @"This patient already exists:";
                // Error page needs creation

            }
        }
    }
}
