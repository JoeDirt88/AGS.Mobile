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
            /*
            var qSurvey = UtilDAL.GetSurvey();

            var list = new List<Symptom>();
            Regex QuestionContentRegex = new Regex(@"Question\\\"": \\""(.*?)\\\""", RegexOptions.Multiline);
            foreach (Match matches in QuestionContentRegex.Matches(qSurvey))
            {
                list.Add(new Symptom(matches.Groups[1].Value));
            }

            if (!list.Any())
                throw new Exception("API connection issue :/");

            var layout = new StackLayout
            {   Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            
            foreach (var question in list)
            {
                layout.Children.Add(new Label { Text = question.Question });
                layout.Children.Add(new Switch { IsToggled = false});
            }
            */
            
            await Navigation.PushModalAsync(new ListViewXaml());
        }

        private async void BitButton_Clicked(object sender, EventArgs e)
        {
            var qSurvey = UtilDAL.GetSurvey("2");

            var list = new List<Symptom>();
            Regex QuestionContentRegex = new Regex(@"Question\\\"": \\""(.*?)\\\""", RegexOptions.Multiline);
            foreach (Match matches in QuestionContentRegex.Matches(qSurvey))
            {
                list.Add(new Symptom(matches.Groups[1].Value));
            }

            if (!list.Any())
                throw new Exception("API connection issue :/");

            StackLayout layout = new StackLayout { Orientation = StackOrientation.Vertical };

            foreach (var question in list)
            {
                layout.Children.Add(new Label { Text = question.Question });
            }

            await Navigation.PushModalAsync(new VADefPage { Content = layout });
        }

        private async void MetButton_Clicked(object sender, EventArgs e)
        {
            var qSurvey = UtilDAL.GetSurvey("9");

            var list = new List<Symptom>();
            Regex QuestionContentRegex = new Regex(@"Question\\\"": \\""(.*?)\\\""", RegexOptions.Multiline);
            foreach (Match matches in QuestionContentRegex.Matches(qSurvey))
            {
                list.Add(new Symptom(matches.Groups[1].Value));
            }

            StackLayout layout = new StackLayout { Orientation = StackOrientation.Vertical };

            if (!list.Any())
            {
                layout.Children.Add(new Label { Text = "No Results." } );
                await Navigation.PushModalAsync(new VADefPage { Content = layout });
            }
            else
            {
                foreach (var question in list)
                {
                    layout.Children.Add(new Label { Text = question.Question });
                }

                await Navigation.PushModalAsync(new VADefPage { Content = layout });
            }
        }
    }
}
