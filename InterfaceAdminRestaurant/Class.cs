using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using BCrypt.Net;

namespace InterfaceAdminRestaurant
{
    public class Article
    {
        public static int compteurArticle = 0;
        public int NumeroArticle { get; }
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public string cheminImage { get; set; }
        public bool disponibilte { get; set; } = true;

        public Article(string nom, decimal prix, string cheminImage, bool disponibilte)
        {
            if (string.IsNullOrWhiteSpace(nom))
                throw new ArticleException("Le nom ne doit pas être null ou vide.");

            if (prix < 0)
                throw new ArticleException("Le prix doit être supérieur à zéro.");

            if (cheminImage == null || cheminImage.Length == 0)
                throw new ArticleException("L'image ne doit pas être vide.");

            this.Nom = nom;
            this.Prix = prix;
            if (cheminImage[1] == ':')
            {
                this.cheminImage = cheminImage;
            }
            else
            {
                this.cheminImage = "C:\\Users\\salah\\Desktop\\informatique B2 Q2\\InterfaceAdminRestaurant\\Adminn\\images\\" + cheminImage + ".JPG";
            }
            this.disponibilte = disponibilte;
            NumeroArticle = ++compteurArticle;
        }

        public override string ToString()
        {
            return $"{Nom} - {Prix}€";
        }
    }















    public class Nouriture : Article
    {
        public char Taille { get; set; }
        public bool EstVegetarienne { get; set; }

        public Nouriture(string nom, decimal prix, char taille, bool estVegetarienne, string cheminImage, bool disponibilte)
            : base(nom, prix, cheminImage, disponibilte)
        {
            if (!new[] { 'S', 'M', 'L' }.Contains(taille))
                throw new NouritureException("La taille de la nourriture doit être S/M/L.");

            this.Taille = taille;
            this.EstVegetarienne = estVegetarienne;
        }

        public override string ToString()
        {
            return base.ToString() + $", Taille: {Taille}, Végétarien: {(EstVegetarienne ? "Oui" : "Non")}";
        }
    }













    public class Boisson : Article
    {
        public int Volume { get; set; }
        public bool EstNonSucree { get; set; }

        public Boisson(string nom, decimal prix, int volume, bool estNonSucree, string cheminImage, bool disponibilte)
            : base(nom, prix, cheminImage, disponibilte)
        {
            if (volume <= 0)
                throw new BoissonException("Le volume de la boisson doit être supérieur à zéro.");

            this.Volume = volume;
            this.EstNonSucree = estNonSucree;
        }

        public override string ToString()
        {
            return base.ToString() + $", Volume: {Volume}ml, Sucrée: {(EstNonSucree ? "Oui" : "Non")}";
        }
    }












    public class Frites : Article
    {
        public string Taille { get; set; }

        public Frites(string nom, decimal prix, string taille, string cheminImage, bool disponibilte)
            : base(nom, prix, cheminImage, disponibilte)
        {
            if (!new[] { "S", "M", "L" }.Contains(taille))
                throw new FritesException("La taille des frites doit être S/M/L.");

            this.Taille = taille;
        }

        public override string ToString()
        {
            return base.ToString() + $", Taille: {Taille}";
        }
    }











    public class Menu
    {
        static int compteurMenu = 0;
        public int idMenu { get; set; }
        public string nomMenu { get; set; }
        public decimal Prix { get; set; }
        public string cheminImage { get; set; }

        public Nouriture nouriture { get; set; }
        public Boisson boisson { get; set; }
        public Frites frites { get; set; }
        public char Taille { get; set; }
        public bool disponibilte { get; set; } = true;

        public Menu(string nomMenu, Nouriture nouriture, string cheminImage, Boisson boisson, Frites frites, decimal prix, bool disponibilte)
        {
            if (nouriture == null || boisson == null || frites == null)
                throw new MenuException("Les trois articles doivent être présents.");

            compteurMenu++;
            this.Prix = prix;
            this.nomMenu = nomMenu;
            if (cheminImage[1] == ':')
            {
                this.cheminImage = cheminImage;
            }
            else
            {
                this.cheminImage = "C:\\Users\\salah\\Desktop\\informatique B2 Q2\\InterfaceAdminRestaurant\\Adminn\\images\\" + cheminImage + ".JPG";
            }
            this.idMenu = compteurMenu;
            this.nouriture = nouriture;
            this.boisson = boisson;
            this.frites = frites;
            this.disponibilte = disponibilte;
        }

