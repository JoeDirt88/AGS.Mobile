using System;
using System.Collections.ObjectModel;
using System.Linq;
using AGS.Mobile.ViewModel;
using Xamarin.Forms;

namespace AGS.Mobile.Views
{
    public partial class ListViewResults : ContentPage
    {
        private ObservableCollection<ResultModel> ResSurvey { get; set; } = new ObservableCollection<ResultModel>();
       
        public ListViewResults(PatientInfoModel patient)
        {
            // Initialise ListView
            #region ListViewSetup_Res_XAML
            InitializeComponent();
            LstResults.ItemsSource = ResSurvey;
            #endregion
            // Populate view with data
            #region PopulateFromqGetSurvey_Res
            var qSurvey = UtilDal.GetResultList(patient.Said);
            
            if (qSurvey.Any())
                foreach (var que in qSurvey)
                {
                    ResSurvey.Add(
                        new ResultModel()
                        {
                            ModuleId = que.ModuleId,
                            Result = que.Result,
                            CurDateTime = que.CurDateTime,
                            Screened = que.Screened
                        });
                }
            else
                throw new Exception("Survey list is empty for Cnt");
            #endregion
        }

        private async void Button_Clicked_RET(object sender, EventArgs e)
        {
            for (var i = 0; i < (Navigation.ModalStack.Count + 1); i++)
            {
                Navigation.PopModalAsync();
            }
            await Navigation.PopModalAsync();
        }
    }
}
