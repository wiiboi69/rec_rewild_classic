using rec_rewild_classic.api.room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static rec_rewild_classic.server.rewild_route_system;

namespace rec_rewild_classic.server.rewild_route
{
    class api_gamesession_route
    {
        [Route("/api/rooms/v2/myrooms")]
        public static string rooms_v2_myrooms()
        {
            return "[]";
        }
        /*
         post: /api/gamesessions/v3/joinroom, application/json, json_class: JoinRoomRequest
         post: /api/gamesessions/v3/joininstance, application/json, json_class: JoinInstanceRequest
         post: /api/gamesessions/v3/joinplayerevent, application/json, json_class: JoinEventRequest
         post: /api/gamesessions/v3/joinplayer, application/json, json_class: JoinPlayerRequest
         */
        [Route("/api/gamesessions/v3/joinroom")]
        public static GameSession_Manager.GameSession_DTO Api_platformlogin_logincached(GameSession_Manager.JoinRoomRequest data)
        {
            Console.WriteLine($"[GameSession_Manager]: RoomName = '{data.RoomName}', SceneName = '{data.SceneName}', Private = '{data.Private}', AdditionalPlayerJoinMode = '{data.AdditionalPlayerJoinMode}'");
            return GameSession_Manager.Create_room_Session(data.RoomName, data.SceneName, data.Private);
        }
    }
}
