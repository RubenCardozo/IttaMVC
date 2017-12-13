using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWcfService
{
    [ServiceContract]
    public interface IServiceItta
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        Client getPartenaire(Client composite);

    }

 
    [DataContract]
    public class Client
    {
        
        string nom = "Pierre";

        [DataMember]
        public bool Marie
        {
            get; set;
        }

        [DataMember]
        public string Nom
        {
            get { return nom; }
            set { nom = value; }

        }
        [DataMember]
        public DateTime DateNaissance
        {
            get; set;
        }
    }
}
