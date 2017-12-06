using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCNovembre2017.Models
{
    static class ClientDAO
    {
        static List<Client> clients;

        static ClientDAO()
        {
            clients = new List<Client>(){
            new Client(nom: "AAA", prenom: "aaa", id: "A", dateNaissance: new DateTime(2010,10,14)),
            new Client(nom: "BBB", prenom: "bbb", id: "B", dateNaissance: new DateTime(2011,11,15)),
            new Client(nom: "CCC", prenom: "ccc", id: "C", dateNaissance: new DateTime(2012,12,16))
        };
        }


        public static List<Client> getAllClients()
        {
            return clients;
        }

        public static Client GetClientById(string id)
        {
            return clients.Find(c => c.Id == id);
        }

        // CREATE
        public static void AddClient(Client client)
        {
            clients.Add(client);
        }

        //DELETE
        public static Client RemoveClient(String id)
        {
            if (id != null)
            {
                Client client = clients.Find(c => c.Id == id);
                if (client != null)
                {
                    if (clients.Remove(client))
                        return client;
                }
            }
            //throw new Exception("pas trouvé id = "+ id);
            return null;
        }

        //UPDATE
        public static bool UpdateOrAddClient(Client client)
        {
            if (client != null)
            {
                Client cli = clients.Find(c => c.Id == client.Id);
                if (cli != null)
                {
                    cli.Nom = client.Nom;
                    cli.Prenom = client.Prenom;
                    cli.DateNaissance = client.DateNaissance;
                    return true;
                }
                else
                {
                    clients.Add(client);
                    return true;
                }
            }
            //throw new Exception("pas trouvé id = "+ id);
            return false;
        }

        static void AddClient(string id)
        {
            throw new NotImplementedException();
        }
    }
}