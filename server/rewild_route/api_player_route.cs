using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static rec_rewild_classic.server.rewild_route_system;
using rec_rewild_classic.api.config;
using rec_rewild_classic.api;
using Newtonsoft.Json;
using static rec_rewild_classic.api.config.Objective.Objective;

namespace rec_rewild_classic.server.rewild_route
{
    class api_player_route
    {
        [Route("/api/avatar/v2")]
        public static string avatar_get()
        {
            return File.ReadAllText("SaveData/Profile/avatar.json");
        }
        [Route("/api/avatar/v2/set")]
        public static void avatar_set()
        {

        }

        [Route("/api/objectives/v1/myprogress")]
        public static string objectives_myprogress()
        {
            return JsonConvert.SerializeObject(new Objective2018());
        }

        [Route("/api/checklist/v1/current")]
        public static string checklist_current()
        {
            return "[]";
        }
        [Route("/api/settings/v2/set")]
        public static void settings_set(Setting text)
        {
            Settings.SetPlayerSettings(text);
        }
        [Route("/api/settings/v2/", priority: url_level.high)]
        public static string settings()
        {
            return File.ReadAllText("SaveData/Profile/settings.json");
        }
       
        [Route("/api/avatar/v*/items")]
        public static string avatar_items()
        {
            return File.ReadAllText("SaveData/avataritems2.txt");
        }

        [Route("/api/avatar/v2/gifts")]
        public static string avatar_gifts()
        {
            return "[]";
        }

        [Route("/api/avatar/v3/saved")]
        public static string avatar_saved()
        {
            return "[]";
        }

        [Route("/api/consumables/v1/getUnlocked")]
        public static string consumables_getUnlocked()
        {
            return "[]";
        }
        [Route("/api/equipment/v1/getUnlocked")]
        public static string equipments_getUnlocked()
        {
            return "[]";
        }

        [Route("/api/playerevents/v1/all")]
        public static string playerevents_all()
        {
            return "{\"Created\":[],\"Responses\":[]}";
        }

        [Route("/api/messages/v2/get")]
        public static string messages_get()
        {
            return "[]";
        }
        [Route("//api/chat/v2/myChats")]
        public static string chat_v2_myChats()
        {
            return "[]";
        }
        [Route("/api/playersubscriptions/v1/my")]
        public static string my_playersubscriptions()
        {
            return "[]";
        }
        [Route("/api/relationships/v1/bulkignoreplatformusers")]
        public static string relationships_bulkignoreplatformusers()
        {
            return "[]";
        }
        [Route("/api/PlayerReporting/v1/moderationBlockDetails")]
        public static string PlayerReporting_moderationBlockDetails()
        {
            return "{\"ReportCategory\":0,\"Duration\":0,\"GameSessionId\":0,\"Message\":\"\"}";
        }

    }
}
