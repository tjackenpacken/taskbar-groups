using System;

namespace client.Classes
{
    // Function that is accessed by all forms to get the starting absolute path of the .exe
    // Added as to not keep generating the path in each form
    static class MainPath
    {
        public static String path;
    }
}
