using System.Collections.Generic;
using System.IO;

namespace TaskbarGroups.Classes
{
    public class Category
    {
        public string Name { get; set; }
        public List<ProgramShortcut> ShortcutList { get; set; }
        public int Width { get; set; }

        public Category(string path)
        {
            // ctor from xml config file
            string fullPath = Path.GetFullPath(path);
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Category));
            using (StreamReader file = new StreamReader(fullPath))
            {
                Category category = (Category)reader.Deserialize(file);
                this.Name = category.Name;
                this.ShortcutList = category.ShortcutList;
                this.Width = category.Width;
            }
        }

        public Category() 
        {
            // needed for xml serialization
        }

    }
}
