using SmallFactoryWPF.Models;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace SmallFactoryWPF.Controls
{
    public partial class ShopItem : UserControl
    {
        private Factory Factory;

        private Part Part;

        private static Timer _timer;

        public ShopItem(ref Factory factory, ref Part part)
        {
            Factory = factory;
            Part = part;
            InitializeComponent();
            DataContext = Part;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LPartName.Content = Part.Name;
            LPartPrice.Content = $"${Part.Price.ToString("N")}";
        }
        private void BBuyPart_Click(object sender, RoutedEventArgs e)
        {
            if (Part.ShopCount - 1 < 0)
            {
                MessageBox.Show(icon: MessageBoxImage.Error,
                                caption: "Ошибка",
                                messageBoxText: "В магазине недостаточно товара.",
                                button: MessageBoxButton.OK);
                return;
            }
            if (Part.StorageCount + 1 > 200)
            {
                MessageBox.Show(icon: MessageBoxImage.Error,
                                caption: "Ошибка",
                                messageBoxText: "Склад уже переполнен этой деталью.",
                                button: MessageBoxButton.OK);
                return;
            }
            if (Factory.Budget - Part.Price < 0)
            {
                MessageBox.Show(icon: MessageBoxImage.Error,
                                caption: "Ошибка",
                                messageBoxText: "На заводе недостаточно средств.",
                                button: MessageBoxButton.OK);
                return;
            }

            Part.ShopCount -= 1;
            Part.StorageCount += 1;
            Factory.Budget -= Part.Price;
        }

        private void BSellPart_Click(object sender, RoutedEventArgs e)
        {
            if (Part.StorageCount - 1 < 0)
            {
                MessageBox.Show(icon: MessageBoxImage.Error,
                                caption: "Ошибка",
                                messageBoxText: "На складе недостаточно этой детали.",
                                button: MessageBoxButton.OK);
                return;
            }

            Part.ShopCount += 1;
            Part.StorageCount -= 1;
            Factory.Budget += Part.Price - (Part.Price / 100 * 5);
        }
    }
}
