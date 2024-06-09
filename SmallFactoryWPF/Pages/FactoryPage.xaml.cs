using SmallFactoryWPF.Models;
using System.Windows;
using System.Windows.Controls;

namespace SmallFactoryWPF.Pages
{
    public partial class FactoryPage : Page
    {
        private Factory Factory;

        public FactoryPage(ref Factory factory)
        {
            Factory = factory;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LBudget.Content = $"Бюджет: ${Factory.Budget}";
        }
    }
}
