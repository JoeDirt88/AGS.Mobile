using System;
using Xamarin.Forms;

namespace AGS.Mobile.Pages
{
    public partial class ErrorPage : ContentPage
    {
        public ErrorPage(Exception error)
        {
            InitializeComponent();
            HeadLabel.Text = "There seems to be a problem:";
            ErrLabel.Text = error.Message;
        }

        private async void Button_Clicked_RET(object sender, EventArgs e)
        {
            for (var i = 0; i < (Navigation.ModalStack.Count); i++)
            {
                Navigation.PopModalAsync();
            }
            await Navigation.PopModalAsync();
        }
    }
}
