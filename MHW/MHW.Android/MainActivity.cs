using System;
using System.IO;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MHW.Droid
{
    [Activity(Label = "MHW", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            //Initialize MHWDB.db
            string targetPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(targetPath, "MHWDB.db");

            if (!File.Exists(path))
            {
                using (Stream input = Assets.Open("MHWDB.db"))
                {
                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        input.CopyTo(fs);
                    }
                }
            }

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(path));
        }
    }
}

