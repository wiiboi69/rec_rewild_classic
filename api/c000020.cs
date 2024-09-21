using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace vaultgamesesh
{
	internal sealed class c000020
	{
		public static c000022 m000027()
		{
			c000041.gamesession gameSession;
			if (c000041.GameSession == null)
			{
				gameSession = c000041.DormRoom_GameSession();
			}
			else
			{
				gameSession = c000041.GameSession;
			}
			return new c000022
			{
				PlayerId = Convert.ToUInt64(File.ReadAllText("SaveData\\Profile\\userid.txt")),
				IsOnline = true,
				PlayerType = 2,
				GameSession = gameSession
			};
		}

	
		public sealed class c000022
		{
			public ulong PlayerId { get; set; }
            public bool IsOnline { get; set; }
            public int PlayerType { get; set; }
            public c000041.gamesession GameSession { get;set;}
		}
	}
}
