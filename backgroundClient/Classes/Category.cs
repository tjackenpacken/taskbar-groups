using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace backgroundClient.Classes
{
    public class Category
    {
        public string Name;
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

        public Category() // needed for XML serialization
        {

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
                    {
                        return Image.FromStream(ms);
                       
                    }
                    
                }
                catch (Exception)
                {
                    /*
                    // Try to recreate the cache icon image and catch and missing file/icon situations that may arise

                    // Checks if the original file even exists to make sure to not do any extra operations

                    // Same processing as above in cacheIcons()
                    String path = Path.Combine(Paths.ConfigPath, this.Name, "Icons", Path.GetFileNameWithoutExtension(programPath) + (Directory.Exists(programPath) ? "_FolderObjTSKGRoup.png" : ".png"));

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
                    */
                    return global::backgroundClient.Properties.Resources.Error;
                }
            }
            else
            {
                return global::backgroundClient.Properties.Resources.Error;
            }
        }

        public String generateCachePath(ProgramShortcut shortcutObject, String programPath)
        {
            /*
            return @Path.GetDirectoryName(Application.ExecutablePath) +
                        @"\config\" + this.Name + @"\Icons\" + ((shortcutObject.isWindowsApp) ? specialCharRegex.Replace(programPath, string.Empty) :
                        @Path.GetFileNameWithoutExtension(programPath)) + (Directory.Exists(programPath) ? "_FolderObjTSKGRoup.png" : ".png");
            */
            
            return Path.Combine(Paths.ConfigPath, this.Name, "Icons",
                        generateMD5Hash(programPath)+".png");
        }

        public Color calculateHoverColor()
        {
            Color BackColor = FromString(ColorString);
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

        public static Color FromString(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name");
            }
             
            KnownColor knownColor;

            if (Enum.TryParse(name, out knownColor))
            {
                return Color.FromKnownColor(knownColor);
            }

            return ColorTranslator.FromHtml(name);
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
    }
}
