using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AGS.Mobile
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Description:    Takes the user to existing patient page
        /// Status:         Creating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OLDButton_Clicked(object sender, EventArgs e)
        {
            // Send to the patient search page
            await Navigation.PushModalAsync(new WelcomePage());
        }

        /// <summary>
        /// Description:    Takes user to the create new patient file page
        /// Status:         Creating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NEWButton_Clicked(object sender, EventArgs e)
        {
            // Send to the patient create page
            await Navigation.PushModalAsync(new ListViewXamlCnt());
        }

        /// <summary>
        /// Description:    Takes user to patient results page
        /// Status:         Implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RESButton_Clicked(object sender, EventArgs e)
        {
            // Send to the patient search page
            await Navigation.PushModalAsync(new WelcomePage());
        }
    }
}
