using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AGS.Mobile.Pages;
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
            #region ListViewSetup_Cnt_XAML
            InitializeComponent();
            LstViewScs.ItemsSource = CntSurvey;
            curPatient = patient;
            selection = i;
            #endregion
            #region PopulateFromqGetSurvey_Scs
            var qSurvey = UtilDal.GetSurvey("Cnt");
            var patientInfo = new List<string> {patient.Name, patient.Surname, patient.Said};
            var iterator=0;
            if (qSurvey.Any())
                foreach (var que in qSurvey)
                {
                    CntSurvey.Add(new SurveyModel() {SurQuestion = que.Question, TextData = patientInfo[iterator]});
                    iterator++;
                }
            else
                throw new Exception("Survey list is empty for Cnt");
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
                    throw new Exception("Broke the welcome screen...HOW?");
            }
            await Navigation.PushModalAsync(new SelectionPage(curPatient));
        }
        #endregion

        #region Button_Clicked_N
        private void Button_Clicked_N(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        #endregion
    }
}
