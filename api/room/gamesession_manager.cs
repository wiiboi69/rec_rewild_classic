using rec_rewild_classic.api.server;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rec_rewild_classic.api.room
{
    partial class GameSession_Manager
    {
        private class SetInProgressRequest
        {
            public long GameSessionId;

            public bool InProgress;
        }
        public static Heartbeat_data heartbeat;
        public static GameSession_DTO Create_room_Session(string room_name, string subroom_name, bool private_room)
        {
            Room_System.Room_Info_Data room = Room_System.Get_Room(Room_System.Get_RoomId(room_name));
            if (room == null)
            {
                return new GameSession_DTO
                {
                    Result = GameSession_Result.NoSuchRoom,
                    RoomDetails = null,
                    GameSession = null
                };
            }
            Room_System.Subroom_Data subroom = Room_System.Get_Subroom(room, subroom_name);
            if (subroom == null)
            {
                return new GameSession_DTO
                {
                    Result = GameSession_Result.NoSuchRoom,
                    RoomDetails = null,
                    GameSession = null
                };
            }
            string photon_room_id = $"Rewild_classic_{room_name}_{subroom_name}_1_eu_none_{subroom.RoomSceneLocationId}";
            if (private_room)
            {
                photon_room_id = $"Rewild_classic_{room_name}_{subroom_name}_{random_num_genatetor.Next(0x100000, 0xffffff)}_eu_{Guid.NewGuid()}_{subroom.RoomSceneLocationId}";
            }
            heartbeat = new Heartbeat_data
            {
                DataBlobName = subroom.DataBlobName,
                RoomId = subroom.RoomId,
                RoomSceneId = subroom.RoomSceneId,
                GameInProgress = false,
                GameSessionId = random_num_genatetor.Next(0,0xffffff),
                IsFull = false,
                IsSandbox = subroom.IsSandbox,
                MaxCapacity = subroom.MaxPlayers,
                Name = room.Room.Name,
                RoomSceneLocationId = subroom.RoomSceneLocationId,
                PlayerEventId = null,
                Private = private_room,
                PhotonRoomId = photon_room_id,
            };
            return new GameSession_DTO
            {
                Result = GameSession_Result.Success,
                RoomDetails = room,
                GameSession = heartbeat
            };
        }
    }
}
