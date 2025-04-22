using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static rec_rewild_classic.server.APIServer.rewild_route_system;
using static rec_rewild_classic.server.APIServer.rewild_route.APIServer2018_new;
using Newtonsoft.Json;
using rewild_room_sesh;
using ws;

namespace rec_rewild_classic.server.APIServer.rewild_route
{
    class Gamesesh_route
    {
        /*
         /api/rooms/v2/myrooms
         /api/presence/v3/heartbeat
        /api/rooms/v4/details
         */
        /*
        [Route("/api/relationships/v2/get")]
        public static string relationships_get()
        {
            return BracketResponse;
        }
        */

        [Route("/api/rooms/v4/details/{room_id}")]
        public static string gamesessions_joinroom(ulong room_id)
        {
            return JsonConvert.SerializeObject(room_data_base.Get_room_detail(room_id));
        }
        [Route("/api/gamesessions/v3/joinroom")]
        public static string gamesessions_joinroom(rewild_2018_sesh.Join_GameSession join_data)
        {
            return room_sesh.Create_GameSession(join_data);
        }
        
        [Route("/api/presence/v3/heartbeat")]
        public static string presence_heartbeat()
        {
            return JsonConvert.SerializeObject(Notification.Reponse.createResponse(Notification.ResponseResults.PresenceHeartbeatResponse, heartbeat.get_heartbeat()));
        }
        [Route("/api/rooms/v2/myrooms")]
        public static string rooms_myrooms()
        {
            return JsonConvert.SerializeObject(room_data_base.get_all_custom_room_fix()); // yeah... this is a mess
        }
    }
}
