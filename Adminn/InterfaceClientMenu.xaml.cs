﻿using System;
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
    public partial class InterfaceClientMenu : Page
    {
        public InterfaceClientMenu()
        {
            InitializeComponent();
            DataContext = this;
            List<InterfaceAdminRestaurant.Menu> menus = Conteneur.Instance.ObtenirTousLesMenus();
            MenusListBox.Items.Clear();
            foreach (InterfaceAdminRestaurant.Menu menu in menus)
            {
                if (menu.disponibilte == true) { MenusListBox.Items.Add(menu); }
            }
        }

        private void ForBurgersClient(object sender, RoutedEventArgs e)
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

        private void Tofrites(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoToInterfaceFritesClient(sender, e);
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
            InterfaceAdminRestaurant.Menu menu = MenusListBox.SelectedItem as InterfaceAdminRestaurant.Menu;
            Conteneur.Instance.Pannier.Nouritures.Add(menu.nouriture);
            Conteneur.Instance.Pannier.Boissons.Add(menu.boisson);
            Conteneur.Instance.Pannier.Frites.Add(menu.frites);

        }
    }
}
