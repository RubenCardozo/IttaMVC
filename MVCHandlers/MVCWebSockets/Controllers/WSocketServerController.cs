using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Net;
using System.Net.WebSockets;
using System.Threading;
using System.Text;

namespace MVCWebSockets.Controllers
{
    public class WSocketServerController : ApiController
    {


        public HttpResponseMessage Get()
        {
            if (HttpContext.Current.IsWebSocketRequest)
            {
                HttpContext.Current.AcceptWebSocketRequest(TacheTraiterRequet);
            }
            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }

        private async Task TacheTraiterRequet(AspNetWebSocketContext context)
        {
            WebSocket ws = context.WebSocket;
            while (true)
            {
                var buffer = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result = await ws.ReceiveAsync(buffer, CancellationToken.None);

                if (ws.State == WebSocketState.Open)
                {
                    String message = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                    buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Message"+ message +" bien recu"+ DateTime.Now.ToShortDateString()));
                    await ws.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                }
                else
                {

                }
            }

        }

    }
}
