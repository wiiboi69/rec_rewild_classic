using Newtonsoft.Json;
using rec_rewild_classic.api.player;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static rec_rewild_classic.api.Login_System;
using static rec_rewild_classic.api.player.PlayerReputation;

namespace rec_rewild_classic.api
{
    class Login_System
    {
        public class PlatformID
        {
            public Platform_Type Platform { get; set; }
            public string PlatformId { get; set; }
        }
        public class GetCachedLogins
        {
            public ulong Id { get; set; }
            public string Username { get; set; }
            public string DisplayName { get; set; }
            public string Bio { get; set; }
            public int XP { get; set; }
            public int Level { get; set; }
            public Registration_Status RegistrationStatus { get; set; }
            public bool Developer { get; set; }
            public bool CanReceiveInvites { get; set; }
            public string ProfileImageName { get; set; }
            public bool JuniorProfile { get; set; }
            public bool ForceJuniorImages { get; set; }
            public bool PendingJunior { get; set; }
            public bool HasBirthday { get; set; }
            public bool AvoidJuniors { get; set; }
            public PlayerReputation PlayerReputation { get; set; }
            public List<PlatformID> PlatformIds { get; set; }
        }
        public enum Platform_Type
        {
            STEAM,
            OCULUS,
            PS4,
            MICROSOFT,
            LINUX_HEADLESS_BOT
        }
        public enum Registration_Status
        {
            Unregistered,
            PendingEmailVerification,
            Registered
        }
        public static string GetPlayerCachedLogins(ulong userid, string platformid)
        {
            int level = int.Parse(File.ReadAllText("SaveData/Profile/level.txt"));
            int xp = int.Parse(File.ReadAllText("SaveData/Profile/xp.txt"));
            string user_name = File.ReadAllText("SaveData/Profile/username.txt");
            string display_name = File.ReadAllText("SaveData/Profile/displayName.txt");
            string bio = File.ReadAllText("SaveData/Profile/bio.txt");
            return JsonConvert.SerializeObject(new List<GetCachedLogins>
            {
                new GetCachedLogins
                {
                    Id = userid,
                    Username = user_name,
                    DisplayName = display_name,
                    Bio = bio,
                    XP = xp,
                    Level = level,
                    RegistrationStatus = Registration_Status.Registered,
                    Developer = true,
                    CanReceiveInvites = false,
                    ProfileImageName = user_name,
                    JuniorProfile = false,
                    ForceJuniorImages = false,
                    PendingJunior = false,
                    HasBirthday = true,
                    AvoidJuniors = true,
                    PlayerReputation = new PlayerReputation
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
                        SelectedCheer = Cheer_Type.none
                    },
                    PlatformIds = new List<PlatformID>
                    {
                        new PlatformID
                        {
                            Platform = 0,
                            PlatformId = platformid
                        }
                    }
                }
            });
        }
    }
}
