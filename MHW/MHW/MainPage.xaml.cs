using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MHW
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
		
		public void DB_Activated(object sender, EventArgs e)
		{
		    Navigation.PushAsync(new Compendium());
		}
	}
}
