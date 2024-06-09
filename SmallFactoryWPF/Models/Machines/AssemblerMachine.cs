using System.Threading.Tasks;

namespace SmallFactoryWPF.Models
{
    public class AssemblerMachine : Machine
    {
        public Part Input1Part;

        public Part Input2Part;

        public AssemblerMachine(ConstructorReceipt receipt, ref Part input1Part, ref Part input2Part, ref Part outputPart) : base(receipt, ref outputPart)
        {
            Input1Part = input1Part;
            Input2Part = input2Part;
        }

        public override async Task Cycle()
        {
            AssemblerReceipt receipt = Receipt as AssemblerReceipt;

            if (receipt.Material1.Name != Input1Part.Name)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Деталь 1 не совпадает с рецептом.";
                return;
            }
            else if (receipt.Material2.Name != Input2Part.Name)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Деталь 2 не совпадает с рецептом.";
                return;
            }
            if (Input1Part.StorageCount < receipt.Material1Required)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Недостаточно \"{receipt.Material1.Name}\".";
                return;
            }
            else if (Input2Part.StorageCount < receipt.Material2Required)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Недостаточно \"{receipt.Material2.Name}\".";
                return;
            }

            Input1Part.StorageCount -= receipt.Material1Required;
            Input2Part.StorageCount -= receipt.Material2Required;
            await base.Cycle();
        }
    }
}
