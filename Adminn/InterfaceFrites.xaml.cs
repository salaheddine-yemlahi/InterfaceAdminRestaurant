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
            FritesListBox.Items.Clear();

            foreach (Frites frites in articles.OfType<Frites>())
            {
                FritesListBox.Items.Add(frites);
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
            Article article = FritesListBox.SelectedItem as Article;
            if (article != null)
            {
                int id = article.NumeroArticle;
                Conteneur.Instance.SupprimerArticleById(id);
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.GoForInterfaceBurger(sender, e);
            }
            else
            {
                MessageBox.Show("Aucun article sélectionné.");
            }
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
        private void ToProfil(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceProfil(sender, e);
        }

    }
}
