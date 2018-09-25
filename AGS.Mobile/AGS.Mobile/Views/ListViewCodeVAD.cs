using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AGS.Mobile
{
	public class ListViewCodeVad : ContentPage
	{
        private ObservableCollection<SurveyModel> Vad_survey { get; set; }

        public ListViewCodeVad ()
		{
            Vad_survey = new ObservableCollection<SurveyModel>();
		    var lstViewVad = new ListView
		    {
		        ItemsSource = Vad_survey, ItemTemplate = new DataTemplate(typeof(SwitchCell))
		    };

		    lstViewVad.ItemTemplate.SetBinding(SwitchCell.TextProperty, "Mquestion");
            lstViewVad.ItemTemplate.SetBinding(SwitchCell.OnProperty, "MisTrue");

		    Content = lstViewVad;

		    var qSurvey = UtilDal.GetSurvey("Vad");

		    var list = JsonConvert.DeserializeObject<List<QModel>>(qSurvey);

            if (!list.Any())
                throw new Exception("API connection issue :/");
            
            foreach (var que in list)
            {
                Vad_survey.Add(new SurveyModel() { Mquestion = que.question, MisTrue = false });
            }
        }
	}
}