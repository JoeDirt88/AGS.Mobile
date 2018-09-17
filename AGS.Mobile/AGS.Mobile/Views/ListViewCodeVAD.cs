using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace AGS.Mobile
{
	public class ListViewCodeVad : ContentPage
	{
        private ObservableCollection<SurveyModel> Vad_survey { get; set; }

        public ListViewCodeVad ()
		{
            Vad_survey = new ObservableCollection<SurveyModel>();
            ListView lstViewVad = new ListView();
            lstViewVad.ItemsSource = Vad_survey;

            lstViewVad.ItemTemplate = new DataTemplate(typeof(SwitchCell));
            lstViewVad.ItemTemplate.SetBinding(SwitchCell.TextProperty, "Mquestion");
            lstViewVad.ItemTemplate.SetBinding(SwitchCell.OnProperty, "MisTrue");
            
            Content = lstViewVad;
            var qSurvey = UtilDAL.GetSurvey();

            var list = new List<Symptom>();

            Regex QuestionContentRegex = new Regex(@"Question\\\"": \\""(.*?)\\\""", RegexOptions.Multiline);
            foreach (Match matches in QuestionContentRegex.Matches(qSurvey))
            {
                list.Add(new Symptom(matches.Groups[1].Value));
            }

            if (!list.Any())
                throw new Exception("API connection issue :/");
            
            foreach (var que in list)
            {
                Vad_survey.Add(new SurveyModel() { Mquestion = que.Question, MisTrue = false });
            }
        }
	}
}