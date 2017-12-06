using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDAO.Models
{
    public class MyPersonne
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public float Salaire { get; set; }
        public DateTime? DateNaissance { get; set; }

        //public static List<Personne> peuple;
    }
}