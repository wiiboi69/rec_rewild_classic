using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Server;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace rec_rewild_classic.server
{
	public class NotificationServer
	{
        public NotificationServer()
        {
            
            try
            {
                Console.WriteLine("[WebSocket signal r] is starting.");

                new Thread(new ThreadStart(StartListen)).Start();
                Console.WriteLine("[WebSocket signal r] has started and now is listening.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occurred while Listening :" + ex.ToString());
            }
        }
        private static HttpListener listener = new HttpListener();

        public class http_data
        {
            public string url;
            public string data;
            public string? Response_data;
            public HttpListenerRequest Request_context;
            public HttpListenerResponse response_context;
        }

        public static http_data Get_http_data(HttpListenerContext context)
        {
            string text;
            using (StreamReader streamReader = new StreamReader(context.Request.InputStream))
            {
                text = streamReader.ReadToEnd();
            }

            return new http_data
            {
                url = context.Request.RawUrl,
                data = text,
                Response_data = "",
                Request_context = context.Request,
                response_context = context.Response
            };
        }
        public static void Send_http_data(http_data data)
        {
            Console.WriteLine($"[WebSocket signal r]: Response_data = {data.Response_data}");

            byte[] bytes = Encoding.UTF8.GetBytes(data.Response_data);
            data.response_context.ContentLength64 = bytes.LongLength;
            data.response_context.OutputStream.Write(bytes, 0, bytes.Length);
        }

        public static void StartListen()
        {
            listener.Prefixes.Add("http://localhost:20183/");
            for (; ; )
            {
                listener.Start();
                HttpListenerContext context = listener.GetContext();
                http_data data = Get_http_data(context);
                Console.WriteLine($"[WebSocket signal r]: url = {data.url}");
                if (data.Request_context.IsWebSocketRequest)
                {
                    Console.WriteLine("[WebSocket signal r]: Websocket wanted");
                    rewild_route.Websocker_routing_system.ProcessRequest(context);
                    continue;
                }
                switch (data.url)
                {
                    case string s when s.StartsWith("/negotiate"):
                        data.Response_data = JsonConvert.SerializeObject(new signal_r_hub
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
                        });
                        break;
                    default:
                        Console.WriteLine("Unknown url: " + data.url);
                        break;
                }
                Send_http_data(data);
                continue;
            }
        }
        public class signal_r_hub
        {
            public int negotiateVersion;
            public string connectionId;
            public List<signal_r_Transport> availableTransports;
        }
        public class signal_r_Transport
        {
            public string transport;
            public List<string> transferFormats;
        }


        public enum ResponseResults
		{
			RelationshipChanged = 1,
			MessageReceived,
			MessageDeleted,
			PresenceHeartbeatResponse,
			SubscriptionListUpdated = 9,
			SubscriptionUpdateProfile = 11,
			SubscriptionUpdatePresence,
			SubscriptionUpdateGameSession,
			SubscriptionUpdateunkon,
            SubscriptionUpdateRoom = 15,
			ModerationQuitGame = 20,
			ModerationUpdateRequired,
			ModerationKick,
			ModerationKickAttemptFailed,
			ServerMaintenance = 25,
			GiftPackageReceived = 30,
            GiftPackageReceivedImmediate,
            ProfileJuniorStatusUpdate = 40,
			RelationshipsInvalid = 50,
			StorefrontBalanceAdd = 60,
			ConsumableMappingAdded = 70,
			ConsumableMappingRemoved,
			PlayerEventCreated = 80,
			PlayerEventUpdated,
			PlayerEventDeleted,
			PlayerEventResponseChanged,
			PlayerEventResponseDeleted,
			PlayerEventStateChanged,
			ChatMessageReceived = 90,
            CommunityBoardUpdate = 95,
            CommunityBoardAnnouncementUpdate
        }

		public class Reponse
		{
			public ResponseResults Id { get; set; }

			public object Msg { get; set; }
			
			public static NotificationServer.Reponse createResponse(ResponseResults id, object msg)
			{
				return new NotificationServer.Reponse
				{
					Id = id,
					Msg = msg
				};
			}
		}
	}
}
