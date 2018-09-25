﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AGS.Mobile
{
	public class ListViewCodeMet : ContentPage
	{
        private ObservableCollection<SurveyModel> Met_survey { get; set; }

        public ListViewCodeMet ()
		{
            Met_survey = new ObservableCollection<SurveyModel>();
		    var lstViewMet = new ListView
		    {
		        ItemsSource = Met_survey, ItemTemplate = new DataTemplate(typeof(EntryCell))
		    };

		    lstViewMet.ItemTemplate.SetBinding(EntryCell.LabelProperty, "Mquestion");
            lstViewMet.ItemTemplate.SetBinding(EntryCell.TextProperty, "Mdata");
			
            Content = lstViewMet;
		    var qSurvey = UtilDal.GetSurvey("Met");

		    var list = JsonConvert.DeserializeObject<List<QModel>>(qSurvey);
            
            if (!list.Any())
                throw new Exception("API connection issue :/");
            
            foreach (var que in list)
            {
                Met_survey.Add(new SurveyModel() { Mquestion = que.question, Mdata = string.Empty });
            }
        }
	}
}