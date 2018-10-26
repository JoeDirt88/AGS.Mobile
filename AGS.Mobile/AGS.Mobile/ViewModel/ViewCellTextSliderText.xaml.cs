using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AGS.Mobile.ViewModel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewCellTextSliderText : ViewCell
	{
		public ViewCellTextSliderText ()
		{
			InitializeComponent ();
		}

	    private void Slider_OnValueChanged(object sender, ValueChangedEventArgs e)
	    {
	        // nothing happens yet
	    }
	}
}