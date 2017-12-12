using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCSignalR.Models
{
    
    [HubName("ittahub")]
    public class IttaHub : Hub<IClient>
    {
        static Dictionary<string, string> users = new Dictionary<string, string>();
        
        [HubMethodName ("envoi")]
        public void envoi(string expediteur, string destinataire, string message)
        {
            //Clients.All.reception(expediteur,destinataire,message);
            Clients.Group("Users").onReception(expediteur, destinataire, message);
        }

        [HubMethodName("envoi")]
        public void connecting(string username, bool connect)
        {
            String cid = Context.ConnectionId;

                if (users[username] == null && connect)
                {
                    users.Add(username, cid);
                    Clients.Others.onReception(username, null, "is_connected");
                }
                else
                    if (users[username] == cid && !connect)
                {
                    users.Remove(username);
                    Clients.Others.onReception(username, null, "is_disconnected");
                }   
        }


        public override Task OnConnected()
        {
            String cid = Context.ConnectionId;
            Groups.Add(cid, "Users");
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {

            String cid = Context.ConnectionId;
            Groups.Remove(cid, "Users");
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
    
    }
   
}