using System;
using System.Diagnostics;
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

        #region ExistingPatientBTN
        /// <summary>
        /// Description:    Takes the user to existing patient page
        /// Status:         Creating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OLDButton_Clicked(object sender, EventArgs e) => await Navigation.PushModalAsync(new WelcomePage());
        #endregion
        #region NewPatientBTN
        /// <summary>
        /// Description:    Takes user to the create new patient file page
        /// Status:         Implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NEWButton_Clicked(object sender, EventArgs e) => await Navigation.PushModalAsync(new ListViewXamlCnt());
        #endregion
        #region PatientInfoBTN
        /// <summary>
        /// Description:    Takes user to patient results page
        /// Status:         Implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RESButton_Clicked(object sender, EventArgs e) => await Navigation.PushModalAsync(new WelcomePage());
        #endregion
    }
}
