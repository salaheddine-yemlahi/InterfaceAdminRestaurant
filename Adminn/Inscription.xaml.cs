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
    /// Interaction logic for Inscription.xaml
    /// </summary>
    public partial class Inscription : Page
    {
        public Inscription()
        {
            InitializeComponent();
        }
        private void GoForLogIn(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForLogInInterface(sender, e);
        }

        public void sauvgarderNouveuRestaurant(object sender, RoutedEventArgs e)
        {
            string NomRestaurant = NomRestaurantTextBox.Text;
            string Adresse = AdresseRestaurant.Text;
            string NumeroGsmRestaurant = NumeroGSM.Text;
            string NomProprietair = NomProprietaire.Text;
            string MDP = MotDePasse.Text;
            Restaurant restaurant = new Restaurant(NomRestaurant, Adresse, NumeroGsmRestaurant, NomProprietair, MDP);
            bool enr = restaurant.EnregistrerRestaurent();
            if (enr)
            {
                MessageBox.Show("Restaurant enregistré, vous pouvez vous identifier maintenant.");
                GoForLogIn(sender, e);
            }
            else
            {
                MessageBox.Show("Restaurant existe déja, identifiez vous oubien choisi un autre non pour l'inscription.");
            }
        }
    }
}
