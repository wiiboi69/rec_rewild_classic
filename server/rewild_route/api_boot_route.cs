using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static rec_rewild_classic.server.rewild_route_system;
using rec_rewild_classic.api.config;
using rec_rewild_classic.api;
using Newtonsoft.Json;
using static rec_rewild_classic.api.Login_System;
using static rec_rewild_classic.api.config.Config;

namespace rec_rewild_classic.server.rewild_route
{
    class api_boot_route
    {
        public static string Version_build = "";

        [Route("/api/versioncheck/v3")]
        public static string GetVersion(string v)
        {
            Console.WriteLine($"APIServer2018: build version: " + v);
            Version_build = v;
            return "{\"ValidVersion\": true}";
        }

        [Route("/api/config/v2")]
        public static ConfigBase Api_config()
        {
            return GetDebugConfig();
        }

        [Route("/api/gameconfigs/v1/all")]
        public static string Api_gameconfigs()
        {
            return File.ReadAllText("SaveData/gameconfigs.txt");
        }

        [Route("/api/presence/v1/setplayertype")]
        public static string Api_presence_setplayertype()
        {
            return APIServer_system.BracketResponse;
        }

        [Route("/api/config/v1/amplitude")]
        public static string amplitude_config()
        {
            return "{\"AmplitudeKey\":\"NoKeyProvided\"}";
        }

        [Route("/api/platformlogin/v1/logincached")]
        public static Player_Account_Login Api_platformlogin_logincached(Login_Player_Account_dto data)
        {
            return Login_player_account(data);
        }

        [Route("/api/platformlogin/v1/getcachedlogins")]
        public static List<GetCachedLogin> Api_platformlogin_getcachedlogins(int Platform, string PlatformId)
        {
            Console.WriteLine($"APIServer: loading Platform " + (Platform_Type)Platform + " cachedlogin PlatformId: " + PlatformId);

            return GetPlayerCachedLogins((Platform_Type)Platform, PlatformId);
        }

        [Route("/api/relationships/v2/get")]
        public static string relationships_get()
        {
            return APIServer_system.BracketResponse;
        }
    }
}
