using System.Collections.Generic;

namespace SmallFactoryWPF.Models
{
    internal class ProductionChain
    {
        public string Name { get; set; }

        public IEnumerable<Machine> Machines { get; set; }
    }
}
