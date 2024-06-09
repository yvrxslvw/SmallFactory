using System.Timers;

namespace SmallFactoryWPF.Models
{
    public class WirePart : Part
    {
        public static decimal ShopPrice = 7;

        public static double ShopCooldown = 1;

        public static int ShopCount = 0;

        private static Timer _timer;

        public WirePart() : base("Проволока") { }

        public static void Replenishment()
        {
            if (ShopCooldown <= 0) return;
            _timer = new Timer(ShopCooldown * 60 * 1000);
            _timer.Elapsed += IncrementCount;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private static void IncrementCount(object sender, ElapsedEventArgs e)
        {
            ShopCount++;
        }
    }
}
