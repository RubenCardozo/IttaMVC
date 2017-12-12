using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSignalR.Models
{
    public interface IClient
    {
        void onReception(string expediteur, string destinataire, string message);
    }
}