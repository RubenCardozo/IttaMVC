using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCNov2017.Models
{
    public class Client
    {
        private string _id;

        public String Id
        {
            get
            {
                return _id;
            }

            private set
            {
                if (value != null)
                    _id = value;
                else
                    throw new Exception("id ne peut pas être null");
            }
        }

        public String Nom { get; private set; }

        public String Prenom { get; private set; }

        public Client() 
        { 
        }

        public Client(String id, String nom, String prenom) 
        {
            this.Id = id;
            Console.WriteLine(Id+" crée");
            this.Nom = nom;
            this.Prenom = prenom;


        }

    }
}