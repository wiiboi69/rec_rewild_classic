using System;
using System.Collections.Generic;

namespace storefront2018
{
	internal class StoreFronts
	{
		public static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
		{
			int num = (day - start.DayOfWeek + 7) % 7;
			return start.AddDays((double)num);
		}
		public enum GiftContext
		{
			None = -1,
			Default,
			First_Activity,
			Game_Drop,
			All_Daily_Challenges_Complete,
			All_Weekly_Challenge_Complete,
			Daily_Challenge_Complete,
			Weekly_Challenge_Complete,
			Unassigned_Equipment = 10,
			Unassigned_Avatar,
			Unassigned_Consumable,
			Reacquisition = 20,
			Membership,
			NUX_TokensAndDressUp = 30,
			NUX_Experiment1,
			NUX_Experiment2,
			NUX_Experiment3,
			NUX_Experiment4,
			NUX_Experiment5,
			LevelUp = 100,
			LevelUp_2 = 102,
			LevelUp_3,
			LevelUp_4,
			LevelUp_5,
			LevelUp_6,
			LevelUp_7,
			LevelUp_8,
			LevelUp_9,
			LevelUp_10,
			LevelUp_11,
			LevelUp_12,
			LevelUp_13,
			LevelUp_14,
			LevelUp_15,
			// Token: 0x04000113 RID: 275
			LevelUp_16,
			// Token: 0x04000114 RID: 276
			LevelUp_17,
			// Token: 0x04000115 RID: 277
			LevelUp_18,
			// Token: 0x04000116 RID: 278
			LevelUp_19,
			// Token: 0x04000117 RID: 279
			LevelUp_20,
			// Token: 0x04000118 RID: 280
			LevelUp_21,
			// Token: 0x04000119 RID: 281
			LevelUp_22,
			// Token: 0x0400011A RID: 282
			LevelUp_23,
			// Token: 0x0400011B RID: 283
			LevelUp_24,
			// Token: 0x0400011C RID: 284
			LevelUp_25,
			// Token: 0x0400011D RID: 285
			LevelUp_26,
			// Token: 0x0400011E RID: 286
			LevelUp_27,
			// Token: 0x0400011F RID: 287
			LevelUp_28,
			// Token: 0x04000120 RID: 288
			LevelUp_29,
			// Token: 0x04000121 RID: 289
			LevelUp_30,
			// Token: 0x04000122 RID: 290
			Event_RawData = 1000,
			// Token: 0x04000123 RID: 291
			SFVRCC_Promo,
			// Token: 0x04000124 RID: 292
			HelixxVR_Promo,
			// Token: 0x04000125 RID: 293
			Paintball_ClearCut = 2000,
			// Token: 0x04000126 RID: 294
			Paintball_Homestead,
			// Token: 0x04000127 RID: 295
			Paintball_Quarry,
			// Token: 0x04000128 RID: 296
			Paintball_River,
			// Token: 0x04000129 RID: 297
			Paintball_Dam,
			// Token: 0x0400012A RID: 298
			Discgolf_Propulsion = 3000,
			// Token: 0x0400012B RID: 299
			Discgolf_Lake,
			// Token: 0x0400012C RID: 300
			Discgolf_Mode_CoopCatch = 3500,
			// Token: 0x0400012D RID: 301
			Quest_Goblin_A = 4000,
			// Token: 0x0400012E RID: 302
			Quest_Goblin_B,
			// Token: 0x0400012F RID: 303
			Quest_Goblin_C,
			// Token: 0x04000130 RID: 304
			Quest_Goblin_S,
			// Token: 0x04000131 RID: 305
			Quest_Goblin_Consumable,
			// Token: 0x04000132 RID: 306
			Quest_Cauldron_A = 4010,
			// Token: 0x04000133 RID: 307
			Quest_Cauldron_B,
			// Token: 0x04000134 RID: 308
			Quest_Cauldron_C,
			// Token: 0x04000135 RID: 309
			Quest_Cauldron_S,
			// Token: 0x04000136 RID: 310
			Quest_Cauldron_Consumable,
			// Token: 0x04000137 RID: 311
			Quest_Pirate1_A = 4100,
			// Token: 0x04000138 RID: 312
			Quest_Pirate1_B,
			// Token: 0x04000139 RID: 313
			Quest_Pirate1_C,
			// Token: 0x0400013A RID: 314
			Quest_Pirate1_S,
			// Token: 0x0400013B RID: 315
			Quest_Pirate1_X,
			// Token: 0x0400013C RID: 316
			Quest_Pirate1_Consumable,
			// Token: 0x0400013D RID: 317
			Quest_SciFi_A = 4500,
			// Token: 0x0400013E RID: 318
			Quest_SciFi_B,
			// Token: 0x0400013F RID: 319
			Quest_SciFi_C,
			// Token: 0x04000140 RID: 320
			Quest_SciFi_S,
			// Token: 0x04000141 RID: 321
			Quest_scifi_Consumable,
			// Token: 0x04000142 RID: 322
			Charades = 5000,
			// Token: 0x04000143 RID: 323
			Soccer = 6000,
			// Token: 0x04000144 RID: 324
			Paddleball = 7000,
			// Token: 0x04000145 RID: 325
			Dodgeball = 8000,
			// Token: 0x04000146 RID: 326
			Lasertag = 9000,
			// Token: 0x04000147 RID: 327
			Store_LaserTag = 100000,
			// Token: 0x04000148 RID: 328
			Store_RecCenter = 100010,
			// Token: 0x04000149 RID: 329
			Consumable = 110000,
			// Token: 0x0400014A RID: 330
			Token = 110100,
			// Token: 0x0400014B RID: 331
			Punchcard_Challenge_Complete = 110200,
			// Token: 0x0400014C RID: 332
			All_Punchcard_Challenges_Complete
		}

