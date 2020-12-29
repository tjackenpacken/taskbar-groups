using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Classes
{
    class handleWindowsApp
    {
        public static Image getWindowsAppIcon(String file)
        {
            String microsoftAppName = GetLnkTarget(file);
            String subAppName = microsoftAppName.Split('_')[0];
            string[] appDirecList = Directory.GetDirectories(Environment.ExpandEnvironmentVariables("%ProgramFiles%") + $@"\WindowsApps\");
            List<string> appPath = new List<string>();
            foreach (var appDirec in appDirecList)
            {
                if (appDirec.Contains(subAppName))
                {
                    appPath.Add(appDirec);
                }
            }
            if (File.Exists(Path.GetFullPath(appPath[0] + "\\Assets\\Square150x150Logo.scale-100.png")))
            {
                using (MemoryStream ms = new MemoryStream(System.IO.File.ReadAllBytes(Path.GetFullPath(appPath[0] + "\\Assets\\Square150x150Logo.scale-100.png"))))
                    return ImageFunctions.ResizeImage(Bitmap.FromStream(ms), 32, 32);
            } else
            {
                return Icon.ExtractAssociatedIcon(file).ToBitmap();
            }
        }

        public static string GetLnkTarget(string lnkPath)
        {
            var shl = new Shell32.Shell();
            lnkPath = System.IO.Path.GetFullPath(lnkPath);
            var dir = shl.NameSpace(System.IO.Path.GetDirectoryName(lnkPath));
            var itm = dir.Items().Item(System.IO.Path.GetFileName(lnkPath));
            var lnk = (Shell32.ShellLinkObject)itm.GetLink;
            return lnk.Target.Path;
        }
    }
}
