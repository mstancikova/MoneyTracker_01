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
using MoneyTracker_01.Resources.DataHelper;

namespace MoneyTracker_01
{
    [Activity(Label = "Groups")]
    public class GroupActivity : Activity
    {
        EditText edtgroupname;
        Button btnsavegroup;
        ListView listviewgroups;
        DataBase db = new DataBase();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Groups);

            edtgroupname = FindViewById<EditText>(Resource.Id.edtGroupname);
            btnsavegroup = FindViewById<Button>(Resource.Id.btnSavegroup);
            listviewgroups = FindViewById<ListView>(Resource.Id.listViewGroups);
            RefreshAdapter();

            btnsavegroup.Click += Btnsavegroup_Click;

            // Create Group database
            var resCreateGroupsTable = db.CreateGroupsTable();
            Toast.MakeText(this, resCreateGroupsTable, ToastLength.Short).Show();
            
        }

        private void RefreshAdapter()
        {
            listviewgroups.Adapter = new ArrayAdapter<string>(listviewgroups.Context, Resource.Layout.GroupList, db.GetGroups().ToArray());
        }

        private void Btnsavegroup_Click(object sender, EventArgs e)
        {
            try
            {
                string result = db.InsertGroup(edtgroupname.Text);
                RefreshAdapter();
                Clear();
                Toast.MakeText(this, result, ToastLength.Short).Show();
            }
            catch(Exception ex){
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }

        void Clear()
        {
            edtgroupname.Text = "";
        }
    }
}