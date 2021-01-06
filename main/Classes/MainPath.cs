using System;

namespace client.Classes
{
    // Function that is accessed by all forms to get the starting absolute path of the .exe
    // Added as to not keep generating the path in each form
    static class MainPath
    {
        /// <summary>
        /// The folder in which the main executable resides.
        /// </summary>
        public static String path;

        /// <summary>
        /// The full path to the application's main executable.
        /// </summary>
        public static String exeString;

        static MainPath()
        {
            exeString = System.Reflection.Assembly.GetExecutingAssembly().Location;
            path = System.IO.Path.GetDirectoryName(exeString);
        }

        private static string AppDataRelativePath
        {
            get
            {
                return System.IO.Path.Combine("Jack Schierbeck", "taskbar-groups");
            }
        }

        public static string ConfigPath
        {
            get
            {
                string directoryPath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppDataRelativePath, "config");
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
                return directoryPath;
            }
        }

        public static string ShortcutsPath
        {
            get
            {
                string directoryPath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppDataRelativePath, "Shortcuts");
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
                return directoryPath;
            }
        }
        public static string OptimizationProfilePath
        {
            get
            {
                string directoryPath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppDataRelativePath, "JITComp");
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
                return directoryPath;
            }
        }

    }
}
