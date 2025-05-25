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
using Adminn;
using GestionRegistre;

namespace InterfaceAdminRestaurant
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
            Conteneur.Instance.ChargerJson();
            GestionRegistre.GestionRegistre.ChargerPanier();
        }
        ~MainWindow()
        {
            Conteneur.Instance.SauvegarderJson();
            GestionRegistre.GestionRegistre.SauvegarderPanier();
        }
        public void GoForSigninInterface(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Inscription());
        }
        public void GoForLogInInterface(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Identification());
        }
        public void GoForInterfaceBurger(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InterfaceBurgers());
        }
        public void GoForInterfaceAddBurger(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddEditBurger());
        }
        public void GoForInterfaceDrinks(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InterfaceDrinks());
        }
        public void GoForInterfaceEditAddDrink(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EditAddDrink());
        }
        public void GoForInterfaceFrites(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InterfaceFrites());
        }
        public void GoForInterfaceEditAddFrites(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddEditFrites());
        }
        public void GoForInterfaceMenus(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InterfaceMenu());
        }
        public void GoForInterfaceAddEditMenu(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddEditMenu());
        }
        public void GoForInterfaceLogin(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Identification());
        }
        public void GoForInterfaceProfil(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Profil());
        }
        public void GoForInterfaceEditRestaurant(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EditRestaurant());
        }
        public void GoForInterfaceIdentificationRestaurant(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Identification());
        }
        public void GoForLoginClient(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new IdentificationClient());
        }
        public void GoForSingInClient(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InscriptionClient());
        }
        public void GoForInterfaceMenuClient(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InterfaceClientMenu());
        }
        public void GoForInterfaceBurgersClient(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InterfaceBurgersClients());
        }
        public void LogOut(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage());
        }
        public void GoToInterfaceMenuClient(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InterfaceClientMenu());
        }
        public void GoToInterfaceDrinkClient(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InterfaceClientDrinks());
        }
        public void GoToInterfaceFritesClient(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InterfaceClientFrites());
        }
        public void GoToInterfaceOrders(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InterfaceOrders());
        }
        public void GoToInterfacePannier(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InertfacePannier());
        }
        public void GoToInterfaceOrdersAdmin(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InterfaceOrderAdmin());
        }
    }
}
