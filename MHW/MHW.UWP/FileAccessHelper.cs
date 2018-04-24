using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Storage;

namespace MHW.UWP
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            string path = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, @"Assets\"+filename);
            return path;
        }
    }
}
