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

        private ConstructorReceipt ScrewReceipt;
        private AssemblerReceipt CircuitBoardReceipt;
        private ConstructorReceipt CableReceipt;
        private ManufacturerReceipt ComputerReceipt;

        private ConstructorMachine ScrewMachine;
        private AssemblerMachine CircuitBoardMachine;
        private ConstructorMachine CableMachine;
        private ManufacturerMachine ComputerMachine;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeParts();
            InitializeReceipts();
            InitializeMachines();

            FShop.Navigate(new ShopPage(ref SmallFactory,
                                        ref IronRodPart,
                                        ref CopperSheetPart,
                                        ref WirePart,
                                        ref PlasticPart,
                                        ref ScrewPart,
                                        ref CircuitBoardPart,
                                        ref CablePart,
                                        ref ComputerPart));
            FMachines.Navigate(new MachinesPage(ref ScrewMachine,
                                                ref CircuitBoardMachine,
                                                ref CableMachine,
                                                ref ComputerMachine));
        }

        private void InitializeParts()
        {
            IronRodPart = new Part("Железный Прут", 5, 1, 16);
            CopperSheetPart = new Part("Медный Лист", 10, 1, 80);
            WirePart = new Part("Проволока", 7, 1, 18);
            PlasticPart = new Part("Пластик", 6, 1, 178);
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

        private void InitializeReceipts()
        {
            ScrewReceipt = new ConstructorReceipt(IronRodPart, 4, ScrewPart, 130, 6);
            CircuitBoardReceipt = new AssemblerReceipt(CopperSheetPart, PlasticPart, 8, 16, CircuitBoardPart, 25, 8);
            CableReceipt = new ConstructorReceipt(WirePart, 2, CablePart, 22.5, 2);
            ComputerReceipt = new ManufacturerReceipt(ScrewPart, CircuitBoardPart, CablePart, PlasticPart, 52, 10, 9, 18, ComputerPart, 2.5, 24);
        }

        private void InitializeMachines()
        {
            ScrewMachine = new ConstructorMachine(ScrewReceipt, ref IronRodPart, ref ScrewPart);
            CircuitBoardMachine = new AssemblerMachine(CircuitBoardReceipt, ref CopperSheetPart, ref PlasticPart, ref CircuitBoardPart);
            CableMachine = new ConstructorMachine(CableReceipt, ref WirePart, ref CablePart);
            ComputerMachine = new ManufacturerMachine(ComputerReceipt, ref ScrewPart, ref CircuitBoardPart, ref CablePart, ref PlasticPart, ref ComputerPart);
        }
    }
}
