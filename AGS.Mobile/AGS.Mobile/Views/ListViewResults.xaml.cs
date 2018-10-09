using System;
using System.Collections.ObjectModel;
using AGS.Mobile.Pages;
using AGS.Mobile.Utilities;
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
            LstViewRes.ItemsSource = ResSurvey;
            NameViewRes.Text = "Results for: " + patient.Name + " " + patient.Surname;
            #endregion
            // Populate view with data
            #region PopulateFromqGetSurvey_Res
            var qSurvey = UtilDal.GetResultList(patient.Said); //VALUES

            if (qSurvey == null)
            {
                ErrorHandle(new Exception($"Result list is empty for Patient with ID: \r\n{patient.Said}"));
            }
            else
            {
                foreach (var que in qSurvey)
                {
                    ResSurvey.Add(
                        new ResultModel
                        {
                            ModuleId = UtilDal.QueryModule(que.ModuleId),
                            Result = ConversionHelper.ScreenConvert(que.Result),
                            CurDateTime = que.CurDateTime,
                            Screened = que.Screened
                        });
                }
            }

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

        public async void ErrorHandle(Exception errException)
        {
            await Navigation.PushModalAsync(new ErrorPage(errException));
        }
    }
}
