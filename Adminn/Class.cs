using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

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
            return $"{ Nom} - {Prix}€";
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
        public Nouriture nouriture { get; set; }
        public Boisson boisson { get; set; }
        public Frites frites { get; set; }
        public bool disponibilte { get; set; } = true;

        public Menu(Nouriture nouriture, Boisson boisson, Frites frites, bool disponibilte)
        {
            if (nouriture == null || boisson == null || frites == null)
                throw new MenuException("Les trois articles doivent être présents.");

            compteurMenu++;
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
        static int compteurOrder = 0;
        public int idOrder { get; set; }
        public Nouriture nouriture { get; set; }
        public Boisson boisson { get; set; }
        public Frites frites { get; set; }
        public Client client { get; set; }
        public char etatOrder { get; set; } = 'N'; // N : nouvelle, A : Ancienne.

        public Order(Nouriture nouriture, Boisson boisson, Frites frites, Client client, char etatOrder)
        {
            if (nouriture == null || boisson == null || frites == null)
                throw new OrderException("Les trois articles doivent être présents.");

            compteurOrder++;
            this.idOrder = compteurOrder;
            this.nouriture = nouriture;
            this.boisson = boisson;
            this.frites = frites;
            this.client = client;
            this.etatOrder = etatOrder;
        }

        public string ToString()
        {
            return $"ID Commande: {this.idOrder}\n{this.nouriture}\n{this.boisson}\n{this.frites}\nÉtat: {etatOrder}";
        }
    }











    public class Client
    {
        public int idClient { get; set; }
        public string nomClient { get; set; }
        public string prenomClient { get; set; }
        public string adresseClient { get; set; }
        public string numeroGSMClient { get; set; }

        public Client(int idClient, string nomClient, string prenomClient, string adresseClient, string numeroGSMClient)
        {
            this.idClient = idClient;
            this.nomClient = nomClient;
            this.prenomClient = prenomClient;
            this.adresseClient = adresseClient;
            this.numeroGSMClient = numeroGSMClient;
        }
        public Client() { }


    }





   public class Restaurant
   {
        private static string cheminFichier = "xmlRestaurant.xml";
        public string nomRestaurant { get; set; }
        public string adresse {  get; set; }
        public string numeroGSM { get; set; }
        public string propretaire {  get; set; }
        public string motDePasse { get; set; } // il faut ajouter un hashage aprés.

        public Restaurant(string nomRestaurant, string adresse, string numeroGSM, string propretaire, string motDePasse)
        {
            if( nomRestaurant == null )
            {
                throw new IdentificationException("le nom doit pas étre null.");
            }
            this.nomRestaurant= nomRestaurant;
            if( adresse == null)
            {
                throw new IdentificationException("l'adresse doit pas étre null.");
            }
            this.adresse = adresse;
            if( numeroGSM == null)
            {
                throw new IdentificationException("le numero doit pas étre null.");
            }
            this.numeroGSM = numeroGSM;
            if( propretaire == null)
            {
                throw new IdentificationException("le propriètaire doit pas étre null.");
            }
            this.propretaire = propretaire;
            if( motDePasse == null)
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
                if (restaurant.nomRestaurant == nomRestaurant)
                {
                    return false;
                }
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
            if (restaurants == null)  return false;
            foreach (Restaurant restaurant in restaurants)
            {
                bool ver = Restaurant.VerifyPassword(motDePasse ,restaurant.motDePasse);
                if (restaurant.nomRestaurant == nomRestaurant && ver == true)
                {
                    return true;
                }
            }
            return false;
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }


    }



}
