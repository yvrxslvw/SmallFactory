using SmallFactoryWPF.Models;
using System.Windows.Controls;

namespace SmallFactoryWPF.Pages
{
    public partial class MachinesPage : Page
    {
        private ConstructorReceipt ScrewReceipt;
        private Part IronRodPart;
        private Part ScrewPart;

        public MachinesPage(ConstructorReceipt screwReceipt, ref Part ironRodPart, ref Part screwPart)
        {
            InitializeComponent();
            ScrewReceipt = screwReceipt;
            IronRodPart = ironRodPart;
            ScrewPart = screwPart;
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ConstructorMachine machine = new ConstructorMachine(ScrewReceipt, ref IronRodPart, ref ScrewPart);
            await machine.Cycle();
        }
    }
}
