using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AGS.Mobile.ViewModel;
using Xamarin.Forms;

namespace AGS.Mobile.Views
{
    public partial class ListViewXamlVad : ContentPage
    {
        private ObservableCollection<SurveyModel> VadSurvey { get; set; } = new ObservableCollection<SurveyModel>();
        private PatientInfoModel curPatient;

        public ListViewXamlVad(PatientInfoModel patient)
        {
            curPatient = patient;
            #region ListViewSetup_Vad_XAML
            InitializeComponent();
            LstViewVad.ItemsSource = VadSurvey;
            #endregion
            #region PopulateFromqGetSurvey_Vad_XAML
            var qSurvey = UtilDal.GetSurvey("Vad");

            if (qSurvey.Any())
                foreach (var que in qSurvey)
                {
                    VadSurvey.Add(new SurveyModel() {SurQuestion = que.Question, IsTrue = false});
                }
            else
                throw new Exception("Survey list is empty for Vad");
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
                ParametersVad = list,
                CurDateTime = DateTime.Today,
                Said = curPatient.Said,
                Age = ConversionHelper.GetAge(curPatient)
        };
            UtilDal.PostAnswer(answerVad);
            Navigation.PopModalAsync();
        }
        #endregion
    }
}
