using System;
using System.Collections.ObjectModel;
using System.Linq;
using AGS.Mobile.ViewModel;
using Xamarin.Forms;

namespace AGS.Mobile.Views
{
	public class ListViewCodeCnt : ContentPage
	{
        private ObservableCollection<SurveyModel> CntSurvey { get; set; } = new ObservableCollection<SurveyModel>();

	    public ListViewCodeCnt()
		{
            #region ListViewSetup_Cnt
            var lstViewMet = new ListView
		    {
		        ItemsSource = CntSurvey,
		        ItemTemplate = new DataTemplate(typeof(EntryCell))
		    };
		    // Bind inputs
            lstViewMet.ItemTemplate.SetBinding(EntryCell.LabelProperty, "SurQuestion");
		    lstViewMet.ItemTemplate.SetBinding(EntryCell.TextProperty, "TextData");
		    // Set content value
            Content = lstViewMet;
            #endregion
            #region PopulateFromqGetSurvey_Cnt
            var qSurvey = UtilDal.GetSurvey("Cnt");
            
		    if (qSurvey.Any())
		        foreach (var que in qSurvey)
		        {
		            CntSurvey.Add(new SurveyModel {SurQuestion = que.Question, TextData = string.Empty});
		        }
		    else
		        throw new Exception("Survey list is empty for Cnt");
            #endregion
		}
	}
}