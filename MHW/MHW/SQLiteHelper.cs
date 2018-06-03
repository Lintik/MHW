using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using MHW.Model;

namespace MHW
{
    public class SQLiteHelper
    {
        public static List<Armor> SearchKeywords(string keyword)
        {
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
                return equip;
            }

        }
    }
}
