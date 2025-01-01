using System;

namespace api

{
	public class Objective
	{
		public Objective_type type { get; set; }
		public int score { get; set; }
	}
    public enum Objective_type
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
        // Token: 0x040079F4 RID: 31220
        UploadPhotoToRecNet,
        // Token: 0x040079F5 RID: 31221
        UpdatePlayerBio,
        // Token: 0x040079F6 RID: 31222
        SaveOutfitSlot,
        // Token: 0x040079F7 RID: 31223
        PurchaseClothingItem,
        // Token: 0x040079F8 RID: 31224
        PurchaseNonClothingItem,
        // Token: 0x040079F9 RID: 31225
        CharadesGames = 100,
        // Token: 0x040079FA RID: 31226
        CharadesWinsPerformer,
        // Token: 0x040079FB RID: 31227
        CharadesWinsGuesser,
        // Token: 0x040079FC RID: 31228
        DiscGolfWins = 200,
        // Token: 0x040079FD RID: 31229
        DiscGolfGames,
        // Token: 0x040079FE RID: 31230
        DiscGolfHolesUnderPar,
        // Token: 0x040079FF RID: 31231
        DodgeballWins = 300,
        // Token: 0x04007A00 RID: 31232
        DodgeballGames,
        // Token: 0x04007A01 RID: 31233
        DodgeballHits,
        // Token: 0x04007A02 RID: 31234
        PaddleballGames = 400,
        // Token: 0x04007A03 RID: 31235
        PaddleballWins,
        // Token: 0x04007A04 RID: 31236
        PaddleballScores,
        // Token: 0x04007A05 RID: 31237
        PaintballAnyModeGames = 500,
        // Token: 0x04007A06 RID: 31238
        PaintballAnyModeWins,
        // Token: 0x04007A07 RID: 31239
        PaintballAnyModeHits,
        // Token: 0x04007A08 RID: 31240
        PaintballCTFWins = 600,
        // Token: 0x04007A09 RID: 31241
        PaintballCTFGames,
        // Token: 0x04007A0A RID: 31242
        PaintballCTFHits,
        // Token: 0x04007A0B RID: 31243
        PaintballFlagCaptures,
        // Token: 0x04007A0C RID: 31244
        PaintballTeamBattleWins = 700,
        // Token: 0x04007A0D RID: 31245
        PaintballTeamBattleGames,
        // Token: 0x04007A0E RID: 31246
        PaintballTeamBattleHits,
        // Token: 0x04007A0F RID: 31247
        PaintballFreeForAllWins = 710,
        // Token: 0x04007A10 RID: 31248
        PaintballFreeForAllGames,
        // Token: 0x04007A11 RID: 31249
        PaintballFreeForAllHits,
        // Token: 0x04007A12 RID: 31250
        SoccerWins = 800,
        // Token: 0x04007A13 RID: 31251
        SoccerGames,
        // Token: 0x04007A14 RID: 31252
        SoccerGoals,
        // Token: 0x04007A15 RID: 31253
        BowlingGames = 900,
        // Token: 0x04007A16 RID: 31254
        BowlingWins,
        // Token: 0x04007A17 RID: 31255
        BowlingStrike,
        // Token: 0x04007A18 RID: 31256
        QuestGames = 1000,
        // Token: 0x04007A19 RID: 31257
        QuestWins,
        // Token: 0x04007A1A RID: 31258
        QuestPlayerRevives,
        // Token: 0x04007A1B RID: 31259
        QuestEnemyKills,
        // Token: 0x04007A1C RID: 31260
        QuestGames_Goblin1 = 1010,
        // Token: 0x04007A1D RID: 31261
        QuestWins_Goblin1,
        // Token: 0x04007A1E RID: 31262
        QuestPlayerRevives_Goblin1,
        // Token: 0x04007A1F RID: 31263
        QuestEnemyKills_Goblin1,
        // Token: 0x04007A20 RID: 31264
        QuestGames_Goblin2 = 1020,
        // Token: 0x04007A21 RID: 31265
        QuestWins_Goblin2,
        // Token: 0x04007A22 RID: 31266
        QuestPlayerRevives_Goblin2,
        // Token: 0x04007A23 RID: 31267
        QuestEnemyKills_Goblin2,
        // Token: 0x04007A24 RID: 31268
        QuestGames_Scifi1 = 1030,
        // Token: 0x04007A25 RID: 31269
        QuestWins_Scifi1,
        // Token: 0x04007A26 RID: 31270
        QuestPlayerRevives_Scifi1,
        // Token: 0x04007A27 RID: 31271
        QuestEnemyKills_Scifi1,
        // Token: 0x04007A28 RID: 31272
        QuestGames_Pirate1 = 1040,
        // Token: 0x04007A29 RID: 31273
        QuestWins_Pirate1,
        // Token: 0x04007A2A RID: 31274
        QuestPlayerRevives_Pirate1,
        // Token: 0x04007A2B RID: 31275
        QuestEnemyKills_Pirate1,
        // Token: 0x04007A2C RID: 31276
        ArenaGames = 2000,
        // Token: 0x04007A2D RID: 31277
        ArenaWins,
        // Token: 0x04007A2E RID: 31278
        ArenaPlayerRevives,
        // Token: 0x04007A2F RID: 31279
        ArenaHeroTags,
        // Token: 0x04007A30 RID: 31280
        ArenaBotTags,
        // Token: 0x04007A31 RID: 31281
        RecRoyaleGames = 3000,
        // Token: 0x04007A32 RID: 31282
        RecRoyaleWins,
        // Token: 0x04007A33 RID: 31283
        RecRoyaleTags
    }
}