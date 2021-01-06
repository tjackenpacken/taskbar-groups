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

        // TODO: Rename this.
        public static string ConfigPath
        {
            get
            {
                string directoryPath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Jack Schierbeck", "taskbar-groups", "config");
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
                return directoryPath;
            }
        }

        // TODO: Rename this.
        public static string ShortcutsPath
        {
            get
            {
                string directoryPath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Jack Schierbeck", "taskbar-groups", "Shortcuts");
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
                return directoryPath;
            }
        }

    }
}
