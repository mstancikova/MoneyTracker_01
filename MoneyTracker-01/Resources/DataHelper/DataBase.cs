using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using SQLite;
using System.IO;
using Android.Util;


namespace MoneyTracker_01.Resources.DataHelper
{
    public class DataBase
    {
        public string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "moneytracker01.db3");
        
        //code to create the database
        public string CreateDB()
        {
            var output = "";
            output += "Create Database if it doesnt exist.";
            var db = new SQLiteConnection(dbPath);
            output = "\n Database created ...";
            return output;
        }

        // -------------------------------- code to create GROUP TABLE
        public string CreateGroupsTable()
        {
            try
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Groups>();
                string result = "Table Groups Created succesfully...";
                return result;
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        //code to insert Group
        public string InsertGroup(string group)
        {
            try
            {
                var db = new SQLiteConnection(dbPath);
                Groups groups = new Groups();
                groups.Groupname = group;
                db.Insert(groups);
                return "Group added...";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        // Create list of Groups
        public List<string> GetGroups()
        {
            List<string> groups = new List<string>();
            using (var db = new SQLiteConnection(dbPath))
            {
                foreach (var s in db.Table<Groups>())
                    groups.Add(s.Groupname);
            }
            return groups;
        }


        // ------------------------------ code to create BANKS TABLE
        public string CreateBanksTable()
        {
            try
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Banks>();
                string result = "Table Banks Created succesfully...";
                return result;
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        //code to insert Bank
        public string InsertBank(string date, string bank, string money)
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "moneytracker01.db3");
                var db = new SQLiteConnection(dbPath);

                Banks banks = new Banks();
                banks.Date = date;
                banks.Bankname = bank;
                banks.Money = money;
                db.Insert(banks);
                return "Bank added...";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        // Create list of Banks
        public List<string> GetBanks()
        {
            List<string> banks = new List<string>();
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "moneytracker01.db3");

            using (var db = new SQLiteConnection(dbPath))
            {
                foreach (var s in db.Table<Banks>())
                    banks.Add(s.Bankname + " ( " + s.Money + " ) ");
            }

            return banks;
        }

    }
}