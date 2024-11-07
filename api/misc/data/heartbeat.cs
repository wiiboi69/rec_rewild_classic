using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace rewild_room_sesh
{
	internal sealed class heartbeat
	{
		public static heartbeat_2018 get_heartbeat()
		{
			room_sesh.gamesession gameSession;
			if (room_sesh.GameSession == null)
			{
				gameSession = room_sesh.DormRoom_GameSession();
			}
			else
			{
				gameSession = room_sesh.GameSession;
			}
			return new heartbeat_2018
			{
				PlayerId = Convert.ToUInt64(File.ReadAllText("SaveData\\Profile\\userid.txt")),
				IsOnline = true,
				PlayerType = 2,
				GameSession = gameSession
			};
		}

	
		public sealed class heartbeat_2018
		{
			public ulong PlayerId { get; set; }
            public bool IsOnline { get; set; }
            public int PlayerType { get; set; }
            public room_sesh.gamesession GameSession { get;set;}
		}
	}
}
