namespace SmallFactoryWPF.Models
{
    public abstract class Part
    {
        public readonly string Name;

        protected Part(string name)
        {
            Name = name;
        }
    }
}
