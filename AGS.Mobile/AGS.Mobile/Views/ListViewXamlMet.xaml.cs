using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AGS.Mobile.ViewModel;
using Xamarin.Forms;

namespace AGS.Mobile.Views
{
    public partial class ListViewXamlMet : ContentPage
    {
        private ObservableCollection<SurveyModel> MetSurvey { get; set; } = new ObservableCollection<SurveyModel>();

        public ListViewXamlMet()
        {
            #region ListViewSetup_Met_XAML
            InitializeComponent();
            LstViewMet.ItemsSource = MetSurvey;
            #endregion
            #region PopulateFromqGetSurvey_Met_XAML
            var qSurvey = UtilDal.GetSurvey("Met");

            if (qSurvey.Any())
                foreach (var que in qSurvey)
                {
                    MetSurvey.Add(new SurveyModel() {SurQuestion = que.Question, TextData = string.Empty});
                }
            else
                throw new Exception("Survey list is empty for Met");
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
            var answerMet = new AnswerModel {Waist = list[0], Systolic = list[1], Age = "2"};

            UtilDal.PostAnswer(answerMet);
            Navigation.PopModalAsync();
        }
        #endregion
        
    }
}
