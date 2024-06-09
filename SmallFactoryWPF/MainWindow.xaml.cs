using SmallFactoryWPF.Models;
using System.Windows;
using SmallFactoryWPF.Pages;

namespace SmallFactoryWPF
{
    public partial class MainWindow : Window
    {
        private Factory SmallFactory = new Factory();

        private ConstructorMachine ScrewConstructor = new ConstructorMachine(new ScrewReceipt());

        private AssemblerMachine CircuitBoardAssembler = new AssemblerMachine(new CircuitBoardReceipt());

        private ConstructorMachine CableConstructor = new ConstructorMachine(new CableReceipt());

        private ManufacturerMachine ComputerManufacturer = new ManufacturerMachine(new ComputerReceipt());

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FFactory.Navigate(new FactoryPage(ref SmallFactory));
        }
    }
}
