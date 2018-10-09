using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AGS.Mobile.Pages;
using AGS.Mobile.Utilities;
using Xamarin.Forms;

namespace AGS.Mobile.Views
{
    public partial class ListViewModVad : ContentPage
    {
        private ObservableCollection<SurveyModel> VadSurvey { get; set; } = new ObservableCollection<SurveyModel>();
        private PatientInfoModel curPatient;

        public ListViewModVad(PatientInfoModel patient)
        {
            curPatient = patient;
            #region ListViewSetup_Vad_XAML
            InitializeComponent();
            LstViewVad.ItemsSource = VadSurvey;
            VadLabel.Text = "Select the relevant options for " + patient.Name + ":";
            #endregion
            #region PopulateFromqGetSurvey_Vad_XAML
            var qSurvey = UtilDal.GetSurvey("Vad");

            if (qSurvey.Any())
                foreach (var que in qSurvey)
                {
                    VadSurvey.Add(new SurveyModel() { SurQuestion = que.Question, IsTrue = false });
                }
            else
            {
                ErrorHandle(new Exception($"Survey list was accessible for Vitamin A Deficiency screening:"
                + $"\r\nPlease ensure that your internet connection is active, and try again."
                + $"\r\n"
                + $"\r\nIf the problem persists, please contact us on our support page."));
            }
            #endregion
        }

        #region ActionSaveVad
        private void Button_Clicked_VAD_save(object sender, EventArgs e)
        {
            var list = new List<string>();
            foreach (var ans in VadSurvey)
            {
                list.Add(ConversionHelper.Bool2Bin(ans.IsTrue));
            }

            var answerVad = new AnswerModel
            {
                // TestData
                ParametersVad = list,
                ModuleId = "Vad",
                // ClientData
                Said = curPatient.Said,
                // EnvironmentData
                CurDateTime = DateTime.Now
            };
            UtilDal.PostAnswer(answerVad);
            Navigation.PopModalAsync();
        }
        #endregion

        public async void ErrorHandle(Exception errException)
        {
            await Navigation.PushModalAsync(new ErrorPage(errException));
        }
    }
}
