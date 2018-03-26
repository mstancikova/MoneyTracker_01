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
    [Table("Groups")]
    public class Groups
    {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int Id { get; set; }
        public string Groupname { get; set; }
    }
}