using System;
using Newtonsoft.Json;
using api;
using server;
using System.IO;

namespace gamesesh
{
	public class GameSessions
	{
		public static string JoinRandom(string jsonData)
		{
			long? creatorid = 1243409L;
			long gamesessionid = long.Parse(start.Program.version + "1");
			Console.WriteLine("rec_rewild_classic GameSession Room");
			GameSessions.JoinRandomRequest joinRandomRequest = JsonConvert.DeserializeObject<GameSessions.JoinRandomRequest>(jsonData);
			if (File.ReadAllText("SaveData\\App\\privaterooms.txt") == "Enabled")
			{
				gamesessionid = new Random().Next(0, 99);
			}
			if (start.Program.version == "2017")
            {
				creatorid = (long?)APIServer_Base.CachedPlayerID;
			}
			Config.localGameSession = new GameSessions.SessionInstance
			{
				GameSessionId = gamesessionid,
				RegionId = "us",
				RoomId = joinRandomRequest.ActivityLevelIds[0],
				RecRoomId = null,
				EventId = null,
				CreatorPlayerId = creatorid,
				Name = "rec_rewild_classic Room",
				ActivityLevelId = joinRandomRequest.ActivityLevelIds[0],
				Private = false,
				Sandbox = false,
				SupportsScreens = true,
				SupportsVR = true,
				GameInProgress = false,
				MaxCapacity = 20,
				IsFull = false
			};
			
			return JsonConvert.SerializeObject(new GameSessions.JoinResult
			{
				Result = 0,
				GameSession = Config.localGameSession
			});
		}
		public static string StatusSession()
		{
			return JsonConvert.SerializeObject(new GameSessions.PlayerStatus
			{
				PlayerId = Convert.ToUInt64(File.ReadAllText("SaveData\\Profile\\userid.txt")),
				IsOnline = true,
				InScreenMode = false,
				GameSession = Config.localGameSession
			});
		}
		public static string Create(string jsonData)
		{
			long gamesessionid = 20161L;
			Console.WriteLine("rec_rewild_classic GameSession Custom Room");
			if (File.ReadAllText("SaveData\\App\\privaterooms.txt") == "Enabled")
			{
				gamesessionid = new Random().Next(0, 99);
			}

			CreateRequest createRequest = JsonConvert.DeserializeObject<CreateRequest>(jsonData);
			Config.localGameSession = new SessionInstance
			{
				GameSessionId = gamesessionid,
				RegionId = "us",
				RoomId = createRequest.ActivityLevelId,
				RecRoomId = null,
				EventId = null,
				CreatorPlayerId = (long?)APIServer_Base.CachedPlayerID,
				Name = "rec_rewild_classic Custom Room",
				ActivityLevelId = createRequest.ActivityLevelId,
				Private = false,
				Sandbox = true,
				SupportsScreens = true,
				SupportsVR = true,
				GameInProgress = false,
				MaxCapacity = 20,
				IsFull = false
			};
			return JsonConvert.SerializeObject(new JoinResult
			{
				Result = 0,
				GameSession = Config.localGameSession
			});
		}
		public static PlayerStatus StatusSessionInstance()
		{
			return new PlayerStatus
			{
				PlayerId = Convert.ToUInt64(File.ReadAllText("SaveData\\Profile\\userid.txt")),
				IsOnline = true,
				InScreenMode = false,
				GameSession = Config.localGameSession
			};
		}
		public enum JoinResultIDs
		{
			Success,
			NoSuchGame,
			PlayerNotOnline,
			InsufficientSpace,
			EventNotStarted,
			EventAlreadyFinished,
			EventCreatorNotReady,
			BlockedFromRoom,
			ProfileLocked,
			NoBirthday,
			MarkedForDelete,
			JuniorNotAllowed,
			Banned,
			NoSuchRoom = 20,
			RoomCreatorNotReady,
			RoomIsNotActive,
			RoomBlockedByCreator,
			RoomBlockingCreator,
			RoomIsPrivate
		}
		public class PlayerStatus
		{
			public ulong PlayerId { get; set; }
			public bool IsOnline { get; set; }
			public bool InScreenMode { get; set; }
			public SessionInstance GameSession { get; set; }
		}
		public class SessionInstance
		{
			public long GameSessionId { get; set; }
			public string RegionId { get; set; }
			public string RoomId { get; set; }
			public long? EventId { get; set; }
			public long? RecRoomId { get; set; }
			public long? CreatorPlayerId { get; set; }
			public string Name { get; set; }
			public string ActivityLevelId { get; set; }
			public bool Private { get; set; }
			public bool Sandbox { get; set; }
			public bool SupportsVR { get; set; }
			public bool SupportsScreens { get; set; }
			public bool GameInProgress { get; set; }
			public int MaxCapacity { get; set; }
			public bool IsFull { get; set; }
		}
		public class JoinRandomRequest
		{
			public string[] ActivityLevelIds { get; set; }
			public ulong[] ExpectedPlayerIds { get; set; }
			public RegionPing[] RegionPings { get; set; }
		}
		public class JoinRoomRequest2
		{
			public ulong[] ExpectedPlayerIds { get; set; }
			public RegionPing[] RegionPings { get; set; }
			public string[] RoomTags { get; set; }
			public string RoomName { get; set; }
			public string SceneName { get; set; }
			public int AdditionalPlayerJoinMode { get; set; }
			public bool Private { get; set; }
		}
		public class CreateRequest
		{
			public string ActivityLevelId { get; set; }
			public ulong[] ExpectedPlayerIds { get; set; }
			public GameSessions.RegionPing[] RegionPings { get; set; }
			public bool IsSandbox { get; set; }
		}
		public class RegionPing
		{
			public string Region { get; set; }
			public int Ping { get; set; }
		}
		private class JoinResult
		{
			public int Result { get; set; }
			public SessionInstance GameSession { get; set; }
		}
	}
}
