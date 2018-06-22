using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AppContacts.Services;
using Foundation;
using UIKit;
using AppContacts.Services;
using Xamarin.Forms;
using AppContacts.iOS.Services;

[assembly: Xamarin.Forms.Dependency(typeof(FileHelper))]
namespace AppContacts.iOS.Services
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "DataBases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);
        }
    }
}