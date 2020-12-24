namespace client.Classes
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
