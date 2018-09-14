using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AGS.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void VADButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new VADefPage());
        }

        private async void BitButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new VADefPage());
        }

        private async void MetButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new VADefPage());
        }
    }
}
