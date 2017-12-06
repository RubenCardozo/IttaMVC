using MvcDAO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDAO.Models
{
    public class PersonneValidator
    {
        [Required(ErrorMessage="Non doit être saisi")]
        public string Nom { get; set; }

        [MaxLength(20, ErrorMessage="Prenom inferieur à 20")]
        public string Prenom { get; set; }
    }

    
}
namespace MvcDAO
{
    [MetadataType(typeof(PersonneValidator))]
    public partial class Personne 
    {
    }

}