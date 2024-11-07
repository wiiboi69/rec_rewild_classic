﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using server;

namespace rewild_room_sesh
{
	internal sealed class room_data_base : rr_room_data
    {
		public static Dictionary<string, room> get_all_custom_rooms()
		{
			Dictionary<string, room> room_list_custom = new Dictionary<string, room>();
			string[] directories = Directory.GetDirectories(room_util.check_room_dir());
			for (int i = 0; i < directories.Length; i++)
			{
				room custom_room_file = JsonConvert.DeserializeObject<room>(File.ReadAllText(directories[i] + "\\RoomDetails.json"));
				room_list_custom.Add(custom_room_file.Room.Name, custom_room_file);
			}
			return room_list_custom;
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
			return main_room["DormRoom"];
		}

        public sealed class subrooms
        {
			public long RoomSceneId { get; set; }
			public ulong RoomId { get; set; }
            public string RoomSceneLocationId { get; set; }
            public string Name { get; set; }
            public bool IsSandbox { get; set; }
            public string DataBlobName { get; set; }
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

		public sealed class room
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

		public sealed class room_data
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

		public sealed class c000062
		{
			public string RoomName { get; set; }
            public long RoomId { get; set; }
            public string ImageName { get; set; }
		}

		public sealed class Tags
		{
			public string Tag { get; set; }
            public int Type { get; set; }
        }
	}
}