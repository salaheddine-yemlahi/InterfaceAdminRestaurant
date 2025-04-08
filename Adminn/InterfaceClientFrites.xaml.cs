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
    /// Interaction logic for InterfaceClientFrites.xaml
    /// </summary>
    public partial class InterfaceClientFrites : Page
    {
        public InterfaceClientFrites()
        {
            InitializeComponent();
            DataContext = this;
            List<Article> articles = Conteneur.Instance.ObtenirTousLesArticlesSansMenus();
            BurgersListBox.Items.Clear();
            foreach (Frites frites in articles.OfType<Frites>())
            {
                if (frites.disponibilte == true)
                {
                    BurgersListBox.Items.Add(frites);
                }
            }
        }

        private void ToBurger(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceBurgersClient(sender, e);
        }

        private void ToDrinks(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoToInterfaceDrinkClient(sender, e);
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.LogOut(sender, e);
        }

        private void ToMenu(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceMenuClient(sender, e);
        }

        private void ToOrders(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoToInterfaceOrders(sender, e);
        }
    }
}
