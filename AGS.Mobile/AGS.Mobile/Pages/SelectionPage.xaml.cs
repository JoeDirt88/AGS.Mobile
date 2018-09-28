using System;
using AGS.Mobile.ViewModel;
using AGS.Mobile.Views;
using Xamarin.Forms;

namespace AGS.Mobile.Pages
{
    

    public partial class SelectionPage : ContentPage
    {
        private PatientInfoModel curPatient;

        public SelectionPage(PatientInfoModel patient)
        {
            InitializeComponent();
            curPatient = patient;

        }

        /// <summary>
        /// Description:    This button event takes the user to the Vitamin A deficiency module
        /// Status:         Implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void VADButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListViewXamlVad(curPatient));
        }

        /// <summary>
        /// Description:    This button event takes the user to the Bitot's Spot module
        /// Status:         Not Implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BitButton_Clicked(object sender, EventArgs e)
        {
            // does nothing yet
            await Navigation.PushModalAsync(new SelectionPage(curPatient));
        }

        /// <summary>
        /// Description:    This button event takes the user to the Metabolic Syndrome module
        /// Status:         Implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MetButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListViewXamlMet(curPatient));
        }
    }
}
