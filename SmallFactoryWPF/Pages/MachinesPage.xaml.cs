using SmallFactoryWPF.Controls;
using SmallFactoryWPF.Models;
using System.Windows;
using System.Windows.Controls;

namespace SmallFactoryWPF.Pages
{
    public partial class MachinesPage : Page
    {
        private bool _isFactoryEnabled = false;

        private ConstructorMachine ScrewMachine;
        private AssemblerMachine CircuitBoardMachine;
        private ConstructorMachine CableMachine;
        private ManufacturerMachine ComputerMachine;

        public MachinesPage(ref ConstructorMachine screwMachine,
                            ref AssemblerMachine circuitBoardMachine,
                            ref ConstructorMachine cableMachine,
                            ref ManufacturerMachine computerMachine)
        {
            ScrewMachine = screwMachine;
            CircuitBoardMachine = circuitBoardMachine;
            CableMachine = cableMachine;
            ComputerMachine = computerMachine;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            BTurnFactory.Content = "Включить завод";
            SPMachines.Children.Clear();
            SPMachines.Children.Add(new MachineItem(ScrewMachine));
            SPMachines.Children.Add(new MachineItem(CircuitBoardMachine));
            SPMachines.Children.Add(new MachineItem(CableMachine));
            SPMachines.Children.Add(new MachineItem(ComputerMachine));
        }

        private void BTurnFactory_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _isFactoryEnabled = !_isFactoryEnabled;
            BTurnFactory.Content = _isFactoryEnabled ? "Выключить завод" : "Включить завод";
            ScrewMachine.IsEnabled = _isFactoryEnabled;
            CircuitBoardMachine.IsEnabled = _isFactoryEnabled;
            CableMachine.IsEnabled = _isFactoryEnabled;
            ComputerMachine.IsEnabled = _isFactoryEnabled;
        }
    }
}
