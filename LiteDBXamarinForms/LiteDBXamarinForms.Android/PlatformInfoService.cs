using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LiteDBXamarinForms.Services;

namespace LiteDBXamarinForms.Droid
{
    public class PlatformInfoService : IPlatformInfoService
    {
        private string _dbFileName = "AppDb.db";
        public string GetLiteDBFilePath()
        {
            return Path.Combine(GetUserDataFolderPath(), _dbFileName);
        }

        private string GetUserDataFolderPath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
        }
    }
}