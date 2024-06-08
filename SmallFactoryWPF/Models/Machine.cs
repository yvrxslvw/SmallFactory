using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmallFactoryWPF.Models
{
    public enum MachineStatus
    {
        ERROR,
        WAITING,
        PROCESSING
    }

    public abstract class Machine
    {
        public MachineStatus Status;

        public readonly Receipt Receipt;

        public readonly List<Part> Input;

        public readonly List<Part> Output;

        public string ErrorMessage = string.Empty;

        protected Machine(Receipt receipt)
        {
            Status = MachineStatus.WAITING;
            Receipt = receipt;
            Input = new List<Part>();
            Output = new List<Part>();
        }

        public virtual async Task Cycle()
        {
            Status = MachineStatus.PROCESSING;
            await Task.Delay((int)(60 / Receipt.ProductionRate * 1000));
            Output.Add(Receipt.ResultPart);
            Status = MachineStatus.WAITING;
        }
    }
}
