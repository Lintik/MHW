using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;

using MHW.Model;

namespace MHW.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Compendium : ContentPage
    {
        public Compendium()
        {
            InitializeComponent();
        }

        private void SortBy()
        {

        }

        //Search database on button pressed
        private void SearchMHWDB(object sender, EventArgs e)
        {
            var keyword = MainSearchBar.Text;

            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();

                var equip = conn.Query<Armor>("select * from Armor left join Armorset using(armorset) where lower(name) like ? UNION select * from Armor left join Armorset using(armorset)  where lower(att1) like ? UNION select * from Armor left join Armorset using(armorset) where lower(att2) like ? order by id desc",
                   "%" + keyword.ToLower() + "%",
                   "%" + keyword.ToLower() + "%",
                   "%" + keyword.ToLower() + "%").ToList();
                MHWDBListView.ItemsSource = equip;
            }
        }

        //Search database on text changed
        private void TextChangedMHWDB(object sender, EventArgs e)
        {
            var keyword = MainSearchBar.Text;

            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();

                var equip = conn.Query<Armor>("select Armor.*, ArmorSet.* from Armor left join Armorset using(armorset) where lower(name) like ? UNION select Armor.*, ArmorSet.* from Armor left join Armorset using(armorset)  where lower(att1) like ? UNION select Armor.*, ArmorSet.* from Armor left join Armorset using(armorset) where lower(att2) like ? order by id desc",
                   "%" + keyword.ToLower() + "%",
                   "%" + keyword.ToLower() + "%",
                   "%" + keyword.ToLower() + "%").ToList();
                MHWDBListView.ItemsSource = equip;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();

                var equip = conn.Query<Armor>("select Armor.*, ArmorSet.* from Armor left join Armorset using(armorset)").ToList();

                MHWDBListView.ItemsSource = equip;
            }
        }
    }
}  