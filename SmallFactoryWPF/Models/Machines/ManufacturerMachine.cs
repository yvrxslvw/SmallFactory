using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallFactoryWPF.Models
{
    public class ManufacturerMachine : Machine
    {
        public ManufacturerMachine(ManufacturerReceipt receipt) : base(receipt) { }

        public override async Task Cycle()
        {
            ManufacturerReceipt receipt = Receipt as ManufacturerReceipt;
            int input1Required = (int)(receipt.Material1Rate / receipt.ProductionRate);
            int input2Required = (int)(receipt.Material2Rate / receipt.ProductionRate);
            int input3Required = (int)(receipt.Material3Rate / receipt.ProductionRate);
            int input4Required = (int)(receipt.Material4Rate / receipt.ProductionRate);
            List<Part> materials1 = Input.Where(p => p.Name == receipt.Material1.Name).ToList();
            List<Part> materials2 = Input.Where(p => p.Name == receipt.Material2.Name).ToList();
            List<Part> materials3 = Input.Where(p => p.Name == receipt.Material3.Name).ToList();
            List<Part> materials4 = Input.Where(p => p.Name == receipt.Material4.Name).ToList();

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
            else if (materials3.Count < input3Required)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Недостаточно \"{receipt.Material3.Name}\".";
                return;
            }
            else if (materials4.Count < input4Required)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Недостаточно \"{receipt.Material4.Name}\".";
                return;
            }

            for (int i = 0; i < input1Required; i++) Input.Remove(materials1[i]);
            for (int i = 0; i < input2Required; i++) Input.Remove(materials2[i]);
            for (int i = 0; i < input3Required; i++) Input.Remove(materials3[i]);
            for (int i = 0; i < input4Required; i++) Input.Remove(materials4[i]);
            await base.Cycle();
        }
    }
}
