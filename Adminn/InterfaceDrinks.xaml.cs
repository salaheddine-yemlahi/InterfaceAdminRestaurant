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
    /// Interaction logic for InterfaceDrinks.xaml
    /// </summary>
    public partial class InterfaceDrinks : Page
    {
        public static bool edit = false;
        public InterfaceDrinks()
        {
            InitializeComponent();
            DataContext = this;
            List<Article> articles = Conteneur.Instance.ObtenirTousLesArticlesSansMenus();
            BurgersListBox.Items.Clear();

            foreach (Boisson boisson in articles.OfType<Boisson>()) // Filtre seulement les Boissons
            {
                BurgersListBox.Items.Add(boisson);
            }
        }

        private void DrinkToBurger(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceBurger(sender, e);
        }

        private void AddDrink(object sender, RoutedEventArgs e)
        {
            edit = false;
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceEditAddDrink(sender, e);
        }

        private void EditDrink(object sender, RoutedEventArgs e)
        {
            edit = true;
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceEditAddDrink(sender, e);
        }

        private void RemoveDrink(object sender, RoutedEventArgs e)
        {
            AskIdWindow askIdWindow = new AskIdWindow();
            bool? result = askIdWindow.ShowDialog();

            if (result == true)
            {
                string idString = askIdWindow.IdValue;
                int id = int.Parse(idString);
                Conteneur.Instance.SupprimerArticleById(id);
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.GoForInterfaceDrinks(sender, e);
            }
            else
            {
                MessageBox.Show("ID non fourni.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ToFrites(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceFrites(sender, e);
        }

        private void ToDrink(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceDrinks(sender, e);
        }

        private void ToMenus(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceMenus(sender, e);
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceLogin(sender, e);
        }
    }
}
