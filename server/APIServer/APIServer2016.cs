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
using System.Linq;
using System.Net.Mime;
using Rec_rewild.api;

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
                this.listener.Prefixes.Add("http://localhost:" + start.Program.version + "0/");
                this.listener.Start();
                Console.WriteLine("[APIServer2016.cs] is listening.");

                while (true)
                {
                    HttpListenerContext context = this.listener.GetContext();
                    ThreadPool.QueueUserWorkItem(o => HandleRequest(context));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                File.WriteAllText("crashdump.txt", Convert.ToString(ex));
                this.listener.Close();
                new APIServer2016();
            }
        }

        static Dictionary<string, string> keyValueStore = new Dictionary<string, string>();

        private void HandleRequest(HttpListenerContext context)
        {
            try
            {
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
                string contentType = request.ContentType;
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
                if (request.HttpMethod == "POST")
                {
                    if (contentType == "application/x-www-form-urlencoded")
                    {
                        keyValueStore = ParseKeyValuePairs(text);                       
                    }
                    else if (contentType == "application/json")
                    {
                       
                    }
                }
                if (!(Url == "images/v2/profile"))
				{
					Console.WriteLine($"API Data: (Content-Type: {contentType}): {text}");
                    bool flag1;
                    string rnfn;
                    string temp1 = ImageUpload_2018.SaveImageFile(array, out flag1, out rnfn);

                    if (flag1)
                    {
                        s = "{\"success\":false,\"error\":\"failed to uploaded image\",\"ImageName\":\"\"}";
                        Console.Beep();
                        Console.WriteLine("Failed to upload image");
                    }
                    else
                    {
                        string name = File.ReadAllText("SaveData/Profile/username.txt");
                        Random random = new Random();
                        var imageData = new
                        {
                            SavedImageId = random.Next(1, 99999999),
                            ImageName = rnfn,
                            Username = name
                        };
                        s = JsonConvert.SerializeObject(imageData, Formatting.Indented);
                    }
                }
                else
                {
                    Console.WriteLine($"API Data: (Content-Type: {contentType}): unviewable");
                }
                if (Url.StartsWith("versioncheck"))
                {
                    s = APIServer_Base.VersionCheckResponse;
                    version_data = request.Headers.Get("X-Rec-Room-Version");
                    Console.WriteLine(version_data);
                }
				if (Url == "config/v2")
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
                    s = getorcreate.GetOrCreate(Get_value<ulong>(keyValueStore, "PlatformId"));
				}
                else if (Url.StartsWith("players/v1/"))
                {
                    ulong temp_1 = ulong.Parse(Url.Substring("players/v1/".Length));
                    s = getorcreate.GetOrCreate(temp_1);
                }
                if (Url.StartsWith("images/v1/profile/"))
				{
					image = true;
					imagebyte = File.ReadAllBytes("SaveData/profileimage.png");
				}
				if (Url == "avatar/v2")
				{
					s = File.ReadAllText("SaveData/avatar.txt");
				}
				if (Url == "avatar/v2/set")
				{
					//for later 2018 builds compatibility
					if (!(text.Contains("FaceFeatures")))
					{
						string postdatacache = text;
						text = postdatacache.Remove(postdatacache.Length - 1, 1) + File.ReadAllText("SaveData/App/facefeaturesadd.txt");
					}
					File.WriteAllText("SaveData/avatar.txt", text);
				}
                //anticheat/v1/config
                if (Url == "anticheat/v1/config")
                {
					s = JsonConvert.SerializeObject(new
					{
						Enabled = false,
                        BannedPlayers = new ulong[0]
                    });
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
					s = File.ReadAllText("SaveData/settings.txt");
				}
				if (Url == "settings/v2/set")
				{
					Settings.SetPlayerSettings(text);
				}
				if (Url == "avatar/v3/items")
				{
					s = File.ReadAllText("SaveData/avataritems.txt");
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
					File.WriteAllBytes("SaveData/profileimage.png", Encoding.UTF8.GetBytes(text.Remove(0, 50).Remove(NewLength - 48, 48)));
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
                outputStream.Flush();
            }
			catch (Exception ex4)
			{
				Console.WriteLine(ex4);
				File.WriteAllText("crashdump.txt", Convert.ToString(ex4));
			}
		}
        static T Get_value<T>(Dictionary<string, string> data, string key)
        {
            foreach (var item in data)
            {
                if (item.Key == key)
                {
                    return (T)Convert.ChangeType(item.Value, typeof(T));
                }
            }
            return default(T);
        }
        static Dictionary<string, string> ParseKeyValuePairs(string data)
        {
            var keyValuePairs = new Dictionary<string, string>();
            var entries = data.Split('&');
            foreach (var entry in entries)
            {
                var pair = entry.Split('=');
                if (pair.Length == 2)
                {
                    string key = pair[0].Trim();
                    string value = pair[1].Trim();
                    keyValuePairs[key] = value;
                }
            }
            return keyValuePairs;
        }

        public static string BlankResponse = "";
        public static string BracketResponse = "[]";

        public static string version_data = "";


        private HttpListener listener = new HttpListener(); 
	}
}
