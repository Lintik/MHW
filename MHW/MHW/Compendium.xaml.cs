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

            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();

                var equip = conn.Query<Armor>("select * from Armor where lower(name) like ?","%" + keyword.ToLower() + "%").ToList();
                MHWDBListView.ItemsSource = equip;
            }
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