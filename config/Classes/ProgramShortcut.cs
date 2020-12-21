using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace config.Classes
{
    public class ProgramShortcut
    {
        public string Name { get; set; }
        public string FilePath { get; set; }

        public ProgramShortcut()
        {
            // needed for xml serialization
        }

    }
}
