using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace MHW.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // Initialize MHWDB.db
            var targetPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            targetPath = Path.Combine(targetPath, "..", "Library");

            var path = Path.Combine(targetPath, "MHWDB.db3");
            if (!File.Exists(path))
            {
                var bundlePath = NSBundle.MainBundle.PathForResource(
                    "MHWDB",
                    "db3"
                );
                File.Copy(bundlePath, path);
            }

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(path));

            return base.FinishedLaunching(app, options);
        }
    }
}
