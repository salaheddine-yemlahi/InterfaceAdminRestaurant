using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace InterfaceAdminRestaurant
{
    public class Conteneur
    {
        private static Conteneur _instance = new Conteneur();
        public static Conteneur Instance => _instance;

        public List<Nouriture> Nouritures { get; set; } = new List<Nouriture>();
        public List<Boisson> Boissons { get; set; } = new List<Boisson>();
        public List<Frites> Frites { get; set; } = new List<Frites>();
        public List<Menu> Menus { get; set; } = new List<Menu>();
        public List<Order> Orders { get; set; } = new List<Order>();

        public Conteneur()
        {
            Nouritures = new List<Nouriture>();
            Boissons = new List<Boisson>();
            Frites = new List<Frites>();
            Menus = new List<Menu>();
            Orders = new List<Order>();
        }


        public void AjouterArticle(Article article)
        {
            switch (article)
            {
                case Nouriture n:
                    Nouritures.Add(n);
                    break;
                case Boisson b:
                    Boissons.Add(b);
                    break;
                case Frites f:
                    Frites.Add(f);
                    break;
                default:
                    throw new Exception("Type d'article inconnu.");
            }
        }


        public void AjouterMenu(Menu menu)
        {
            Menus.Add(menu);
        }


        public void AjouterOrder(Order order)
        {
            Orders.Add(order);
        }


        public void SupprimerArticleById(int id)
        {
            Nouritures.RemoveAll(n => n.NumeroArticle == id);
            Boissons.RemoveAll(b => b.NumeroArticle == id);
            Frites.RemoveAll(f => f.NumeroArticle == id);


            Menus.RemoveAll(m =>
                (m.nouriture != null && m.nouriture.NumeroArticle == id) ||
                (m.boisson != null && m.boisson.NumeroArticle == id) ||
                (m.frites != null && m.frites.NumeroArticle == id));
        }


        public void SupprimerMenuById(int id)
        {
            Menus.RemoveAll(m => m.idMenu == id);
        }


        public void SupprimerOrdreById(int id)
        {
            Orders.RemoveAll(o => o.idOrder == id);
        }

        // ✅ Récupérer un article par ID
        /*public Article ObtenirArticleParId(int id)
        {
            return Nouritures.FirstOrDefault(n => n.NumeroArticle == id)
                   Boissons.FirstOrDefault(b => b.NumeroArticle == id)
                   Frites.FirstOrDefault(f => f.NumeroArticle == id);
        }*/


        public Menu ObtenirMenuParId(int id)
        {
            return Menus.FirstOrDefault(m => m.idMenu == id);
        }


        public Order ObtenirOrderParId(int id)
        {
            return Orders.FirstOrDefault(o => o.idOrder == id);
        }


        public List<Article> ObtenirTousLesArticlesSansMenus()
        {
            return Nouritures.Cast<Article>().Concat(Boissons).Concat(Frites).ToList();
        }




        public List<Menu> ObtenirTousLesMenus()
        {
            Console.WriteLine("Appel de ObtenirTousLesMenus, Nombre de menus : " + Menus.Count);
            return Menus.ToList();
        }


        public void Vider()
        {
            Nouritures.Clear();
            Boissons.Clear();
            Frites.Clear();
            Menus.Clear();
            Orders.Clear();
        }


        public void SauvegarderJson(string cheminFichier)
        {
            try
            {
                string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(cheminFichier, json);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la sauvegarde : " + e.Message);
            }
        }


        public void ChargerJson(string cheminFichier)
        {
            try
            {
                if (!File.Exists(cheminFichier))
                {
                    Console.WriteLine("Le fichier spécifié n'existe pas.");
                    return;
                }

                string json = File.ReadAllText(cheminFichier);
                var conteneur = JsonSerializer.Deserialize<Conteneur>(json);

                if (conteneur != null)
                {
                    Nouritures = conteneur.Nouritures;
                    Boissons = conteneur.Boissons;
                    Frites = conteneur.Frites;
                    Menus = conteneur.Menus;
                    Orders = conteneur.Orders;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors du chargement : " + e.Message);
            }
        }

    }
}
