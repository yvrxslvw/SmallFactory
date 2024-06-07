using System.Collections.Generic;

namespace SmallFactoryWPF.Models
{
    internal class Storage
    {
        public IEnumerable<Part> Parts { get; set; }

        public int Max { get; set; }
    }
}
