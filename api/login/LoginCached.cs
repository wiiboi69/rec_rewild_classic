using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Net.NetworkInformation;

namespace api2018
{
	public class logincached
	{
        public class logincached_login
        {
            public string AppVersion { get; set; }
            public int Platform { get; set; }
            public string PlatformId { get; set; }
            public ulong ClientTimestamp { get; set; }
            public ulong BuildTimestamp { get; set; }
            public string DeviceId { get; set; }
            public string LoginLockToken { get; set; }
            public string AuthParams { get; set; }
            public string Verify { get; set; }
            public ulong PlayerId { get; set; }
        }

        public string Error { get; set; }
		public getcachedlogins Player { get; set; }
		public string Token { get; set; }
		public bool FirstLoginOfTheDay { get; set; }
		public ulong AnalyticsSessionId { get; set; }
		public bool CanUseScreenMode { get; set; }
		public static string loginCache(ulong userid, ulong platformid)
		{
			int level = int.Parse(File.ReadAllText("SaveData/Profile/level.txt"));
			string name = File.ReadAllText("SaveData/Profile/username.txt");
			string despayname = File.ReadAllText("SaveData/Profile/displayName.txt");
            string bio = File.ReadAllText("SaveData/Profile/bio.txt");

            return JsonConvert.SerializeObject(new logincached
			{
				Error = "",
				Player = new getcachedlogins
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
				},
				Token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOjEsImV4cCI6MTYxOTI4NzQ2MSwidmVycyI6IjIwMTcxMTE3X0VBIn0.-GqtcqPwAzr9ZJioTiz5v0Kl4HMMjH8hFMtVzQtRN5c",
				FirstLoginOfTheDay = true,
				AnalyticsSessionId = 392394UL,
				CanUseScreenMode = true
			}); 
		}
	}
}
