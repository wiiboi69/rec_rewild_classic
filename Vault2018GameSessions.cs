using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Newtonsoft.Json;
using System.IO;

namespace vaultgamesesh
{

	internal sealed class c000041
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
			c00006b.Join_GameSession GameSession_join = JsonConvert.DeserializeObject<c00006b.Join_GameSession>(p0);
			Console.WriteLine("[BackEnd] Room Name: " + GameSession_join.RoomName);
			Thread.Sleep(1);
			Console.WriteLine("[BackEnd] Scene Name: " + GameSession_join.SceneName);
			bool flag = c00005d.m00003b().ContainsKey(GameSession_join.RoomName);
			if (flag)
			{
				room_data = c00005d.m00003b()[GameSession_join.RoomName];
			}
			else
			{
				bool flag2 = c00005d.m00003a().ContainsKey(GameSession_join.RoomName);
				if (flag2)
				{
                    room_data = c00005d.m00003a()[GameSession_join.RoomName];
				}
				else
				{
                    room_data = c00005d.f000050["DormRoom"];
				}
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
			string text = string.Format("{0}", room_data.Scenes[num].RoomId);
			bool flag4 = GameSession != null && text + c000004.room_name_Region == GameSession.PhotonRoomId;
			if (flag4)
			{
				text += "Instance2";
			}
			text += c000004.room_name_Region;
			bool @private = GameSession_join.Private;
            if (@private)
            {
                text += string.Format("Pri{0}", server.APIServer_Base.CachedPlayerID);
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

		// Token: 0x0400000B RID: 11
		public static c00005d.room room_data;

		// Token: 0x0400000C RID: 12
		public static gamesession GameSession;

		// Token: 0x02000028 RID: 40
		public sealed class join_GameSession_Result
        {
			// Token: 0x17000039 RID: 57
			// (get) Token: 0x060000D7 RID: 215 RVA: 0x0000B290 File Offset: 0x00009490
			// (set) Token: 0x060000D8 RID: 216 RVA: 0x0000B2A8 File Offset: 0x000094A8
			public int Result { get; set; }

			// Token: 0x1700003A RID: 58
			// (get) Token: 0x060000D9 RID: 217 RVA: 0x0000B2B4 File Offset: 0x000094B4
			// (set) Token: 0x060000DA RID: 218 RVA: 0x0000B2CC File Offset: 0x000094CC
			public gamesession GameSession { get; set; }

			// Token: 0x1700003B RID: 59
			// (get) Token: 0x060000DB RID: 219 RVA: 0x0000B2D8 File Offset: 0x000094D8
			// (set) Token: 0x060000DC RID: 220 RVA: 0x0000B2F0 File Offset: 0x000094F0
			public c00005d.room RoomDetails { get;set; }

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
