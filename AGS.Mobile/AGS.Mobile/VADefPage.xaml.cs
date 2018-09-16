using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections;
using System.Text.RegularExpressions;

namespace AGS.Mobile
{
    

    /*
    public class RandomObject
    {
        public Symptoms Symptoms { get; set; }
    }

    public class Symptoms
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

    public interface ISymptoms
    {
        string Question { get; set; }
        float Significance { get; set; }
    }

    public class Symptom
    {
        public string Question { get; set; }

        public Symptom()
        {
            
        }

        public Symptom(string question)
        {
            Question = question;
        }

       
    }

    public class Dry_Skin : ISymptoms
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }
    public class Dry_Eyes : ISymptoms
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }
    public class Eye_Anomalies : ISymptoms
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }
    public class Night_Blindness : ISymptoms
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }
    public class Delayed_Growth : ISymptoms
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }
    public class Infections : ISymptoms
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }
    public class Wound_Healing : ISymptoms
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }
    public class Acne : ISymptoms
    {
        public string Question { get; set; }
        public float Significance { get; set; }
    }*/

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VADefPage : ContentPage
	{
		public VADefPage ()
		{
			InitializeComponent();
            Jsonnify();
        }

        public void Jsonnify()
        {
            var qSurvey = UtilDAL.GetSurvey();
            //qSurvey = qSurvey.Substring(1, qSurvey.Length - 2);
            //var something1 = qSurvey.((<char>(c => c == '"'));
            //qSurvey.Remove

            //var mJson = "\"{\\r\\n    \\\"Symptoms\\\" : " + qSurvey + "\\r\\n }\"";

            var s = JsonConvert.DeserializeObject<string>(qSurvey);
            var d = JsonConvert.DeserializeObject<RootObject>(s);

            /* Regex done by Shaun

            char dQ = '"';

            Regex regex = new Regex($@"Question\{dQ}: {dQ}(.*?)\{dQ}", RegexOptions.Multiline);

           string pattern = $@"Question\{dQ}: {dQ}(.*?)\{dQ}";
            var list = new List<Symptom>();
            Regex ItemRegex = new Regex($@"Question\{dQ}: {dQ}(.*?)\{dQ}", RegexOptions.Multiline);
            foreach (Match ItemMatch in ItemRegex.Matches(qSurvey))
            {
                list.Add(new Symptom(ItemMatch.Groups[0].Value));
            }
            */

        }

        public class Symptom
        {
            public string Question { get; set; }
            public double Significance { get; set; }
        }

        public class RootObject
        {
            public List<Symptom> Symptoms { get; set; }
        }
    }
}