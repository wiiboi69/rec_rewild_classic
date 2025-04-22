using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace rewild_room_sesh
{
	internal sealed class room_sesh
	{
		public static gamesession DormRoom_GameSession()
		{
			return new gamesession
            {
				GameSessionId = 20181L,
				PhotonRegionId = "us",
				PhotonRoomId = "1",
				Name = "DormRoom",
				RoomId = 1L,
				RoomSceneId = 1L,
				RoomSceneLocationId = "76d98498-60a1-430c-ab76-b54a29b7a163",
				IsSandbox = false,
				DataBlobName = string.Empty,
				PlayerEventId = null,
				Private = false,
				GameInProgress = false,
				MaxCapacity = 20,
				IsFull = false
			};
		}
        public static string Create_GameSession(string p0)
        {
            rewild_2018_sesh.Join_GameSession GameSession_join = JsonConvert.DeserializeObject<rewild_2018_sesh.Join_GameSession>(p0);

            return Create_GameSession(GameSession_join);
        }
        public static string Create_GameSession(rewild_2018_sesh.Join_GameSession GameSession_join)
		{
			Console.WriteLine("[BackEnd] Room Name: " + GameSession_join.RoomName);
			Thread.Sleep(1);
			Console.WriteLine("[BackEnd] Scene Name: " + GameSession_join.SceneName);

			bool flag = room_data_base.get_all_custom_rooms().ContainsKey(GameSession_join.RoomName);
			if (flag)
			{
                room_data = room_data_base.get_all_custom_rooms()[GameSession_join.RoomName];
			}
			else
			{
                room_data = room_data_base.main_room[GameSession_join.RoomName];
            }
            
			int num = 0;
			for (int i = 0; i < room_data.Scenes.Count(); i++)
			{
				bool flag3 = room_data.Scenes[i].Name == GameSession_join.SceneName;
				if (flag3)
				{
					num = i;
				}
			}
            room_data.InvitedCoOwners = new List<ulong> { };
            room_data.InvitedHosts = new List<ulong> { };
            string text = string.Format("{0}", room_data.Scenes[num].RoomId);
			bool flag4 = GameSession != null && text + room_util.room_name_Region == GameSession.PhotonRoomId;

			if (flag4)
			{
				text += "Instance2";
			}
			text += room_util.room_name_Region;
			bool @private = GameSession_join.Private;
            if (@private)
            {
                text += string.Format("Private{0}", server.APIServer_Base.CachedPlayerID);
            }
			long gameseshid = 20181L;

            GameSession = new gamesession
            {
				GameSessionId = gameseshid,
				PhotonRegionId = "us",
				PhotonRoomId = text,
				Name = room_data.Room.Name,
				RoomId = (long)room_data.Room.RoomId,
				RoomSceneId = (long)(num + 1),
				RoomSceneLocationId = room_data.Scenes[num].RoomSceneLocationId,
				IsSandbox = room_data.Scenes[num].IsSandbox,
				DataBlobName = room_data.Scenes[num].DataBlobName,
				PlayerEventId = null,
				Private = GameSession_join.Private,
				GameInProgress = false,
				MaxCapacity = 20,
				IsFull = false
			};

            join_GameSession_Result GameSession_Result = new join_GameSession_Result();
            GameSession_Result.Result = 0;
            GameSession_Result.GameSession = GameSession;
            GameSession_Result.RoomDetails = room_data;

			Console.WriteLine(JsonConvert.SerializeObject(GameSession_Result));

			return JsonConvert.SerializeObject(GameSession_Result);
		}

		public static room_data_base.room room_data;
		public static gamesession GameSession;

		public sealed class join_GameSession_Result
        {
			public int Result { get; set; }
			public gamesession GameSession { get; set; }
			public room_data_base.room RoomDetails { get;set; }
		}

		public sealed class gamesession
        {
			public long GameSessionId { get; set; }
			public string PhotonRegionId { get; set; }
			public string PhotonRoomId { get; set; }
            public string Name { get; set; }
            public long RoomId { get; set; }
            public long RoomSceneId { get; set; }
            public string RoomSceneLocationId { get; set; }
            public bool IsSandbox { get; set; }
            public string DataBlobName { get; set; }
            public long? PlayerEventId { get; set; }
            public bool Private { get; set; }
            public bool GameInProgress { get; set; }
            public int MaxCapacity { get; set; }
            public bool IsFull { get; set; }
		}
	}
}
