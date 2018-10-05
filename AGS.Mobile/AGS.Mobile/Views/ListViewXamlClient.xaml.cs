using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AGS.Mobile.ViewModel;
using Xamarin.Forms;

namespace AGS.Mobile.Views
{
    public partial class ListViewXamlCnt : ContentPage
    {
        private ObservableCollection<SurveyModel> CntSurvey { get; set; } = new ObservableCollection<SurveyModel>();

        public ListViewXamlCnt()
        {
            #region ListViewSetup_Cnt_XAML
            InitializeComponent();
            LstViewCnt.ItemsSource = CntSurvey;
            #endregion
            #region PopulateFromqGetSurvey_Cnt_XAML
            var qSurvey = UtilDal.GetSurvey("Cnt");

            if (qSurvey.Any())
                foreach (var que in qSurvey)
                {
                    CntSurvey.Add(new SurveyModel() {SurQuestion = que.Question, TextData = string.Empty});
                }
            else
                throw new Exception("Survey list is empty for Cnt");
            #endregion
        }

        #region ActionSaveCnt
        private async void Button_Clicked_CNT_save(object sender, EventArgs e)
        {
            // Add on-screen values to a lst
            var list = new List<string>();
            foreach (var item in CntSurvey)
            {
                list.Add(item.TextData);
            }
            // Put list items into model
            var answerCnt = new PatientInfoModel {Name = list[0], Surname = list[1], Said = list[2]};
            // Send the ID number over to the DAL Utility to check the database
            if (UtilDal.QueryNewClient(answerCnt) == true)
            {
                // This means that the creation was a success

                await Navigation.PushModalAsync(new ListViewSuccess(answerCnt, 0));
                // success page needs creation
            }
            else
            {
                // This means a patient with that ID already exists
                throw new Exception(@"This patient already exists");
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
