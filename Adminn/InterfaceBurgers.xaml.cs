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
    /// Interaction logic for InterfaceBurgers.xaml
    /// </summary>
    public partial class InterfaceBurgers : Page
    {
        public InterfaceBurgers()
        {
            InitializeComponent();
            DataContext = this;
            /*Conteneur.Instance.ChargerJson();
            List<Article> articles = Conteneur.Instance.ObtenirTousLesArticlesSansMenus();
            ArticlesListBox.Items.Clear();
            foreach (var article in articles)
            {
                ArticlesListBox.Items.Add(article);
            }*/
            List<Nouriture> list = new List<Nouriture>();
            list.Add(new Nouriture("Cheeseburge", 5, 'M', true, "C:\\Users\\salah\\Desktop\\informatique B2 Q2\\InterfaceAdminRestaurant\\Adminn\\image.png", true));
            list.Add(new Nouriture("Cheeseburge", 5, 'M', true, "C:\\Users\\salah\\Desktop\\informatique B2 Q2\\InterfaceAdminRestaurant\\Adminn\\image.png", true));
            list.Add(new Nouriture("Cheeseburge", 5, 'M', false, "C:\\Users\\salah\\Desktop\\informatique B2 Q2\\InterfaceAdminRestaurant\\Adminn\\image.png", false));
            list.Add(new Nouriture("Cheeseburge", 5, 'M', true, "C:\\Users\\salah\\Desktop\\informatique B2 Q2\\InterfaceAdminRestaurant\\Adminn\\image.png", true));
            list.Add(new Nouriture("Cheeseburge", 5, 'M', false, "C:\\Users\\salah\\Desktop\\informatique B2 Q2\\InterfaceAdminRestaurant\\Adminn\\image.png", true));
            list.Add(new Nouriture("Cheeseburge", 5, 'M', true, "C:\\Users\\salah\\Desktop\\informatique B2 Q2\\InterfaceAdminRestaurant\\Adminn\\image.png", false));
            list.Add(new Nouriture("Cheeseburge", 5, 'M', true, "C:\\Users\\salah\\Desktop\\informatique B2 Q2\\InterfaceAdminRestaurant\\Adminn\\image.png", true));
            list.Add(new Nouriture("Cheeseburge", 5, 'M', true, "C:\\Users\\salah\\Desktop\\informatique B2 Q2\\InterfaceAdminRestaurant\\Adminn\\image.png", true));
            list.Add(new Nouriture("Cheeseburge", 5, 'M', true, "C:\\Users\\salah\\Desktop\\informatique B2 Q2\\InterfaceAdminRestaurant\\Adminn\\image.png", true));
            foreach (var article in list)
            {
                BurgersListBox.Items.Add(article);
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
