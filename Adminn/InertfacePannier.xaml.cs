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
using Microsoft.Win32;

namespace Adminn
{
    public partial class InertfacePannier : Page
    {
        public InertfacePannier()
        {
            InitializeComponent();
            if (Conteneur.Instance.Pannier == null)
            {
                Conteneur.Instance.Pannier = new Order(); // Initialisez Pannier si nécessaire
            }
            DataContext = this;
            PannierListBox.Items.Clear();
            PannierListBox.Items.Add(Conteneur.Instance.Pannier);
        }

        private void ToBurgers(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceBurgersClient(sender, e);
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.LogOut(sender, e);
        }

        private void ToFrites(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoToInterfaceFritesClient(sender, e);
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

        private void ToDrinks(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoToInterfaceDrinkClient(sender, e);
        }

        private void AddItem(object sender, RoutedEventArgs e)
        {
            AskIdWindow askIdWindow = new AskIdWindow();
            bool? result = askIdWindow.ShowDialog();
            string idString = askIdWindow.IdValue;
            int id;
            bool isValidId = int.TryParse(idString, out id);
            // Récupération de l'article par ID
            Article article = Conteneur.Instance.ObtenirArticleParId(id);

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

            // Mise à jour de l'interface avec les éléments du panier
            PannierListBox.Items.Clear();
            PannierListBox.Items.Add(Conteneur.Instance.Pannier);

        }

        private void AddMenu(object sender, RoutedEventArgs e)
        {
            AskIdWindow askIdWindow = new AskIdWindow();
            bool? result = askIdWindow.ShowDialog();
            string idString = askIdWindow.IdValue;
            int id = int.Parse(idString);
            InterfaceAdminRestaurant.Menu menu = Conteneur.Instance.ObtenirMenuParId(id);
            Conteneur.Instance.Pannier.Nouritures.Add(menu.nouriture);
            Conteneur.Instance.Pannier.Boissons.Add(menu.boisson);
            Conteneur.Instance.Pannier.Frites.Add(menu.frites);
            PannierListBox.Items.Clear();
            PannierListBox.Items.Add(Conteneur.Instance.Pannier);
        }

        private void PassOrder(object sender, RoutedEventArgs e)
        {
            Conteneur.Instance.Orders.Add(Conteneur.Instance.Pannier);
            Conteneur.Instance.Pannier = null;
            Conteneur.Instance.Pannier = new Order();
            PannierListBox.Items.Clear();
            PannierListBox.Items.Add(Conteneur.Instance.Pannier);
        }

        private void ClearPannier(object sender, RoutedEventArgs e)
        {
            Conteneur.Instance.Pannier = null;
            Conteneur.Instance.Pannier = new Order();
            PannierListBox.Items.Clear();
        }
    }
}
