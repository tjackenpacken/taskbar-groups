using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace client.Classes
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
            // Use application's absolute path; (grabs the .exe)
            // Gets the parent folder of the exe and concats the rest of the path
            string fullPath;

            // Check if path is a full directory or part of a file name
            // Passed from two different applications; the main task-bar group and the main client
            if (System.IO.Directory.Exists(path))
            {
                fullPath = new Uri(path + "\\ObjectData.xml").AbsolutePath;
            }
            else
            {
                fullPath = new Uri($"{MainPath.path}\\{path}\\ObjectData.xml").AbsolutePath;
            }

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
            //string filePath = path + @"\" + this.Name + "Group.exe";
            //
            // Directory and .exe
            //
            System.IO.Directory.CreateDirectory(@path);
            System.IO.Directory.CreateDirectory(@path + @"\Shortcuts\");

            //System.IO.File.Copy(@"config\config.exe", @filePath);
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
            

            ShellLink.InstallShortcut(
                Path.GetFullPath(@System.AppDomain.CurrentDomain.FriendlyName),
                "tjackenpacken.taskbarGroup.menu." + this.Name,
                 path + " shortcut",
                 Path.GetFullPath(@path),
                 Path.GetFullPath(path + @"\GroupIcon.ico"),
                 path + "\\" + this.Name + ".lnk",
                 this.Name
            );

            cacheIcons();

            /*
                var wsh = new IWshShell_Class();
    
            IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(
                path + "\\" + this.Name + ".lnk") as IWshRuntimeLibrary.IWshShortcut;
            shortcut.Arguments = this.Name;
            shortcut.TargetPath = Path.GetFullPath(@System.AppDomain.CurrentDomain.FriendlyName);
            shortcut.WindowStyle = 1;
            shortcut.Description = path + " shortcut";
            shortcut.WorkingDirectory = Path.GetFullPath(@path);
            shortcut.IconLocation = Path.GetFullPath(path + @"\GroupIcon.ico");
            shortcut.Save();

            */


            System.IO.File.Move(@path + "\\" + this.Name + ".lnk",
                Path.GetFullPath(@path + "\\Shortcuts\\" + this.Name + ".lnk")); // moving .lnk to correct directory
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

        public void cacheIcons()
        {
            string path = @MainPath.path + @"\config\" + this.Name;
            string iconPath = path + "\\Icons\\";

            if (Directory.Exists(iconPath))
            {
                Directory.Delete(iconPath, true);
            }

            Directory.CreateDirectory(iconPath);

            iconPath = @path + @"\Icons\";

            for (int i = 0; i < ShortcutList.Count; i++)
            {
                String filePath = ShortcutList[i].FilePath;
                
                if (Path.GetExtension(filePath).ToLower() == ".lnk")
                {
                    IWshShortcut lnkIcon = ((IWshShortcut)new WshShell().CreateShortcut(filePath));

                    if (lnkIcon.IconLocation != null && !lnkIcon.IconLocation.Contains("http"))
                    {
                        Icon.ExtractAssociatedIcon(lnkIcon.IconLocation.Substring(0, lnkIcon.IconLocation.Length - 2)).ToBitmap().Save(iconPath + "\\" + Path.GetFileNameWithoutExtension(filePath) + ".jpg");
                    }
                    else
                    {
                        Icon.ExtractAssociatedIcon(lnkIcon.TargetPath).ToBitmap().Save(iconPath + "\\" + Path.GetFileNameWithoutExtension(filePath) + ".jpg");
                    }
                } else
                {
                    Icon.ExtractAssociatedIcon(filePath).ToBitmap().Save(iconPath + "\\" + Path.GetFileNameWithoutExtension(filePath) + ".jpg");
                }
            }
        }

        public Image loadImageCache(String programPath)
        {

            string path = @Path.GetDirectoryName(Application.ExecutablePath) + @"\config\" + this.Name + @"\Icons\" + Path.GetFileNameWithoutExtension(programPath) + ".jpg";
            
            using (MemoryStream ms = new MemoryStream(System.IO.File.ReadAllBytes(path)))
                 return Image.FromStream(ms);
        }
        //
        // END OF CLASS
        //
    }
}
