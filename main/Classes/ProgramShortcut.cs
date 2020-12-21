using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.Classes
{
    public class ProgramShortcut
    {
        public string FilePath { get; set; }

        public ProgramShortcut(string filePath)
        {
            FilePath = filePath;
        }

        public ProgramShortcut() // needed for XML serialization
        {

        }

    }
}
