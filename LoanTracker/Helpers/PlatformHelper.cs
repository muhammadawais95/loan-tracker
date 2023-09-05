using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LoanTracker.Helpers
{
    public static class PlatformHelper
    {
        public static string GetApplicationPath()
        {
            //TODO: to be tested on all platforms? linux/browser/mac
            if (OperatingSystem.IsWindows())
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if (OperatingSystem.IsMacOS())
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}