using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using start;
using static System.Net.WebRequestMethods;

namespace server
{
	internal class NameServer
	{
		public NameServer()
		{
			try
			{
				Console.WriteLine("[NameServer.cs] has started.");
				new Thread(new ThreadStart(this.StartListen)).Start();
                //new Thread(new ThreadStart(this.StartListen2)).Start();
            }
			catch (Exception ex)
			{
				Console.WriteLine("An Exception Occurred while Listening :" + ex.ToString());
			}
		}

		private void StartListen()
		{
			//nameserver is ONLY for 2018
			this.listener.Prefixes.Add("http://localhost:2035/");
            for (; ; )
            {
                this.listener.Start();
                Console.WriteLine("[NameServer.cs] is listening.");
                HttpListenerContext context = this.listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                string rawUrl = request.RawUrl;
                string s = "";
                NSData data = new NSData()
                {
                    API = $"http://localhost:{start.Program.api_port}",
                    Cdn = "http://localhost:20182",
                    Notifications = "http://localhost:20161",
                    Images = "http://localhost:20182"
                };
                s = JsonConvert.SerializeObject(data);
                if (rawUrl.StartsWith("/new"))
                {
                    s = JsonConvert.SerializeObject(new
                    {
                        API = $"http://localhost:{start.Program.api_port}",
                        Accounts = $"http://localhost:{start.Program.api_port}",
                        Auth = $"http://localhost:{start.Program.api_port}",
                        CDN = $"http://localhost:20182",
                        Chat = $"http://localhost:{start.Program.api_port}",
                        Clubs = $"http://localhost:{start.Program.api_port}",
                        Commerce = $"http://localhost:{start.Program.api_port}",
                        DataCollection = $"http://localhost:{start.Program.api_port}",
                        Images = "http://localhost:20182",
                        Leaderboard = $"http://localhost:{start.Program.api_port}",
                        Link = $"http://localhost:{start.Program.api_port}",
                        Matchmaking = $"http://localhost:{start.Program.api_port}",
                        Moderation = $"http://localhost:{start.Program.api_port}",
                        Notifications = $"http://localhost:{start.Program.api_port}",
                        PlatformNotifications = $"http://localhost:{start.Program.api_port}",
                        RoomComments = $"http://localhost:{start.Program.api_port}",
                        Rooms = $"http://localhost:{start.Program.api_port}",
                        Storage = $"http://localhost:{start.Program.api_port}",
                        WWW = $"http://localhost:{start.Program.api_port}",
                    });
                }
                Console.WriteLine("API Response: " + s);
                byte[] bytes = Encoding.UTF8.GetBytes(s);
                response.ContentLength64 = (long)bytes.Length;
                Stream outputStream = response.OutputStream;
                outputStream.Write(bytes, 0, bytes.Length);
                Thread.Sleep(400);
                outputStream.Close();
                this.listener.Stop();
            }
        }

        private void StartListen2()
        {
            //nameserver is ONLY for 2018
            this.listener2.Prefixes.Add("http://localhost:56/");
            for (; ; )
            {
                this.listener2.Start();
                Console.WriteLine("[NameServer2.cs] is listening.");
                HttpListenerContext context = this.listener2.GetContext();  
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                string rawUrl = request.RawUrl;
                string s = "";
                NSData data = new NSData()
                {
                    API = "http://localhost:2018",
                    Cdn = "http://localhost:20182",
                    Notifications = "http://localhost:20161",
                    Images = "http://localhost:20182"
                };
                s = JsonConvert.SerializeObject(data);
                Console.WriteLine("API Response: " + s);
                byte[] bytes = Encoding.UTF8.GetBytes(s);
                response.ContentLength64 = (long)bytes.Length;
                Stream outputStream = response.OutputStream;
                outputStream.Write(bytes, 0, bytes.Length);
                Thread.Sleep(500);
                outputStream.Close();
                this.listener2.Stop();
            }
        }
        public static string VersionCheckResponse = "{\"ValidVersion\":true}";
		public static string BlankResponse = "";
		public class NSData
        {
			public string API { get; set; }
			public string Notifications { get; set; }
			public string Images { get; set; }
            public string Cdn { get; set; }

        }

        private HttpListener listener = new HttpListener();

		private HttpListener listener2 = new HttpListener();
	}
}
