using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace rec_rewild_classic.api.room
{
    partial class Room_System
    {
        public static Subroom_Data Get_Subroom(Room_Info_Data room, string subroom_name)
        {
            if (string.IsNullOrEmpty(subroom_name)) return room.Scenes[0];
            if (room == null) return null;
            foreach (var item in room.Scenes)
            {
                if (item.Name == subroom_name)
                    return item;
            }
            return null;
        }
        public static long Get_RoomId(string room_name)
        {
            foreach (var item in Rooms_List)
            {
                if (item.Value.Room.Name == room_name)
                {
                    return item.Value.Room.RoomId;
                }
            }
            return 0;
        }
        public static Room_Info_Data Get_Room(long Room_id)
        {
            if (Room_id <= 0) return null;
            if (!Rooms_List.TryGetValue(Room_id, out Room_Info_Item room_Info)) return null;
            Room_Info_Data room = new Room_Info_Data();
            List<Subroom_Data> subroom = new List<Subroom_Data>();
            foreach (var item in room_Info.Scenes)
            {
                subroom.Add(new Subroom_Data
                {
                    Name = item.Name,
                    DataModifiedAt = item.DataModifiedAt,
                    DataBlobName = item.DataBlobName,
                    RoomId = item.RoomId,
                    MaxPlayers = item.MaxPlayers,
                    RoomSceneId = item.RoomSceneId,
                    RoomSceneLocationId = item.RoomSceneLocationId,
                    CanMatchmakeInto = item.Support_mode.HasFlag(Subroom_Support_mode.CanMatchmakeInto),
                    IsSandbox = item.Support_mode.HasFlag(Subroom_Support_mode.Sandbox)
                });
            }
            room.Scenes = subroom;
            room.Room = new Room_Data
            {
                Name = room_Info.Room.Name,
                ImageName = room_Info.Room.ImageName,
                Description = room_Info.Room.Description,
                Accessibility = room_Info.Room.Accessibility,
                RoomId = room_Info.Room.RoomId,
                IsAGRoom = room_Info.Room.SupportsMode.HasFlag(Support_mode.AGRoom),
                CloningAllowed = room_Info.Room.SupportsMode.HasFlag(Support_mode.CloningAllowed),
                SupportsLevelVoting = room_Info.Room.SupportsMode.HasFlag(Support_mode.LevelVoting),
                SupportsScreens = room_Info.Room.SupportsMode.HasFlag(Support_mode.Screens),
                SupportsTeleportVR = room_Info.Room.SupportsMode.HasFlag(Support_mode.Teleport),
                SupportsWalkVR = room_Info.Room.SupportsMode.HasFlag(Support_mode.Walk),
                State = room_Info.Room.State,
                CreatorPlayerId = room_Info.Room.CreatorPlayerId,
            };
            room.Tags = room_Info.Tags;
            room.CheerCount = room_Info.CheerCount;
            room.FavoriteCount = room_Info.FavoriteCount;
            room.VisitCount = room_Info.VisitCount;
            room.CoOwners = room_Info.CoOwners;
            if (room_Info.Room.SupportsMode.HasFlag(Support_mode.Player_Is_room_owner))
            {
                room.CoOwners.Add(int.Parse(File.ReadAllText("SaveData/Profile/userid.txt")));
            }
            room.InvitedCoOwners = room_Info.InvitedCoOwners;
            room.Hosts = room_Info.Hosts;
            room.InvitedHosts = room_Info.InvitedHosts;
            return room;
        }
    }
}
