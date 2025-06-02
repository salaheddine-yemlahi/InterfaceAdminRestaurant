﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using InterfaceAdminRestaurant;

namespace Adminn
{
    public partial class AddEditBurger : Page
    {
        public AddEditBurger()
        {
            if(InterfaceBurgers.edit == true )
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

        private void vegetarienCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            VegitarienCheckBox.IsChecked = true;
        }

        private void SaveNewEditBurger(object sender, RoutedEventArgs e)
        {
            char size = string.IsNullOrEmpty(BurgerSizeTextBox.Text) ? 'M' : BurgerSizeTextBox.Text[0];
            if (!decimal.TryParse(BurgerPriceTextBox.Text, out decimal price))
            {
                MessageBox.Show("Le prix saisi est invalide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Nouriture Burger = new Nouriture(BurgerNameTextBox.Text, price, size, VegitarienCheckBox.IsChecked == true, BurgerImagePathTextBox.Text, AvibilityCheckBox.IsChecked == true);
            Conteneur.Instance.AjouterArticle(Burger);
            MessageBox.Show("le burger est ajouté.");
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceBurger(sender, e);
        }
        private void InterfaceBurger(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.GoForInterfaceBurger(sender, e);
        }

        private void InterfaceBurgerToDrinks(object sender, RoutedEventArgs e)
        {

        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.LogOut(sender, e);
        }
    }
}
