using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using api;
using api2018;
using api2017;
using Newtonsoft.Json;
using rewild_room_sesh;
using System.Collections.Generic;

namespace server
{
	internal class APIServer2016
	{
		public APIServer2016()
		{
			try
			{
				Console.WriteLine("[APIServer2016.cs] has started.");
				new Thread(new ThreadStart(this.StartListen)).Start();
			}
			catch (Exception ex)
			{
				Console.WriteLine("An Exception Occurred while Listening :" + ex.ToString());
			}
		}
		private void StartListen()
		{
			try
			{
				//2 different servers for 3 different stages of the game, the apis change so much idk anymore
				this.listener.Prefixes.Add("http://localhost:" + start.Program.version + "/");

				for (; ; )
				{
					this.listener.Start();
					Console.WriteLine("[APIServer.cs] is listening.");
					HttpListenerContext context = this.listener.GetContext();
					HttpListenerRequest request = context.Request;
					HttpListenerResponse response = context.Response;
					string rawUrl = request.RawUrl;
					string Url = "";
					bool image = false;
					byte[] imagebyte = null;
					if (rawUrl.StartsWith("/api/"))
					{
						Url = rawUrl.Remove(0, 5);
					}
                    string text;
                    string s = "";
                    byte[] array;
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        context.Request.InputStream.CopyTo(memoryStream);
                        array = memoryStream.ToArray();
                        text = Encoding.ASCII.GetString(array);
                    }
                    if (!(Url == ""))
					{
						Console.WriteLine("API Requested: " + Url);
					}
					else
					{
						Console.WriteLine("API Requested (rawUrl): " + rawUrl);
					}
					if (!(Url == "images/v2/profile"))
					{
						Console.WriteLine("API Data: " + text);
					}
					if (Url.StartsWith("versioncheck"))
					{
						s = APIServer_Base.VersionCheckResponse;
					}
					if (Url == ("config/v2"))
					{
						s = Config.GetDebugConfig();
					}
					if (Url == "notification/v2")
					{
						s = "[]";
					}
					if (Url == "PlayerReporting/v1/moderationBlockDetails")
					{
						s = APIServer_Base.ModerationBlockDetails;
					}
					if (Url == "config/v1/amplitude")
					{
						s = Amplitude.amplitude();
					}
					if (Url == "players/v1/getorcreate")
					{
						s = getorcreate.GetOrCreate((ulong.Parse(text.Remove(0, 32).Remove(7, text.Length - 39))));
					}
					if (Url.StartsWith("images/v1/profile/"))
					{
						image = true;
						imagebyte = File.ReadAllBytes("SaveData\\profileimage.png");
					}
					if (Url == "avatar/v2")
					{
						s = File.ReadAllText("SaveData\\avatar.txt");
					}
					if (Url == "avatar/v2/set")
					{
						//for later 2018 builds compatibility
						if (!(text.Contains("FaceFeatures")))
						{
							string postdatacache = text;
							text = postdatacache.Remove(postdatacache.Length - 1, 1) + File.ReadAllText("SaveData\\App\\facefeaturesadd.txt");
						}
						File.WriteAllText("SaveData\\avatar.txt", text);
					}
					if (Url == "messages/v2/get")
					{
						s = BracketResponse;
					}
					if (Url == "relationships/v2/get")
					{
						s = BracketResponse;
					}
					if (Url == "settings/v2/")
					{
						s = File.ReadAllText("SaveData\\settings.txt");
					}
					if (Url == "settings/v2/set")
					{
						Settings.SetPlayerSettings(text);
					}
					if (Url == "avatar/v3/items")
					{
						s = File.ReadAllText("SaveData\\avataritems.txt");
					}
					if (Url == "avatar/v2/gifts")
					{
						s = BracketResponse;
					}
					if (Url == "events/v3/list")
					{
						s = Events.list();
					}
					if (Url == "playerevents/v1/all")
					{
						s = APIServer_Base.PlayerEventsResponse;
					}
					if (Url == "activities/charades/v1/words")
					{
						s = Charades.words();
					}
					if (Url == "images/v2/profile/") //disabled with a / at the end
					{
						s = BracketResponse;
						int NewLength = text.Length - 50;
						File.WriteAllBytes("SaveData\\profileimage.png", Encoding.UTF8.GetBytes(text.Remove(0, 50).Remove(NewLength - 48, 48)));
					}
					Console.WriteLine("API Response: " + s);
					byte[] bytes = null;
					if (image == true)
					{
						bytes = imagebyte;
					}
					else
					{
						bytes = Encoding.UTF8.GetBytes(s);
					}
					response.ContentLength64 = (long)bytes.Length;
					Stream outputStream = response.OutputStream;
					outputStream.Write(bytes, 0, bytes.Length);
					Thread.Sleep(20);
					outputStream.Close();
					this.listener.Stop();
				}
				

			}
			catch (Exception ex4)
			{
				Console.WriteLine(ex4);
				File.WriteAllText("crashdump.txt", Convert.ToString(ex4));
				this.listener.Close();
				new APIServer2016();
			}
		}


        public static string BlankResponse = "";
        public static string BracketResponse = "[]";

        private HttpListener listener = new HttpListener(); 
	}
}
