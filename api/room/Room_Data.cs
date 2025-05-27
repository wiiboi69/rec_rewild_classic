using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rec_rewild_classic.api.room
{
    partial class Room_System
    {
        public static Dictionary<long, Room_Info_Item> Rooms_List = new Dictionary<long, Room_Info_Item>
        {
            {
                1,
                new Room_Info_Item
                {
                    Room = new Room_Item
                    {
                        Name = "DormRoom",
                        Description = "Your private room.",
                        CreatorPlayerId = 1,
                        Accessibility = Accessibility_Type.Unlisted,
                        RoomId = 1,
                        ImageName = "data/server_data/img/rro/placeholder.png",
                        State = Room_State.Active,
                        SupportsMode = Support_mode.Screen_And_VR_Players | Support_mode.AGRoom | Support_mode.Player_Is_room_owner,
                    },
                    Scenes = new List<Subroom_Item>
                    {
                        new Subroom_Item
                        {
                            RoomSceneId = 1,
                            RoomId = 1,
                            RoomSceneLocationId = "76d98498-60a1-430c-ab76-b54a29b7a163",
                            Name = "home",
                            DataBlobName = string.Empty,
                            MaxPlayers = 4,
                            DataModifiedAt = DateTime.Now,
                            Support_mode = Subroom_Support_mode.Sandbox | Subroom_Support_mode.Cdn_Room_File
                        }
                    },
                    CoOwners = new List<int>(),
                    InvitedCoOwners = new List<int>(),
                    Hosts = new List<int>(),
                    InvitedHosts = new List<int>(),
                    CheerCount = 0,
                    FavoriteCount = 0,
                    VisitCount = 0,
                    Tags = new List<Tag_data>
                    {
                        new Tag_data
                        {
                            Tag = "rro",
                            Type = Tag_Type.AGOnly,
                        },
                        new Tag_data
                        {
                            Tag = "Dorm",
                            Type = Tag_Type.General,
                        }
                    }
                }
            }
        };

        public enum Room_State
        {
            Active,
            PendingJunior = 11,
            Moderation_PendingReview = 100,
            Moderation_Closed,
            MarkedForDelete = 1000
        }
        public enum Accessibility_Type
        {
            Private,
            Public,
            Unlisted
        }
        [Flags]
        public enum Support_mode
        {
            none = 0,
            Screens = 1,
            Walk = 2,
            Teleport = 4,
            LevelVoting = 8,
            AGRoom = 16,
            CloningAllowed = 32,
            Player_Is_room_owner = 64,
            Screens_Walk = Screens | Walk,
            Screens_Teleport = Screens | Teleport,
            Only_VR_Players = Walk | Teleport,
            Screen_And_VR_Players = Screens | Walk | Teleport,
        }
        public class Room_Item
        {
            public long RoomId;
            public string Name;
            public string Description;
            public int CreatorPlayerId;
            public string ImageName;
            public Room_State State;
            public Accessibility_Type Accessibility;
            public Support_mode SupportsMode;
        }
        public class Room_Data
        {
            public long RoomId;
            public string Name;
            public string Description;
            public int CreatorPlayerId;
            public string ImageName;
            public Room_State State;
            public Accessibility_Type Accessibility;
            public bool SupportsLevelVoting;
            public bool IsAGRoom;
            public bool CloningAllowed;
            public bool SupportsScreens;
            public bool SupportsWalkVR;
            public bool SupportsTeleportVR;
        }
        [Flags]
        public enum Subroom_Support_mode
        {
            none = 0,
            Sandbox = 1,
            CanMatchmakeInto = 2,
            /// <summary>
            /// when this flag is set, The server will look for a file in "savedata/rooms/cdn/{Name}_{Subroom_Scene.Name}_{RoomId}.Room"
            /// </summary>
            Cdn_Room_File = 4,
        }
        public class Subroom_Item
        {
            public long RoomSceneId;
            public long RoomId;
            public string RoomSceneLocationId;
            public string Name;
            public Subroom_Support_mode Support_mode;
            public string DataBlobName;
            public int MaxPlayers;
            public DateTime DataModifiedAt;
        }
        public class Subroom_Data
        {
            public long RoomSceneId;
            public long RoomId;
            public string RoomSceneLocationId;
            public string Name;
            public bool IsSandbox;
            public string DataBlobName;
            public int MaxPlayers;
            public bool? CanMatchmakeInto;
            public DateTime DataModifiedAt;
        }
        public enum Tag_Type
        {
            General,
            Auto,
            AGOnly,
            Banned
        }
        public class Room_Info_Item
        {
            public Room_Item Room;
            public List<Subroom_Item> Scenes;
            public List<int> CoOwners;
            public List<int> InvitedCoOwners;
            public List<int> Hosts;
            public List<int> InvitedHosts;
            public int CheerCount;
            public int FavoriteCount;
            public int VisitCount;
            public List<Tag_data> Tags;
        }
        public class Room_Info_Data
        {
            public Room_Data Room;
            public List<Subroom_Data> Scenes;
            public List<int> CoOwners;
            public List<int> InvitedCoOwners;
            public List<int> Hosts;
            public List<int> InvitedHosts;
            public int CheerCount;
            public int FavoriteCount;
            public int VisitCount;
            public List<Tag_data> Tags;
        }
        public class Tag_data
        {
            public string Tag;
            public Tag_Type Type;
        }
    }
}
