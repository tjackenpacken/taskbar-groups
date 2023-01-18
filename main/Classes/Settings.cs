using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace client.Classes
{
    static class Settings
    {
        private static string appDataRelative = System.IO.Path.Combine("Jack Schierbeck", "taskbar-groups");
        public static string settingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), appDataRelative, "Settings.xml");
        public static string defaultSettingsPath;
        public static Setting settingInfo;

        static Settings()
        {
            defaultSettingsPath = settingsPath;
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.xml")))
            {
                settingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.xml");
            }
            else if (!File.Exists(settingsPath))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), appDataRelative));
                settingInfo = new Setting();
                writeXML();
                return;
            }

            System.Xml.Serialization.XmlSerializer reader =
            new System.Xml.Serialization.XmlSerializer(typeof(Setting));
            using (StreamReader file = new StreamReader(settingsPath))
            {
                settingInfo = (Setting)reader.Deserialize(file);
                file.Close();
            }

            if (settingInfo.portableMode == true && !File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.xml")))
            {
                settingInfo.portableMode = false;
                writeXML();
            }
            
        }

        public static void writeXML()
        {
            try
            {
                System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Setting));

                using (FileStream file = System.IO.File.Create(settingsPath))
                {
                    writer.Serialize(file, settingInfo);
                    file.Close();
                }
            }catch(IOException e)
            {
                DialogResult result = MessageBox.Show("Settings.xml may be open in another file.\r\n\r\nError: " + e.Message, "Exit", MessageBoxButtons.OK);
                Environment.Exit(4);
            }
        }
    }

    [Serializable()]
    public class Setting
    {
        [XmlElement]
        public bool portableMode { get; set; } = false;
    }
}
