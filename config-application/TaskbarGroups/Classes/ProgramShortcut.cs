namespace TaskbarGroups.Classes
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
