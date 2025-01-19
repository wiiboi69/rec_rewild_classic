using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using api;

namespace api
{
    internal class ConfigBase
    {
        public string CdnBaseUri { get; set; }
        public List<ConfigTableEntry> ConfigTable { get; set; }
        public Objective[][] DailyObjectives { get; set; }
        public List<LevelProgressionEntry> LevelProgressionMaps { get; set; }
        public MatchmakingConfigParams MatchmakingParams { get; set; }
        public string MessageOfTheDay { get; set; }
        public photonConfig PhotonConfig { get; set; }
    }

    internal class Config
    {
        public static gamesesh.GameSessions.SessionInstance localGameSession;
        public static Objective[][] dailyObjectives = new Objective[][]
        {
            new Objective[]
            {
                new Objective
                {
                    type = Objective_type.OOBE_GoToLockerRoom,
                    score = 1
                },
                new Objective
                {
                    type = Objective_type.OOBE_GoToActivity,
                    score = 1
                },
                new Objective
                {
                    type = Objective_type.OOBE_FinishActivity,
                    score = 1
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = Objective_type.OOBE_GoToLockerRoom,
                    score = 1
                },
                new Objective
                {
                    type = Objective_type.OOBE_GoToActivity,
                    score = 1
                },
                new Objective
                {
                    type = Objective_type.OOBE_FinishActivity,
                    score = 1
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = Objective_type.OOBE_GoToLockerRoom,
                    score = 1
                },
                new Objective
                {
                    type = Objective_type.OOBE_GoToActivity,
                    score = 1
                },
                new Objective
                {
                    type = Objective_type.OOBE_FinishActivity,
                    score = 1
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = Objective_type.OOBE_GoToLockerRoom,
                    score = 1
                },
                new Objective
                {
                    type = Objective_type.OOBE_GoToActivity,
                    score = 1
                },
                new Objective
                {
                    type = Objective_type.OOBE_FinishActivity,
                    score = 1
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = Objective_type.OOBE_GoToLockerRoom,
                    score = 1
                },
                new Objective
                {
                    type = Objective_type.OOBE_GoToActivity,
                    score = 1
                },
                new Objective
                {
                    type = Objective_type.OOBE_FinishActivity,
                    score = 1
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = Objective_type.OOBE_GoToLockerRoom,
                    score = 1
                },
                new Objective
                {
                    type = Objective_type.OOBE_GoToActivity,
                    score = 1
                },
                new Objective
                {
                    type = Objective_type.OOBE_FinishActivity,
                    score = 1
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = Objective_type.OOBE_GoToLockerRoom,
                    score = 1
                },
                new Objective
                {
                    type = Objective_type.OOBE_GoToActivity,
                    score = 1
                },
                new Objective
                {
                    type = Objective_type.OOBE_FinishActivity,
                    score = 1
                }
            }
        };

        public static string GetDebugConfig()
		{
			
			return JsonConvert.SerializeObject(new ConfigBase
            {
				MessageOfTheDay = new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Update/motd.txt"),
				CdnBaseUri = "http://localhost:20182/",
				LevelProgressionMaps = new List<LevelProgressionEntry>
				{
					new LevelProgressionEntry
					{
						Level = 0,
						RequiredXp = 1
					},
					new LevelProgressionEntry
					{
						Level = 1,
						RequiredXp = 2
					},
					new LevelProgressionEntry
					{
						Level = 2,
						RequiredXp = 3
					},
					new LevelProgressionEntry
					{
						Level = 3,
						RequiredXp = 4
					},
					new LevelProgressionEntry
					{
						Level = 4,
						RequiredXp = 5
					},
					new LevelProgressionEntry
					{
						Level = 5,
						RequiredXp = 6
					},
					new LevelProgressionEntry
					{
						Level = 6,
						RequiredXp = 7
					},
					new LevelProgressionEntry
					{
						Level = 7,
						RequiredXp = 8
					},
					new LevelProgressionEntry
					{
						Level = 8,
						RequiredXp = 9
					},
					new LevelProgressionEntry
					{
						Level = 9,
						RequiredXp = 10
					},
					new LevelProgressionEntry
					{
						Level = 10,
						RequiredXp = 11
					},
					new LevelProgressionEntry
					{
						Level = 11,
						RequiredXp = 12
					},
					new LevelProgressionEntry
					{
						Level = 12,
						RequiredXp = 13
					},
					new LevelProgressionEntry
					{
						Level = 13,
						RequiredXp = 14
					},
					new LevelProgressionEntry
					{
						Level = 14,
						RequiredXp = 15
					},
					new LevelProgressionEntry
					{
						Level = 15,
						RequiredXp = 16
					},
					new LevelProgressionEntry
					{
						Level = 16,
						RequiredXp = 17
					},
					new LevelProgressionEntry
					{
						Level = 17,
						RequiredXp = 18
					},
					new LevelProgressionEntry
					{
						Level = 18,
						RequiredXp = 19
					},
					new LevelProgressionEntry
					{
						Level = 19,
						RequiredXp = 20
					},
					new LevelProgressionEntry
					{
						Level = 20,
						RequiredXp = 21
					}
				},
				MatchmakingParams = new MatchmakingConfigParams
				{
					PreferEmptyRoomsFrequency = 0f,
					PreferFullRoomsFrequency = 1f
				},
				DailyObjectives = Config.dailyObjectives,
				ConfigTable = new List<ConfigTableEntry>
				{
					new ConfigTableEntry
					{
						Key = "Gift.DropChance",
						Value = 0.5f.ToString()
					},
					new ConfigTableEntry
					{
						Key = "Gift.XP",
						Value = 0.5f.ToString()
					}
				},
				PhotonConfig = new photonConfig
				{
					CloudRegion = "us",
					CrcCheckEnabled = false,
					EnableServerTracingAfterDisconnect = false
				}
			});
		}
	}
}
