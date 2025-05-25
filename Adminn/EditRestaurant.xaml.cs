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
    public partial class EditRestaurant : Page
    {
        public EditRestaurant()
        {
            InitializeComponent();
            NomRestaurantTextBox.Text = Restaurant.CurrentRestaurant.nomRestaurant;
            AdresseRestaurant.Text = Restaurant.CurrentRestaurant.adresse;
            NumeroGSM.Text = Restaurant.CurrentRestaurant.numeroGSM;
            NomProprietaire.Text = Restaurant.CurrentRestaurant.propretaire;
        }

        private void EditRestaurant1(object sender, RoutedEventArgs e)
        {
            string NomRestaurant = NomRestaurantTextBox.Text;
            string Adresse = AdresseRestaurant.Text;
            string NumeroGsmRestaurant = NumeroGSM.Text;
            string NomProprietair = NomProprietaire.Text;
            string MDP = MotDePasse.Password;
            Restaurant restaurant = new Restaurant(NomRestaurant, Adresse, NumeroGsmRestaurant, NomProprietair, MDP);
            bool enr = restaurant.EnregistrerRestaurent();
            Restaurant.currentRestaurant = NomRestaurant;
            if (enr)
            {
                MessageBox.Show("le mot de passe doit pas étre null.");
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.GoForInterfaceProfil(sender, e);
            }
            else
            {
                MessageBox.Show("Restaurant existe déja, identifiez vous oubien choisi un autre non pour l'inscription.");
            }
        }
    }
}
