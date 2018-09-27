using System;
using System.Collections.ObjectModel;
using System.Linq;
using AGS.Mobile.ViewModel;
using Xamarin.Forms;

namespace AGS.Mobile.Views
{
    public class ListViewCodeVad : ContentPage
	{
        private ObservableCollection<SurveyModel> VadSurvey { get; set; } = new ObservableCollection<SurveyModel>();

	    public ListViewCodeVad ()
		{
		    #region ListViewSetup_Vad
            var lstViewVad = new ListView
		    {
		        ItemsSource = VadSurvey,
		        ItemTemplate = new DataTemplate(typeof(SwitchCell))
		    };
            // Bind inputs
		    lstViewVad.ItemTemplate.SetBinding(SwitchCell.TextProperty, "SurQuestion");
            lstViewVad.ItemTemplate.SetBinding(SwitchCell.OnProperty, "IsTrue");
            // Set content value
		    Content = lstViewVad;
            #endregion
		    #region PopulateFromqGetSurvey_Vad
            var qSurvey = UtilDal.GetSurvey("Vad");

		    if (qSurvey.Any())
		        foreach (var que in qSurvey)
		        {
		            VadSurvey.Add(new SurveyModel {SurQuestion = que.Question, IsTrue = false});
		        }
		    else
		        throw new Exception("Survey list is empty for Vad");
		    #endregion
		}
	}
}