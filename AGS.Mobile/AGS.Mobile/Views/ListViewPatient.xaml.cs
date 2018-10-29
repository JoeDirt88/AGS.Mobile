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
    public partial class ListViewPatient : ContentPage
    {
        private ObservableCollection<SurveyModel> PntSurvey { get; set; } = new ObservableCollection<SurveyModel>();
        private int selection;

        public ListViewPatient(int i)
        {
            #region ListViewSetup_Pnt_XAML
            InitializeComponent();
            LstViewPnt.ItemsSource = PntSurvey;
            selection = i;
            #endregion
            #region PopulateFromqGetSurvey_Pnt_XAML
            var qSurvey = UtilDal.GetSurvey("Cnt"); // MODULE
            if (qSurvey == null)
            {
                ErrorHandle(new Exception($"Response from server API Failed.\r\n\r\n"
                                          + "Please ensure that you are connected to the internet and try again"));
            }
            else
            {
                foreach (var que in qSurvey)
                {
                    PntSurvey.Add(new SurveyModel() { SurQuestion = que.Question, TextData = string.Empty , Significance = que.Significance });
                }
                PntSurvey.RemoveAt(0);
                PntSurvey.RemoveAt(0);
            }
            #endregion
        }

        #region ActionSavePatient
        private async void Button_Clicked_PNT_save(object sender, EventArgs e)
        {
            // Add on-screen values to a lst
            var list = string.Empty;
            foreach (var item in PntSurvey)
            {
                list = item.TextData;
            }
            // Put list items into model
            var answerCnt = new PatientInfoModel {Name = string.Empty, Surname = string.Empty, Said = list};

            var patient = UtilDal.QueryClient(answerCnt);
            if (patient.Said!="0")
            {
                await Navigation.PushModalAsync(new ListViewSuccess(patient, selection));
            }
            else
            {
                ErrorHandle(new Exception($"This entry doesn't exists for ID: \r\n{answerCnt.Said}"));
            }
        }
        #endregion

        private async void Button_Clicked_RET(object sender, EventArgs e) => await Navigation.PopModalAsync();
        
        public async void ErrorHandle(Exception errException) => await Navigation.PushModalAsync(new ErrorPage(errException));
        
    }
}
