using client.User_controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace client.Classes
{
    public class Category
    {
        public string Name;
        public string ColorString = System.Drawing.ColorTranslator.ToHtml(Color.FromArgb(31, 31, 31));
        public bool allowOpenAll = false;
        public List<ProgramShortcut> ShortcutList;
        public int Width; // not used aon
        public double Opacity = 10;
        public List<ProgramShortcut> recentlyOpened = new List<ProgramShortcut>();

        Regex specialCharRegex = new Regex("[*'\",_&#^@]");

        private static int[] iconSizes = new int[] {16,32,64,128,256,512};

        string folderPath;

        public Category(string path)
        {
            // Use application's absolute path; (grabs the .exe)
            // Gets the parent folder of the exe and concats the rest of the path
            string fullPath;

            // Check if path is a full directory or part of a file name
            // Passed from the main shortcut client and the config client

            if (System.IO.File.Exists(@MainPath.path + @"\" + path + @"\ObjectData.xml"))
            {
                fullPath = @MainPath.path + @"\" + path + @"\ObjectData.xml";
            }
            else
            {
                fullPath = Path.GetFullPath(path + "\\ObjectData.xml");
            }

            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Category));
            using (StreamReader file = new StreamReader(fullPath))
            {
                Category category = (Category)reader.Deserialize(file);
                this.Name = category.Name;
                this.ShortcutList = category.ShortcutList;
                this.Width = category.Width;
                this.ColorString = category.ColorString;
                this.Opacity = category.Opacity;
                this.allowOpenAll = category.allowOpenAll;
                this.recentlyOpened = category.recentlyOpened;
            }
            folderPath = MainPath.path + @"\config\" + this.Name;
        }

        public Category() // needed for XML serialization
        {

        }

        public void CreateConfig(Image groupImage)
        {

            if (folderPath == null) {
                folderPath = MainPath.path + @"\config\" + this.Name;
            }
            //string filePath = path + @"\" + this.Name + "Group.exe";
            //
            // Directory and .exe
            //
            System.IO.Directory.CreateDirectory(folderPath);

            //System.IO.File.Copy(@"config\config.exe", @filePath);


            writeXML();

            //
            // Create .ico
            //

            Image img = ImageFunctions.ResizeImage(groupImage, 256, 256); // Resize img if too big
            img.Save(folderPath + @"\GroupImage.png");

            if (GetMimeType(groupImage).ToString() == "*.PNG")
            {
                createMultiIcon(groupImage, folderPath + @"\GroupIcon.ico");
            }
            else { 
                using (FileStream fs = new FileStream(folderPath + @"\GroupIcon.ico", FileMode.Create))
                {
                    ImageFunctions.IconFromImage(img).Save(fs);
                    fs.Close();
                }
            }


            // Through shellLink.cs class, pass through into the function information on how to construct the icon
            // Needed due to needing to set a unique AppUserModelID so the shortcut applications don't stack on the taskbar with the main application
            // Tricks Windows to think they are from different applications even though they are from the same .exe
            ShellLink.InstallShortcut(
                Path.GetFullPath(@System.AppDomain.CurrentDomain.FriendlyName),
                "tjackenpacken.taskbarGroup.menu." + this.Name,
                 folderPath + " shortcut",
                 Path.GetFullPath(folderPath),
                 Path.GetFullPath(folderPath + @"\GroupIcon.ico"),
                 folderPath + "\\" + this.Name + ".lnk",
                 this.Name
            );


            // Build the icon cache
            cacheIcons();

            System.IO.File.Move(folderPath + "\\" + this.Name + ".lnk",
                Path.GetFullPath(@"Shortcuts\" + Regex.Replace(this.Name, @"(_)+", " ") + ".lnk")); // Move .lnk to correct directory

            Process p = new Process();
            p.StartInfo.FileName = MainPath.exeString;
            p.StartInfo.Arguments = this.Name + " setGroupContextMenu";
            p.Start();
        }

        public bool updateRecentlyOpened(ProgramShortcut shortcutPressed)
        {
            if (!recentlyOpened.Where(pShortcut => pShortcut.FilePath == shortcutPressed.FilePath).Any())
            {
                if (recentlyOpened.Count >= 5)
                {
                    recentlyOpened.RemoveAt(0);
                }
                recentlyOpened.Add(shortcutPressed);
                writeXML();
                return true;
            } else
            {
                return false;
            }
        }

        private void writeXML()
        {
            //
            // XML config
            //
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Category));

            using (FileStream file = System.IO.File.Create(folderPath + @"\ObjectData.xml"))
            {
                writer.Serialize(file, this);
                file.Close();
            }
        }

        private static void createMultiIcon(Image iconImage, string filePath)
        {


            var diffList = from number in iconSizes
                select new
                    {
                        number,
                        difference = Math.Abs(number - iconImage.Height)
                    };
            var nearestSize = (from diffItem in diffList
                          orderby diffItem.difference
                          select diffItem).First().number;

            List<Bitmap> iconList = new List<Bitmap>();

            while (nearestSize != 16)
            {
                iconList.Add(ImageFunctions.ResizeImage(iconImage, nearestSize, nearestSize));
                nearestSize = (int)Math.Round((decimal) nearestSize / 2);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                IconFactory.SavePngsAsIcon(iconList.ToArray(), stream);
            }
        }

        public Bitmap LoadIconImage() // Needed to access img without occupying read/write
        {
            string path = @MainPath.path + @"\config\" + Name + @"\GroupImage.png";

            using (MemoryStream ms = new MemoryStream(System.IO.File.ReadAllBytes(path)))
                return new Bitmap(ms);
        }

        // Goal is to create a folder with icons of the programs pre-cached and ready to be read
        // Avoids having the icons need to be rebuilt everytime which takes time and resources
        public void cacheIcons()
        {

            // Defines the paths for the icons folder
            string path = @MainPath.path + @"\config\" + this.Name;
            string iconPath = path + "\\Icons\\";

            // Check and delete current icons folder to completely rebuild the icon cache
            // Only done on re-edits of the group and isn't done usually
            if (Directory.Exists(iconPath))
            {
                Directory.Delete(iconPath, true);
            }

            // Creates the icons folder inside of existing config folder for the group
            Directory.CreateDirectory(iconPath);

            iconPath = @path + @"\Icons\";

            // Loops through each shortcut added by the user and gets the icon
            // Writes the icon to the new folder in a .jpg format
            // Namign scheme for the files are done through Path.GetFileNameWithoutExtension()
            IEnumerable<ProgramShortcut> shortcutListReversed = ShortcutList.AsEnumerable().Reverse();

            int ind = 0;
            foreach(ProgramShortcut shrtcutList in shortcutListReversed)
            {
                String filePath = ShortcutList[ind].FilePath;

                ucProgramShortcut programShortcutControl = Application.OpenForms["frmGroup"].Controls["pnlShortcuts"].Controls[ind] as ucProgramShortcut;
                string savePath;

                if (ShortcutList[ind].isWindowsApp)
                {
                    savePath = iconPath + "\\" + specialCharRegex.Replace(filePath, string.Empty) + ".png";
                }
                else if (Directory.Exists(filePath))
                {
                    savePath = iconPath + "\\" + Path.GetFileNameWithoutExtension(filePath) + "_FolderObjTSKGRoup.png";
                }
                else
                {
                    savePath = iconPath + "\\" + Path.GetFileNameWithoutExtension(filePath) + ".png";
                }

                programShortcutControl.logo.Save(savePath);
                ind++;
            }
        }

        // Try to load an iamge from the cache
        // Takes in a programPath (shortcut) and processes it to the proper file name
        public Image loadImageCache(ProgramShortcut shortcutObject)
        {

            String programPath = shortcutObject.FilePath;

            if (System.IO.File.Exists(programPath) || Directory.Exists(programPath) || shortcutObject.isWindowsApp)
            {
                try
                {
                    // Try to construct the path like if it existed
                    // If it does, directly load it into memory and return it
                    // If not then it would throw an exception in which the below code would catch it
                    String cacheImagePath = generateCachePath(shortcutObject, programPath);

                    using (MemoryStream ms = new MemoryStream(System.IO.File.ReadAllBytes(cacheImagePath)))
                        return Image.FromStream(ms);
                    
                }
                catch (Exception)
                {
                    // Try to recreate the cache icon image and catch and missing file/icon situations that may arise

                    // Checks if the original file even exists to make sure to not do any extra operations

                    // Same processing as above in cacheIcons()
                    String path = MainPath.path + @"\config\" + this.Name + @"\Icons\" + Path.GetFileNameWithoutExtension(programPath) + (Directory.Exists(programPath) ? "_FolderObjTSKGRoup.png" : ".png");

                    Image finalImage;

                    if (Path.GetExtension(programPath).ToLower() == ".lnk")
                    {
                        finalImage = Forms.frmGroup.handleLnkExt(programPath);
                    }
                    else if (Directory.Exists(programPath))
                    {
                        finalImage = handleFolder.GetFolderIcon(programPath).ToBitmap();
                    } else 
                    {
                        finalImage = Icon.ExtractAssociatedIcon(programPath).ToBitmap();
                    }


                    // Above all sets finalIamge to the bitmap that was generated from the icons
                    // Save the icon after it has been fetched by previous code
                    finalImage.Save(path);

                    // Return the said image
                    return finalImage;
                }
            }
            else
            {
                return global::client.Properties.Resources.Error;
            }
        }

        public String generateCachePath(ProgramShortcut shortcutObject, String programPath)
        {
            return @Path.GetDirectoryName(Application.ExecutablePath) +
                        @"\config\" + this.Name + @"\Icons\" + ((shortcutObject.isWindowsApp) ? specialCharRegex.Replace(programPath, string.Empty) :
                        @Path.GetFileNameWithoutExtension(programPath)) + (Directory.Exists(programPath) ? "_FolderObjTSKGRoup.png" : ".png");
        }

        public static string GetMimeType(Image i)
        {
            var imgguid = i.RawFormat.Guid;
            foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageDecoders())
            {
                if (codec.FormatID == imgguid)
                    return codec.FilenameExtension;
            }
            return "image/unknown";
        }
        //
        // END OF CLASS
        //
    }
}
