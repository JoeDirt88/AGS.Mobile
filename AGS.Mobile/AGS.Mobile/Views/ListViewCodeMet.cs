using System;
using System.Collections.ObjectModel;
using System.Linq;
using AGS.Mobile.ViewModel;
using Xamarin.Forms;

namespace AGS.Mobile.Views
{
    public class ListViewCodeMet : ContentPage
	{
        private ObservableCollection<SurveyModel> MetSurvey { get; set; } = new ObservableCollection<SurveyModel>();

	    public ListViewCodeMet ()
		{
            #region ListViewSetup_Met
            var lstViewMet = new ListView
		    {
		        ItemsSource = MetSurvey,
		        ItemTemplate = new DataTemplate(typeof(EntryCell))
		    };
		    // Bind inputs
            lstViewMet.ItemTemplate.SetBinding(EntryCell.LabelProperty, "SurQuestion");
            lstViewMet.ItemTemplate.SetBinding(EntryCell.TextProperty, "TextData");
		    // Set content value
            Content = lstViewMet;
            #endregion
            #region PopulateFromqGetSurvey_Met
            var qSurvey = UtilDal.GetSurvey("Met");

		    if (qSurvey.Any())
		        foreach (var que in qSurvey)
		        {
		            MetSurvey.Add(new SurveyModel {SurQuestion = que.Question, TextData = string.Empty});
		        }
		    else
		        throw new Exception("Survey list is empty for Mat");
            #endregion
		}
	}
}