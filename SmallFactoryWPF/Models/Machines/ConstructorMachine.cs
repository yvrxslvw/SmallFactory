using System;
using System.Threading.Tasks;
using System.Timers;

namespace SmallFactoryWPF.Models
{
    public class ConstructorMachine : Machine
    {
        public Part Input1Part;

        private Timer _timer;

        public ConstructorMachine(ConstructorReceipt receipt, ref Part input1Part, ref Part outputPart) : base(receipt, ref outputPart)
        {
            Input1Part = input1Part;
            _timer = new Timer();
            _timer.AutoReset = true;
            _timer.Enabled = false;
            _timer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (Process == 100) return;
            Process += 1;
        }

        public override async Task Cycle()
        {
            if (Status == MachineStatus.PROCESSING) return;
            Status = MachineStatus.PROCESSING;
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

            ErrorMessage = string.Empty;
            _timer.Interval = (Receipt.CycleRate / 100) * 1000 - 10;
            _timer.Enabled = true;
            await Task.Delay((int)(Receipt.CycleRate * 1000));
            _timer.Enabled = false;
            Status = IsEnabled ? MachineStatus.WAITING : MachineStatus.TURNED_OFF;
            Process = 0;

            OutputPart.StorageCount += (int)Math.Ceiling(Receipt.ProductionRate / (60 / Receipt.CycleRate));
        }
    }
}
