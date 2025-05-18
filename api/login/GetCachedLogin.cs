using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using api2018;
using System.IO;
using System.Net.NetworkInformation;

namespace api2018
{
	public class getcachedlogins
	{
		public static string GetDebugLogin(ulong userid, ulong platformid)
		{
			int level = int.Parse(File.ReadAllText("SaveData/Profile/level.txt"));
            string name = File.ReadAllText("SaveData/Profile/username.txt");
            string despayname = File.ReadAllText("SaveData/Profile/displayName.txt");
            string bio = File.ReadAllText("SaveData/Profile/bio.txt");
            return JsonConvert.SerializeObject(new List<getcachedlogins>
			{
				new getcachedlogins
				{
					Id = userid,
					Username = name,
					DisplayName = despayname,
					Bio = bio,
					XP = 9999,
					Level = level,
					RegistrationStatus = 2,
					Developer = true,
					CanReceiveInvites = false,
					ProfileImageName = name,
					JuniorProfile = false,
					ForceJuniorImages = false,
					PendingJunior = false,
					HasBirthday = true,
					AvoidJuniors = true,
					PlayerReputation = new mPlayerReputation
					{
						Noteriety = 0,
						CheerCredit = 20,
						CheerGeneral = 10,
						CheerHelpful = 10,
						CheerGreatHost = 10,
						CheerSportsman = 10,
						CheerCreative = 10,
						SubscriberCount = 0,
						SubscribedCount = 0,
						SelectedCheer = 0
					},
					PlatformIds = new List<mPlatformID>
					{
						new mPlatformID
						{
							Platform = 0,
							PlatformId = platformid
						}
					}
				}
				
			});
		}
		public ulong Id { get; set; }
		public string Username { get; set; }
		public string DisplayName { get; set; }
        public string Bio { get; set; }
        public int XP { get; set; }
		public int Level { get; set; }
		public int RegistrationStatus { get; set; }
		public bool Developer { get; set; }
		public bool CanReceiveInvites { get; set; }
		public string ProfileImageName { get; set; }
		public bool JuniorProfile { get; set; }
		public bool ForceJuniorImages { get; set; }
		public bool PendingJunior { get; set; }
		public bool HasBirthday { get; set; }
		public bool AvoidJuniors { get; set; }
		public mPlayerReputation PlayerReputation { get; set; }
		public List<mPlatformID> PlatformIds { get; set; }
	}
}
