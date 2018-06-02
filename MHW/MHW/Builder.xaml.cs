﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using MHW.Model;

namespace MHW
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Builder : ContentPage
	{
		public Builder ()
		{
			InitializeComponent ();
		}

        //Query the database given the keywords
        private void SearchSelected(object sender, EventArgs e)
        {
            var keyword = ToBeSearch.Text;
            List<String> keywords = new List<string>();
            if (keyword != null)
                keywords = keyword.Split(' ').ToList();

            String query = "select * from Armor where lower(name) like \'%" + keyword + "%\'"
                            + " UNION select * from Armor where lower(att0) like \'%" + keyword + "%\'"
                            + " UNION select * from Armor where lower(att1) like \'%" + keyword + "%\'";

            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();

                var equip = conn.Query<Armor>(query).ToList();

                if (equip.Count != 0)
                {
                    ToBeEquip.Text = equip[0].name;
                }
            }
        }

        private void EquipSelected(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();

                var equip = conn.Query<Armor>("select * from Armor where lower(name) like ?",
                   "%" + ToBeEquip.Text + "%").ToList();

                if (equip.Count != 0)
                {
                    if (equip[0].part == "head")
                    {
                        Head.Text = equip[0].name;
                    }
                    else if (equip[0].part == "body")
                    {
                        Body.Text = equip[0].name;
                    }
                    else if (equip[0].part == "arms")
                    {
                        Arms.Text = equip[0].name;
                    }
                    else if (equip[0].part == "waist")
                    {
                        Waist.Text = equip[0].name;
                    }
                    else
                    {
                        Legs.Text = equip[0].name;
                    }
                }
            }
        }
    }
}