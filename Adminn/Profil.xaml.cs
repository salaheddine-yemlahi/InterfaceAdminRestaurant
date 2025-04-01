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
    public partial class Profil : Page
    {
        public Profil()
        {
            InitializeComponent();
            chargeTextbox();

        }
        public void chargeTextbox()
        {
            Restaurant restaurant = Restaurant.ChargerRestaurant();
            if(restaurant == null )
            {
                throw new Exception("cette restaurant existe pas");
            }
            RestaurantNameTextBox.Text = restaurant.nomRestaurant;
            RestaurantAdressTextBox.Text = restaurant.adresse;
            RestaurantGSMTextBox.Text = restaurant.numeroGSM;
            RestaurantOwnerTextBox.Text = restaurant.propretaire;
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceLogin(sender, e);
        }

        private void ToBurger(object sender, RoutedEventArgs e)
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

        private void Tomenus(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceMenus(sender, e);
        }

        private void EditRestaurant(object sender, RoutedEventArgs e)
        {
            bool vrai = Restaurant.EditRestaurant(RestaurantNameTextBox.Text);
            if (vrai == true)
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.GoForInterfaceEditRestaurant(sender, e);
            }
        }
    }
}
