using System.ComponentModel;
using System.Threading.Tasks;

namespace SmallFactoryWPF.Models
{
    public enum MachineStatus
    {
        ERROR,
        WAITING,
        PROCESSING
    }

    public abstract class Machine : INotifyPropertyChanged
    {
        private MachineStatus status;

        public MachineStatus Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public Part OutputPart;

        public readonly Receipt Receipt;

        private string errorMessage = string.Empty;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected Machine(Receipt receipt, ref Part outputPart)
        {
            Status = MachineStatus.WAITING;
            Receipt = receipt;
            OutputPart = outputPart;
        }

        public virtual async Task Cycle()
        {
            Status = MachineStatus.PROCESSING;
            await Task.Delay((int)(Receipt.CycleRate * 1000));
            OutputPart.StorageCount += (int)(Receipt.ProductionRate / 60 * Receipt.CycleRate);
            Status = MachineStatus.WAITING;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
