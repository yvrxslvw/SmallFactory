using SmallFactoryWPF.Models;
using System;
using System.Timers;
using System.Windows.Controls;

namespace SmallFactoryWPF.Controls
{
    public partial class MachineItem : UserControl
    {
        private Machine Machine;
        private Timer _timer;

        public MachineItem(Machine machine)
        {
            Machine = machine;
            InitializeComponent();
            DataContext = Machine;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            LMachineName.Content = GetMachineName();
            InitializeMaterials();
            InitializeRates();
            InitializeResultPart();
            ProductionProcess();
        }

        private string GetMachineName()
        {
            if (Machine is ConstructorMachine) return "Конструктор";
            else if (Machine is AssemblerMachine) return "Ассемблер";
            else if (Machine is ManufacturerMachine) return "Производитель";
            else return "ашыбка";
        }

        private void InitializeMaterials()
        {
            SPMaterials.Children.Clear();

            if (Machine is ConstructorMachine)
            {
                ConstructorReceipt receipt = Machine.Receipt as ConstructorReceipt;
                Label material1 = new Label() { Content = $"{receipt.Material1Required} {receipt.Material1.Name}" };
                SPMaterials.Children.Add(material1);
            }
            else if (Machine is AssemblerMachine)
            {
                AssemblerReceipt receipt = Machine.Receipt as AssemblerReceipt;
                Label material1 = new Label() { Content = $"{receipt.Material1Required} {receipt.Material1.Name}" };
                Label material2 = new Label() { Content = $"{receipt.Material2Required} {receipt.Material2.Name}" };
                SPMaterials.Children.Add(material1);
                SPMaterials.Children.Add(material2);
            }
            else if (Machine is ManufacturerMachine)
            {
                ManufacturerReceipt receipt = Machine.Receipt as ManufacturerReceipt;
                Label material1 = new Label() { Content = $"{receipt.Material1Required} {receipt.Material1.Name}" };
                Label material2 = new Label() { Content = $"{receipt.Material2Required} {receipt.Material2.Name}" };
                Label material3 = new Label() { Content = $"{receipt.Material3Required} {receipt.Material3.Name}" };
                Label material4 = new Label() { Content = $"{receipt.Material4Required} {receipt.Material4.Name}" };
                SPMaterials.Children.Add(material1);
                SPMaterials.Children.Add(material2);
                SPMaterials.Children.Add(material3);
                SPMaterials.Children.Add(material4);
            }
        }

        private void InitializeRates()
        {
            SPRates.Children.Clear();
            Label cycleRate = new Label() { Content = $"{Machine.Receipt.CycleRate} сек" };
            Label productionRate = new Label() { Content = $"{Machine.Receipt.ProductionRate} шт/мин" };
            SPRates.Children.Add(cycleRate);
            SPRates.Children.Add(productionRate);
        }

        private void InitializeResultPart()
        {
            SPResultPart.Children.Clear();
            int resultCount = (int)Math.Ceiling(Machine.Receipt.ProductionRate / (60 / Machine.Receipt.CycleRate));
            Label resultPart = new Label() { Content = $"{resultCount} {Machine.Receipt.ResultPart.Name}" };
            SPResultPart.Children.Add(resultPart);
        }

        private void ProductionProcess()
        {
            _timer = new Timer(1 * 1000);
            _timer.Elapsed += MakeCycle;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private async void MakeCycle(object sender, ElapsedEventArgs e)
        {
            if (Machine.Status == MachineStatus.PROCESSING || !Machine.IsEnabled) return;
            await Machine.Cycle();
        }

        private void BTurnMachine_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Machine.IsEnabled = !Machine.IsEnabled;
        }
    }
}
