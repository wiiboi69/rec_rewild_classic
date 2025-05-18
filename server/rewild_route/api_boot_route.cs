using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static rec_rewild_classic.server.rewild_route_system;
using rec_rewild_classic.api.config;

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
        public static string Api_config()
        {
            return Config.GetDebugConfig();
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
        public static string Api_platformlogin_logincached(/*logincached_login login*/)
        {
            return APIServer_system.BracketResponse;//logincached.loginCache(login.PlayerId, ulong.Parse(login.PlatformId));
        }


        [Route("/api/platformlogin/v1/getcachedlogins")]
        public static string Api_platformlogin_getcachedlogins(int Platform, ulong PlatformId)
        {
            //Console.WriteLine($"APIServer2018: loading Platform " + Platform + " cachedlogin PlatformId: " + PlatformId + " with playerid: " + CachedPlayerID);

            return APIServer_system.BracketResponse;//getcachedlogins.GetDebugLogin((ulong)CachedPlayerID, PlatformId);
        }

        [Route("/api/relationships/v2/get")]
        public static string relationships_get()
        {
            return APIServer_system.BracketResponse;
        }
    }
}
