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
    /// Interaction logic for InscriptionClient.xaml
    /// </summary>
    public partial class InscriptionClient : Page
    {
        public InscriptionClient()
        {
            InitializeComponent();
        }

        private void sauvgarderNouveuRestaurant(object sender, RoutedEventArgs e)
        {
            string NomClient = NomClientTextBox.Text;
            string PrenomClient = FirstNameClient.Text;
            string Adresse = AdressClient.Text;
            string NumeroGsmClient = NumeroGSM.Text;
            string MDP = MotDePasse.Text;
            Client client = new Client(NomClient, PrenomClient, Adresse, NumeroGsmClient, MDP);
            bool enr = client.EnregistrerClient();
            if (enr)
            {
                MessageBox.Show("Client enregistré, vous pouvez vous identifier maintenant.");
                GoToLogin(sender, e);
            }
            else
            {
                MessageBox.Show("Client existe déja, identifiez vous oubien choisi un autre non pour l'inscription.");
            }
        }

        private void GoToLogin(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForLoginClient(sender, e);
        }
    }
}
