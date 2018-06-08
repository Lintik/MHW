using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using SQLite;
using MHW.Model;

namespace MHW.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        //Navigate to Database
        public void DB_Activated(object sender, EventArgs e)
		{
		    Navigation.PushAsync(new Compendium() { Title = "Database"});
		}

        //Navigate to Builder
        public void BD_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Builder() { Title = "Builder" });
        }
       
    }
}
