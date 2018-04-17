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
            string path = ApplicationData.Current.LocalFolder.Path;
            string dbPath = Path.Combine(path, filename);

            //CopyDatabaseIfNotExists(dbPath);

            return dbPath;
        }
        
        //public async static void CopyDatabaseIfNotExists(string dbPath)
        //{
        //    if (!File.Exists(dbPath))
        //    {
        //        StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        //        StorageFile sampleFileCreate = await storageFolder.CreateFileAsync("MHWDB.db", CreationCollisionOption.ReplaceExisting);
        //    }
        //}
    }
}
