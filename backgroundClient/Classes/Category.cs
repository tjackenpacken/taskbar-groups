using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace backgroundClient.Classes
{
    public class Category
    {
        public List<Image> programImages = new List<Image>();

        public string Name = "";
        public string ColorString = System.Drawing.ColorTranslator.ToHtml(Color.FromArgb(31, 31, 31));
        public bool allowOpenAll = false;
        public List<ProgramShortcut> ShortcutList;
        public int Width; // not used aon
        public double Opacity = 10;
        public String HoverColor;
        public int IconSize = 30;
        public int Separation = 8;

        public Icon groupIco;

        public Category()
        {

        }

        public Category(string loadCat)
        {
            String fullPath = Path.GetFullPath(Path.Combine(loadCat, "ObjectData.xml"));

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



            foreach (ProgramShortcut psc in ShortcutList)
            {
                programImages.Add(loadImageCache(psc));
            }

            using (MemoryStream ms = new MemoryStream(System.IO.File.ReadAllBytes(Path.Combine(loadCat, "GroupIcon.ico"))))
                groupIco = new Icon(ms);

            Color sysColor = bkgProcess.SystemColors;
            if (ColorString == "sys")
            {
                ColorString = "#" + sysColor.R.ToString("X2") + sysColor.G.ToString("X2") + sysColor.B.ToString("X2");
            }
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
                    String cacheImagePath = generateCachePath(shortcutObject);

                    using (MemoryStream ms = new MemoryStream(System.IO.File.ReadAllBytes(cacheImagePath)))
                    {
                        return Image.FromStream(ms);

                    }

                }
                catch (Exception)
                {
                    return global::backgroundClient.Properties.Resources.Error;
                }
            }
            else
            {
                return global::backgroundClient.Properties.Resources.Error;
            }
        }

        public String generateCachePath(ProgramShortcut shortcutObject)
        {
            return Path.Combine(Paths.ConfigPath, this.Name, "Icons",
                        generateMD5Hash(shortcutObject.FilePath + shortcutObject.Arguments) + ".png");
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
    }
}
