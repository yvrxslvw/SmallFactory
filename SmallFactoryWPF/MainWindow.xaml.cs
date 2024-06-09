using SmallFactoryWPF.Models;
using SmallFactoryWPF.Pages;
using System.Windows;

namespace SmallFactoryWPF
{
    public partial class MainWindow : Window
    {
        private Factory SmallFactory = new Factory();

        private Part IronRodPart;
        private Part CopperSheetPart;
        private Part WirePart;
        private Part PlasticPart;
        private Part ScrewPart;
        private Part CircuitBoardPart;
        private Part CablePart;
        private Part ComputerPart;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeParts();

            FShop.Navigate(new ShopPage(ref SmallFactory,
                                        ref IronRodPart,
                                        ref CopperSheetPart,
                                        ref WirePart,
                                        ref PlasticPart,
                                        ref ScrewPart,
                                        ref CircuitBoardPart,
                                        ref CablePart,
                                        ref ComputerPart));
        }

        private void InitializeParts()
        {
            IronRodPart = new Part("Железный Прут", 5, 1, 10);
            CopperSheetPart = new Part("Медный Лист", 10, 1, 10);
            WirePart = new Part("Проволока", 7, 1, 10);
            PlasticPart = new Part("Пластик", 6, 1, 20);
            ScrewPart = new Part("Винт", 3, 0, 0);
            CircuitBoardPart = new Part("Печатная Плата", 18, 0, 0);
            CablePart = new Part("Кабель", 8, 0, 0);
            ComputerPart = new Part("Компьютер", 42, 0, 0);

            IronRodPart.Replenishment();
            CopperSheetPart.Replenishment();
            WirePart.Replenishment();
            PlasticPart.Replenishment();
            ScrewPart.Replenishment();
            CircuitBoardPart.Replenishment();
            CablePart.Replenishment();
            ComputerPart.Replenishment();
        }
    }
}
