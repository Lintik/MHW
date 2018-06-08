using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using MHW.Model;

namespace MHW.Services
{
    public class SQLiteHelper
    {
        public static List<EquipmentType> SearchKeyWords(string keyword)
        {
            string query = "select * from EquipmentType where lower(name) like \'%" + keyword + "%\'";
            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<EquipmentType>();

                var equip = conn.Query<EquipmentType>(query).ToList();
                return equip;
            }
        }

        public static List<Armor> SearchArmor(string keyword)
        {

            string query = "select * from Armor where lower(name) like \'%" + keyword + "%\'"
                            + " UNION select * from Armor where lower(att1) like \'%" + keyword + "%\'"
                            + " UNION select * from Armor where lower(att2) like \'%" + keyword + "%\'";

            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();

                var equip = conn.Query<Armor>(query).ToList();
                return equip;
            }

        }

        public static List<Weapon> SearchWeapon(string keyword)
        {
            string query = "select * from Weapon where lower(name) like \'%" + keyword + "%\'";
            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Weapon>();

                var equip = conn.Query<Weapon>(query).ToList();
                return equip;
            }
        }
    }
}
