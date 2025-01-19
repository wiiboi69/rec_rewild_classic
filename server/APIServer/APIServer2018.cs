using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using api;
using api2018;
using Newtonsoft.Json;
using rewild_room_sesh;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using ws;
using Rec_rewild.api;
using start;
using Spectre.Console;
using System.Web;
using static rewild_room_sesh.c000079;
using static rewild_room_sesh.room_data_base;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Net.Mime.MediaTypeNames;

namespace server
{
	internal class APIServer2018
	{
		public APIServer2018()
		{
			try
			{
				Console.WriteLine("[APIServer2018.cs] has started.");
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
				this.listener.Prefixes.Add("http://localhost:" + start.Program.api_port + "/");
				this.listener.Start();
				for (; ; )
				{
					Console.WriteLine("[APIServer.cs] is listening.");
					HttpListenerContext context = this.listener.GetContext();
					HttpListenerRequest request = context.Request;
					HttpListenerResponse response = context.Response;
					List<byte> list = new List<byte>();
					string rawUrl = request.RawUrl;
					string Url = "";
					byte[] bytes = null;
					string signature = request.Headers.Get("X-RNSIG");
					if (rawUrl.StartsWith("/api/"))
					{
						Url = rawUrl.Remove(0, 5);
					}
                    if (rawUrl.StartsWith("//api/"))
                    {
                        Url = rawUrl.Remove(0, 6);
                    }
                    if (!(Url == ""))
					{
						Console.WriteLine("API Requested: " + Url);
					}
					else
					{
						Console.WriteLine("API Requested (rawUrl): " + rawUrl);
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
                    if (text.EndsWith('\n')) // check 2
                    {
                        Console.WriteLine("API Data: unviewable");
                    }
                    if (text.Length > 0xfff)
                    {
                        Console.WriteLine("API Data: unviewable");
                    }
                    else
                    {
                        Console.WriteLine("API Data: " + text);
                    }
                    if (Url.StartsWith("versioncheck"))
					{
						if (Url.Contains("201809"))
						{
                            APIServer_Base.CachedVersionMonth = 09;
						}
						else
						{
                            APIServer_Base.CachedVersionMonth = 05;
						}
						s = APIServer_Base.VersionCheckResponse;
					}
					if (Url == ("config/v2"))
					{
						s = Config.GetDebugConfig();
					}
					if (Url == "platformlogin/v1/getcachedlogins")
					{
						s = getcachedlogins.GetDebugLogin(ulong.Parse(text.Remove(0, 32)), ulong.Parse(text.Remove(0, 22)));
						APIServer_Base.CachedPlayerID = ulong.Parse(text.Remove(0, 32));
                        APIServer_Base.CachedPlatformID = ulong.Parse(text.Remove(0, 22));
						File.WriteAllText("SaveData/Profile/userid.txt", Convert.ToString(APIServer_Base.CachedPlayerID));
					}
					if (Url == "platformlogin/v1/loginaccount")
					{
						s = logincached.loginCache(APIServer_Base.CachedPlayerID, APIServer_Base.CachedPlatformID);
					}
					if (Url == "platformlogin/v1/createaccount")
					{
						s = logincached.loginCache(APIServer_Base.CachedPlayerID, APIServer_Base.CachedPlatformID);
					}
					if (Url == "platformlogin/v1/logincached")
					{
						s = logincached.loginCache(APIServer_Base.CachedPlayerID, APIServer_Base.CachedPlatformID);
					}
					if (Url == "relationships/v1/bulkignoreplatformusers")
					{
						s = BlankResponse;
					}
					if (Url == "players/v1/list")
					{
						s = BracketResponse;
					}
                    if (Url == "players/v2/displayname")
                    {
                        string temp = HttpUtility.UrlDecode(text.Substring("Name=".Length));
						Console.WriteLine(temp);
                        File.WriteAllText("SaveData\\Profile\\displayName.txt", temp);
						s = "{\"Success\":true,\"Message\":\"" + temp + "\"}";
                    }
                    if (Url == "players/v1/bio")
                    {
                        string temp2 = HttpUtility.UrlDecode(text.Substring("Bio=".Length));
                        Console.WriteLine(temp2);
                        File.WriteAllText("SaveData\\Profile\\bio.txt", temp2);
                        s = "{\"Success\":true,\"Message\":\"" + temp2 + "\"}";
                    }
                    if (Url == "config/v1/amplitude")
					{
						s = Amplitude.amplitude();
					}
					if (Url == "images/v2/named")
					{
						s = APIServer_Base.ImagesV2Named;
					}
					if (Url == "PlayerReporting/v1/moderationBlockDetails")
					{
						s = APIServer_Base.ModerationBlockDetails;
					}
					if (Url == "//api/chat/v2/myChats?mode=0&count=50")
					{
						s = BracketResponse;
					}
					if (Url == "messages/v2/get")
					{
						s = BracketResponse;
					}
					if (Url == "relationships/v2/get")
					{
						s = BracketResponse;
					}
					if (Url == "gameconfigs/v1/all")
					{
						s = File.ReadAllText("SaveData/gameconfigs.txt");
					}
					if (Url.StartsWith("storefronts/v3/giftdropstore"))
					{
						s = BracketResponse;
					}
					if (Url.StartsWith("storefronts/v3/balance/"))
					{
						s = BracketResponse;
					}
					if (Url == "avatar/v2")
					{
						s = File.ReadAllText("SaveData/avatar.txt");
					}

                    if (Url == "avatar/v2/saved")
					{
						s = BracketResponse;
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
					if (Url == "settings/v2/")
					{
						s = File.ReadAllText("SaveData/settings.txt");
					}
					if (Url == "settings/v2/set")
					{
						Settings.SetPlayerSettings(text);
					}
					if (rawUrl == "//api/chat/v2/myChats?mode=0&count=50")
					{
						s = BracketResponse;
					}
					if (Url == "playersubscriptions/v1/my")
					{
						s = BracketResponse;
					}
					if (Url == "avatar/v3/items")
					{
						s = File.ReadAllText("SaveData/avataritems2.txt");
					}
                    if (Url == "rewild_studio/avatar/avatar_mask")
                    {
						s = new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/Rec_rewild_server_data/refs/heads/main/AdditionalData/Masks.json");
                    }
                    if (Url == "rewild_studio/avatar/avatar_Swatch")
                    {
                        s = new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/Rec_rewild_server_data/refs/heads/main/AdditionalData/Swatches.json");
                    }
                    if (Url == "rewild_studio/avatar/avatar_Decal")
                    {
                        s = new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/Rec_rewild_server_data/refs/heads/main/AdditionalData/Decals.json");
                    }
                    if (Url == "equipment/v1/getUnlocked")
					{
                        s = BracketResponse;
                        //s = File.ReadAllText("SaveData/equipment.txt");
                    }
                    if (Url == "avatar/v1/saved")
					{
						s = BracketResponse;
					}
					if (Url == "consumables/v1/getUnlocked")
					{
						//if (APIServer_Base.CachedVersionMonth == 09)
						{
							s = BracketResponse;
						}
						//else
						{
						//	s = File.ReadAllText("SaveData/consumables.txt");
						}
					}
					if (Url == "avatar/v2/gifts")
					{
						s = BracketResponse;
					}
					if (Url == "storefronts/v2/2")
					{
						s = BlankResponse;
					}
					if (Url == "storefronts/v1/allGiftDrops/2")
					{
						s = BracketResponse;
					}
					if (Url == "objectives/v1/myprogress")
					{
                       s = JsonConvert.SerializeObject(new Objective2018());
                    }
                    if (Url == "rooms/v1/myrooms")
					{
						s = File.ReadAllText("SaveData/myrooms.txt");
					}
                    if (Url == "rooms/v2/myrooms")
                    {               
                        s = JsonConvert.SerializeObject(room_data_base.get_all_custom_room_fix(), Formatting.Indented); // yeah... this is a mess
                    }
                    if (Url == "rooms/v2/baserooms")
					{
						s = File.ReadAllText("SaveData/baserooms.txt");
					}
					if (Url == "rooms/v1/mybookmarkedrooms")
					{
						s = BracketResponse;
					}
					if (Url == "rooms/v1/myRecent?skip=0&take=10")
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
					if (Url == "gamesessions/v2/joinrandom")
					{
						s = gamesesh.GameSessions.JoinRandom(text);
					}
					if (Url == "gamesessions/v2/create")
					{
						s = gamesesh.GameSessions.Create(text);
					}
					if (Url == "gamesessions/v3/joinroom")
					{
						s = room_sesh.Create_GameSession(text);
					}
					if (Url == "sanitize/v1/isPure")
					{
						s = "{\"IsPure\":true}";
					}
                    if (Url == "images/v3/uploadsaved")
                    {
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
                                Username = name,
                            };
                            s = JsonConvert.SerializeObject(imageData);
                        }
                    }
                    if (Url == "images/v3/profile")
                    {
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
                    if (rawUrl == "playerevents//v1")
                    {
                        s = "[]";
                    }
                    if (Url == "avatar/v3/saved")
					{
						s = BracketResponse;
					}
                    if (Url == "rooms/v1/report")
                    {
                        s = "{\"Success\":false,\"Message\":\"no\"}";
                    }
                    if (Url == "checklist/v1/current")
					{
                        s = BracketResponse;
                        //s = APIServer_Base.ChecklistV1Current;
                    }
                    if (Url == "presence/v1/setplayertype")
					{
						s = BracketResponse;
					}
					if (Url == "challenge/v1/getCurrent")
					{
						s = APIServer_Base.ChallengesV1GetCurrent;
					}
					if (Url == "rooms/v1/featuredRoomGroup")
                    {
                        s = BracketResponse;
					}
                    if (Url == "rooms/v1/filters")
                    {
                        s = APIServer_Base.FiltersResponse;
                    }
                    if (Url == "rooms/v1/clone")
					{
						s = JsonConvert.SerializeObject(rewild_custom_room_2018.clone_room(text));
					}
					if (Url.StartsWith("rooms/v2/saveData"))
					{
                        //string text26 = "5GDNL91ZY43PXN2YJENTBL";
                        //string path = c000004.m000007() + c000041.f000043.Room.Name;
                        //File.WriteAllBytes(string.Concat(new string[]
                        //{
                        //c000004.m000007(),
                        //c000041.f000043.Room.Name,
                        //"/room/",
                        //text26,
                        //".room"
                        //}), m00005d(list.ToArray(), "data.dat"));
                        //c000041.f000043.Scenes[0].DataBlobName = text26 + ".room";
                        //c000041.f000043.Scenes[0].DataModifiedAt = DateTime.Now;
                        //File.WriteAllText(c000004.m000007() + c000041.f000043.Room.Name + "/RoomDetails.json", JsonConvert.SerializeObject(c000041.f000043));
                        //s = JsonConvert.SerializeObject(c00005d.m000035());
					}
                    if (Url.StartsWith("rooms/v2/modify"))
                    {
                        // RoomData.c000061 c69 = JsonConvert.DeserializeObject<RoomData.c000061>(@string);
                        // RoomData.c000060 c70 = RoomData.m000023((int)c69.RoomId);
                        //if (c69.Description != null)
                        // {
                        //  c70.Room.Description = c69.Description;
                        //  }
                        //  if (c69.ImageName != null)
                        //  {
                        //      c70.Room.ImageName = c69.ImageName;
                        //   }
                        //   File.WriteAllText("SaveData/Rooms/" + c70.Room.Name + "/RoomDetails.json", JsonConvert.SerializeObject(c70));
                        //   text2 = JsonConvert.SerializeObject(new c000099.c00009b
                        //  {
                        //   Result = 0,
                        //       RoomDetails = c70
                        //  });
                    }
                    if (Url == "presence/v3/heartbeat")
					{
						s = JsonConvert.SerializeObject(Notification.Reponse.createResponse(Notification.ResponseResults.PresenceHeartbeatResponse, heartbeat.get_heartbeat()));
					}
					if (Url == "rooms/v1/featuredRoomGroup")
					{
						s = new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Update/dormslideshow.txt");
					}
					if (Url.StartsWith("rooms/v1/hot"))
					{
						s = new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Update/hotrooms.txt");
					}
					if (Url.StartsWith("rooms/v2/instancedetails"))
					{
						s = BracketResponse;
					}
					if (Url.StartsWith("rooms/v2/search?value="))
					{
                        s = JsonConvert.SerializeObject(rewild_custom_room_2018.room_find(Url.Remove(0, 22)));
					}
					if (Url.StartsWith("rooms/v4/details"))
					{
						s = JsonConvert.SerializeObject(room_data_base.Get_room_detail(ulong.Parse(Url.Substring("rooms/v4/details/".Length))));
					}
					if (Url == "images/v1/slideshow")
					{
						s = new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Update/rcslideshow.txt");
					}
					Console.WriteLine("API Response: " + s);
					bytes = Encoding.UTF8.GetBytes(s);
					response.ContentLength64 = (long)bytes.Length;
					Stream outputStream = response.OutputStream;
					outputStream.Write(bytes, 0, bytes.Length);
					outputStream.Flush();
					//Thread.Sleep(200);
					//outputStream.Close();
					//this.listener.Stop();
				}
			}
			catch (Exception ex4)
			{
				Console.WriteLine(ex4);
				if (Convert.ToString(ex4).Contains("System.Net.HttpListenerException"))
				{
					start.Program.api_port +=1;

                    Console.WriteLine($"moving port to {start.Program.api_port}");

				}
				File.WriteAllText("crashdump.txt", Convert.ToString(ex4));
				this.listener.Close();

				new APIServer2018();
			}
		}


        public static string BlankResponse = "";
        public static string BracketResponse = "[]";


        private HttpListener listener = new HttpListener(); 
	}
}
