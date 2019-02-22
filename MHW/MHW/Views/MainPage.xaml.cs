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
	public partial class MainPage : TabbedPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        void GoToEquipmentPage (object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new EquipmentPage());
        }

    }

    
}
