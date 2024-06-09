using System.Threading.Tasks;

namespace SmallFactoryWPF.Models
{
    public class ManufacturerMachine : Machine
    {
        public Part Input1Part;

        public Part Input2Part;

        public Part Input3Part;

        public Part Input4Part;

        public ManufacturerMachine(ConstructorReceipt receipt,
                                   ref Part input1Part,
                                   ref Part input2Part,
                                   ref Part input3Part,
                                   ref Part input4Part,
                                   ref Part outputPart) : base(receipt, ref outputPart)
        {
            Input1Part = input1Part;
            Input2Part = input2Part;
            Input3Part = input3Part;
            Input4Part = input4Part;
        }

        public override async Task Cycle()
        {
            ManufacturerReceipt receipt = Receipt as ManufacturerReceipt;

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
            else if (receipt.Material3.Name != Input3Part.Name)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Деталь 3 не совпадает с рецептом.";
                return;
            }
            else if (receipt.Material4.Name != Input4Part.Name)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Деталь 4 не совпадает с рецептом.";
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
            else if (Input3Part.StorageCount < receipt.Material3Required)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Недостаточно \"{receipt.Material3.Name}\".";
                return;
            }
            else if (Input4Part.StorageCount < receipt.Material4Required)
            {
                Status = MachineStatus.ERROR;
                ErrorMessage = $"Недостаточно \"{receipt.Material4.Name}\".";
                return;
            }

            Input1Part.StorageCount -= receipt.Material1Required;
            Input2Part.StorageCount -= receipt.Material2Required;
            Input3Part.StorageCount -= receipt.Material3Required;
            Input4Part.StorageCount -= receipt.Material4Required;
            await base.Cycle();
        }
    }
}
