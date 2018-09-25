using System;
using System.Collections.Generic;
using System.Text;

namespace AGS.Mobile
{
    public class SurveyModel
    {
        public string Mquestion { get; set; }
        public bool MisTrue { get; set; }
        public string Mdata { get; set; }
    }

    public class QModel
    {
        public string qID { get; set; }
        public string question { get; set; }
    }

    public class CModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Said { get; set; }
    }
}
