using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AGS.Mobile.Pages;
using AGS.Mobile.Utilities;
using AGS.Mobile.ViewModel;
using Xamarin.Forms;

namespace AGS.Mobile.Views
{
    public partial class ListViewSuccess : ContentPage
    {
        private ObservableCollection<SurveyModel> CntSurvey { get; set; } = new ObservableCollection<SurveyModel>();
        private PatientInfoModel curPatient;
        private int selection;

        public ListViewSuccess(PatientInfoModel patient, int i)
        {
            #region ListViewSetup_Scs_XAML
            InitializeComponent();
            LstViewScs.ItemsSource = CntSurvey;
            curPatient = patient;
            selection = i;
            #endregion
            #region PopulateFromqGetSurvey_Scs
            var qSurvey = UtilDal.GetSurvey("Cnt");

            var patientInfo = new List<string> { patient.Name, patient.Surname, patient.Said };
            var iterator = 0;
            if (qSurvey.Any())
                foreach (var que in qSurvey)
                {
                    CntSurvey.Add(new SurveyModel() { SurQuestion = que.Question, TextData = patientInfo[iterator] , Significance = que.Significance });
                    iterator++;
                }
            else
            {
                ErrorHandle(new Exception($"The patient information database is not connected:"
                                          + $"\r\nPlease ensure that your internet connection is active, and try again."
                                          + $"\r\n"
                                          + $"\r\nIf the problem persists, please contact us on our support page."));
            }
            #endregion
        }

        #region Button_Clicked_Y
        private async void Button_Clicked_Y(object sender, EventArgs e)
        {
            switch (selection)
            {
                case 0:
                    await Navigation.PushModalAsync(new SelectionPage(curPatient));
                    break;
                case 1:
                    // need display screen for results
                    await Navigation.PushModalAsync(new ListViewResults(curPatient));
                    break;
                default:
                    {
                        ErrorHandle(new Exception($"It seems the page you want to visit is under maintenance:"
                                            + $"\r\nPlease try again later."));
                    }
                    break;
            }
        }
        #endregion

        #region Button_Clicked_N
        private async void Button_Clicked_N(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        #endregion

        public async void ErrorHandle(Exception errException)
        {
            await Navigation.PushModalAsync(new ErrorPage(errException));
        }
    }
}
