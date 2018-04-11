using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MHW.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            var path = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, @"Assets\MHWDB.db");
            this.InitializeComponent();

            LoadApplication(new MHW.App(path));
        }
    }
}
