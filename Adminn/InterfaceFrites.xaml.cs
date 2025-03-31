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
    public partial class InterfaceFrites : Page
    {
        public InterfaceFrites()
        {
            InitializeComponent();
            DataContext = this;
            List<Article> articles = Conteneur.Instance.ObtenirTousLesArticlesSansMenus();
            BurgersListBox.Items.Clear();

            foreach (Frites frites in articles.OfType<Frites>())
            {
                BurgersListBox.Items.Add(frites);
            }
            InitializeComponent();
        }

        private void ToBurger(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceBurger(sender, e);
        }

        private void ToDrink(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceDrinks(sender, e);
        }

        private void RemoveFrites(object sender, RoutedEventArgs e)
        {
            AskIdWindow askIdWindow = new AskIdWindow();
            bool? result = askIdWindow.ShowDialog();

            if (result == true)
            {
                string idString = askIdWindow.IdValue;
                int id = int.Parse(idString);
                Conteneur.Instance.SupprimerArticleById(id);
            }
            else
            {
                MessageBox.Show("ID non fourni.");
            }
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceFrites(sender, e);
        }

        private void EditFrites(object sender, RoutedEventArgs e)
        {
            InterfaceBurgers.edit = true;
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceEditAddFrites(sender, e);
        }

        private void AddFrites(object sender, RoutedEventArgs e)
        {
            InterfaceBurgers.edit = false;
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceEditAddFrites(sender, e);
        }
    }
}
