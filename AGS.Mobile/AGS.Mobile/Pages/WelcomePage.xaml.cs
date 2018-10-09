using System;
using System.Diagnostics;
using System.Reflection;
using Xamarin.Forms;
using AGS.Mobile.Views;

namespace AGS.Mobile.Pages
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            Debug.WriteLine("Hello");
        }

        #region Buttons
        #region Existing Patient
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OLDButton_Clicked(object sender, EventArgs e) => await Navigation.PushModalAsync(new ListViewPatient(0));
        #endregion

        #region New Patient
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NEWButton_Clicked(object sender, EventArgs e) => await Navigation.PushModalAsync(new ListViewClient());
        #endregion

        #region Patient Info
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RESButton_Clicked(object sender, EventArgs e) => await Navigation.PushModalAsync(new ListViewPatient(1));
        #endregion

        #endregion
        
    }
}
