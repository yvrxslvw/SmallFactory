using System.ComponentModel;

namespace SmallFactoryWPF.Models
{
    public class Factory : INotifyPropertyChanged
    {
        private decimal budget = 12000;

        public decimal Budget
        {
            get { return budget; }
            set
            {
                if (budget != value)
                {
                    budget = value;
                    OnPropertyChanged(nameof(Budget));
                    OnPropertyChanged(nameof(FormattedBudget));
                }
            }
        }

        public string FormattedBudget
        {
            get { return budget.ToString("N"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
