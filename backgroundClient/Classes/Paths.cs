using backgroundClient.Properties;
using IWshRuntimeLibrary;
using System;
using System.IO;

namespace backgroundClient.Classes
{
    // Function that is accessed by all forms to get the starting absolute path of the .exe
    // Added as to not keep generating the path in each form
    static class Paths
    {
        /// <summary>
        /// The folder in which the main executable resides.
        /// </summary>
        public static String path = System.IO.Path.GetDirectoryName(exeString);

        /// <summary>
        /// The full path to the application's main executable.
        /// </summary>
        public static String exeString = System.Reflection.Assembly.GetExecutingAssembly().Location;

        public static String exeFolder = AppDomain.CurrentDomain.BaseDirectory;

        public static String defaultConfigPath;

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

        public static string MainClientShortcut
        {
            get
            {
                string filePath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppDataRelativePath, "Taskbar Group Editor.lnk");
                return filePath;
            } 
        }
    }
}
