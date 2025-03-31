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
    public partial class InterfaceMenu : Page
    {
        public InterfaceMenu()
        {
            InitializeComponent();
            DataContext = this;
            List<InterfaceAdminRestaurant.Menu> menus = Conteneur.Instance.ObtenirTousLesMenus();
            MenusListBox.Items.Clear();
            foreach (InterfaceAdminRestaurant.Menu menu in menus)
            {
                MenusListBox.Items.Add(menu);
            }
        }

        private void RemoveMenu(object sender, RoutedEventArgs e)
        {
            AskIdWindow askIdWindow = new AskIdWindow();
            bool? result = askIdWindow.ShowDialog();

            if (result == true)
            {
                string idString = askIdWindow.IdValue;
                int id = int.Parse(idString);
                Conteneur.Instance.SupprimerMenuById(id);
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.GoForInterfaceMenus(sender, e);
            }
            else
            {
                MessageBox.Show("ID non fourni.");
            }
        }

        private void AddNewMenu(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceAddEditMenu(sender, e);
        }

        private void InterfaceMenusToBurgers(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceBurger(sender, e);
        }

        private void InterfaceMenusToDrinks(object sender, RoutedEventArgs e)
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

        private void EditMenu(object sender, RoutedEventArgs e)
        {
            AskIdWindow askIdWindow = new AskIdWindow();
            bool? result = askIdWindow.ShowDialog();

            if (result == true)
            {
                string idString = askIdWindow.IdValue;
                int id = int.Parse(idString);
                Conteneur.Instance.SupprimerMenuById(id);
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.GoForInterfaceAddEditMenu(sender, e);
            }
            else
            {
                MessageBox.Show("ID non fourni.");
            }
        }
    }
}
