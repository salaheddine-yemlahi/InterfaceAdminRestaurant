using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for AddEditFrites.xaml
    /// </summary>
    public partial class AddEditFrites : Page
    {
        public AddEditFrites()
        {
            if (InterfaceBurgers.edit == true)
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
            }
            InitializeComponent();
        }

        private void AvailabilityCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AvibilityCheckBox.IsChecked = true;
        }

        private void ToInterfaceDrinks(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceDrinks(sender, e);
        }

        private void InterfaceBurger(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceBurger(sender, e);
        }

        private void SaveNewEditFrites(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(FritesPriceTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
            {
                MessageBox.Show("Le prix saisi est invalide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Frites frites = new Frites(FritesNameTextBox.Text, price, FritesSizeTextBox.Text, FritesImagePathTextBox.Text, AvibilityCheckBox.IsChecked == true);
            Conteneur.Instance.AjouterArticle(frites);
            MessageBox.Show("les frites est ajouté.");
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceBurger(sender, e);
        }
    }
}
