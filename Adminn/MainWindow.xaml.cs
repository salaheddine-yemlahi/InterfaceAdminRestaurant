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
using Adminn;

namespace InterfaceAdminRestaurant
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Identification());
            Conteneur.Instance.ChargerJson();
        }
        ~MainWindow()
        {
            Conteneur.Instance.SauvegarderJson();
        }
        public void GoForSigninInterface(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Inscription());
        }
        public void GoForLogInInterface(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Identification());
        }
        public void GoForInterfaceBurger(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InterfaceBurgers());
        }
        public void GoForInterfaceAddBurger(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddEditBurger());
        }
    }
}
