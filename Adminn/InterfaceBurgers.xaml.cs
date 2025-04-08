using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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
using Microsoft.VisualBasic;

namespace Adminn
{
    public partial class InterfaceBurgers : Page
    {
        public static bool edit = false;
        public InterfaceBurgers()
        {
            InitializeComponent();
            DataContext = this;
            List<Article> articles = Conteneur.Instance.ObtenirTousLesArticlesSansMenus();
            BurgersListBox.Items.Clear();
            foreach (Nouriture burger in articles.OfType<Nouriture>())
            {
                BurgersListBox.Items.Add(burger);
            }
        }

        private void EditBurger(object sender, RoutedEventArgs e)
        {
            InterfaceBurgers.edit = true;
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceAddBurger(sender, e);
        }

        private void RemoveBurger(object sender, RoutedEventArgs e)
        {
            AskIdWindow askIdWindow = new AskIdWindow();
            bool? result = askIdWindow.ShowDialog();

            if (result == true)
            {
                string idString = askIdWindow.IdValue;
                int id = int.Parse(idString);
                Conteneur.Instance.SupprimerArticleById(id);
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.GoForInterfaceBurger(sender, e);
            }
            else
            {
                MessageBox.Show("ID non fourni.");
            }
        }

        private void AddNewBurger(object sender, RoutedEventArgs e)
        {
            InterfaceBurgers.edit = false;
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceAddBurger(sender, e);
        }

        private void InterfaceBurgerToDrinks(object sender, RoutedEventArgs e)
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
        public void changeDisponibilite(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.DataContext is InterfaceAdminRestaurant.Menu menu)
            {
                menu.disponibilte = checkBox.IsChecked ?? false;
                Conteneur.Instance.SauvegarderJson();
            }
        }

        private void ToOrders(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoToInterfaceOrdersAdmin(sender, e);
        }
    }
}
