using System;
using System.Runtime.CompilerServices;
using static gamesesh.GameSessions;

namespace rewild_room_sesh
{ 
	internal sealed class rewild_2018_sesh
	{
		public sealed class Join_GameSession
        {
			public ulong[] ExpectedPlayerIds { get; set; }
			public regionpings[] RegionPings { get; set; }
            public string[] RoomTags { get; set; }
            public string RoomName { get; set; }
            public string SceneName { get; set; }
            public int AdditionalPlayerJoinMode { get; set; }
            public bool Private { get; set; }            
		}

		public sealed class regionpings
        {
			public string Region {  get; set; }
			public int Ping { get; set; }
		}
	}
}
