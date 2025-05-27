using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static rec_rewild_classic.api.config.Objective.Objective;

namespace rec_rewild_classic.api.config
{
    public class Config
    {
        public class photonConfig
        {
            public string CloudRegion { get; set; }
            public bool CrcCheckEnabled { get; set; }
            public bool EnableServerTracingAfterDisconnect { get; set; }
        }
        public class ConfigTableEntry
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
        public class MatchmakingConfigParams
        {
            public float PreferFullRoomsFrequency { get; set; }
            public float PreferEmptyRoomsFrequency { get; set; }
        }
        public class LevelProgressionEntry
        {
            public int Level { get; set; }
            public int RequiredXp { get; set; }
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
        public static Objective_item[][] dailyObjectives = new Objective_item[][]
        {
            new Objective_item[]
            {
                new Objective_item
                {
                    type = ObjectivesType.QuestGames_Scifi1,
                    score = 1,
                    xp = 200
                },
                new Objective_item
                {
                    type = ObjectivesType.QuestEnemyKills_Scifi1,
                    score = 10,
                    xp = 200
                },
                new Objective_item
                {
                    type = ObjectivesType.ArenaGames,
                    score = 1,
                    xp = 200
                }
            },
            new Objective_item[]
            {
                new Objective_item
                {
                    type = ObjectivesType.PaintballCTFGames,
                    score = 2,
                    xp = 200
                },
                new Objective_item
                {
                    type = ObjectivesType.VisitACustomRoom,
                    score = 1,
                    xp = 200
                },
                new Objective_item
                {
                    type = ObjectivesType.ScoreBasketInRecCenter,
                    score = 1,
                    xp = 200
                }
            },
            new Objective_item[]
            {
                new Objective_item
                {
                    type = ObjectivesType.DodgeballGames,
                    score = 2,
                    xp = 200
                },
                new Objective_item
                {
                    type = ObjectivesType.DodgeballHits,
                    score = 2,
                    xp = 200
                },
                new Objective_item
                {
                    type = ObjectivesType.CheerAPlayer,
                    score = 1,
                    xp = 200
                }
            },
            new Objective_item[]
            {
                new Objective_item
                {
                    type = ObjectivesType.PaintballTeamBattleGames,
                    score = 2,
                    xp = 200
                },
                new Objective_item
                {
                    type = ObjectivesType.PaintballTeamBattleHits,
                    score = 20,
                    xp = 200
                },
                new Objective_item
                {
                    type = ObjectivesType.VisitACustomRoom,
                    score = 1,
                    xp = 200
                }
            },
            new Objective_item[]
            {
                new Objective_item
                {
                    type = ObjectivesType.QuestGames_Goblin1,
                    score = 1,
                    xp = 200
                },
                new Objective_item
                {
                    type = ObjectivesType.QuestEnemyKills_Goblin1,
                    score = 10,
                    xp = 200
                },
                new Objective_item
                {
                    type = ObjectivesType.CheerAPlayer,
                    score = 1,
                    xp = 200
                }
            },
            new Objective_item[]
            {
                new Objective_item
                {
                    type = ObjectivesType.PaintballAnyModeGames,
                    score = 2,
                    xp = 200
                },
                new Objective_item
                {
                    type = ObjectivesType.PaintballAnyModeHits,
                    score = 20,
                    xp = 200
                },
                new Objective_item
                {
                    type = ObjectivesType.ArenaGames,
                    score = 1,
                    xp = 200
                }
            },
            new Objective_item[]
            {
                new Objective_item
                {
                    type = ObjectivesType.QuestGames_Goblin2,
                    score = 1,
                    xp = 200
                },
                new Objective_item
                {
                    type = ObjectivesType.QuestEnemyKills_Goblin2,
                    score = 10,
                    xp = 200
                },
                new Objective_item
                {
                    type = ObjectivesType.VisitACustomRoom,
                    score = 1,
                    xp = 200
                }
            }
        };
        public class ConfigBase
        {
            public string CdnBaseUri { get; set; } = "http://localhost:20182";
            public string ShareBaseUrl { get; set; } = "http://localhost:" + Program.api_port + "/web/img/view/{0}";
            public List<ConfigTableEntry> ConfigTable { get; set; } = new List<ConfigTableEntry>
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
            };
            public Objective_item[][] DailyObjectives { get; set; }
            public List<LevelProgressionEntry> LevelProgressionMaps { get; set; } = levelProgressionsMap_create();
            public MatchmakingConfigParams MatchmakingParams { get; set; } = new MatchmakingConfigParams
            {
                PreferEmptyRoomsFrequency = 1,
                PreferFullRoomsFrequency = 1
            };
            public string MessageOfTheDay { get; set; } = new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Update/motd.txt");
            public photonConfig PhotonConfig { get; set; } = new photonConfig
            {
                CloudRegion = "EU",
                CrcCheckEnabled = false,
                EnableServerTracingAfterDisconnect = false
            };
        }
        public static ConfigBase GetDebugConfig()
        {
            return new ConfigBase
            {
                DailyObjectives = dailyObjectives
            };
        }
    }
}
