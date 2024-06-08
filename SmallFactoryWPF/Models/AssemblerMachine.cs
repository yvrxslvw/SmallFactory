using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmallFactoryWPF.Models
{
    public class AssemblerMachine : Machine
    {
        public readonly List<Part> Input1;

        public readonly List<Part> Input2;

        public AssemblerMachine(AssemblerReceipt receipt) : base(receipt)
        {
            Input1 = new List<Part>();
            Input2 = new List<Part>();
        }

        protected override async Task Cycle()
        {
            AssemblerReceipt receipt = Receipt as AssemblerReceipt;
            int input1Required = (int)(60 / receipt.Material1Rate);
            int input2Required = (int)(60 / receipt.Material2Rate);

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

            Input1.RemoveRange(0, input1Required);
            Input2.RemoveRange(0, input2Required);
            await base.Cycle();
        }
    }
}
