using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;
using System.Collections.Generic;

namespace client.Classes
{
    class handleWindowsApp
    {
        public static Dictionary<string, string> fileDirectoryCache = new Dictionary<string, string>();

        public static Image getWindowsAppIcon(String file, bool alreadyAppID = false)
        {
            // Get the app's ID from its shortcut target file (Ex. 4DF9E0F8.Netflix_mcm4njqhnhss8!Netflix.app)
            String microsoftAppName = (!alreadyAppID) ? GetLnkTarget(file) : file;

            // Split the string to get the app name from the beginning (Ex. 4DF9E0F8.Netflix)
            String subAppName = microsoftAppName.Split('_')[0];

            // Loop through each of the folders with the app name to find the one with the manifest + logos
            String appPath = findWindowsAppsFolder(subAppName);

            // Load and read manifest to get the logo path
            XmlDocument appManifest = new XmlDocument();
            appManifest.Load(appPath + "\\AppxManifest.xml");

            XmlNamespaceManager appManifestNamespace = new XmlNamespaceManager(new NameTable());
            appManifestNamespace.AddNamespace("sm", "http://schemas.microsoft.com/appx/manifest/foundation/windows10");

            String logoLocation = (appManifest.SelectSingleNode("/sm:Package/sm:Properties/sm:Logo", appManifestNamespace).InnerText).Replace("\\", @"\");

            if (logoLocation != null)
            {
                // Get the last instance or usage of \ to cut out the path of the logo just to have the path leading to the general logo folder
                logoLocation = logoLocation.Substring(0, logoLocation.LastIndexOf(@"\"));
                String logoLocationFullPath = Path.GetFullPath(appPath + "\\" + logoLocation);

                String logoPath = "";

                // Search for all files with 150x150 in its name and use the first result
                string fileGoal = "StoreLogo";
                DirectoryInfo logoDirectory = new DirectoryInfo(logoLocationFullPath);
                FileInfo[] filesInDir = logoDirectory.GetFiles("*" + fileGoal + "*.*");

                logoPath = filesInDir.Last().FullName;

                if (File.Exists(logoPath))
                {
                    using (MemoryStream ms = new MemoryStream(System.IO.File.ReadAllBytes(logoPath)))
                        return ImageFunctions.ResizeImage(Bitmap.FromStream(ms), 64, 64);
                } else
                {
                    return Icon.ExtractAssociatedIcon(file).ToBitmap();
                }
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

        public static string findWindowsAppsFolder(string subAppName)
        {
            if (!fileDirectoryCache.ContainsKey(subAppName))
            {
                // Find the directories in the WindowsApps folder containg that direcotry
                string[] appDirecList = Directory.GetDirectories(Environment.ExpandEnvironmentVariables("%ProgramW6432%") + $@"\WindowsApps\");

                foreach (var appDirec in appDirecList)
                {
                    if (appDirec.Contains(subAppName) && File.Exists(appDirec + "\\AppxManifest.xml"))
                    {
                        fileDirectoryCache[subAppName] = appDirec;
                        return appDirec;
                    }
                }
                return "";
            }
            else
            {
                return fileDirectoryCache[subAppName];
            }
        }

        public static string findWindowsAppsName(string AppName)
        {
            String subAppName = AppName.Split('_')[0];

            String appPath = findWindowsAppsFolder(subAppName);

            // Load and read manifest to get the logo path
            XmlDocument appManifest = new XmlDocument();
            appManifest.Load(appPath + "\\AppxManifest.xml");

            XmlNamespaceManager appManifestNamespace = new XmlNamespaceManager(new NameTable());
            appManifestNamespace.AddNamespace("sm", "http://schemas.microsoft.com/appx/manifest/foundation/windows10");
            appManifestNamespace.AddNamespace("uap", "http://schemas.microsoft.com/appx/manifest/uap/windows10");

            try
            {
                return appManifest.SelectSingleNode("/sm:Package/sm:Applications/sm:Application/uap:VisualElements", appManifestNamespace).Attributes.GetNamedItem("DisplayName").InnerText;
            } catch (Exception)
            {
                return appManifest.SelectSingleNode("/sm:Package/sm:Properties/sm:DisplayName", appManifestNamespace).InnerText;
            }
        }
    }
}
