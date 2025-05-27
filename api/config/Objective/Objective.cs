using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rec_rewild_classic.api.config.Objective
{
    public class Objective
    {
        public class Objective2018
        {
            public List<ObjectiveEntry> Objectives { get; set; }
            public List<ObjectiveGroup> ObjectiveGroups { get; set; }

            public Objective2018()
            {
                this.Objectives = new List<ObjectiveEntry>();
                this.ObjectiveGroups = new List<ObjectiveGroup>();
            }
        }
    
        public class ObjectiveGroup
        {
            public int Group { get; set; }
            public bool IsCompleted { get; set; }
            public DateTime ClearedAt { get; set; }
        }
        public class ObjectiveEntry
        {
            public int Index { get; set; }
            public int Group { get; set; }
            public float Progress { get; set; }
            public float VisualProgress { get; set; }
            public bool IsCompleted { get; set; }
            public bool IsRewarded { get; set; }
        }
        public class Objective_item
        {
            public ObjectivesType type { get; set; }
            public int score { get; set; }
            public int xp { get; set; }
        }
        public enum ObjectivesType
        {
            Default = -1,
            FirstSessionOfDay = 1,
            AddAFriend,
            PartyUp,
            AllOtherChallenges,
            LevelUp,
            CheerAPlayer,
            PointedAtPlayer,
            CheerARoom,
            SubscribeToPlayer,
            DailyObjective1,
            DailyObjective2,
            DailyObjective3,
            AllDailyObjectives,
            CompleteAnyDaily,
            CompleteAnyWeekly,
            OOBE_GoToLockerRoom = 20,
            OOBE_GoToActivity,
            OOBE_FinishActivity,
            NUX_PunchcardObjective = 25,
            NUX_AllPunchcardObjectives,
            GoToRecCenter = 30,
            FinishActivity,
            VisitACustomRoom,
            CreateACustomRoom,
            ScoreBasketInRecCenter = 35,
            UploadPhotoToRecNet,
            UpdatePlayerBio,
            SaveOutfitSlot,
            PurchaseClothingItem,
            PurchaseNonClothingItem,
            CharadesGames = 100,
            CharadesWinsPerformer,
            CharadesWinsGuesser,
            DiscGolfWins = 200,
            DiscGolfGames,
            DiscGolfHolesUnderPar,
            DodgeballWins = 300,
            DodgeballGames,
            DodgeballHits,
            PaddleballGames = 400,
            PaddleballWins,
            PaddleballScores,
            PaintballAnyModeGames = 500,
            PaintballAnyModeWins,
            PaintballAnyModeHits,
            PaintballCTFWins = 600,
            PaintballCTFGames,
            PaintballCTFHits,
            PaintballFlagCaptures,
            PaintballTeamBattleWins = 700,
            PaintballTeamBattleGames,
            PaintballTeamBattleHits,
            PaintballFreeForAllWins = 710,
            PaintballFreeForAllGames,
            PaintballFreeForAllHits,
            SoccerWins = 800,
            SoccerGames,
            SoccerGoals,
            BowlingGames = 900,
            BowlingWins,
            BowlingStrike,
            QuestGames = 1000,
            QuestWins,
            QuestPlayerRevives,
            QuestEnemyKills,
            QuestGames_Goblin1 = 1010,
            QuestWins_Goblin1,
            QuestPlayerRevives_Goblin1,
            QuestEnemyKills_Goblin1,
            QuestGames_Goblin2 = 1020,
            QuestWins_Goblin2,
            QuestPlayerRevives_Goblin2,
            QuestEnemyKills_Goblin2,
            QuestGames_Scifi1 = 1030,
            QuestWins_Scifi1,
            QuestPlayerRevives_Scifi1,
            QuestEnemyKills_Scifi1,
            QuestGames_Pirate1 = 1040,
            QuestWins_Pirate1,
            QuestPlayerRevives_Pirate1,
            QuestEnemyKills_Pirate1,
            ArenaGames = 2000,
            ArenaWins,
            ArenaPlayerRevives,
            ArenaHeroTags,
            ArenaBotTags,
            RecRoyaleGames = 3000,
            RecRoyaleWins,
            RecRoyaleTags
        }
    }
}
