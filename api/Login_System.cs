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
        public class GetCachedLogin
        {
            public int Id { get; set; }
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
        public class Login_Player_Account_dto
        {
            public string AppVersion { get; set; }
            public Platform_Type Platform { get; set; }
            public string PlatformId { get; set; }
            public long ClientTimestamp { get; set; }
            public long BuildTimestamp { get; set; }
            public string DeviceId { get; set; }
            public string LoginLockToken { get; set; }
            public string AuthParams { get; set; }
            public string Verify { get; set; }
        }
        public class Create_Player_Account_dto : Login_Player_Account_dto
        {
            public DateTime Birthday { get; set; }
            public string Email { get; set; }
        }
        public class Player_Account_login_base
        {
            public string Error { get; set; }
            public GetCachedLogin Player { get; set; }
            public string Token { get; set; }
            public bool FirstLoginOfTheDay { get; set; }
            public long AnalyticsSessionId { get; set; }
        }
        public class Player_Account_Login : Player_Account_login_base
        {
            public bool CanUseScreenMode { get; set; }
        }
        public static Player_Account_Login Login_player_account(Login_Player_Account_dto data)
        {
            return new Player_Account_Login
            {
                Error = "",
                Player = GetPlayerCachedLogins(data.Platform, data.PlatformId)[0],
                Token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOjEsImV4cCI6MTYxOTI4NzQ2MSwidmVycyI6IjIwMTcxMTE3X0VBIn0.-GqtcqPwAzr9ZJioTiz5v0Kl4HMMjH8hFMtVzQtRN5c",
                FirstLoginOfTheDay = true,
                AnalyticsSessionId = 392394L,
                CanUseScreenMode = true
            };
        }
        public static Player_Account_login_base Create_Player_Account_Login(Create_Player_Account_dto data)
        {
            return new Player_Account_login_base
            {
                Error = "",
                Player = GetPlayerCachedLogins(data.Platform, data.PlatformId)[0],
                Token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOjEsImV4cCI6MTYxOTI4NzQ2MSwidmVycyI6IjIwMTcxMTE3X0VBIn0.-GqtcqPwAzr9ZJioTiz5v0Kl4HMMjH8hFMtVzQtRN5c",
                FirstLoginOfTheDay = true,
                AnalyticsSessionId = 392394L,
            };
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
        public static List<GetCachedLogin> GetPlayerCachedLogins(Platform_Type platform, string platformid)
        {
            int level = int.Parse(File.ReadAllText("SaveData/Profile/level.txt"));
            int xp = int.Parse(File.ReadAllText("SaveData/Profile/xp.txt"));
            int userid = int.Parse(File.ReadAllText("SaveData/Profile/userid.txt"));
            string user_name = File.ReadAllText("SaveData/Profile/username.txt");
            string display_name = File.ReadAllText("SaveData/Profile/displayName.txt");
            string bio = File.ReadAllText("SaveData/Profile/bio.txt");
            return new List<GetCachedLogin>
            {
                new GetCachedLogin
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
                            Platform = platform,
                            PlatformId = platformid
                        }
                    }
                }
            };
        }
    }
}
