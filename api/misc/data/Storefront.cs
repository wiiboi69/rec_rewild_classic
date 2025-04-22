using System;
using System.Collections.Generic;

namespace storefront2018
{
	public class StoreFronts
	{
        /*
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
			LevelUp_16,
			LevelUp_17,
			LevelUp_18,
			LevelUp_19,
			LevelUp_20,
			LevelUp_21,
			LevelUp_22,
			LevelUp_23,
			LevelUp_24,
			LevelUp_25,
			LevelUp_26,
			LevelUp_27,
			LevelUp_28,
			LevelUp_29,
			LevelUp_30,
			Event_RawData = 1000,
			SFVRCC_Promo,
			HelixxVR_Promo,
			Paintball_ClearCut = 2000,
			Paintball_Homestead,
			Paintball_Quarry,
			Paintball_River,
			Paintball_Dam,
			Discgolf_Propulsion = 3000,
			Discgolf_Lake,
			Discgolf_Mode_CoopCatch = 3500,
			Quest_Goblin_A = 4000,
			Quest_Goblin_B,
			Quest_Goblin_C,
			Quest_Goblin_S,
			Quest_Goblin_Consumable,
			Quest_Cauldron_A = 4010,
			Quest_Cauldron_B,
			Quest_Cauldron_C,
			Quest_Cauldron_S,
			Quest_Cauldron_Consumable,
			Quest_Pirate1_A = 4100,
			Quest_Pirate1_B,
			Quest_Pirate1_C,
			Quest_Pirate1_S,
			Quest_Pirate1_X,
			Quest_Pirate1_Consumable,
			Quest_SciFi_A = 4500,
			Quest_SciFi_B,
			Quest_SciFi_C,
			Quest_SciFi_S,
			Quest_scifi_Consumable,
			Charades = 5000,
			Soccer = 6000,
			Paddleball = 7000,
			Dodgeball = 8000,
			Lasertag = 9000,
			Store_LaserTag = 100000,
			Store_RecCenter = 100010,
			Consumable = 110000,
			Token = 110100,
			Punchcard_Challenge_Complete = 110200,
			All_Punchcard_Challenges_Complete
		}

		public enum GiftTypes
		{
			GiftDrop,
			SeasonTier,
			SeasonEliteUpgrade
		}

		public enum CurrencyTypes
		{
			Invalid,
			LaserTagTickets,
			RecCenterTokens,
			LostSkullsGold = 100,
            DraculaSilver,
            RecRoyale_Season1 = 200
		}

		public enum StoreFrontTypes
		{
            None,
            LaserTag,
            RecCenter,
            Watch,
            Quest_LostSkulls = 100,
            Quest_Dracula,
            RecRoyale = 200,
            Cafe = 300,
            Paintball = 400,
            Bowling = 500
        }

		public enum ItemRarity
		{
			None = -1,
			Common,
			Uncommon = 10,
			Rare = 20,
			Epic = 30,
			Legendary = 50
		}

		public class GiftDropStore
		{
			public StoreFrontTypes StorefrontType { get; set; }
			public DateTime NextUpdate { get; set; }
			public List<StoreItem> StoreItems { get; set; }
		}

		public static GiftDropStore dropStore = new GiftDropStore()
		{
			StorefrontType = StoreFrontTypes.RecCenter,
			NextUpdate = GetNextWeekday(DateTime.Now, DayOfWeek.Wednesday),
			StoreItems = new List<StoreItem>
			{
				new StoreItem
				{
					PurchasableItemId = 0,
					Type = 0,
					IsFeatured = false,
					Prices = new List<ItemPrice>
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
			}
		};
		public class StoreItem
		{
			public int PurchasableItemId { get; set; }
			public int Type { get; set; }
			public bool IsFeatured { get; set; }
			public List<ItemPrice> Prices { get; set; }
			public List<GiftDrop> GiftDrops { get; set; }
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
        */
	}
}
