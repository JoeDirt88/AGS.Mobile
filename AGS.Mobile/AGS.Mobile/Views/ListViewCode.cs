using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace AGS.Mobile
{
	public class ListViewCode : ContentPage
	{
        private ObservableCollection<SurveyModel> survey { get; set; }

        public ListViewCode ()
		{
            survey = new ObservableCollection<SurveyModel>();
            ListView lstView = new ListView();
            lstView.ItemsSource = survey;

            //TODO - uncomment the region for the built-in cell type you'd like to see
            /*#region textCell
			lstView.ItemTemplate = new DataTemplate (typeof(TextCell));
			lstView.ItemTemplate.SetBinding (TextCell.TextProperty, "name");
			lstView.ItemTemplate.SetBinding (TextCell.DetailProperty, "comment");
			#endregion*/

            /*#region imageCell
			lstView.ItemTemplate = new DataTemplate (typeof(ImageCell));
			lstView.ItemTemplate.SetBinding (ImageCell.TextProperty, "name");
			lstView.ItemTemplate.SetBinding (ImageCell.DetailProperty, "comment");
			lstView.ItemTemplate.SetBinding(ImageCell.ImageSourceProperty, "image");
			#endregion*/

            #region switchCell
            lstView.ItemTemplate = new DataTemplate(typeof(SwitchCell));
            lstView.ItemTemplate.SetBinding(SwitchCell.TextProperty, "question");
            lstView.ItemTemplate.SetBinding(SwitchCell.OnProperty, "isTrue");
            #endregion

            /*#region entryCell
			lstView.ItemTemplate = new DataTemplate(typeof(EntryCell));
			lstView.ItemTemplate.SetBinding(EntryCell.LabelProperty, "name");
			lstView.ItemTemplate.SetBinding(EntryCell.TextProperty, "comment");
			#endregion*/

            Content = lstView;
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
                survey.Add(new SurveyModel() { question = que.Question, isTrue = false });
            }
        }
	}
}