using System.ComponentModel;
using System.Threading.Tasks;

namespace SmallFactoryWPF.Models
{
    public enum MachineStatus
    {
        [Description("Выключен")]
        TURNED_OFF,
        [Description("Ошибка")]
        ERROR,
        [Description("Ожидание")]
        WAITING,
        [Description("Процесс")]
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

        private int process;

        public int Process
        {
            get { return process; }
            set
            {
                if (process != value)
                {
                    process = value;
                    OnPropertyChanged(nameof(Process));
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

        private bool isEnabled = false;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                if (isEnabled != value)
                {
                    if (Status != MachineStatus.PROCESSING) Status = value ? MachineStatus.WAITING : MachineStatus.TURNED_OFF;
                    ErrorMessage = string.Empty;
                    isEnabled = value;
                    OnPropertyChanged(nameof(IsEnabled));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected Machine(Receipt receipt, ref Part outputPart)
        {
            Status = MachineStatus.TURNED_OFF;
            Receipt = receipt;
            OutputPart = outputPart;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task Cycle() { return Task.CompletedTask; }
    }
}
