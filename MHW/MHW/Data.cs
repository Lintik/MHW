using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MHW
{
    public class Armor
    {
        [PrimaryKey]
        public string name { get; set; }
        public string set { get; set; }
    }
}
