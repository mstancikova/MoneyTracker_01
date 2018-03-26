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
    [Activity(Label = "BankActivity")]
    public class BankActivity : Activity
    {
        EditText edtdate;
        EditText edtbankname;
        EditText edtmoney;
        Button btnsavebank;
        ListView listviewbanks;
        DataBase db = new DataBase();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Banks);

            edtdate = FindViewById<EditText>(Resource.Id.edtDate);
            edtbankname = FindViewById<EditText>(Resource.Id.edtBankname);
            edtmoney = FindViewById<EditText>(Resource.Id.edtMoney);
            btnsavebank = FindViewById<Button>(Resource.Id.btnSavebank);
            listviewbanks = FindViewById<ListView>(Resource.Id.listViewBanks);
            RefreshAdapter();

            btnsavebank.Click += Btnsavebank_Click;

            // Create Group database
            var resCreateBanksTable = db.CreateBanksTable();
            Toast.MakeText(this, resCreateBanksTable, ToastLength.Short).Show();

            
        }

        private void RefreshAdapter()
        {
            listviewbanks.Adapter = new ArrayAdapter<string>(listviewbanks.Context, Resource.Layout.BanksList, db.GetBanks().ToArray());
        }

        private void Btnsavebank_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}