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
        //code to create the database
        public string CreateDB()
        {
            var output = "";
            output += "Create Database if it doesnt exist.";
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "moneytracker01.db3");
            var db = new SQLiteConnection(dbPath);
            output = "\n Database created ...";
            return output;
        }

        // -------------------------------- code to create Group table
        public string CreateGroupsTable()
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "moneytracker01.db3");
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
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "moneytracker01.db3");
                var db = new SQLiteConnection(dbPath);

                Groups groupname = new Groups();
                groupname.Groupname = group;
                db.Insert(groupname);
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
            List<string> motti = new List<string>();
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "moneytracker01.db3");

            using (var db = new SQLiteConnection(dbPath))
            {
                foreach (var s in db.Table<Groups>())
                    motti.Add(s.Groupname);
            }

            return motti;
        }


        // ------------------------------ code to create Banks table
        public string CreateBanksTable()
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "moneytracker01.db3");
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
        public string InsertBank(string bank)
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "moneytracker01.db3");
                var db = new SQLiteConnection(dbPath);

                Banks bankname = new Banks();
                bankname.Bankname = bank;
                db.Insert(bankname);
                return "Bank added...";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

    }
}