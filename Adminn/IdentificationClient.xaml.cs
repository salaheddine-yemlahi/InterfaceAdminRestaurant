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
    /// Interaction logic for IdentificationClient.xaml
    /// </summary>
    public partial class IdentificationClient : Page
    {
        public IdentificationClient()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            string nomClient = NomClientTextBox.Text;
            string motDePasse = MotDePasseTextBox.Password;
            bool verifie = Client.VerifierClient(nomClient, motDePasse);
            if (verifie)
            {
                MessageBox.Show("accès autoriser, bienvenue encore.");
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.GoForInterfaceBurgersClient(sender, e);
            }
            else
            {
                MessageBox.Show("vérifiez vos informations.");
            }
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForSingInClient(sender, e);
        }
    }
}
