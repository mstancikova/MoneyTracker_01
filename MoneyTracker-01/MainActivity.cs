using Android.App;
using Android.Widget;
using Android.OS;

using MoneyTracker_01.Resources.DataHelper;
using System.IO;

namespace MoneyTracker_01
{
    [Activity(Label = "MoneyTracker 01", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnexpencies;
        Button btngroups;
        Button btnbanks;
        DataBase db = new DataBase();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //database creation
            var resCreateDB = db.CreateDB();
            //Toast.MakeText(this, resCreateDB, ToastLength.Short).Show();

            btnexpencies = FindViewById<Button>(Resource.Id.btnExpencies);
            btngroups = FindViewById<Button>(Resource.Id.btnGroups);
            btnbanks = FindViewById<Button>(Resource.Id.btnBanks);

            btnexpencies.Click += Btnexpencies_Click;
            btngroups.Click += delegate{
                StartActivity(typeof(GroupActivity));
            };
      
            btnbanks.Click += delegate {
                StartActivity(typeof(BankActivity));
            };
        }

        private void Btnexpencies_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

    }
}

