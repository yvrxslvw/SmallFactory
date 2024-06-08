using System.Collections.Generic;

namespace SmallFactoryWPF.Models
{
    public class Storage<T>
    {
        private readonly List<T> Parts;

        public readonly int Max;

        public Storage(int max)
        {
            Parts = new List<T>();
            Max = max;
        }

        public void Add(T part)
        {
            Parts.Add(part);
        }

        public List<T> GetParts()
        {
            return Parts;
        }
    }
}
