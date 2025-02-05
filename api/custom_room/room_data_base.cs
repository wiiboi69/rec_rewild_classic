using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using server;
using static rewild_room_sesh.room_data_base;

namespace rewild_room_sesh
{
	public class room_data_base : rr_room_data
    {
		public static Dictionary<string, room> get_all_custom_rooms()
		{
			Dictionary<string, room> room_list_custom = new Dictionary<string, room>();
			string[] directories = Directory.GetDirectories(room_util.check_room_dir());
			for (int i = 0; i < directories.Length; i++)
			{
                try
                {
                    room custom_room_file = JsonConvert.DeserializeObject<room>(File.ReadAllText(directories[i] + "/RoomDetails.json"));
                    room_list_custom.Add(custom_room_file.Room.Name, custom_room_file);
                }
                catch { }
            }
            return room_list_custom;
        }

        public static List<room_data> get_all_base_cloneable_rooms()
        {
            List<room_data> room_list_custom = new List<room_data>();
            foreach (var item in Base_cloneable_room)
            {
                room_list_custom.Add(item.Value.Room);
            }
            return room_list_custom;
        }

        public static List<room> get_all_base_rooms()
        {
            List<room> room_list_custom = new List<room>();
            foreach (var item in Base_cloneable_room)
            {
                room_list_custom.Add(item.Value);
            }
            return room_list_custom;
        }
        public static List<room> get_all_rooms()
        {
            List<room> room_list_custom = new List<room>();
            foreach (var item in main_room)
            {
                room_list_custom.Add(item.Value);
            }
            return room_list_custom;
        }

        public static List<room> get_all_custom_room_detail_fix()
        {
            List<room> list = new List<room>();
            foreach (KeyValuePair<string, room> keyValuePair in get_all_custom_rooms())
            {
                list.Add(keyValuePair.Value);
            }
            return list;
        }

        public static List<room_data_base.room_data> get_all_custom_room_fix()
        {
            List<room_data_base.room_data> list = new List<room_data_base.room_data>();
            foreach (KeyValuePair<string, room_data_base.room> keyValuePair in room_data_base.get_all_custom_rooms())
            {
                list.Add(keyValuePair.Value.Room);
            }
            return list;
        }

        public static room Get_room_detail(ulong p0)
		{
			room temp = new room();
			foreach (KeyValuePair<string, room> keyValuePair in main_room)
            {

                if (keyValuePair.Value.Room.RoomId == p0)
                {
					temp = keyValuePair.Value;
					temp.InvitedCoOwners = new List<ulong> {};
					temp.InvitedHosts = new List<ulong> {};
                    return temp;
				}
			}
            //get_all_custom_room_detail_fix
            foreach (var keyValuePair in get_all_custom_room_detail_fix())
            {

                if (keyValuePair.Room.RoomId == p0)
                {
                    temp = keyValuePair;
                    temp.InvitedCoOwners = new List<ulong> { };
                    temp.InvitedHosts = new List<ulong> { };
                    return temp;
                }
            }
            return main_room["DormRoom"];
		}
        /// <summary>
        /// rrs in 2018:: this get a a subroom bundle detail data
        /// </summary>
        /// <param name="roomid">a room id</param>
        /// <param name="subroomid"></param>
        /// <returns></returns>
        public static rewild_studio_subroom Get_rewild_subroom_bundle_detail(long roomid, long subroomid)
        {
            foreach (var keyValuePair in main_room)
            {
                if (keyValuePair.Value.Room.RoomId == (ulong)roomid)
                {
                    if (keyValuePair.Value.Scenes[(int)subroomid].rewild_studio_data != null)
                        return keyValuePair.Value.Scenes[(int)subroomid].rewild_studio_data;
                        /*
                    foreach (var keyValuePai1r in keyValuePair.Value.Scenes)
                    {
                        if (keyValuePai1r.RoomId == (ulong)subroomid)
                        {
                            if (keyValuePai1r != null)
                                return keyValuePai1r.rewild_studio_data;
                        }
                    }
                        */
                }
            }
            return null;
        }

        public class rewild_studio_subroom
		{
            public string? AssetBundleName { get; set; }
            public string? DataSceneName { get; set; }
            public List<string> RequiredAssetBundleNames { get; set; } = new List<string>();
            public List<string> RequiredSubSceneNames { get; set; } = new List<string>();
            public List<string> LevelRoomSubSceneNames { get; set; } = new List<string>();
        }
        public class subrooms
        {
			public long RoomSceneId { get; set; }
			public ulong RoomId { get; set; }
            public string RoomSceneLocationId { get; set; }
            public string Name { get; set; }
            public bool IsSandbox { get; set; }
            public string DataBlobName { get; set; }
            public rewild_studio_subroom? rewild_studio_data { get; set; } = null;
            public int MaxPlayers { get; set; }
            public bool CanMatchmakeInto { get; set; }
            public DateTime DataModifiedAt { get; set; }
            public string ReplicationId { get; set; }
			public bool UseLevelBasedMatchmaking { get; set; }
			public bool UseAgeBasedMatchmaking { get; set; }
			public bool UseRecRoyaleMatchmaking { get; set; }
			public int ReleaseStatus { get; set; }
			public bool SupportsJoinInProgress { get; set; }
		}

		public class room
        {
			public room_data Room { get; set; }
            public List<subrooms> Scenes { get; set; }
            public List<ulong> CoOwners { get; set; }
            public List<ulong> InvitedCoOwners { get; set; }
            public List<ulong> Hosts { get; set; }
            public List<ulong> InvitedHosts { get; set; }
            public ulong CheerCount { get; set; }
            public ulong FavoriteCount { get; set; }
            public ulong VisitCount { get; set; }
            public List<Tags> Tags { get; set; }
		}

		public class room_data
		{
            public ulong RoomId { get; set; }
			public string Name { get; set; }
            public string Description { get; set; }
            public ulong CreatorPlayerId { get; set; }
            public string ImageName { get; set; }
            public int State { get; set; }
            public int Accessibility { get; set; }
            public bool SupportsLevelVoting { get; set; }
            public bool IsAGRoom { get; set; }
            public bool CloningAllowed { get; set; }
            public bool SupportsScreens { get; set; }
            public bool SupportsWalkVR { get; set; }
            public bool SupportsTeleportVR { get; set; }
            public string ReplicationId { get; set; }
			public int ReleaseStatus { get; set; }
		}

		public class Tags
		{
			public string Tag { get; set; }
            public int Type { get; set; }
        }
	}
}
