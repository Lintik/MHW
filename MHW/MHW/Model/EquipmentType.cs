using SQLite;

namespace MHW.Model
{
    public class EquipmentType
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }
}
