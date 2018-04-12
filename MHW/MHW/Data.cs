using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

#pragma warning disable 0436

namespace MHW
{
    public class Armor
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string armorSet { get; set; }
    }
}
