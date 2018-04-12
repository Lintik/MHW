using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#pragma warning disable 0436

namespace MHW
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Compendium : ContentPage
    {
        public Compendium()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();

                var equip = conn.Table<Armor>().ToList();
                SQLiteListView.ItemsSource = equip;
            }
        }
    }


}