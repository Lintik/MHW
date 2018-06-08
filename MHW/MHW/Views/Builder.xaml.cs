using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;

using MHW.Model;

namespace MHW.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Builder : ContentPage
	{
		public Builder ()
		{
			InitializeComponent ();
		}

        //Retain the memory of equipped items
        protected override void OnAppearing()
        {
            base.OnAppearing();

            Head.Text = Equipment.head;
            Body.Text = Equipment.body;
            Arms.Text = Equipment.arms;
            Waist.Text = Equipment.waist;
            Legs.Text = Equipment.legs;
            Size1.Text = Equipment.SlotCount[0].ToString();
            Size2.Text = Equipment.SlotCount[1].ToString();
            Size3.Text = Equipment.SlotCount[2].ToString();
            SkillsListView.ItemsSource = Equipment.SkillList;
        }

        //Search database on button pressed
        private void SearchMHWDB(object sender, EventArgs e)
        {
            var keyword = ToBeSearch.Text;
            List<String> keywords = new List<string>();
            if (keyword != null)
                keywords = keyword.Split(' ').ToList();

            String query = "select * from Armor where lower(name) like \'%" + keyword + "%\'"
                            + " UNION select * from Armor where lower(att1) like \'%" + keyword + "%\'"
                            + " UNION select * from Armor where lower(att2) like \'%" + keyword + "%\'";

            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();

                var equip = conn.Query<Armor>(query).ToList();

                if (equip.Count != 0)
                {
                    ToBeEquip.ItemsSource = equip.Select(x => x.name).ToList();
                }
            }
        }

        //Equipped Selected Armor, Charms, Decorations or Weapon
        private void EquipSelected(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();
                List<Armor> equip = new List<Armor>();
                try
                {
                    equip = conn.Query<Armor>("select * from Armor where lower(name) like ?",
                       "%" + (ToBeEquip.Items[ToBeEquip.SelectedIndex]).ToString() + "%").ToList();
                }
                catch
                {

                }

                if (equip.Count != 0)
                {
                    if (equip[0].part == "head")
                    {
                        Head.Text = equip[0].name;
                        Equipment.UpdateEquipped("head", equip[0].id);
                    }
                    else if (equip[0].part == "body")
                    {
                        Body.Text = equip[0].name;
                        Equipment.UpdateEquipped("body", equip[0].id);
                    }
                    else if (equip[0].part == "arms")
                    {
                        Arms.Text = equip[0].name;
                        Equipment.UpdateEquipped("arms", equip[0].id);
                    }
                    else if (equip[0].part == "waist")
                    {
                        Waist.Text = equip[0].name;
                        Equipment.UpdateEquipped("waist", equip[0].id);
                    }
                    else
                    {
                        Legs.Text = equip[0].name;
                        Equipment.UpdateEquipped("legs", equip[0].id);
                    }
                }
            }

            SkillsListView.ItemsSource = Equipment.SkillList;
            Size1.Text = Equipment.SlotCount[0].ToString();
            Size2.Text = Equipment.SlotCount[1].ToString();
            Size3.Text = Equipment.SlotCount[2].ToString();
        }

    }
}