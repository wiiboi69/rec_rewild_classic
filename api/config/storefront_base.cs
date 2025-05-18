using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace rec_rewild_classic.api.config
{
    public class storefront_base
    {
        public static string Get_storefront_data(CurrencyTypes currency)
        {
            object obj = "";
            switch (currency)
            {
                case CurrencyTypes.LaserTagTickets:
                    obj = storefronts.Lasertag_storefront.Get_Storefront();
                    break;
                case CurrencyTypes.Invalid:
                case CurrencyTypes.RecCenterTokens:
                case CurrencyTypes.LostSkullsGold:
                case CurrencyTypes.DraculaSilver:
                case CurrencyTypes.RecRoyale_Season1:
                default:
                    return "[]";
            }
            return JsonConvert.SerializeObject(obj);
        }
        /*
         LaserTag 1000 - 1500
         RecCenter 1501 - 2000
         Quest_LostSkulls 2001 - 2500
         Quest_Dracula 2501 - 3000
         RecRoyale 3001 - 4000 // there is no storefront but there is a level system
         Cafe / Bowling 4001 - 4500
         Paintball 4501 - 5000
         Watch 8001 - 12000
        */
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
        public class storefront_data_base
        {
            public StoreFrontTypes StorefrontType;
            public DateTime NextUpdate;
            public List<StoreItem> StoreItems;
        }
        public class ItemPrice
        {
            public CurrencyTypes CurrencyType;
            public int Price;
        }
        public class StoreItem
        {
            public int PurchasableItemId;
            [JsonProperty("Type")]
            public GiftTypes Gift_Type;
            public bool IsFeatured;
            public List<ItemPrice> Prices;
            public List<GiftDrop> GiftDrops;
        }
        public class GiftDrop
        {
            public int GiftDropId;
            public string FriendlyName;
            public string Tooltip;
            public string AvatarItemDesc = null;
            public string ConsumableItemDesc = null;
            public string EquipmentPrefabName = null;
            public string EquipmentModificationGuid = "";
            public ItemRarity Rarity;
            public bool IsQuery;
            public bool Unique;
            public int Level;
            public GiftContext Context;
        }
        public static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            int num = (day - start.DayOfWeek + 7) % 7;
            return start.AddDays(num);
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
    }
}