		// Token: 0x02000040 RID: 64
		public enum GiftTypes
		{
			// Token: 0x0400014E RID: 334
			GiftDrop,
			// Token: 0x0400014F RID: 335
			SeasonTier,
			// Token: 0x04000150 RID: 336
			SeasonEliteUpgrade
		}

		// Token: 0x02000041 RID: 65
		public enum CurrencyTypes
		{
			// Token: 0x04000152 RID: 338
			Invalid,
			// Token: 0x04000153 RID: 339
			LaserTagTickets,
			// Token: 0x04000154 RID: 340
			RecCenterTokens,
			// Token: 0x04000155 RID: 341
			LostSkullsGold = 100,
			// Token: 0x04000156 RID: 342
			RecRoyale_Season1 = 200
		}

		// Token: 0x02000042 RID: 66
		public enum StoreFrontTypes
		{
			// Token: 0x04000158 RID: 344
			None,
			// Token: 0x04000159 RID: 345
			LaserTag,
			// Token: 0x0400015A RID: 346
			RecCenter,
			// Token: 0x0400015B RID: 347
			Watch,
			// Token: 0x0400015C RID: 348
			Quest_LostSkulls = 100,
			// Token: 0x0400015D RID: 349
			RecRoyale = 200
		}

		// Token: 0x02000043 RID: 67
		public enum ItemRarity
		{
			// Token: 0x0400015F RID: 351
			None = -1,
			// Token: 0x04000160 RID: 352
			Common,
			// Token: 0x04000161 RID: 353
			Uncommon = 10,
			// Token: 0x04000162 RID: 354
			Rare = 20,
			// Token: 0x04000163 RID: 355
			Epic = 30,
			// Token: 0x04000164 RID: 356
			Legendary = 50
		}

		// Token: 0x02000044 RID: 68
		public class AllGiftDrop
		{
		}