        public override string ToString()
        {
            return $"ID Menu: {this.idMenu}\n{this.nouriture}\n{this.boisson}\n{this.frites}\nDisponible: {(disponibilte ? "Oui" : "Non")}";
        }
    }













    public class Order
    {
        public static int compteurOrder = 1000;

        public int idOrder { get; set; }
        public List<Nouriture> Nouritures { get; set; }
        public List<Boisson> Boissons { get; set; }
        public List<Frites> Frites { get; set; }
        public Client client { get; set; } = Client.CurrentClient;
        public char EtatOrder { get; set; } = 'N'; // N : Nouvelle, A : Ancienne
        public Order() 
        {
            compteurOrder++;
            this.idOrder = compteurOrder;

            Nouritures = new List<Nouriture>();
            Boissons = new List<Boisson>();
            Frites = new List<Frites>();
            client = Client.CurrentClient;
            EtatOrder = 'N';
        }

        public Order(List<Nouriture> nouritures, List<Boisson> boissons, List<Frites> frites, Client client, char etatOrder)
        {
            if ((nouritures == null || nouritures.Count == 0) &&
                (boissons == null || boissons.Count == 0) &&
                (frites == null || frites.Count == 0))
            {
                throw new OrderException("La commande doit contenir au moins un article.");
            }

            compteurOrder++;
            this.idOrder = compteurOrder;
            this.Nouritures = nouritures ?? new List<Nouriture>();
            this.Boissons = boissons ?? new List<Boisson>();
            this.Frites = frites ?? new List<Frites>();
            this.client = client;
            this.EtatOrder = etatOrder;
        }
    }













    public class Client
    {
        private static string cheminFichier = "xmlClient.xml";
        public static string currentClient;
        public static Client CurrentClient;
        public int idClient { get; set; }
        public string nomClient { get; set; }
        public string prenomClient { get; set; }
        public string adresseClient { get; set; }
        public string numeroGSMClient { get; set; }
        public string motDePasse { get; set; }


        public Client(string nomClient, string prenomClient, string adresseClient, string numeroGSMClient, string MDP)
        {
            this.nomClient = nomClient;
            this.prenomClient = prenomClient;
            this.adresseClient = adresseClient;
            this.numeroGSMClient = numeroGSMClient;
            this.motDePasse = MDP;
        }
        public Client() { }

