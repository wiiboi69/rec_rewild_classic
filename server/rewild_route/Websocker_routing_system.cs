using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static rec_rewild_classic.server.NotificationServer;

namespace rec_rewild_classic.server.rewild_route
{
    internal class Websocker_routing_system
    {
        public class SockSignalR
        {
            public MessageTypes type;
            public string invocationId;
            public bool nonblocking;
            public string target;
            public object[] arguments;
            public object item;
            public object result;
            public string error;
        }

        public enum MessageTypes
        {
            Handshake,
            Invocation,
            StreamItem,
            Completion,
            StreamInvocation,
            CancelInvocation,
            Ping,
            Close
        }

        public static int id = 1;

        public class Respond
        {
            public object Id { get; set; }
            public object Msg { get; set; }
        }
        public static async void ProcessRequest(HttpListenerContext ctx)
        {
            HttpListenerWebSocketContext httpListenerWebSocketContext = await ctx.AcceptWebSocketAsync(null);
            CancellationTokenSource src = new CancellationTokenSource();
            System.Net.WebSockets.WebSocket ws = httpListenerWebSocketContext.WebSocket;
            while (ws.State == WebSocketState.Open)
            {
                string temp1 = "";
                string temp2 = "";
                string temp3 = "";

                if (temp1 == null)
                {
                    temp1 = "{}";
                }

                Console.WriteLine(temp1);
                byte[] received = new byte[2048];
                int offset = 0;
                for (; ; )
                {
                    try
                    {
                        ArraySegment<byte> arraySegment = new ArraySegment<byte>(received, offset, received.Length);
                        WebSocketReceiveResult webSocketReceiveResult = await ws.ReceiveAsync(arraySegment, src.Token);
                        offset += webSocketReceiveResult.Count;
                        if (!webSocketReceiveResult.EndOfMessage)
                        {
                            continue;
                        }
                    }
                    catch
                    {
                    }
                    break;
                }
                if (offset != 0)
                {
                    string @string = Encoding.ASCII.GetString(received);
                    Console.WriteLine("{ws} game request: " + @string);

                    id++;
                    temp2 = JsonConvert.SerializeObject(new
                    {
                        Id = "PresenceUpdate",
                        Msg = temp1
                    });
                    byte[] array;
                    temp3 = JsonConvert.SerializeObject(new SockSignalR
                    {
                        type = MessageTypes.Invocation,
                        result = "200 OK",
                        nonblocking = true,
                        target = "Notification",
                        arguments = new object[] { JsonConvert.SerializeObject(new Respond
                        {
                            Id = "PresenceUpdate",
                            //Msg = JsonConvert.SerializeObject(Notification.Reponse.createResponse(Notification.ResponseResults.SubscriptionUpdatePresence, heartbeat.get_heartbeat()))
                        }) },
                        error = "",
                        invocationId = "1",
                        item = ""
                    });
                    if (@string.Contains("version"))
                    {
                        Console.WriteLine("{ws} game request json handshake!");
                        array = Encoding.ASCII.GetBytes("{}\u001e");
                    }
                    else if (@string.Contains("SubscribeToPlayers"))
                    {
                        Console.WriteLine("{ws} game request presence!");
                        temp3 = JsonConvert.SerializeObject(new SockSignalR
                        {
                            type = MessageTypes.Invocation,
                            result = "200 OK",
                            nonblocking = true,
                            target = "Notification",
                            arguments = new object[]
                            {
                                JsonConvert.SerializeObject(new Respond
                                {
                                    Id = "PresenceUpdate",
                                    Msg = JsonConvert.SerializeObject(new signal_r_hub
                                    {
                                        negotiateVersion = 0,
                                        connectionId = "notif",
                                        availableTransports = new List<signal_r_Transport>
                                        {
                                            new signal_r_Transport
                                            {
                                                transport = "WebSockets",
                                                transferFormats = new List<string>
                                                {
                                                    "Text",
                                                    "Binary"
                                                }
                                            }
                                        }
                                    })
                                })
                            },
                            error = null,
                            invocationId = null,
                            item = null
                        });
                    }
                    Console.WriteLine(temp3 + "\u001e");

                    array = Encoding.ASCII.GetBytes(temp3 + "\u001e");

                    await ws.SendAsync(new ArraySegment<byte>(array, 0, array.Length), WebSocketMessageType.Text, true, src.Token);
                    received = null;
                }
                received = null;
            }
        }
    }
}
