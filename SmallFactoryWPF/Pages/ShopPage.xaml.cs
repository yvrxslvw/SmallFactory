using SmallFactoryWPF.Controls;
using SmallFactoryWPF.Models;
using System.Windows.Controls;

namespace SmallFactoryWPF.Pages
{
    public partial class ShopPage : Page
    {
        private Factory Factory;

        private Part IronRodPart;
        private Part CopperSheetPart;
        private Part WirePart;
        private Part PlasticPart;
        private Part ScrewPart;
        private Part CircuitBoardPart;
        private Part CablePart;
        private Part ComputerPart;

        public ShopPage(ref Factory factory,
                        ref Part ironRodPart,
                        ref Part copperSheetPart,
                        ref Part wirePart,
                        ref Part plasticPart,
                        ref Part screwPart,
                        ref Part circuitBoardPart,
                        ref Part cablePart,
                        ref Part computerPart)
        {
            Factory = factory;
            IronRodPart = ironRodPart;
            CopperSheetPart = copperSheetPart;
            WirePart = wirePart;
            PlasticPart = plasticPart;
            ScrewPart = screwPart;
            CircuitBoardPart = circuitBoardPart;
            CablePart = cablePart;
            ComputerPart = computerPart;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            RenderBalance();
            InitializeShop();
            DataContext = Factory;
        }

        private void RenderBalance()
        {
            string balance = Factory.Budget.ToString("N");
        }

        private void InitializeShop()
        {
            SPShopItems.Children.Clear();
            SPShopItems.Children.Add(new ShopItem(ref Factory, ref IronRodPart));
            SPShopItems.Children.Add(new ShopItem(ref Factory, ref CopperSheetPart));
            SPShopItems.Children.Add(new ShopItem(ref Factory, ref WirePart));
            SPShopItems.Children.Add(new ShopItem(ref Factory, ref PlasticPart));
            SPShopItems.Children.Add(new ShopItem(ref Factory, ref ScrewPart));
            SPShopItems.Children.Add(new ShopItem(ref Factory, ref CircuitBoardPart));
            SPShopItems.Children.Add(new ShopItem(ref Factory, ref CablePart));
            SPShopItems.Children.Add(new ShopItem(ref Factory, ref ComputerPart));
        }
    }
}
