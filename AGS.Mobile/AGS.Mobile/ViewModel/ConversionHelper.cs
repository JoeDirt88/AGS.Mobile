using System;
using System.Collections.Generic;
using System.Text;

namespace AGS.Mobile.ViewModel
{
    internal class ConversionHelper
    {
        /// <summary>
        /// Description:    Quick converter to condition data before POST
        /// </summary>
        /// <param name="tick">Boolean answer from SwitchCell</param>
        /// <returns>string(true = "1", false = "0")</returns>
        public static string Bool2Bin(bool tick)
        {
            return tick == true ? "1" : "0";
        }
    }
}
