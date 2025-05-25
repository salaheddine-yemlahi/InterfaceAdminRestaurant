using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using InterfaceAdminRestaurant;
using Microsoft.Win32;

namespace GestionRegistre
{
    public class GestionRegistre
    {
        private static RegistryKey key;

        public static void ChargerPanier()
        {
            try
            {
                key = Registry.CurrentUser.OpenSubKey(@"Software\MonApplication");
                string json = key?.GetValue("Panier")?.ToString();
                key?.Close();
                Conteneur.Instance.Pannier = JsonSerializer.Deserialize<Order>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors du chargement du panier : " + e.Message);
            }
        }

        public static void SauvegarderPanier()
        {
            try
            {
                key = Registry.CurrentUser.CreateSubKey(@"Software\MonApplication");
                string json = JsonSerializer.Serialize(Conteneur.Instance.Pannier);
                key.SetValue("Panier", json, RegistryValueKind.String);
                key.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la sauvegarde du panier : " + e.Message);
            }
        }
    }
}
