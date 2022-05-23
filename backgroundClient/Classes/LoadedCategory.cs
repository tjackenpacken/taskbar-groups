using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backgroundClient.Classes
{
    public class LoadedCategory
    {
        public List<Image> programImages = new List<Image>();
        public List<ProgramShortcut> programShortcuts = new List<ProgramShortcut>();

        public bool allowOpenAll;
        public int Width;
        public double Opacity = 10;
        public string ColorString = System.Drawing.ColorTranslator.ToHtml(Color.FromArgb(31, 31, 31));
        public Icon groupIco;
        public string Name;

        public String HoverColor;

        public LoadedCategory(string loadCat)
        {
            Category newCat = new Category(loadCat);

            programShortcuts = newCat.ShortcutList;
            HoverColor = newCat.HoverColor;
            Width = newCat.Width;
            ColorString = newCat.ColorString;
            Name = newCat.Name;
            allowOpenAll = newCat.allowOpenAll;

            foreach (ProgramShortcut psc in programShortcuts)
            {
                programImages.Add(newCat.loadImageCache(psc));
            }

            using (MemoryStream ms = new MemoryStream(System.IO.File.ReadAllBytes(Path.Combine(loadCat, "GroupIcon.ico"))))
                groupIco = new Icon(ms);
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

    }
}
