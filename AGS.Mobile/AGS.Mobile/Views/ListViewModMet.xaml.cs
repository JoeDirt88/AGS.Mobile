using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AGS.Mobile.Pages;
using AGS.Mobile.Utilities;
using Xamarin.Forms;

namespace AGS.Mobile.Views
{
    public partial class ListViewModMet : ContentPage
    {
        private ObservableCollection<SurveyModel> MetSurvey { get; set; } = new ObservableCollection<SurveyModel>();
        private PatientInfoModel curPatient;

        public ListViewModMet(PatientInfoModel patient)
        {
            curPatient = patient;
            #region ListViewSetup_Met_XAML
            InitializeComponent();
            LstViewMet.ItemsSource = MetSurvey;
            MetLabel.Text = "Please enter the measurements for " + patient.Name + ":";
            #endregion

            #region PopulateFromqGetSurvey_Met_XAML
            var qSurvey = UtilDal.GetSurvey("Met");

            if (qSurvey.Any())
                foreach (var que in qSurvey)
                {
                    MetSurvey.Add(new SurveyModel() { SurQuestion = que.Question, TextData = string.Empty });
                }
            else
            {
                ErrorHandle(new Exception($"Survey list was accessible for Metabolic Syndrome screening:"
                                          + $"\r\nPlease ensure that your internet connection is active, and try again."
                                          + $"\r\n"
                                          + $"\r\nIf the problem persists, please contact us on our support page."));
            }
            #endregion
        }

        #region ActionSaveMet
        private void Button_Clicked_MET_save(object sender, EventArgs e)
        {
            var list = new List<string>();
            foreach (var ans in MetSurvey)
            {
                list.Add(ans.TextData);
            }
            // fix this age from datetime.
            var answerMet = new AnswerModel
            {
                // TestData
                Waist = list[0],
                Systolic = list[1],
                Age = ConversionHelper.GetAge(curPatient),
                ModuleId = "Met",
                // ClientData
                Said = curPatient.Said,
                // EnvironmentData
                CurDateTime = DateTime.Now,
            };

            UtilDal.PostAnswer(answerMet);
            Navigation.PopModalAsync();
        }
        #endregion

        public async void ErrorHandle(Exception errException)
        {
            await Navigation.PushModalAsync(new ErrorPage(errException));
        }
    }
}
