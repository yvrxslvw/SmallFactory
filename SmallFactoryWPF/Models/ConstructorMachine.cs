using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallFactoryWPF.Models
{
    public class ConstructorMachine : Machine
    {
        public ConstructorMachine(ConstructorReceipt receipt) : base(receipt) { }

        public override async Task Cycle()
        {
            ConstructorReceipt receipt = Receipt as ConstructorReceipt;
            int input1Required = (int)(receipt.Material1Rate / receipt.ProductionRate);
            List<Part> materials1 = Input.Where(p => p.Name == receipt.Material1.Name).ToList();

            if (materials1.Count < input1Required)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Недостаточно \"{receipt.Material1.Name}\".";
                return;
            }

            for (int i = 0; i < input1Required; i++) Input.Remove(materials1[i]);
            await base.Cycle();
        }
    }
}
