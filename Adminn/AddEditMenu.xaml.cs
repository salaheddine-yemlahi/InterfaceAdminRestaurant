using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for AddEditMenu.xaml
    /// </summary>
    public partial class AddEditMenu : Page
    {
        public AddEditMenu()
        {
            InitializeComponent();
        }

        private void SaveNewEditMenu(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(MenuPriceTextBox.Text, out decimal price))
            {
                MessageBox.Show("Le prix saisi est invalide.", "Erreur", MessageBoxButton.OK);
                return;
            }
            int idBurger = int.Parse(IdBurger.Text);
            Nouriture burger = Conteneur.Instance.ObtenirArticleParId(idBurger) as Nouriture;

            int idBoisson = int.Parse(IdBoisson.Text);
            Boisson boisson = Conteneur.Instance.ObtenirArticleParId(idBoisson) as Boisson;

            int idFrites = int.Parse(IdFrites.Text);
            Frites frites = Conteneur.Instance.ObtenirArticleParId(idFrites) as Frites;

            int prix = int.Parse(MenuPriceTextBox.Text);
            InterfaceAdminRestaurant.Menu menu = new InterfaceAdminRestaurant.Menu(MenuNameTextBox.Text, burger, MenuImagePathTextBox.Text, boisson, frites,prix, AvibilityCheckBox.IsChecked == true);

            Conteneur.Instance.AjouterMenu(menu);

            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceMenus(sender, e);
        }

        private void InterfaceBurger(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceBurger(sender, e);
        }

        private void InterfaceDrink(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceDrinks(sender, e);
        }

        private void InterfaceFrites(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceFrites(sender, e);
        }

        private void InterfaceMenus(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceMenus(sender, e);
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.LogOut(sender, e);
        }
    }
}
