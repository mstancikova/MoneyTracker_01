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

namespace MoneyTracker_01.Resources.DataHelper
{
    [Table("Banks")]
    public class Banks
    {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int Id { get; set; }
        public string Date { get; set; }
        public string Bankname { get; set; }
        public double Money { get; set; }
    }
}