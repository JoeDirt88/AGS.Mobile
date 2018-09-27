using System;
using System.Collections.Generic;
using System.Dynamic;

namespace AGS.Mobile.ViewModel
{
    public class SurveyModel
    {
        public string SurQuestion { get; set; }
        public bool IsTrue { get; set; }
        public string TextData { get; set; }
    }

    public class QuestionInfoModel
    {
        public string Qid { get; set; }
        public string Question { get; set; }
    }

    public class PatientInfoModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Said { get; set; }
    }

    public class AnswerModel
    {
        public string Said { get; set; }
        public DateTime CurDateTime { get; set; }
        public List<string> ParametersVad { get; set; }
        public string Age { get; set; }
        public string Waist { get; set; }
        public string Systolic { get; set; }
    }
}
