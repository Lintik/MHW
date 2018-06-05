using SQLite;

namespace MHW.Model
{
    public class Armor
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
        public string armorset { get; set; }
        public string part { get; set; }
        public int slot1 { get; set; }
        public int slot2 { get; set; }
        public int slot3 { get; set; }
        public string att1 { get; set; }
        public int att1lvl { get; set; }
        public string att2 { get; set; }
        public int att2lvl { get; set; }
        public string mat1 { get; set; }
        public int mat1count { get; set; }
        public string mat2 { get; set; }
        public int mat2count { get; set; }
        public string mat3 { get; set; }
        public int mat3count { get; set; }
        public string mat4 { get; set; }
        public int mat4count { get; set; }
    }

    public class ArmorSet
    {
        [PrimaryKey]
        public string armorset { get; set; }
        public int rank { get; set; }
        public int def { get; set; }
        public int fire { get; set; }
        public int water { get; set; }
        public int thunder { get; set; }
        public int ice { get; set; }
        public int dragon { get; set; }
    }
}
