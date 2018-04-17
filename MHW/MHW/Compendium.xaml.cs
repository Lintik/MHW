using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

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

        private void SearchMHWDB(object sender, EventArgs e)
        {
            var keyword = MainSearchBar.Text;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();

                var equip = conn.Table<Armor>().ToList();
                MHWDBListView.ItemsSource = equip;
            }
        }
    }


}  