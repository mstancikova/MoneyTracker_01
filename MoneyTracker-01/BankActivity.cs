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
using Java.Util;
using System.Globalization;

namespace MoneyTracker_01
{
    [Activity(Label = "BankActivity")]
    public class BankActivity : Activity
    {
        EditText edtdate, edtbankname, edtmoney;
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
            edtdate.Click += Edtdate_Click;

            // Create Bank database
            var resCreateBanksTable = db.CreateBanksTable();
            Toast.MakeText(this, resCreateBanksTable, ToastLength.Short).Show();

        }

        // Date input 
        private void Edtdate_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time) {
                edtdate.Text = time.ToLongDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        // Save Bank
        private void Btnsavebank_Click(object sender, EventArgs e)
        {
            try
            {
                string result = db.InsertBank(edtdate.Text, edtbankname.Text, edtmoney.Text);
                RefreshAdapter();
                Clear();
                Toast.MakeText(this, result, ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }

        // empty inputs
        void Clear()
        {
            edtdate.Text = "";
            edtbankname.Text = "";
            edtmoney.Text = "";
        }

        // Refresh bank list
        private void RefreshAdapter()
        {
            listviewbanks.Adapter = new ArrayAdapter<string>(listviewbanks.Context, Resource.Layout.BList, db.GetBanks().ToArray());
        }


        // Create a class DatePickerFragment  
        public class DatePickerFragment : DialogFragment,
            DatePickerDialog.IOnDateSetListener
        {
            // TAG can be any string of your choice.  
            public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();
            // Initialize this value to prevent NullReferenceExceptions.  
            Action<DateTime> _dateSelectedHandler = delegate { };
            public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
            {
                DatePickerFragment frag = new DatePickerFragment
                {
                    _dateSelectedHandler = onDateSelected
                };
                return frag;
            }
            public override Dialog OnCreateDialog(Bundle savedInstanceState)
            {
                DateTime currently = DateTime.Now;
                DatePickerDialog dialog = new DatePickerDialog(Activity, this, currently.Year, currently.Month, currently.Day);
                return dialog;
            }
            public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
            {
                // Note: monthOfYear is a value between 0 and 11, not 1 and 12!  
                DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
                Android.Util.Log.Debug(TAG, selectedDate.ToLongDateString());
                _dateSelectedHandler(selectedDate);
            }
        }

    }
}