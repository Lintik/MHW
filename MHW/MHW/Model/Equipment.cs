﻿using System;
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

        public static int Slot1Count = 0;
        public static int Slot2Count = 0;
        public static int Slot3COunt = 0;
        public static string weapon = "";
        public static string head = "";
        public static string body = "";
        public static string arms = "";
        public static string waist = "";
        public static string legs = "";



        //Update EquippedSkills 
        public static void UpdateEquipped(string part, int id)
        {
            if (EquippedID.ContainsKey(part) && part != null)
            {
                RemoveSkill(part);
                Equipment.EquippedID.Remove(part);
                Equipment.EquippedID.Add(part, id);
                AddSkill(part);
            }
            else
            {
                Equipment.EquippedID.Add(part, id);
                AddSkill(part);
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

                if (EquippedSkills.ContainsKey(att1) && att1 != null) EquippedSkills[att1] += att1lvl;
                else EquippedSkills.Add(att1, att1lvl);

                if (EquippedSkills.ContainsKey(att2) && att2 != null) EquippedSkills[att2] += att2lvl;
                else EquippedSkills.Add(att2, att2lvl);
            }

            UpdateSkillList();
        }

        //Clear SkillList and repopulate the list with the new values
        public static void UpdateSkillList()
        {
            SkillList.Clear();
            foreach (KeyValuePair<string, int> entry in EquippedSkills)
            {
                if(entry.Key != null)
                    SkillList.Add(entry.Key + " " + entry.Value.ToString());
            }
        }
    }
}
