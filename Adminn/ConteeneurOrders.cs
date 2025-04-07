using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using InterfaceAdminRestaurant;

namespace Adminn
{
    internal class ConteeneurOrders 
    {
        private static string cheminJSon = "Order.json";
        private static ConteeneurOrders _instance = new ConteeneurOrders();
        public static ConteeneurOrders Instance => _instance;

        public List<Nouriture> Nouritures { get; set; } = new List<Nouriture>();
        public List<Boisson> Boissons { get; set; } = new List<Boisson>();
        public List<Frites> Frites { get; set; } = new List<Frites>();
        public List<InterfaceAdminRestaurant.Menu> Menus { get; set; } = new List<InterfaceAdminRestaurant.Menu>();

        public ConteeneurOrders()
        {
            Nouritures = new List<Nouriture>();
            Boissons = new List<Boisson>();
            Frites = new List<Frites>();
            Menus = new List<InterfaceAdminRestaurant.Menu>();
        }

    }
}
