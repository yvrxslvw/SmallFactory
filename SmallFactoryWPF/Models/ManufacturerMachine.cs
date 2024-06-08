using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmallFactoryWPF.Models
{
    public class ManufacturerMachine : Machine
    {
        public readonly List<Part> Input1;

        public readonly List<Part> Input2;

        public readonly List<Part> Input3;

        public readonly List<Part> Input4;

        public ManufacturerMachine(ManufacturerReceipt receipt) : base(receipt)
        {
            Input1 = new List<Part>();
            Input2 = new List<Part>();
            Input3 = new List<Part>();
            Input4 = new List<Part>();
        }

        protected override async Task Cycle()
        {
            ManufacturerReceipt receipt = Receipt as ManufacturerReceipt;
            int input1Required = (int)(60 / receipt.Material1Rate);
            int input2Required = (int)(60 / receipt.Material2Rate);
            int input3Required = (int)(60 / receipt.Material3Rate);
            int input4Required = (int)(60 / receipt.Material4Rate);

            if (Input1.Count < input1Required)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Недостаточно {receipt.Material1.Name}.";
                return;
            }
            else if (Input2.Count < input2Required)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Недостаточно {receipt.Material2.Name}.";
                return;
            }
            else if (Input3.Count < input3Required)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Недостаточно {receipt.Material3.Name}.";
                return;
            }
            else if (Input4.Count < input4Required)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Недостаточно {receipt.Material4.Name}.";
                return;
            }

            Input1.RemoveRange(0, input1Required);
            Input2.RemoveRange(0, input2Required);
            Input3.RemoveRange(0, input3Required);
            Input4.RemoveRange(0, input4Required);
            await base.Cycle();
        }
    }
}
