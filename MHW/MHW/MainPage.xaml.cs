using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using SQLite;

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

        private void SearchSelected(object Sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();
                var equip = conn.Query<Armor>("select * from Armor where lower(name) like ?", "%" + (EquipmentKeyword.Text).ToLower() + "%").ToList();
                if(equip[0].name != null)
                    ToBeEquip.Text = equip[0].name;
            }
        }
        private void EquipSelected(object Sender, EventArgs e)
        {

        }

    }
}
