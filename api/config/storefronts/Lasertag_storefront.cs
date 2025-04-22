using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static rec_rewild_classic.api.config.storefront_base;

namespace rec_rewild_classic.api.config.storefronts
{
    public class Lasertag_storefront
    {
        public static storefront_data_base Get_Storefront()
        {
            return new storefront_data_base
            {
                NextUpdate = GetNextWeekday(DateTime.Now, DayOfWeek.Sunday),
                StorefrontType = StoreFrontTypes.LaserTag,
                StoreItems = new List<StoreItem>
                {
                    new StoreItem
                    {
                        PurchasableItemId = 1000,
                        IsFeatured = false,
                        Gift_Type = GiftTypes.GiftDrop,
                        Prices = new List<ItemPrice>
                        {
                            new ItemPrice
                            {
                                CurrencyType = CurrencyTypes.LaserTagTickets,
                                Price = 1
                            },
                            new ItemPrice
                            {
                                CurrencyType = CurrencyTypes.LaserTagTickets,
                                Price = 1
                            },
                            new ItemPrice
                            {
                                CurrencyType = CurrencyTypes.LaserTagTickets,
                                Price = 1
                            },
                            new ItemPrice
                            {
                                CurrencyType = CurrencyTypes.LaserTagTickets,
                                Price = 1
                            },
                        },
                        GiftDrops = new List<GiftDrop>
                        {
                            new GiftDrop
                            {
                                GiftDropId = 1001,
                                FriendlyName = "Laser Tag Sensors (pink)",
                                Tooltip = "",
                                AvatarItemDesc = "24d94673-f394-42e6-a3c8-276f8b8aa722,,,",
                                Rarity = ItemRarity.None,
                                IsQuery = false,
                                Unique = true,
                                Level = 0,
                                Context = GiftContext.Store_LaserTag
                            },
                            new GiftDrop
                            {
                                GiftDropId = 1002,
                                FriendlyName = "Laser Tag Sensors (Blue)",
                                Tooltip = "",
                                AvatarItemDesc = "24d94673-f394-42e6-a3c8-276f8b8aa722,08b7c12d-3317-4d27-9b40-34737a709454,959ed05b-0215-4bbe-bb3d-64e4448d676b,",
                                Rarity = ItemRarity.None,
                                IsQuery = false,
                                Unique = true,
                                Level = 0,
                                Context = GiftContext.Store_LaserTag
                            },
                            new GiftDrop
                            {
                                GiftDropId = 1003,
                                FriendlyName = "Laser Tag Sensors (Orange)",
                                Tooltip = "",
                                AvatarItemDesc = "24d94673-f394-42e6-a3c8-276f8b8aa722,jkuw9EhCpEKn-2lKJXWd3Q,959ed05b-0215-4bbe-bb3d-64e4448d676b,",
                                Rarity = ItemRarity.None,
                                IsQuery = false,
                                Unique = true,
                                Level = 0,
                                Context = GiftContext.Store_LaserTag
                            },
                            new GiftDrop
                            {
                                GiftDropId = 1004,
                                FriendlyName = "Laser Tag Sensors (Teal)",
                                Tooltip = "",
                                AvatarItemDesc = "24d94673-f394-42e6-a3c8-276f8b8aa722,2Z_FxSPiyUODtlFZWF9DFQ,959ed05b-0215-4bbe-bb3d-64e4448d676b,",
                                Rarity = ItemRarity.None,
                                IsQuery = false,
                                Unique = true,
                                Level = 0,
                                Context = GiftContext.Store_LaserTag
                            }
                        }
                    }
                }
            };
        }
    }
}
