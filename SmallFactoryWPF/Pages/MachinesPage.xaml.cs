using SmallFactoryWPF.Controls;
using SmallFactoryWPF.Models;
using System.Windows.Controls;

namespace SmallFactoryWPF.Pages
{
    public partial class MachinesPage : Page
    {
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
            SPTest.Children.Clear();
            SPTest.Children.Add(new MachineItem(ScrewMachine));
        }
    }
}
