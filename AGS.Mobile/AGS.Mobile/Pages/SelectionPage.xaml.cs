using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AGS.Mobile
{
    public class Symptom
    {
        public string Question { get; set; }

        public Symptom(string question)
        {
            Question = question;
        }
    }

    public partial class SelectionPage : ContentPage
    {
        public SelectionPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Description:    This button event takes the user to the Vitamin A deficiency module
        /// Status:         Implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void VADButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListViewXamlVad());
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
            await Navigation.PushModalAsync(new SelectionPage());
        }

        /// <summary>
        /// Description:    This button event takes the user to the Metabolic Syndrome module
        /// Status:         Implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MetButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListViewXamlMet());
        }
    }
}
