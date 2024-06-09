using SmallFactoryWPF.Models;
using System.Windows;

namespace SmallFactoryWPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ShopReplenishment();
            base.OnStartup(e);
        }

        private void ShopReplenishment()
        {
            CablePart.Replenishment();
            CircuitBoardPart.Replenishment();
            ComputerPart.Replenishment();
            CopperSheetPart.Replenishment();
            IronRodPart.Replenishment();
            PlasticPart.Replenishment();
            ScrewPart.Replenishment();
            WirePart.Replenishment();
        }
    }
}
