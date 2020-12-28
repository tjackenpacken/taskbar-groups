namespace client.Classes
{
    public class ProgramShortcut
    {
        public string FilePath { get; set; }
        public string Arguments = "";

        public ProgramShortcut(string filePath)
        {
            FilePath = filePath;
        }

       

        public ProgramShortcut() // needed for XML serialization
        {

        }

    }
}
