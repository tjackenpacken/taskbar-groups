using client.Properties;
using IWshRuntimeLibrary;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace client.Classes
{
    // Function that is accessed by all forms to get the starting absolute path of the .exe
    // Added as to not keep generating the path in each form
    static class Paths
    {
        /// <summary>
        /// The full path to the application's main executable.
        /// </summary>
        public static String exeString = System.Reflection.Assembly.GetExecutingAssembly().Location;

        public static String exeFolder = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// The folder in which the main executable resides.
        /// </summary>
        public static String path = System.IO.Path.GetDirectoryName(exeString);

        public static String defaultConfigPath;
        public static String defaultShortcutsPath;
        public static String defaultBackgroundPath;

        public static bool justWritten = false;

        static Paths()
        {
            
        }

        private static string AppDataRelativePath
        {
            get
            {
                return System.IO.Path.Combine("Jack Schierbeck", "taskbar-groups");
            }
        }

        public static string ConfigPath = setupConfigPath();
        public static string BackgroundApplication = setupBackgroundApplication();
        public static string ShortcutsPath = setupShortcutsPath();

        private static string setupConfigPath()
        {
            string directoryPath;
            defaultConfigPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppDataRelativePath, "config");
            if (!Settings.settingInfo.portableMode)
            {
                directoryPath = defaultConfigPath;
            }
            else
            {
                directoryPath = Path.Combine(exeFolder, "config");
            }

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            
            return directoryPath;
        }

        private static string setupShortcutsPath()
        {
            string directoryPath;
            defaultShortcutsPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppDataRelativePath, "Shortcuts");
            if (!Settings.settingInfo.portableMode)
            {
                directoryPath = defaultShortcutsPath;
            }
            else
            {
                directoryPath = Path.Combine(exeFolder, "Shortcuts");
            }

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return directoryPath;
        }

        public static string OptimizationProfilePath
        {
            get
            {
                string directoryPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppDataRelativePath, "JITComp");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                return directoryPath;
            }
        }

        private static string setupBackgroundApplication()
        {
            Directory.CreateDirectory(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppDataRelativePath));

            string filePath;
            defaultBackgroundPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppDataRelativePath, "Taskbar Groups Background.exe");

            if (!Settings.settingInfo.portableMode)
            {
                filePath = defaultBackgroundPath;
            }
            else
            {
                filePath = Path.Combine(exeFolder, "Taskbar Groups Background.exe");
            }

            if (!System.IO.File.Exists(filePath))
            {
                System.IO.File.WriteAllBytes(filePath, Resources.Taskbar_Groups_Background);

                justWritten = true;
            } else
            {
                byte[] fileHash;
                byte[] localHash;
                using (var md5 = MD5.Create())
                {
                    using (MemoryStream memStream = new MemoryStream(Resources.Taskbar_Groups_Background))
                    {
                        using (var stream = System.IO.File.OpenRead(filePath))
                        {
                            fileHash = md5.ComputeHash(stream);
                        }

                        localHash = md5.ComputeHash(memStream);
                    }


                }

                if (fileHash.SequenceEqual(localHash) == false)
                {
                    System.IO.File.WriteAllBytes(filePath, Resources.Taskbar_Groups_Background);

                    justWritten = true;
                }
            }
            
            return filePath;
        }

        private static string setupMainClientShortcut()
        {
            string filePath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppDataRelativePath, "Taskbar Group Editor.lnk");
            if (!System.IO.File.Exists(filePath))
            {
                string shortcutLocation = System.IO.Path.Combine(filePath);
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

                shortcut.Description = "Shortcut for Edit Group context menu feature";   // The description of the shortcut
                shortcut.TargetPath = Paths.exeString;                 // The path of the file that will launch when the shortcut is run
                shortcut.Save();
            }
            return filePath;
        }


        public static string MainClientShortcut = setupMainClientShortcut();
    }
}
