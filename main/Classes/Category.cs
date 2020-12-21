using IWshRuntimeLibrary;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace main.Classes
{
    public class Category
    {
        public string Name { get; set; }
        public List<ProgramShortcut> ShortcutList { get; set; }
        public int Width { get; set; } // not used aon

        public Category(string name, List<ProgramShortcut> shortcutList, int rows)
        {
            Name = name;
            ShortcutList = shortcutList;
            Width = rows;
        }

        public Category(string path)
        {
            // read XML config for category
            string fullPath = Path.GetFullPath(path + @"\ObjectData.xml");
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

        public Category() // needed for XML serialization
        {

        }

        public void CreateConfig(Image groupImage)
        {

            string path = @"config\" + this.Name;
            string filePath = path + @"\" + this.Name + "Group.exe";
            //
            // Directory and .exe
            //
            System.IO.Directory.CreateDirectory(@"Shortcuts\");
            System.IO.Directory.CreateDirectory(@path);
            System.IO.File.Copy(@"config\config.exe", @filePath);
            //
            // XML config
            //
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Category));

            using (FileStream file = System.IO.File.Create(@path + @"\ObjectData.xml"))
                writer.Serialize(file, this);
            //
            // Create .ico
            //

            Image img = ImageFunctions.ResizeImage(groupImage, 1024, 1024); // Resize img if too big
            img.Save(path + @"\GroupImage.png");

            using (FileStream fs = new FileStream(path + @"\GroupIcon.ico", FileMode.Create))
                ImageFunctions.IconFromImage(img).Save(fs); // saving as icon
                                                            //
                                                            // Create .lnk shortcut
                                                            //
            var wsh = new IWshShell_Class();
            IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(
                path + "\\" + this.Name + ".lnk") as IWshRuntimeLibrary.IWshShortcut;
            shortcut.Arguments = "";
            shortcut.TargetPath = Path.GetFullPath(@filePath);
            shortcut.WindowStyle = 1;
            shortcut.Description = path + " shortcut";
            shortcut.WorkingDirectory = Path.GetFullPath(@path);
            shortcut.IconLocation = Path.GetFullPath(path + @"\GroupIcon.ico");
            shortcut.Save();
            System.IO.File.Move(@path + "\\" + this.Name + ".lnk",
                Path.GetFullPath(@"Shortcuts\" + this.Name + ".lnk")); // moving .lnk to correct directory
        }

        public Bitmap LoadIconImage() // needed to access img without occupying read/write
        {
            string path = @"config\" + Name + @"\GroupImage.png";

            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
                return new Bitmap(memoryStream);
            }
        }
        //
        // END OF CLASS
        //
    }
}
