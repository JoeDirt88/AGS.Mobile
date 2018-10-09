using System;
using AGS.Mobile.Utilities;
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
            SelLabel.Text = "Please select the screening test that you would like to run for: "
                            + patient.Name
                            + " "
                            + patient.Surname;
        }

        /// <summary>
        /// Description:    This button event takes the user to the Vitamin A deficiency module
        /// Status:         Implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void VADButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListViewModVad(curPatient));
        }

        /// <summary>
        /// Description:    This button event takes the user to the Metabolic Syndrome module
        /// Status:         Implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MetButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListViewModMet(curPatient));
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
