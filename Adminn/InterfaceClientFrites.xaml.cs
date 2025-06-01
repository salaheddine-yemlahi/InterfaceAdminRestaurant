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
    public partial class InterfaceClientFrites : Page
    {
        public InterfaceClientFrites()
        {
            InitializeComponent();
            DataContext = this;
            List<Article> articles = Conteneur.Instance.ObtenirTousLesArticlesSansMenus();
            FritesListBox.Items.Clear();
            foreach (Frites frites in articles.OfType<Frites>())
            {
                if (frites.disponibilte == true)
                {
                    FritesListBox.Items.Add(frites);
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

        private void ToPannier(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoToInterfacePannier(sender, e);
        }

        private void AddtoPanner(object sender, RoutedEventArgs e)
        {
            Article article = FritesListBox.SelectedItem as Frites;
            // Vérification si l'article est null
            if (article == null)
            {
                MessageBox.Show("Article non trouvé.");
                return; // Sortie si l'article n'est pas trouvé
            }

            // Vérification si le panier est bien initialisé, sinon l'initialiser
            if (Conteneur.Instance.Pannier == null)
            {
                Conteneur.Instance.Pannier = new Order();
            }

            // Vérification si les collections du panier sont bien initialisées, sinon les initialiser
            if (Conteneur.Instance.Pannier.Nouritures == null)
            {
                Conteneur.Instance.Pannier.Nouritures = new List<Nouriture>();
            }
            if (Conteneur.Instance.Pannier.Boissons == null)
            {
                Conteneur.Instance.Pannier.Boissons = new List<Boisson>();
            }
            if (Conteneur.Instance.Pannier.Frites == null)
            {
                Conteneur.Instance.Pannier.Frites = new List<Frites>();
            }

            // Ajout de l'article dans le panier en fonction de son type
            if (article is Nouriture nouriture)
            {
                Conteneur.Instance.Pannier.Nouritures.Add(nouriture);
            }
            else if (article is Boisson boisson)
            {
                Conteneur.Instance.Pannier.Boissons.Add(boisson);
            }
            else if (article is Frites frites)
            {
                Conteneur.Instance.Pannier.Frites.Add(frites);
            }
            else
            {
                MessageBox.Show("Type d'article inconnu.");
            }
        }
    }
}
