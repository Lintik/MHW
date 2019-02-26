using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
namespace MHW.Models
{
    public class Weapon
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int attackraw{ get; set; }
        public string affinity { get; set; }
        public string status { get; set; }
        public int statusvalue{ get; set; }
        public int slot1 { get; set; }
        public int slot2 { get; set; }
        public int slot3 { get; set; }
        public int rarity { get; set; }
    }

    public class GreatSword
    {
        [PrimaryKey]
        public string name {get;set;}
        public string sharpness0 {get;set;}
        public string sharpness1 { get;set;}
        public string sharpness2 { get;set;}
        public string sharpness3 { get;set;}
        public string sharpness4 { get; set; }
        public string sharpness5 { get; set; }
    }

    public class LongSword
    {
        [PrimaryKey]
        public string name { get; set; }
        public string sharpness0 { get; set; }
        public string sharpness1 { get; set; }
        public string sharpness2 { get; set; }
        public string sharpness3 { get; set; }
        public string sharpness4 { get; set; }
        public string sharpness5 { get; set; }
    }

    public class SwordAndShield
    {
        [PrimaryKey]
        public string name { get; set; }
        public string sharpness0 { get; set; }
        public string sharpness1 { get; set; }
        public string sharpness2 { get; set; }
        public string sharpness3 { get; set; }
        public string sharpness4 { get; set; }
        public string sharpness5 { get; set; }
    }

    public class DualBlades
    {
        [PrimaryKey]
        public string name { get; set; }
        public string sharpness0 { get; set; }
        public string sharpness1 { get; set; }
        public string sharpness2 { get; set; }
        public string sharpness3 { get; set; }
        public string sharpness4 { get; set; }
        public string sharpness5 { get; set; }
    }
    public class Hammer
    {
        [PrimaryKey]
        public string name { get; set; }
        public string sharpness0 { get; set; }
        public string sharpness1 { get; set; }
        public string sharpness2 { get; set; }
        public string sharpness3 { get; set; }
        public string sharpness4 { get; set; }
        public string sharpness5 { get; set; }
    }
    public class HuntingHorn
    {
        [PrimaryKey]
        public string name { get; set; }
        public string sharpness0 { get; set; }
        public string sharpness1 { get; set; }
        public string sharpness2 { get; set; }
        public string sharpness3 { get; set; }
        public string sharpness4 { get; set; }
        public string sharpness5 { get; set; }
    }
    public class Lance
    {
        [PrimaryKey]
        public string name { get; set; }
        public string sharpness0 { get; set; }
        public string sharpness1 { get; set; }
        public string sharpness2 { get; set; }
        public string sharpness3 { get; set; }
        public string sharpness4 { get; set; }
        public string sharpness5 { get; set; }
    }
    public class Gunlance
    {
        [PrimaryKey]
        public string name { get; set; }
        public string sharpness0 { get; set; }
        public string sharpness1 { get; set; }
        public string sharpness2 { get; set; }
        public string sharpness3 { get; set; }
        public string sharpness4 { get; set; }
        public string sharpness5 { get; set; }
    }
    public class SwitchAxe
    {
        [PrimaryKey]
        public string name { get; set; }
        public string sharpness0 { get; set; }
        public string sharpness1 { get; set; }
        public string sharpness2 { get; set; }
        public string sharpness3 { get; set; }
        public string sharpness4 { get; set; }
        public string sharpness5 { get; set; }
    }
    public class ChargeBlade
    {
        [PrimaryKey]
        public string name { get; set; }
        public string sharpness0 { get; set; }
        public string sharpness1 { get; set; }
        public string sharpness2 { get; set; }
        public string sharpness3 { get; set; }
        public string sharpness4 { get; set; }
        public string sharpness5 { get; set; }
    }
    public class InsectGlaive
    {
        [PrimaryKey]
        public string name { get; set; }
        public string sharpness0 { get; set; }
        public string sharpness1 { get; set; }
        public string sharpness2 { get; set; }
        public string sharpness3 { get; set; }
        public string sharpness4 { get; set; }
        public string sharpness5 { get; set; }
    }
    public class Bow
    {

    }
    public class LightBowgun
    {

    }
    public class HeavyBowgun
    {

    }

}