        private static List<Client> ChargerClient()
        {
            if (!File.Exists(cheminFichier))
                return new List<Client>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Client>));  // Crée un objet XmlSerializer capable de transformer du XML en une List<Client>
            using (StreamReader reader = new StreamReader(Client.cheminFichier)) //  Ouvre le fichier XML situé à l’endroit indiqué par Client.cheminFichier pour lecture.
            {
                return (List<Client>)serializer.Deserialize(reader); 
            }
        }

        public bool EnregistrerClient()
        {
            List<Client> clients = ChargerClient();

            foreach (Client client in clients)
            {
                if (client.nomClient == this.nomClient)
                {
                    return false;
                }
            }
            if (this.motDePasse == "" || this.motDePasse == null)
            {
                return false;
            }
            this.motDePasse = Restaurant.HashPassword(this.motDePasse);

            clients.Add(this);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Client>)); // Crée un objet XmlSerializer capable de transformer du XML en une List<Client>
            using (StreamWriter writer = new StreamWriter(cheminFichier))  //  Ouvre le fichier XML situé à l’endroit indiqué par Client.cheminFichier pour ecriture.
            {
                serializer.Serialize(writer, clients);
            }
            return true;
        }


        public static bool VerifierClient(string nomClient, string motDePasse)
        {
            List<Client> clients = ChargerClient();
            if (clients == null) return false;
            foreach (Client client in clients)
            {
                bool ver = Restaurant.VerifyPassword(motDePasse, client.motDePasse);
                if (client.nomClient == nomClient && ver == true)
                {
                    currentClient = nomClient;
                    CurrentClient = client;
                    return true;
                }
            }
            return false;
        }


        public static string HashPassword(string password) // BCrypt.Net.
        {
            return BCrypt.Net.BCrypt.HashPassword(password); 
        }

        public static bool VerifyPassword(string password, string hashedPassword) //BCrypt.Net.
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public static bool EditClient(string nomClient)
        {
            List<Client> clients = ChargerClient();
            if (clients == null) return false;
            foreach (Client client in clients)
            {
                if (client.nomClient == nomClient)
                {
                    CurrentClient = client;
                    clients.Remove(client);
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Restaurant>));
                    using (StreamWriter writer = new StreamWriter(cheminFichier))
                    {
                        serializer.Serialize(writer, client);
                    }
                    return true;
                }
            }
            return false;
        }


    }





    public class Restaurant
    {
        private static string cheminFichier = "xmlRestaurant.xml";
        public static string currentRestaurant;
        public static Restaurant CurrentRestaurant;
        public string nomRestaurant { get; set; }
        public string adresse { get; set; }
        public string numeroGSM { get; set; }
        public string propretaire { get; set; }
        public string motDePasse { get; set; }

        public Restaurant(string nomRestaurant, string adresse, string numeroGSM, string propretaire, string motDePasse)
        {
            if (nomRestaurant == null)
            {
                throw new IdentificationException("le nom doit pas étre null.");
            }
            this.nomRestaurant = nomRestaurant;
            if (adresse == null)
            {
                throw new IdentificationException("l'adresse doit pas étre null.");
            }
            this.adresse = adresse;
            if (numeroGSM == null)
            {
                throw new IdentificationException("le numero doit pas étre null.");
            }
            this.numeroGSM = numeroGSM;
            if (propretaire == null)
            {
                throw new IdentificationException("le propriètaire doit pas étre null.");
            }
            this.propretaire = propretaire;
            if (motDePasse == null)
            {
                throw new IdentificationException("le mot de passe doit pas étre null.");
            }
            this.motDePasse = motDePasse;
        }
        public Restaurant() { }


        private static List<Restaurant> ChargerRestaurants()
        {
            if (!File.Exists(cheminFichier))
                return new List<Restaurant>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Restaurant>));
            using (StreamReader reader = new StreamReader(cheminFichier))
            {
                return (List<Restaurant>)serializer.Deserialize(reader);
            }
        }
        public bool EnregistrerRestaurent()
        {
            List<Restaurant> restaurants = ChargerRestaurants();

            foreach (Restaurant restaurant in restaurants)
            {
                if (restaurant.nomRestaurant == this.nomRestaurant)
                {
                    return false;
                }
            }
            if (this.motDePasse == "" || this.motDePasse == null)
            {
                return false;
            }
            this.motDePasse = Restaurant.HashPassword(this.motDePasse);

            restaurants.Add(this);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Restaurant>));
            using (StreamWriter writer = new StreamWriter(cheminFichier))
            {
                serializer.Serialize(writer, restaurants);
            }
            return true;
        }

        public static bool VerifierRestaurant(string nomRestaurant, string motDePasse)
        {
            List<Restaurant> restaurants = ChargerRestaurants();
            if (restaurants == null) return false;
            foreach (Restaurant restaurant in restaurants)
            {
                bool ver = Restaurant.VerifyPassword(motDePasse, restaurant.motDePasse);
                if (restaurant.nomRestaurant == nomRestaurant && ver == true)
                {
                    currentRestaurant = nomRestaurant;
                    return true;
                }
            }
            return false;
        }

        public static Restaurant ChargerRestaurant()
        {
            List<Restaurant> restaurants = ChargerRestaurants();
            if (restaurants == null) return null;
            foreach (Restaurant restaurant in restaurants)
            {
                if (restaurant.nomRestaurant == currentRestaurant)
                {
                    return restaurant;
                }
            }
            return null;
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public static bool EditRestaurant(string restaurant)
        {
            List<Restaurant> restaurant1 = ChargerRestaurants();
            if (restaurant1 == null) return false;
            foreach (Restaurant restaurant2 in restaurant1)
            {
                if (restaurant2.nomRestaurant == restaurant)
                {
                    CurrentRestaurant = restaurant2;
                    restaurant1.Remove(restaurant2);
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Restaurant>));
                    using (StreamWriter writer = new StreamWriter(cheminFichier))
                    {
                        serializer.Serialize(writer, restaurant1);
                    }
                    return true;
                }
            }
            return false;
        }
    }
}