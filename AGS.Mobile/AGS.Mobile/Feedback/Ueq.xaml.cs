using System;
using System.Collections.ObjectModel;
using System.Linq;
using AGS.Mobile.Pages;
using AGS.Mobile.Utilities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AGS.Mobile.Feedback
{
    public partial class Ueq : ContentPage
    {
        private ObservableCollection<UxSurvey> FbSurvey { get; set; } = new ObservableCollection<UxSurvey>();
        private int StepValue = 1;

        public Ueq()
        {
            InitializeComponent();
            SurveyList.ItemsSource = FbSurvey;

            var qSurvey = UtilDal.FeedbackSurvey();

            if (qSurvey.Any())
                foreach (var que in qSurvey)
                {
                    FbSurvey.Add(new UxSurvey() { Question = que.Question, Left = que.Left, Slider = 2, Right = que.Right });
                }
            else
            {
                ErrorHandle(new Exception($"Survey list was accessible for Vitamin A Deficiency screening:"
                                          + $"\r\nPlease ensure that your internet connection is active, and try again."
                                          + $"\r\n"
                                          + $"\r\nIf the problem persists, please contact us on our support page."));
            }
        }


        #region Controllers

        private async void BTN_NXT(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void BTN_RET(object sender, EventArgs e)
        {
            for (var i = 0; i < (Navigation.ModalStack.Count-1); i++)
            {
                Navigation.PopModalAsync();
            }
            await Navigation.PopModalAsync();
        }

        #endregion

        private void Slider_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public async void ErrorHandle(Exception errException)
        {
            await Navigation.PushModalAsync(new ErrorPage(errException));
        }
    }
}