using System;

namespace InterfaceAdminRestaurant
{
    public class ArticleException : Exception
    {
        public ArticleException(string message) : base(message) { }
    }

    public class NouritureException : Exception
    {
        public NouritureException(string message) : base(message) { }
    }

    public class BoissonException : Exception
    {
        public BoissonException(string message) : base(message) { }
    }

    public class FritesException : Exception
    {
        public FritesException(string message) : base(message) { }
    }
    public class MenuException : Exception
    {
        public MenuException(string message) : base(message) { }
    }
    public class GestionFichierException : Exception
    {
        private string nomFichier;
        public GestionFichierException(string message, string nomFichier) : base(message) { this.nomFichier = nomFichier; }
    }
    public class IdentificationException : Exception
    {
        public IdentificationException(string message) : base(message) { }
    }
    public class OrderException : Exception
    {
        public OrderException(string message) : base(message) { }
    }
}