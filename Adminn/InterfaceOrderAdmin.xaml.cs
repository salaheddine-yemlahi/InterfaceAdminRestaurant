using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InterfaceAdminRestaurant;

namespace Adminn
{
    /// <summary>
    /// Interaction logic for InterfaceOrderAdmin.xaml
    /// </summary>
    public partial class InterfaceOrderAdmin : Page
    {
        public InterfaceOrderAdmin()
        {
            InitializeComponent();
            DataContext = this;
            List<Order> orders = Conteneur.Instance.ObtenirToutesLesCommandes();
            OrdersListBox.Items.Clear();
            foreach (Order order in orders)
            {
                OrdersListBox.Items.Add(order);
            }
        }

        private void ToBurgers(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceBurger(sender, e);
        }

        private void ToDrinks(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceDrinks(sender, e);
        }

        private void ToFrites(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceFrites(sender, e);
        }

        private void ToMenus(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceMenus(sender, e);
        }
        private void LogOut(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.LogOut(sender, e);
        }
        private void ToProfil(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceProfil(sender, e);
        }

    }
}
