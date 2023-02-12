using client.User_controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace client.Classes
{
    public class Category
    {
        public string Name = "";
        public string ColorString = System.Drawing.ColorTranslator.ToHtml(Color.FromArgb(31, 31, 31));
        public bool allowOpenAll = false;
        public List<ProgramShortcut> ShortcutList;
        public int Width; // not used aon
        public double Opacity = 10;
        public String HoverColor;
        public int IconSize = 50;
        public int Separation = 8;

        Regex specialCharRegex = new Regex("[*'\",_&#^@]");

        private static int[] iconSizes = new int[] {16,32,64,128,256,512};
        private string path;

        public Category(string inputPath)
        {
            path = inputPath;
            // Use application's absolute path; (grabs the .exe)
            // Gets the parent folder of the exe and concats the rest of the path
            string fullPath;

            // Check if path is a full directory or part of a file name
            // Passed from the main shortcut client and the config client


            // This if won't ever be true, because the path passed in is a full path to a folder.
            /*
            if (System.IO.File.Exists(@Paths.path + @"\" + path + @"\ObjectData.xml"))
            {
                fullPath = @Paths.path + @"\" + path + @"\ObjectData.xml";
            }
            else
            {
            */
            fullPath = Path.GetFullPath(Path.Combine(inputPath, "ObjectData.xml"));
            /*
            }
            */

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
                this.HoverColor = category.HoverColor;
                this.IconSize = category.IconSize;
                this.Separation = category.Separation;
            }

        }

        public String getPath()
        {
            return path;
        }

        public Category() // needed for XML serialization
        {

        }

        public void CreateConfig(Image groupImage)
        {
            try
            {
                //string filePath = path + @"\" + this.Name + "Group.exe";
                //
                // Directory and .exe
                //
                path = Path.Combine(Paths.ConfigPath, this.Name);
                System.IO.Directory.CreateDirectory(@path);

                //System.IO.File.Copy(@"config\config.exe", @filePath);


                writeXML();

                //
                // Create .ico
                //

                Image img = ImageFunctions.ResizeImage(groupImage, 256, 256); // Resize img if too big
                img.Save(Path.Combine(path, "GroupImage.png"));

                if (GetMimeType(groupImage).ToString() == "*.PNG")
                {
                    createMultiIcon(groupImage, Path.Combine(path, "GroupIcon.ico"));
                }
                else
                {
                    using (FileStream fs = new FileStream(Path.Combine(path, "GroupIcon.ico"), FileMode.Create))
                    {
                        ImageFunctions.IconFromImage(img).Save(fs);
                        fs.Close();
                    }
                }


                // Through shellLink.cs class, pass through into the function information on how to construct the icon
                // Needed due to needing to set a unique AppUserModelID so the shortcut applications don't stack on the taskbar with the main application
                // Tricks Windows to think they are from different applications even though they are from the same .exe
                ShellLink.InstallShortcut(
                    Paths.BackgroundApplication,
                    "tjackenpacken.taskbarGroup.menu." + this.Name,
                    path + " shortcut",
                    path,
                    Path.Combine(path, "GroupIcon.ico"),
                    Path.Combine(path, this.Name + ".lnk"),
                    this.Name
                );


                // Build the icon cache
                cacheIcons();

                System.IO.File.Move(Path.Combine(path, this.Name + ".lnk"),
                    Path.Combine(Paths.ShortcutsPath, Regex.Replace(this.Name, @"(_)+", " ") + ".lnk")); // Move .lnk to correct directory
            }
            catch { }
            finally
            {

                closeBackgroundApp();


                Process backgroundProcess = new Process();
                backgroundProcess.StartInfo.FileName = Paths.BackgroundApplication;
                backgroundProcess.Start();
                

                Process p = new Process();
                p.StartInfo.FileName = Paths.BackgroundApplication;
                p.StartInfo.Arguments = this.Name + " setGroupContextMenu";
                p.Start();
                
            }
        }


        private void writeXML()
        {
            //
            // XML config
            //
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Category));

            using (FileStream file = System.IO.File.Create(Path.Combine(@path, "ObjectData.xml")))
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
            string path = Path.Combine(Paths.ConfigPath, Name, "GroupImage.png");

            using (MemoryStream ms = new MemoryStream(System.IO.File.ReadAllBytes(path)))
                return new Bitmap(ms);
        }

        // Goal is to create a folder with icons of the programs pre-cached and ready to be read
        // Avoids having the icons need to be rebuilt everytime which takes time and resources
        public void cacheIcons()
        {

            // Defines the paths for the icons folder
            string path = Path.Combine(Paths.ConfigPath, this.Name);
            string iconPath = Path.Combine(path, "Icons");

            // Check and delete current icons folder to completely rebuild the icon cache
            // Only done on re-edits of the group and isn't done usually
            if (Directory.Exists(iconPath))
            {
                Directory.Delete(iconPath, true);
            }

            // Creates the icons folder inside of existing config folder for the group
            Directory.CreateDirectory(iconPath);

            // Loops through each shortcut added by the user and gets the icon
            // Writes the icon to the new folder in a .jpg format
            // Namign scheme for the files are done through Path.GetFileNameWithoutExtension()

            for(int i=0; i< ShortcutList.Count; i++)
            {
                String filePath = ShortcutList[i].FilePath;

                ucProgramShortcut programShortcutControl = Application.OpenForms["frmGroup"].Controls["pnlShortcuts"].Controls[i] as ucProgramShortcut;
                string savePath = Path.Combine(iconPath, generateMD5Hash(filePath) + ".png");
                programShortcutControl.logo.Save(savePath);
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
                    String cacheImagePath = generateCachePath(programPath);

                    using (MemoryStream ms = new MemoryStream(System.IO.File.ReadAllBytes(cacheImagePath)))
                        return Image.FromStream(ms);
                    
                }
                catch (Exception)
                {
                    // Try to recreate the cache icon image and catch and missing file/icon situations that may arise

                    // Checks if the original file even exists to make sure to not do any extra operations

                    // Same processing as above in cacheIcons()
                    String path = Path.Combine(Paths.ConfigPath, this.Name, "Icons", generateMD5Hash(programPath)+".png");

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

        public String generateCachePath(String programPath)
        {
            /*
            return @Path.GetDirectoryName(Application.ExecutablePath) +
                        @"\config\" + this.Name + @"\Icons\" + ((shortcutObject.isWindowsApp) ? specialCharRegex.Replace(programPath, string.Empty) :
                        @Path.GetFileNameWithoutExtension(programPath)) + (Directory.Exists(programPath) ? "_FolderObjTSKGRoup.png" : ".png");
            */

            return Path.Combine(Paths.ConfigPath, this.Name, "Icons",
                        generateMD5Hash(programPath) + ".png");
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

        public Color calculateHoverColor()
        {
            Color BackColor = ImageFunctions.FromString(ColorString);
            if (BackColor.R * 0.2126 + BackColor.G * 0.7152 + BackColor.B * 0.0722 > 255 / 2)
            {
                // Do prior calculations on darker colors to prevent color values going negative
                int backColorR = BackColor.R - 50 >= 0 ? BackColor.R - 50 : 0;
                int backColorG = BackColor.G - 50 >= 0 ? BackColor.G - 50 : 0;
                int backColorB = BackColor.B - 50 >= 0 ? BackColor.B - 50 : 0;

                //if backcolor is light, set hover color as darker
                return Color.FromArgb(BackColor.A, backColorR, backColorG, backColorB);
            }
            else
            {
                // Do prior calculations on darker colors to prevent color values going over 255
                int backColorR = BackColor.R + 50 <= 255 ? BackColor.R + 50 : 255;
                int backColorG = BackColor.G + 50 <= 255 ? BackColor.G + 50 : 255;
                int backColorB = BackColor.B + 50 <= 255 ? BackColor.B + 50 : 255;

                //light backcolor is light, set hover color as darker
                return Color.FromArgb(BackColor.A, (BackColor.R + 50), (BackColor.G + 50), (BackColor.B + 50));
            }
        }

        private String generateMD5Hash(String s)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(s);
                byte[] hashBytes = md5.ComputeHash(inputBytes);


                StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                     sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        //
        // END OF CLASS
        //

        public static void closeBackgroundApp(string path = "")
        {
            Process[] pname = Process.GetProcessesByName(Path.GetFileNameWithoutExtension("Taskbar Groups Background"));
            if (pname.Length != 0)
            {
                Process bkg = pname[0];

                Process p = new Process();
                if (path == "")
                {
                    path = Paths.BackgroundApplication;
                }
                p.StartInfo.FileName = path;
                p.StartInfo.Arguments = "exitApplicationModeReserved";
                p.Start();

                if(!bkg.WaitForExit(2000))
                {
                    bkg.Kill();
                }
            }
            
        }
    }
}
