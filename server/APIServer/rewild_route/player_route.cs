using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static rec_rewild_classic.server.APIServer.rewild_route_system;
using static rec_rewild_classic.server.APIServer.rewild_route.APIServer2018_new;
using System.IO;
using api;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json;
using rec_rewild_classic.api.Objective;
using api2018;

namespace rec_rewild_classic.server.APIServer.rewild_route
{
    class player_route
    {
        /*
        /api/avatar/v2
        /api/avatar/v3/items
        /api/settings/v2/
        /api/avatar/v3/saved
        /api/equipment/v1/getUnlocked
        /api/consumables/v1/getUnlocked
        /api/avatar/v2/gifts
        /api/storefronts/v3/giftdropstore/3
        /api/objectives/v1/myprogress
        /api/checklist/v1/current
        /api/playerevents/v1/all
         */
        [Route("/api/avatar/v2")]
        public static string avatar_get()
        {
            return File.ReadAllText("SaveData/avatar.txt");
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
        ////api/players/v1/list
        [Route("/api/players/v1/list")]
        public static string players_list()
        {
            return BracketResponse;
        }
        [Route("/api/checklist/v1/current")]
        public static string checklist_current()
        {
            return BracketResponse;
        }

        [Route("/api/playerevents/v1/all")]
        public static string playerevents_all()
        {
            return "{\"Created\":[],\"Responses\":[]}";
        }


        [Route("/api/storefronts/v3/giftdropstore/{giftdropid}")]
        public static string storefronts_giftdropstore(int giftdropid)
        {
            Console.WriteLine($"APIServer2018: trying to get giftdropstore: " + giftdropid);
            return api.config.storefront_base.Get_storefront_data((api.config.storefront_base.CurrencyTypes)giftdropid);
        }

        [Route("/api/storefronts/v3/balance/{balance}")]
        public static string storefronts_balance(int balance)
        {
            Console.WriteLine($"APIServer2018: trying to get storefronts balance: " + balance);
            return JsonConvert.SerializeObject(new
            {
                Balance = 69420,
                CurrencyType = balance
            });
        }
        

        [Route("/api/settings/v2/")]
        public static string settings()
        {
            return File.ReadAllText("SaveData/settings.txt");
        }
        [Route("/api/settings/v2/set")]
        public static void settings_set(Setting text)
        {
            Settings.SetPlayerSettings(text);
        }
        [Route("/api/avatar/v*/items")]
        public static string avatar_items()
        {
            return File.ReadAllText("SaveData/avataritems2.txt");
        }

        [Route("/api/avatar/v2/gifts")]
        public static string avatar_gifts()
        {
            return BracketResponse;
        }

        [Route("/api/avatar/v3/saved")]
        public static string avatar_saved()
        {
            return BracketResponse;
        }

        [Route("/api/consumables/v1/getUnlocked")]
        public static string consumables_getUnlocked()
        {
            return BracketResponse;
        }
        [Route("/api/equipment/v1/getUnlocked")]
        public static string equipments_getUnlocked()
        {
            return BracketResponse;
        }
    }
}
