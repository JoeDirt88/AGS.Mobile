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

        private async void VADButton_Clicked(object sender, EventArgs e)
        {
            var qSurvey = UtilDAL.GetSurvey();

            var list = new List<Symptom>();
            Regex QuestionContentRegex = new Regex(@"Question\\\"": \\""(.*?)\\\""", RegexOptions.Multiline);
            foreach (Match matches in QuestionContentRegex.Matches(qSurvey))
            {
                list.Add(new Symptom(matches.Groups[1].Value));
            }

            StackLayout layout = new StackLayout { Orientation = StackOrientation.Vertical };

            foreach (var question in list)
            {
                layout.Children.Add(new Checkbox());
                layout.Children.Add(new Label { Text = question.Question });
            }

            await Navigation.PushModalAsync(new VADefPage { Content = layout });
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
