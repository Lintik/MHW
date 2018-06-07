using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;
using System.Collections.ObjectModel;

namespace MHW.Model
{
    public class Equipment
    {
        public static Dictionary<string, int> EquippedSkills = new Dictionary<string, int>();
        public static Dictionary<string, int> EquippedID = new Dictionary<string, int>();
        public static ObservableCollection<string> SkillList = new ObservableCollection<string>();

        public static int[] SlotCount = new int[3] { 0, 0, 0 };
        public static string weapon = "";
        public static string head = "";
        public static string body = "";
        public static string arms = "";
        public static string waist = "";
        public static string legs = "";

        public static void UpdateEquipped(string part, int id)
        {
            if (EquippedID.ContainsKey(part) && part != null)
            {
                RemoveSkill(part);
                RemoveSlot(part);
                Equipment.EquippedID.Remove(part);
                Equipment.EquippedID.Add(part, id);
                AddSkill(part);
                AddSlot(part);
                UpdatePart(part);
            }
            else
            {
                Equipment.EquippedID.Add(part, id);
                AddSkill(part);
                AddSlot(part);
                UpdatePart(part);
            }
        }

        //Connect to database to fetch necessary values then remove skills according to specific amount
        public static void RemoveSkill(string part)
        {
            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();

                var armor = conn.Get<Armor>(EquippedID[part]);
                string att1 = armor.att1;
                int att1lvl = armor.att1lvl;
                string att2 = armor.att2;
                int att2lvl = armor.att2lvl;

                if (EquippedSkills.ContainsKey(att1) && att1 != null)
                {
                    EquippedSkills[att1] -= att1lvl;
                    if (EquippedSkills[att1] < 1)
                        EquippedSkills.Remove(att1);
                }

                if (EquippedSkills.ContainsKey(att2) && att2 != null)
                {
                    EquippedSkills[att2] -= att2lvl;
                    if (EquippedSkills[att2] < 1)
                        EquippedSkills.Remove(att2);
                }
            }
            UpdateSkillList();
        }

        //Connect to database to fetch necessary values then insert them into EquippedSkills
        public static void AddSkill(string part)
        {
            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();

                var armor = conn.Get<Armor>(EquippedID[part]);
                string att1 = armor.att1;
                int att1lvl = armor.att1lvl;
                string att2 = armor.att2;
                int att2lvl = armor.att2lvl;

                if (EquippedSkills.ContainsKey(att1) && att1 != null && att1lvl != null) EquippedSkills[att1] += att1lvl;
                else if (att1 != null && att1lvl != null)EquippedSkills.Add(att1, att1lvl);

                if (EquippedSkills.ContainsKey(att2) && att2 != null && att2lvl != null) EquippedSkills[att2] += att2lvl;
                else if (att2 != null && att2lvl != null) EquippedSkills.Add(att2, att2lvl);
            }

            UpdateSkillList();
        }

        public static void RemoveSlot(string part)
        {
            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();

                var armor = conn.Get<Armor>(EquippedID[part]);
                if (armor.slot1 != 0) SlotCount[armor.slot1 - 1]--;
                if (armor.slot2 != 0) SlotCount[armor.slot2 - 1]--;
                if (armor.slot3 != 0) SlotCount[armor.slot3 - 1]--;
            }
        }

        public static void AddSlot(string part)
        {
            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();

                var armor = conn.Get<Armor>(EquippedID[part]);
                if (armor.slot1 != 0) SlotCount[armor.slot1 - 1]++;
                if (armor.slot2 != 0) SlotCount[armor.slot2 - 1]++;
                if (armor.slot3 != 0) SlotCount[armor.slot3 - 1]++;
            }
        }

        //Clear SkillList and repopulate the list with the new values
        public static void UpdateSkillList()
        {
            SkillList.Clear();
            foreach (KeyValuePair<string, int> entry in EquippedSkills)
            {
                if (entry.Key != null && entry.Value != 0)
                    SkillList.Add(entry.Key + " " + entry.Value.ToString());
            }
        }

        public static void UpdatePart(string part)
        {
            using (var conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Armor>();

                var armor = conn.Get<Armor>(EquippedID[part]);
                if (armor.part == "head") head = armor.name;
                else  if (armor.part == "body") body = armor.name;
                else if (armor.part == "arms") arms = armor.name;
                else if (armor.part == "waist") waist = armor.name;
                else if (armor.part == "legs") legs = armor.name;
            }
        }

    }
}
