using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using api;
using Newtonsoft.Json;
using rewild_room_sesh;

namespace ws
{
    internal class WebSocketHTTP
    {
        public WebSocketHTTP()
        {
            try
            {
                Console.WriteLine("{ws} server started!");
                WebSocketHTTP.listen.Start();
            }
            catch (Exception)
            {
            }
        }

        public static void ADListen()
        {
            WebSocketHTTP.server.Prefixes.Add("http://localhost:20199/");
            for (; ; )
            {
                WebSocketHTTP.server.Start();
                Console.WriteLine("{ws} listening");
                HttpListenerContext context = WebSocketHTTP.server.GetContext();
                string rawUrl = context.Request.RawUrl;
                string text = "[]";
                Console.WriteLine("{ws} requested! " + rawUrl + ".");
                string text2;
                using (StreamReader streamReader = new StreamReader(context.Request.InputStream))
                {
                    text2 = streamReader.ReadToEnd();
                }
                if (rawUrl.StartsWith("/negotiate"))
                {
                    text = "{\"negotiateVersion\":0,\"connectionId\":\"notif\",\"availableTransports\":[{\"transport\":\"WebSockets\",\"transferFormats\":[\"Text\", \"Binary\"]}]}";
                    goto IL_C9;
                }
                if (!context.Request.IsWebSocketRequest)
                {
                    goto IL_C9;
                }
                Console.WriteLine("{ws} requested!");
                Console.WriteLine(text2);
                WebSocketHTTP.ProcessRequest(context);
            IL_BA:
                Console.WriteLine("{ws} connected!");
                continue;
            IL_C9:
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                context.Response.ContentLength64 = (long)bytes.Length;
                context.Response.OutputStream.Write(bytes, 0, bytes.Length);
                goto IL_BA;
            }
        }

        private static async void ProcessRequest(HttpListenerContext ctx)
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
                    WebSocketHTTP.id++;
                    temp2 = JsonConvert.SerializeObject(new
                    {
                        Id = "PresenceUpdate",
                        Msg = temp1
                    });
                    byte[] array;
                    temp3 = JsonConvert.SerializeObject(new WebSocketHTTP.SockSignalR
                    {
                        type = WebSocketHTTP.MessageTypes.Invocation,
                        result = "200 OK",
                        nonblocking = true,
                        target = "Notification",
                        arguments = new object[] { JsonConvert.SerializeObject(new Respond
                        {
                            Id = "PresenceUpdate",
                            Msg = JsonConvert.SerializeObject(Notification.Reponse.createResponse(Notification.ResponseResults.SubscriptionUpdatePresence, heartbeat.get_heartbeat()))
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
                        temp3 = JsonConvert.SerializeObject(new WebSocketHTTP.SockSignalR
                        {
                            type = WebSocketHTTP.MessageTypes.Invocation,
                            result = "200 OK",
                            nonblocking = true,
                            target = "Notification",
                            arguments = new object[] { JsonConvert.SerializeObject(new Respond
                            {
                                Id = "PresenceUpdate",
                                Msg = JsonConvert.SerializeObject(Notification.Reponse.createResponse(Notification.ResponseResults.SubscriptionUpdatePresence, heartbeat.get_heartbeat()))
                            }) },
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

        public class Respond
        {
            public object Id { get; set; }
            public object Msg { get; set; }
        }

        public static HttpListener server = new HttpListener();

        public static Thread listen = new Thread(new ThreadStart(WebSocketHTTP.ADListen));

        public static Dictionary<string, string> missingApis;

        public static int id = 1;

        public class SockSignalR
        {
            public WebSocketHTTP.MessageTypes type;
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
    }
}