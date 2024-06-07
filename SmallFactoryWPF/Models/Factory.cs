using System.Collections.Generic;

namespace SmallFactoryWPF.Models
{
    internal class Factory
    {
        public decimal Budget { get; set; }

        public IEnumerable<ProductionChain> ProductionChains { get; set; }
    }
}
