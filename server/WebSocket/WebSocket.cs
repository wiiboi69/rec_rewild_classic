using System;
using System.IO;
using System.Net;
using start;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace ws
{
	internal class WebSocket
	{
		public WebSocket()
		{
			WebSocketServer webSocketServer = new WebSocketServer(string.Format("ws://localhost:20161", Array.Empty<object>()));
			webSocketServer.AddWebSocketService<WebSocket.NotificationV2>("/api/notification/v2");
			webSocketServer.AddWebSocketService<WebSocket.NotificationV2>("/hub/v1");
			webSocketServer.Start();
			Console.WriteLine("[WebSocket.cs] has started.");
			Console.WriteLine("[WebSocket.cs] is listening.");
		}

		public class NotificationV2 : WebSocketBehavior
		{
			protected override void OnMessage(MessageEventArgs e)
			{
				Console.WriteLine("WebSocket.cs called for.");
				base.Send(Notification.ProcessRequest(e.Data));
			}
		}
	}
}
