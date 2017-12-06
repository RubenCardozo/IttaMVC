using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCNovembre2017.Models
{

    public class Client :IValidatableObject

    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
        {
            if (ClientDAO.getAllClients().Count(c => c.Id == Id) > 0)
            {
                yield return new ValidationResult(Id + "existe déjà", new[] {"Id"});
            }
        }

        private String _id;

        [DisplayName("Identifiant : ")]
        [Required (ErrorMessage = "L'ID du client est obligatoire")]
        public String Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (value != null)
                    _id = value;
                else
                    throw new Exception("id ne peut pas être null");
            }
        }

        
        [DisplayName("Nom Client : ")]
        [Required(ErrorMessage = "Le nom du client est obligatoire")]
        [RegularExpression(@"[a-z]{1,30}", ErrorMessage="Format de nom en minuscule")]
        public String Nom { get; set;}

        [DisplayName("Prenom Client : ")]
        [DataType (DataType.MultilineText)]
        [StringLength(20, MinimumLength=1, ErrorMessage="Prenom entre 1 et 20 caractères")]
        [AntiChuck(ErrorMessage="Il n'y qu'un Chuck")]
        public String Prenom { get; set; }
        


        [DisplayName("Date Naissance : ")]
        //[DataType(DataType.Date]
        [DisplayFormat (DataFormatString="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true, ConvertEmptyStringToNull=true)]
        public DateTime? DateNaissance { get; set; }

        //[Range(1, 150)]
        //public int age { get; set; }


        public Client()
        {
        }

        public Client(String id, String nom, String prenom)
        {
            this.Id = id;
            Console.WriteLine(Id + " crée");
            this.Nom = nom;
            this.Prenom = prenom;
        }

        public Client(String id, String nom, String prenom, DateTime dateNaissance)
            :this(id,nom,prenom)
        {
            this.DateNaissance = dateNaissance;
        }

    }



    //static class ClientDAO
    //{
    //    static List<Client> clients;

    //    static ClientDAO() 
    //    {
    //        clients = new List<Client>(){
    //        new Client(nom: "AAA", prenom:"aaa", id: "A", dateNaissance: new DateTime(2010,10,14) ),
    //        new Client(nom: "BBB", prenom: "bbb", id: "B", dateNaissance: new DateTime(2011,11,15)),
    //        new Client(nom: "CCC", prenom: "ccc", id: "C", dateNaissance: new DateTime(2012,12,16))
    //    };
    //    }


    //    public static List<Client> getAllClients()
    //    {
    //        return clients;
    //    }

    //    public static Client GetClientById(string id) 
    //    {
    //        return clients.Find(c => c.Id == id);
    //    }

    //    // CREATE
    //    public static void AddClient(Client client)
    //    {
    //        clients.Add(client);
    //    }

    //    //DELETE
    //    public static Client RemoveClient(String id)
    //    {
    //        if (id != null)
    //        {
    //            Client client = clients.Find(c => c.Id == id);
    //            if (client != null)
    //            {
    //                if (clients.Remove(client))
    //                    return client;
    //            }
    //        }
    //        //throw new Exception("pas trouvé id = "+ id);
    //        return null;
    //    }

    //    //UPDATE
    //    public static bool UpdateOrAddClient(Client client)
    //    {
    //        if (client != null)
    //        {
    //            Client cli = clients.Find(c => c.Id == client.Id);
    //            if (cli != null)
    //            {
    //                cli.Nom = client.Nom;
    //                cli.Prenom = client.Prenom;
    //                return true;
    //            }
    //            else
    //            {
    //                clients.Add(client);
    //                return true;
    //            }
    //        }
    //        //throw new Exception("pas trouvé id = "+ id);
    //        return false;
    //    }

    //    static void AddClient(string id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}