namespace client.Classes
{
    public class ProgramShortcut
    {
        public string FilePath { get; set; }
        public string name { get; set; } = "";
        public string Arguments = "";
 

        public ProgramShortcut() // needed for XML serialization
        {

        }

    }
}
