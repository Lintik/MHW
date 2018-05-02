using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using SQLite;
using MHW.Model;

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

        private void SearchSelected(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();

                var equip = conn.Table<Armor>().ToList();
                
                if(equip[0].name != null)
                {
                    ToBeEquip.Text = equip[0].name;
                }
            }
        }

        private void EquipSelected(object sender, EventArgs e)
        {

        }
    }
}