		// Token: 0x02000045 RID: 69
		public class GiftDropStore
		{
			public int StorefrontType { get; set; }
			public DateTime NextUpdate { get; set; }
			public List<StoreFronts.StoreItem> StoreItems { get; set; }
			public GiftDropStore()
			{
				this.StorefrontType = 2;
				this.NextUpdate = StoreFronts.GetNextWeekday(DateTime.Now, DayOfWeek.Wednesday);
				this.StoreItems = new List<StoreFronts.StoreItem>
				{
					new StoreFronts.StoreItem
					{
						PurchasableItemId = 0,
						Type = 0,
						IsFeatured = false,
						Prices = new List<StoreFronts.ItemPrice>
						{
							new StoreFronts.ItemPrice
							{
								CurrencyType = 2,
								Price = 30000
							}
						},
						GiftDrops = new List<StoreFronts.GiftDrop>
						{
							new StoreFronts.GiftDrop
							{
								GiftDropId = 0,
								FriendlyName = "Saija Helmet",
								Tooltip = "",
								AvatarItemDesc = "274cb9b2-2f59-47ea-9a8d-a5b656d148c6,,,",
								ConsumableItemDesc = "",
								EquipmentPrefabName = "",
								EquipmentModificationGuid = "",
								Rarity = 50,
								IsQuery = false,
								Unique = false,
								Level = 50,
								Context = 100010
							}
						}
					},
					new StoreFronts.StoreItem
					{
						PurchasableItemId = 1,
						Type = 0,
						IsFeatured = false,
						Prices = new List<StoreFronts.ItemPrice>
						{
							new StoreFronts.ItemPrice
							{
								CurrencyType = 2,
								Price = 35000
							}
						},
						GiftDrops = new List<StoreFronts.GiftDrop>
						{
							new StoreFronts.GiftDrop
							{
								GiftDropId = 1,
								FriendlyName = "Saija Shirt",
								Tooltip = "",
								AvatarItemDesc = "2c679f89-c76e-4cfb-94e9-448c8fd44d55,,,",
								ConsumableItemDesc = "",
								EquipmentPrefabName = "",
								EquipmentModificationGuid = "",
								Rarity = 50,
								IsQuery = false,
								Unique = false,
								Level = 50,
								Context = 100010
							}
						}
					},
					new StoreFronts.StoreItem
					{
						PurchasableItemId = 2,
						Type = 0,
						IsFeatured = false,
						Prices = new List<StoreFronts.ItemPrice>
						{
							new StoreFronts.ItemPrice
							{
								CurrencyType = 2,
								Price = 10000
							}
						},
						GiftDrops = new List<StoreFronts.GiftDrop>
						{
							new StoreFronts.GiftDrop
							{
								GiftDropId = 2,
								FriendlyName = "Saija Gloves",
								Tooltip = "",
								AvatarItemDesc = "50c9c6f8-2963-4ef3-95d5-e999a898269f,,,",
								ConsumableItemDesc = "",
								EquipmentPrefabName = "",
								EquipmentModificationGuid = "",
								Rarity = 50,
								IsQuery = false,
								Unique = false,
								Level = 50,
								Context = 100010
							}
						}
					},
					new StoreFronts.StoreItem
					{
						PurchasableItemId = 0,
						Type = 0,
						IsFeatured = false,
						Prices = new List<StoreFronts.ItemPrice>
						{
							new StoreFronts.ItemPrice
							{
								CurrencyType = 2,
								Price = 15000
							}
						},
						GiftDrops = new List<StoreFronts.GiftDrop>
						{
							new StoreFronts.GiftDrop
							{
								GiftDropId = 0,
								FriendlyName = "Bishop Hair",
								Tooltip = "",
								AvatarItemDesc = "b861e5f3-fc6d-43b3-9861-c1b45cb493a8,,,",
								ConsumableItemDesc = "",
								EquipmentPrefabName = "",
								EquipmentModificationGuid = "",
								Rarity = 50,
								IsQuery = false,
								Unique = false,
								Level = 50,
								Context = 100010
							}
						}
					},
					new StoreFronts.StoreItem
					{
						PurchasableItemId = 4,
						Type = 0,
						IsFeatured = false,
						Prices = new List<StoreFronts.ItemPrice>
						{
							new StoreFronts.ItemPrice
							{
								CurrencyType = 2,
								Price = 20000
							}
						},
						GiftDrops = new List<StoreFronts.GiftDrop>
						{
							new StoreFronts.GiftDrop
							{
								GiftDropId = 4,
								FriendlyName = "Bishop Shirt",
								Tooltip = "",
								AvatarItemDesc = "6930ce13-4be4-4ab9-9817-667bd261ffc3,,,",
								ConsumableItemDesc = "",
								EquipmentPrefabName = "",
								EquipmentModificationGuid = "",
								Rarity = 50,
								IsQuery = false,
								Unique = false,
								Level = 50,
								Context = 100010
							}
						}
					},
					new StoreFronts.StoreItem
					{
						PurchasableItemId = 5,
						Type = 0,
						IsFeatured = false,
						Prices = new List<StoreFronts.ItemPrice>
						{
							new StoreFronts.ItemPrice
							{
								CurrencyType = 2,
								Price = 20000
							}
						},
						GiftDrops = new List<StoreFronts.GiftDrop>
						{
							new StoreFronts.GiftDrop
							{
								GiftDropId = 5,
								FriendlyName = "Bishop Gloves",
								Tooltip = "",
								AvatarItemDesc = "abc25091-ed5f-4c72-9364-fffeef1bc239,,,",
								ConsumableItemDesc = "",
								EquipmentPrefabName = "",
								EquipmentModificationGuid = "",
								Rarity = 50,
								IsQuery = false,
								Unique = false,
								Level = 50,
								Context = 100010
							}
						}
					},
					new StoreFronts.StoreItem
					{
						PurchasableItemId = 0,
						Type = 0,
						IsFeatured = false,
						Prices = new List<StoreFronts.ItemPrice>
						{
							new StoreFronts.ItemPrice
							{
								CurrencyType = 2,
								Price = 30000
							}
						},
						GiftDrops = new List<StoreFronts.GiftDrop>
						{
							new StoreFronts.GiftDrop
							{
								GiftDropId = 0,
								FriendlyName = "Saija Helmet",
								Tooltip = "",
								AvatarItemDesc = "274cb9b2-2f59-47ea-9a8d-a5b656d148c6,,,",
								ConsumableItemDesc = "",
								EquipmentPrefabName = "",
								EquipmentModificationGuid = "",
								Rarity = 50,
								IsQuery = false,
								Unique = false,
								Level = 50,
								Context = 100010
							}
						}
					},
					new StoreFronts.StoreItem
					{
						PurchasableItemId = 1,
						Type = 0,
						IsFeatured = false,
						Prices = new List<StoreFronts.ItemPrice>
						{
							new StoreFronts.ItemPrice
							{
								CurrencyType = 2,
								Price = 35000
							}
						},
						GiftDrops = new List<StoreFronts.GiftDrop>
						{
							new StoreFronts.GiftDrop
							{
								GiftDropId = 1,
								FriendlyName = "Saija Shirt",
								Tooltip = "",
								AvatarItemDesc = "2c679f89-c76e-4cfb-94e9-448c8fd44d55,,,",
								ConsumableItemDesc = "",
								EquipmentPrefabName = "",
								EquipmentModificationGuid = "",
								Rarity = 50,
								IsQuery = false,
								Unique = false,
								Level = 50,
								Context = 100010
							}
						}
					},
					new StoreFronts.StoreItem
					{
						PurchasableItemId = 2,
						Type = 0,
						IsFeatured = false,
						Prices = new List<StoreFronts.ItemPrice>
						{
							new StoreFronts.ItemPrice
							{
								CurrencyType = 2,
								Price = 10000
							}
						},
						GiftDrops = new List<StoreFronts.GiftDrop>
						{
							new StoreFronts.GiftDrop
							{
								GiftDropId = 2,
								FriendlyName = "Saija Gloves",
								Tooltip = "",
								AvatarItemDesc = "50c9c6f8-2963-4ef3-95d5-e999a898269f,,,",
								ConsumableItemDesc = "",
								EquipmentPrefabName = "",
								EquipmentModificationGuid = "",
								Rarity = 50,
								IsQuery = false,
								Unique = false,
								Level = 50,
								Context = 100010
							}
						}
					},
					new StoreFronts.StoreItem
					{
						PurchasableItemId = 0,
						Type = 0,
						IsFeatured = false,
						Prices = new List<StoreFronts.ItemPrice>
						{
							new StoreFronts.ItemPrice
							{
								CurrencyType = 2,
								Price = 15000
							}
						},
						GiftDrops = new List<StoreFronts.GiftDrop>
						{
							new StoreFronts.GiftDrop
							{
								GiftDropId = 0,
								FriendlyName = "Bishop Hair",
								Tooltip = "",
								AvatarItemDesc = "b861e5f3-fc6d-43b3-9861-c1b45cb493a8,,,",
								ConsumableItemDesc = "",
								EquipmentPrefabName = "",
								EquipmentModificationGuid = "",
								Rarity = 50,
								IsQuery = false,
								Unique = false,
								Level = 50,
								Context = 100010
							}
						}
					},
					new StoreFronts.StoreItem
					{
						PurchasableItemId = 4,
						Type = 0,
						IsFeatured = false,
						Prices = new List<StoreFronts.ItemPrice>
						{
							new StoreFronts.ItemPrice
							{
								CurrencyType = 2,
								Price = 20000
							}
						},
						GiftDrops = new List<StoreFronts.GiftDrop>
						{
							new StoreFronts.GiftDrop
							{
								GiftDropId = 4,
								FriendlyName = "Bishop Shirt",
								Tooltip = "",
								AvatarItemDesc = "6930ce13-4be4-4ab9-9817-667bd261ffc3,,,",
								ConsumableItemDesc = "",
								EquipmentPrefabName = "",
								EquipmentModificationGuid = "",
								Rarity = 50,
								IsQuery = false,
								Unique = false,
								Level = 50,
								Context = 100010
							}
						}
					},
					new StoreFronts.StoreItem
					{
						PurchasableItemId = 5,
						Type = 0,
						IsFeatured = false,
						Prices = new List<StoreFronts.ItemPrice>
						{
							new StoreFronts.ItemPrice
							{
								CurrencyType = 2,
								Price = 20000
							}
						},
						GiftDrops = new List<StoreFronts.GiftDrop>
						{
							new StoreFronts.GiftDrop
							{
								GiftDropId = 5,
								FriendlyName = "Bishop Gloves",
								Tooltip = "",
								AvatarItemDesc = "abc25091-ed5f-4c72-9364-fffeef1bc239,,,",
								ConsumableItemDesc = "",
								EquipmentPrefabName = "",
								EquipmentModificationGuid = "",
								Rarity = 50,
								IsQuery = false,
								Unique = false,
								Level = 50,
								Context = 100010
							}
						}
					}
				};
			}
		}
		public class StoreItem
		{
			public int PurchasableItemId { get; set; }
			public int Type { get; set; }
			public bool IsFeatured { get; set; }
			public List<StoreFronts.ItemPrice> Prices { get; set; }
			public List<StoreFronts.GiftDrop> GiftDrops { get; set; }
		}
		public class GiftDrop
		{
			public int GiftDropId { get; set; }
			public string FriendlyName { get; set; }
			public string Tooltip { get; set; }
			public string AvatarItemDesc { get; set; }
			public string ConsumableItemDesc { get; set; }
			public string EquipmentPrefabName { get; set; }
			public string EquipmentModificationGuid { get; set; }
			public int Rarity { get; set; }
			public bool IsQuery { get; set; }
			public bool Unique { get; set; }
			public int Level { get; set; }
			public int Context { get; set; }
		}
		public class ItemPrice
		{
			public int CurrencyType { get; set; }
			public int Price { get; set; }
		}
	}
}
