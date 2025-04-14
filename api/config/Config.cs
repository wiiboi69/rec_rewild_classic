using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using api;
using server;

namespace api
{
    internal class ConfigBase
    {
        public string CdnBaseUri { get; set; }
        public string ShareBaseUrl { get; set; }
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
                    type = Objective_type.QuestGames_Scifi1,
                    score = 1,
                    xp = 200
                },
                new Objective
                {
                    type = Objective_type.QuestEnemyKills_Scifi1,
                    score = 10,
                    xp = 200
                },
                new Objective
                {
                    type = Objective_type.ArenaGames,
                    score = 1,
                    xp = 200
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = Objective_type.PaintballCTFGames,
                    score = 2,
                    xp = 200
                },
                new Objective
                {
                    type = Objective_type.VisitACustomRoom,
                    score = 1,
                    xp = 200
                },
                new Objective
                {
                    type = Objective_type.ScoreBasketInRecCenter,
                    score = 1,
                    xp = 200
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = Objective_type.DodgeballGames,
                    score = 2,
                    xp = 200
                },
                new Objective
                {
                    type = Objective_type.DodgeballHits,
                    score = 2,
                    xp = 200
                },
                new Objective
                {
                    type = Objective_type.CheerAPlayer,
                    score = 1,
                    xp = 200
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = Objective_type.PaintballTeamBattleGames,
                    score = 2,
                    xp = 200
                },
                new Objective
                {
                    type = Objective_type.PaintballTeamBattleHits,
                    score = 20,
                    xp = 200
                },
                new Objective
                {
                    type = Objective_type.VisitACustomRoom,
                    score = 1,
                    xp = 200
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = Objective_type.QuestGames_Goblin1,
                    score = 1,
                    xp = 200
                },
                new Objective
                {
                    type = Objective_type.QuestEnemyKills_Goblin1,
                    score = 10,
                    xp = 200
                },
                new Objective
                {
                    type = Objective_type.CheerAPlayer,
                    score = 1,
                    xp = 200
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = Objective_type.PaintballAnyModeGames,
                    score = 2,
                    xp = 200
                },
                new Objective
                {
                    type = Objective_type.PaintballAnyModeHits,
                    score = 20,
                    xp = 200
                },
                new Objective
                {
                    type = Objective_type.ArenaGames,
                    score = 1,
                    xp = 200
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = Objective_type.QuestGames_Goblin2,
                    score = 1,
                    xp = 200
                },
                new Objective
                {
                    type = Objective_type.QuestEnemyKills_Goblin2,
                    score = 10,
                    xp = 200
                },
                new Objective
                {
                    type = Objective_type.VisitACustomRoom,
                    score = 1,
                    xp = 200
                }
            }
        };
        public static Objective[][] dailyObjectivessMap_create()
        {
            List<Objective[]> objectives = new List<Objective[]>();
            for (int i = 0; i < 7; i++)
            {
                objectives.Add(new Objective[]
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
                });

            }
            return objectives.ToArray();
        }

        public static List<LevelProgressionEntry> levelProgressionsMap_create()
        {
            List<LevelProgressionEntry> levelProgressions = new List<LevelProgressionEntry>();
            int RequiredXp = 0;
            for (int Level = 0; Level < 51; Level++)
            {
                switch (Level)
                {
                    case 0:
                        RequiredXp = 0;
                        break;
                    case < 4:
                        RequiredXp = 10;
                        break;
                    case < 11:
                        RequiredXp = 20;
                        break;
                    case < 21:
                        RequiredXp = 45;
                        break;
                    case < 31:
                        RequiredXp = 115;
                        break;
                    case < 41:
                        RequiredXp = 360;
                        break;
                    default:
                        RequiredXp = 1080;
                        break;
                }
                levelProgressions.Add(new LevelProgressionEntry
                {
                    Level = Level,
                    RequiredXp = RequiredXp
                });
            }
            return levelProgressions;
        }

        public static string GetDebugConfig()
		{
            if (!string.IsNullOrEmpty(APIServer2016.version_data))
            {
                return JsonConvert.SerializeObject(new ConfigBase
                {
                    MessageOfTheDay = new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Update/motd.txt"),
                    CdnBaseUri = "http://localhost:20182/",

                    MatchmakingParams = new MatchmakingConfigParams
                    {
                        PreferEmptyRoomsFrequency = 0f,
                        PreferFullRoomsFrequency = 1f
                    },
                    DailyObjectives = dailyObjectivessMap_create(),
                    ConfigTable = new List<ConfigTableEntry> { },

                    PhotonConfig = new photonConfig
                    {
                        CloudRegion = "EU",
                        CrcCheckEnabled = false,
                        EnableServerTracingAfterDisconnect = false
                    }
                });
            }
			return JsonConvert.SerializeObject(new ConfigBase
            {
				MessageOfTheDay = new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Update/motd.txt"),
				CdnBaseUri = "http://localhost:20182/",
               
                MatchmakingParams = new MatchmakingConfigParams
				{
					PreferEmptyRoomsFrequency = 0f,
					PreferFullRoomsFrequency = 1f
				},
				LevelProgressionMaps = levelProgressionsMap_create(),
				DailyObjectives = Config.dailyObjectives,
				ConfigTable = new List<ConfigTableEntry>
				{
					new ConfigTableEntry
					{
						Key = "Gift.DropChance",
						Value = 0.33f.ToString()
					},
                    new ConfigTableEntry
                    {
                        Key = "Gift.Falloff",
                        Value = 1.2f.ToString()
                    },
                    new ConfigTableEntry
                    {
                        Key = "Gift.Falloff",
                        Value = 0xA.ToString()
                    },
                    new ConfigTableEntry
					{
						Key = "Gift.XP",
						Value = 0.5f.ToString()
					},
                    new ConfigTableEntry
                    {
                        Key = "impossiblesAllowed",
                        Value = true.ToString()
                    }
                },
                
                PhotonConfig = new photonConfig
				{
					CloudRegion = "EU",
					CrcCheckEnabled = false,
					EnableServerTracingAfterDisconnect = false
				}
			});

            /*
             impossiblesAllowed
             
             */
        }
    }
}
