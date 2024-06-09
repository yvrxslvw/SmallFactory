using System.Threading.Tasks;

namespace SmallFactoryWPF.Models
{
    public class ConstructorMachine : Machine
    {
        public Part Input1Part;

        public ConstructorMachine(ConstructorReceipt receipt, ref Part input1Part, ref Part outputPart) : base(receipt, ref outputPart)
        {
            Input1Part = input1Part;
        }

        public override async Task Cycle()
        {
            ConstructorReceipt receipt = Receipt as ConstructorReceipt;

            if (receipt.Material1.Name != Input1Part.Name)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Деталь 1 не совпадает с рецептом.";
                return;
            }
            if (Input1Part.StorageCount < receipt.Material1Required)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Недостаточно \"{receipt.Material1.Name}\".";
                return;
            }

            Input1Part.StorageCount -= receipt.Material1Required;
            await base.Cycle();
        }
    }
}
