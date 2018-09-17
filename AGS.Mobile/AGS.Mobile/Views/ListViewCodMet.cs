﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace AGS.Mobile
{
	public class ListViewCodeMet : ContentPage
	{
        private ObservableCollection<SurveyModel> Met_survey { get; set; }

        public ListViewCodeMet ()
		{
            Met_survey = new ObservableCollection<SurveyModel>();
            ListView lstViewMet = new ListView();
            lstViewMet.ItemsSource = Met_survey;

            lstViewMet.ItemTemplate = new DataTemplate(typeof(EntryCell));
            lstViewMet.ItemTemplate.SetBinding(EntryCell.LabelProperty, "Mquestion");
            lstViewMet.ItemTemplate.SetBinding(EntryCell.TextProperty, "Mdata");
			
            Content = lstViewMet;
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
                Met_survey.Add(new SurveyModel() { Mquestion = que.Question, Mdata = string.Empty });
            }
        }
	}
}