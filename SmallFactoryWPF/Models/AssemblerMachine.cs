using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallFactoryWPF.Models
{
    public class AssemblerMachine : Machine
    {
        public AssemblerMachine(AssemblerReceipt receipt) : base(receipt) { }

        public override async Task Cycle()
        {
            AssemblerReceipt receipt = Receipt as AssemblerReceipt;
            int input1Required = (int)(receipt.Material1Rate / receipt.ProductionRate);
            int input2Required = (int)(receipt.Material2Rate / receipt.ProductionRate);
            List<Part> materials1 = Input.Where(p => p.Name == receipt.Material1.Name).ToList();
            List<Part> materials2 = Input.Where(p => p.Name == receipt.Material2.Name).ToList();

            if (materials1.Count < input1Required)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Недостаточно \"{receipt.Material1.Name}\".";
                return;
            }
            else if (materials2.Count < input2Required)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Недостаточно \"{receipt.Material2.Name}\".";
                return;
            }

            for (int i = 0; i < input1Required; i++) Input.Remove(materials1[i]);
            for (int i = 0; i < input2Required; i++) Input.Remove(materials2[i]);
            await base.Cycle();
        }
    }
}
