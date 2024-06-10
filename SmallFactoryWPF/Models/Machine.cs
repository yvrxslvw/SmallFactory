using System.ComponentModel;
using System.Threading.Tasks;
using System.Timers;

namespace SmallFactoryWPF.Models
{
    public enum MachineStatus
    {
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

        private Timer _timer;

        public event PropertyChangedEventHandler PropertyChanged;

        protected Machine(Receipt receipt, ref Part outputPart)
        {
            Status = MachineStatus.WAITING;
            Receipt = receipt;
            OutputPart = outputPart;
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

        public virtual async Task Cycle()
        {
            ErrorMessage = string.Empty;
            Status = MachineStatus.PROCESSING;
            _timer.Interval = Receipt.CycleRate * 1000 / 100;
            _timer.Enabled = true;
            await Task.Delay((int)(Receipt.CycleRate * 1000));
            _timer.Enabled = false;
            OutputPart.StorageCount += (int)(Receipt.ProductionRate / 60 * Receipt.CycleRate);
            Status = MachineStatus.WAITING;
            Process = 0;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
