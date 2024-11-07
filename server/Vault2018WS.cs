using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using start;
using WebSocketSharp;
using WebSocketSharp.Server;
using ws;

namespace rewild_room_sesh
{
	public class Late2018WebSock
	{
		public Late2018WebSock()
		{
			Late2018WebSock.instance = this;
			this.WebSock.AddWebSocketService<Late2018WebSock.NotificationWS>("/api/notification/v2");
			this.WebSock.AddWebSocketService<Late2018WebSock.HubWS>("/hub/v1");
			this.WebSock.Start();
			Console.WriteLine("[LateWebSocket.cs] has started.");
			Console.WriteLine("[LateWebSocket.cs] is listening.");
		}

		public void Broadcast(Notification.Reponse res)
		{
			Console.WriteLine(string.Concat(new string[]
			{
				"Broadcasting ",
				JsonConvert.SerializeObject(res),
				" to ",
				this.WebSock.WebSocketServices["/api/notification/v2"].Sessions.Count.ToString(),
				" clients."
			}));

			WebSock.WebSocketServices["/api/notification/v2"].Sessions.Broadcast(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(res)));
		}

		public static Late2018WebSock instance;

		public WebSocketServer WebSock = new WebSocketServer("ws://localhost:20161");

		public class HubWS : WebSocketBehavior
		{
			protected override void OnMessage(MessageEventArgs e)
			{
				Console.WriteLine("LateWebSocket.cs Hub Requested. ");
				string temp = Encoding.ASCII.GetString(e.RawData);
                Console.WriteLine("LateWebSocket.cs Hub: " + temp);
                if (temp.Contains("SubscribeToPlayers"))
                {
                    base.Send(JsonConvert.SerializeObject(new WebSocketHTTP.SockSignalR
                    {
                        type = (WebSocketHTTP.MessageTypes)1,
                        result = "200 OK",
                        nonblocking = true,
                        target = "Notification",
                        arguments = new object[] { JsonConvert.SerializeObject(Notification.Reponse.createResponse(12, heartbeat.get_heartbeat())) },
                        error = "",
                        invocationId = "naaaa",
                        item = ""
                    }) + "\u001e");
                    return;
                }
                base.Send(JsonConvert.SerializeObject(new WebSocketHTTP.SockSignalR
                {
                    type = (WebSocketHTTP.MessageTypes)1,
                    result = "200 OK",
                    nonblocking = true,
                    target = "HubConnection",
                    arguments = new object[] { JsonConvert.SerializeObject(new Late2018WebSock.Hub()) },
                    error = "",
                    invocationId = "spin",
                    item = ""
                }) + "\u001e");

			}

			public HubWS()
			{
			}
		}

		public class Hub : WebSocketBehavior
		{
			public Hub()
			{
				this.accessToken = "AccessDeezNuts";
				this.SupportedTransports = new List<string>();
				this.negotiateVersion = 0;
				this.url = new Uri("ws://localhost:20199/");
			}

			public Uri url { get; set; }

			public string accessToken { get; set; }

			public List<string> SupportedTransports { get; set; }

			public int negotiateVersion { get; set; }
		}

		public class NotificationWS : WebSocketBehavior
		{
			protected override void OnMessage(MessageEventArgs p0)
			{
				Console.WriteLine("LateWebSocket.cs Notif Requested.");
				bool flag2 = p0.Data == null;
				bool flag3 = flag2;
				bool flag4 = flag3;
				if (flag4)
				{
					base.Send(string.Empty);
				}
				else
				{
					base.Send(Notification2018.ProcessRequest(p0.Data));
				}
			}

			public NotificationWS()
			{
			}
		}
	}
}
