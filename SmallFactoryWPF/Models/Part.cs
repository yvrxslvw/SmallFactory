using System.ComponentModel;
using System.Timers;

namespace SmallFactoryWPF.Models
{
    public class Part : INotifyPropertyChanged
    {
        public readonly string Name;

        public readonly decimal Price;

        public readonly double ShopCooldown;

        private int shopCount;

        public int ShopCount
        {
            get { return shopCount; }
            set
            {
                if (shopCount != value)
                {
                    shopCount = value;
                    OnPropertyChanged(nameof(ShopCount));
                }
            }
        }

        private int storageCount = 0;

        public int StorageCount
        {
            get { return storageCount; }
            set
            {
                if (storageCount != value)
                {
                    storageCount = value;
                    OnPropertyChanged(nameof(StorageCount));
                }
            }
        }

        private Timer _timer;

        public Part(string name, decimal price, double shopCooldown, int shopCount)
        {
            Name = name;
            Price = price;
            ShopCooldown = shopCooldown;
            ShopCount = shopCount;
        }

        public void Replenishment()
        {
            if (ShopCooldown <= 0) return;
            _timer = new Timer(ShopCooldown * 60 * 1000);
            _timer.Elapsed += IncrementCount;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void IncrementCount(object sender, ElapsedEventArgs e)
        {
            ShopCount++;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
