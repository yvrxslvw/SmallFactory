using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmallFactoryWPF.Models
{
    public class ConstructorMachine : Machine
    {
        public readonly List<Part> Input1;

        public ConstructorMachine(ConstructorReceipt receipt) : base(receipt)
        {
            Input1 = new List<Part>();
        }

        protected override async Task Cycle()
        {
            ConstructorReceipt receipt = Receipt as ConstructorReceipt;
            int input1Required = (int)(60 / receipt.Material1Rate);

            if (Input1.Count < input1Required)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Недостаточно \"{receipt.Material1.Name}\".";
                return;
            }

            Input1.RemoveRange(0, input1Required);
            await base.Cycle();
        }
    }
}
