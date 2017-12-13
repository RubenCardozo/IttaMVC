using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ServiceItta : IServiceItta
    {
        public string GetData(int value)
        {
            return string.Format("Vous avez saisi: {0}", value);
        }

        public Client getPartenaire(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("T'es null ou  quoi?");
            }
            
            return new Client(){Nom="Pierre", Marie=true, DateNaissance= new DateTime(1971,12,22)};
        }
    }
}
