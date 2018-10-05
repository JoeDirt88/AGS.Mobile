using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AGS.Mobile.Pages;
using AGS.Mobile.ViewModel;
using Xamarin.Forms;

namespace AGS.Mobile.Views
{
    public partial class ListViewXamlPnt : ContentPage
    {
        private ObservableCollection<SurveyModel> PntSurvey { get; set; } = new ObservableCollection<SurveyModel>();
        // This determines the case outcome for why the patient search is being done
        private int selection;

        public ListViewXamlPnt(int i)
        {
            #region ListViewSetup_Pnt_XAML
            InitializeComponent();
            LstViewPnt.ItemsSource = PntSurvey;
            selection = i;
            #endregion
            #region PopulateFromqGetSurvey_Pnt_XAML
            var qSurvey = UtilDal.GetSurvey("Cnt");

            if (qSurvey.Any())
            {
                foreach (var que in qSurvey)
                {
                    PntSurvey.Add(new SurveyModel() { SurQuestion = que.Question, TextData = string.Empty });
                }
                PntSurvey.RemoveAt(0);
                PntSurvey.RemoveAt(0);
            }
            else
                throw new Exception("Survey list is empty for Cnt");
            #endregion
        }

        #region ActionSaveCnt
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
            // Send the ID number over to the DAL Utility to check the database
            var patient = UtilDal.QueryClient(answerCnt);
            if (patient.Said!="0")
            {
                await Navigation.PushModalAsync(new ListViewSuccess(patient, selection));
            }
            else
            {
                // This means a patient with that ID already exists
                throw new Exception(@"This patient doesn't exists");
                // Error page needs creation
            }
        }
        #endregion

        private async void Button_Clicked_RET(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
