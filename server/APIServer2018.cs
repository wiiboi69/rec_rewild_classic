﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using api;
using api2018;
using Newtonsoft.Json;
using vaultgamesesh;
using System.Collections.Generic;

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
				this.listener.Prefixes.Add("http://localhost:" + start.Program.version + "/");

				for (; ; )
				{
					this.listener.Start();
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
					using (StreamReader streamReader = new StreamReader(request.InputStream, request.ContentEncoding))
					{
						text = streamReader.ReadToEnd();
					}
					Console.WriteLine("API Data: " + text);
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
						s = Config2.GetDebugConfig();
					}
					if (Url == "platformlogin/v1/getcachedlogins")
					{
						s = getcachedlogins.GetDebugLogin(ulong.Parse(text.Remove(0, 32)), ulong.Parse(text.Remove(0, 22)));
						APIServer_Base.CachedPlayerID = ulong.Parse(text.Remove(0, 32));
                        APIServer_Base.CachedPlatformID = ulong.Parse(text.Remove(0, 22));
						File.WriteAllText("SaveData\\Profile\\userid.txt", Convert.ToString(APIServer_Base.CachedPlayerID));

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
						s = File.ReadAllText("SaveData\\gameconfigs.txt");
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
						s = File.ReadAllText("SaveData\\avatar.txt");
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
							text = postdatacache.Remove(postdatacache.Length - 1, 1) + File.ReadAllText("SaveData\\App\\facefeaturesadd.txt");
						}
						File.WriteAllText("SaveData\\avatar.txt", text);
					}
					if (Url == "settings/v2/")
					{
						s = File.ReadAllText("SaveData\\settings.txt");
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
						s = File.ReadAllText("SaveData\\avataritems2.txt");
					}
					if (Url == "equipment/v1/getUnlocked")
					{
                        //s = File.ReadAllText("SaveData\\equipment.txt");
                        s = BracketResponse;
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
						//	s = File.ReadAllText("SaveData\\consumables.txt");
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
						s = File.ReadAllText("SaveData\\myrooms.txt");
					}
					if (Url == "rooms/v2/myrooms")
					{
						s = BracketResponse;
					}
					if (Url == "rooms/v2/baserooms")
					{
						s = File.ReadAllText("SaveData\\baserooms.txt");
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
						s = Activities.Charades.words();
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
						s = c000041.Create_GameSession(text);
					}
					if (rawUrl == "//api/sanitize/v1/isPure")
					{
						s = "{\"IsPure\":true}";
					}
					if (Url == "avatar/v3/saved")
					{
						s = BracketResponse;
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
					if (Url == "rooms/v1/clone")
					{
						s = JsonConvert.SerializeObject(c000099.m00000a(text));
					}
					if (Url.StartsWith("rooms/v2/saveData"))
					{
						//string text26 = "5GDNL91ZY43PXN2YJENTBL";
						//string path = c000004.m000007() + c000041.f000043.Room.Name;
						//File.WriteAllBytes(string.Concat(new string[]
						//{
						//c000004.m000007(),
						//c000041.f000043.Room.Name,
						//"\\room\\",
						//text26,
						//".room"
						//}), m00005d(list.ToArray(), "data.dat"));
						//c000041.f000043.Scenes[0].DataBlobName = text26 + ".room";
						//c000041.f000043.Scenes[0].DataModifiedAt = DateTime.Now;
						//File.WriteAllText(c000004.m000007() + c000041.f000043.Room.Name + "\\RoomDetails.json", JsonConvert.SerializeObject(c000041.f000043));
						//s = JsonConvert.SerializeObject(c00005d.m000035());
					}
					if (Url == "presence/v3/heartbeat")
					{
						s = JsonConvert.SerializeObject(Notification2018.Reponse.createResponse(4, c000020.m000027()));
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
						CustomRooms.RoomGet(Url.Remove(0, 22));
					}
					if (Url == "rooms/v4/details/29")
					{
						//s = File.ReadAllText("SaveData\\Rooms\\Downloaded\\RoomDetails.json");
						Thread.Sleep(100);
					}
					else if (Url.StartsWith("rooms/v4/details"))
					{
						s = JsonConvert.SerializeObject(c00005d.m000023(Convert.ToInt32(Url.Remove(0, 17))));
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
					Thread.Sleep(200);
					outputStream.Close();
					this.listener.Stop();

				}
				
			}
			catch (Exception ex4)
			{
				Console.WriteLine(ex4);
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
