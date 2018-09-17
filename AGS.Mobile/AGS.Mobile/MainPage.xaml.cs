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

    public partial class MainPage : ContentPage
    {
        public MainPage()
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
            await Navigation.PushModalAsync(new MainPage());
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

       /* private async void metbutton_clicked(object sender, eventargs e)
        {
            var qsurvey = utildal.getsurvey("9");

            var list = new list<symptom>();
            regex questioncontentregex = new regex(@"question\\\"": \\""(.*?)\\\""", regexoptions.multiline);
            foreach (match matches in questioncontentregex.matches(qsurvey))
            {
                list.add(new symptom(matches.groups[1].value));
            }

            stacklayout layout = new stacklayout { orientation = stackorientation.vertical };

            if (!list.any())
            {
                layout.children.add(new label { text = "no results." });
                await navigation.pushmodalasync(new vadefpage { content = layout });
            }
            else
            {
                foreach (var question in list)
                {
                    layout.children.add(new label { text = question.question });
                }

                await navigation.pushmodalasync(new vadefpage { content = layout });
            }
        }*/
    }
}
