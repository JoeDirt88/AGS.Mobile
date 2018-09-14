using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AGS.Mobile
{
    public class RandomObject
    {
        public Dry_Skin Dry_Skin { get; set; }
        public Dry_Eyes Dry_Eyes { get; set; }
        public Eye_Anomalies Eye_Anomalies { get; set; }
        public Night_Blindness Night_Blindness { get; set; }
        public Delayed_Growth Delayed_Growth { get; set; }
        public Infections Infections { get; set; }
        public Wound_Healing Wound_Healing { get; set; }
        public Acne Acne { get; set; }

    }

    public class Dry_Skin
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }
    public class Dry_Eyes
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }
    public class Eye_Anomalies
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }
    public class Night_Blindness
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }
    public class Delayed_Growth
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }
    public class Infections
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }
    public class Wound_Healing
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }
    public class Acne
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VADefPage : ContentPage
	{
		public VADefPage ()
		{
			InitializeComponent();
            jSonnify();
        }

        public void jSonnify()
        {
            var qSurvey = UtilDAL.GetSurvey();
            var s = JsonConvert.DeserializeObject<string>(qSurvey);
            var d = JsonConvert.DeserializeObject<RandomObject>(s);
        }
    }
    
    public class SurveyModel
    {
        public List<SurveyQuestion> SurveyQuestions { get; set; }
    }

    public class SurveyQuestion
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }
}