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

        public ListViewXamlPnt()
        {
            #region ListViewSetup_Pnt_XAML
            InitializeComponent();
            LstViewPnt.ItemsSource = PntSurvey;
            #endregion
            #region PopulateFromqGetSurvey_Pnt_XAML
            var qSurvey = UtilDal.GetSurvey("Cnt");

            if (qSurvey.Any())
                foreach (var que in qSurvey)
                {
                    PntSurvey.Add(new SurveyModel() {SurQuestion = que.Question, TextData = string.Empty});
                }
            else
                throw new Exception("Survey list is empty for Cnt");
            #endregion
        }

        #region ActionSaveCnt
        private async void Button_Clicked_PNT_save(object sender, EventArgs e)
        {
            // Add on-screen values to a lst
            var list = new List<string>();
            foreach (var item in PntSurvey)
            {
                list.Add(item.TextData);
            }
            // Put list items into model
            var answerCnt = new PatientInfoModel {Name = list[0], Surname = list[1], Said = list[2]};
            // Send the ID number over to the DAL Utility to check the database

            if (UtilDal.QueryClient(answerCnt) != null)
            {
                // Call PatientInfoGet
                var patient = UtilDal.QueryClient(answerCnt);
                await Navigation.PushModalAsync(new SelectionPage(patient));
                // success page needs creation
            }
            else
            {
                // This means a patient with that ID already exists
                throw new Exception(@"This patient doesn't exists");
                // Error page needs creation
            }
        }
        #endregion
        
    }
}
