using rec_rewild_classic.api;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace rec_rewild_classic.Program_menu
{
    internal class setting_menu
    {
        public class SettingItem
        {
            public string Name { get; set; }
            public string ItemUUID { get; set; }
            public Action OnSelect { get; set; }
        }

        private static List<SettingItem> menuItems = new List<SettingItem>();

        public static void setting()
        {
            Console.Clear();

            // Initialize menu items
            menuItems.Clear();
            AddSetting(
                "Private Rooms: " + (api.server.Server_Setting.Setting.Private_Room ? "Enabled" : "Disabled"),
                "uuid-001",
                TogglePrivateRooms);
            AddSetting(
                "Private Dorm: " + (api.server.Server_Setting.Setting.Private_Dorm ? "Enabled" : "Disabled"),
                "Private-Dorm",
                TogglePrivateDorm);

            AddSetting("CDN server", "uuid-002", OpenCDNSettings);
            AddSetting("Reset SaveData", "uuid-003", ResetSaveData);
            AddSetting("Go Back", "exit_menu", null);

        Settings:
            Console.Title = "rec_rewild_classic Settings Menu";

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .EnableSearch()
                    .Title("rec_rewild_classic Settings Menu")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
                    .AddChoices(menuItems.Select(s => s.Name)));

            if (selection == "Go Back")
            {
                Console.Clear();
                return; // Exit settings menu directly
            }

            // Execute corresponding action
            var selectedItem = menuItems.Find(s => s.Name == selection);
            selectedItem?.OnSelect.Invoke();
            goto Settings;
        }

        public static void AddSetting(string name, string item_uuid, Action On_Select)
        {
            if (!menuItems.Exists(s => s.ItemUUID == item_uuid))
            {
                menuItems.Add(new SettingItem
                {
                    Name = name,
                    ItemUUID = item_uuid,
                    OnSelect = On_Select
                });
            }
        }
        public static void EditSetting(string name, string item_uuid)
        {
            foreach (var item in menuItems)
            {
                if (item.ItemUUID == item_uuid)
                    item.Name = name;
            }
        }
        public static void RemoveSetting(string item_uuid)
        {
            menuItems.RemoveAll(s => s.ItemUUID == item_uuid);
        }

        private static void TogglePrivateRooms()
        {
            bool flag = !rec_rewild_classic.api.server.Server_Setting.Setting.Private_Room;
            string newState = flag ? "Enabled" : "Disabled";
            rec_rewild_classic.api.server.Server_Setting.Setting.Private_Room = flag;

            EditSetting("Private Rooms: " + newState, "uuid-001");

            Console.Clear();
            Console.WriteLine("Success!");
        }
        private static void TogglePrivateDorm()
        {
            bool flag = !rec_rewild_classic.api.server.Server_Setting.Setting.Private_Dorm;
            string newState = flag ? "Enabled" : "Disabled";
            rec_rewild_classic.api.server.Server_Setting.Setting.Private_Dorm = flag;

            EditSetting("Private Dorm: " + newState, "Private-Dorm");

            Console.Clear();
            Console.WriteLine("Success!");
        }

        private static void OpenCDNSettings()
        {
            cdn_setting_menu.cdn_setting();
        }

        private static void ResetSaveData()
        {
            Console.WriteLine("Are you sure about deleting your save data?");
            Console.WriteLine("Yes or No");

            string tmp_1 = Console.ReadLine();

            if (tmp_1.ToLower() != "y") return;

            File.Delete("SaveData\\avatar.txt");
            File.Delete("SaveData\\avataritems.txt");
            File.Delete("SaveData\\equipment.txt");
            File.Delete("SaveData\\consumables.txt");
            File.Delete("SaveData\\gameconfigs.txt");
            File.Delete("SaveData\\storefronts2.txt");
            File.Delete("SaveData\\Profile\\username.txt");
            File.Delete("SaveData\\Profile\\level.txt");
            File.Delete("SaveData\\Profile\\userid.txt");
            File.Delete("SaveData\\myrooms.txt");
            File.Delete("SaveData\\Profile\\settings.txt");
            File.Delete("SaveData\\App\\privaterooms.txt");
            File.Delete("SaveData\\Profile\\facefeaturesadd.txt");
            File.Delete("SaveData\\profileimage.png");
            File.Delete("SaveData\\App\\firsttime.txt");

            File.Delete("SaveData\\avataritems2.txt");

            File.Delete("SaveData\\Rooms\\Downloaded\\roomname.txt");
            File.Delete("SaveData\\Rooms\\Downloaded\\roomid.txt");
            File.Delete("SaveData\\Rooms\\Downloaded\\datablob.txt");
            File.Delete("SaveData\\Rooms\\Downloaded\\roomsceneid.txt");
            File.Delete("SaveData\\Rooms\\Downloaded\\imagename.txt");
            File.Delete("SaveData\\Rooms\\Downloaded\\cheercount.txt");
            File.Delete("SaveData\\Rooms\\Downloaded\\favcount.txt");
            File.Delete("SaveData\\Rooms\\Downloaded\\visitcount.txt");

            Console.WriteLine("Success!");
            Setup.setup();
        }
    }
}


/*
namespace start.Program_menu
{   
    internal class setting_menu
    {
        public static void setting()
        {
            Console.Clear();

        Settings:
            Console.Title = "rec_rewild_classic Settings Menu";

            string readline4 = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .EnableSearch()
                    .Title("rec_rewild_classic Settings Menu")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
                    .AddChoices(new[] {
                            "Private Rooms: " + File.ReadAllText("SaveData\\App\\privaterooms.txt"),
                            //"Custom Room Downloader",
                            "CDN server",
                            "Reset SaveData",
                            "Go Back",
                    }));
            if (readline4.StartsWith("Private Rooms"))
            {
                if (File.ReadAllText("SaveData\\App\\privaterooms.txt") == "Disabled")
                {
                    File.WriteAllText("SaveData\\App\\privaterooms.txt", "Enabled");
                }
                else
                {
                    File.WriteAllText("SaveData\\App\\privaterooms.txt", "Disabled");
                }
                Console.Clear();
                Console.WriteLine("Success!");
                goto Settings;
            }
            else if (readline4 == "CDN server")
            {
                cdn_setting_menu.cdn_setting();
                goto Settings;
            }
            else if (readline4 == "Reset SaveData")
            {
                Console.WriteLine("are you sure about deleting your save data?");
                Console.WriteLine("Yes or No");

                string tmp_1 = Console.ReadLine();

                if (tmp_1.ToLower() != "y")
                {
                    goto Settings;
                }

                File.Delete("SaveData\\avatar.txt");
                File.Delete("SaveData\\avataritems.txt");
                File.Delete("SaveData\\equipment.txt");
                File.Delete("SaveData\\consumables.txt");
                File.Delete("SaveData\\gameconfigs.txt");
                File.Delete("SaveData\\storefronts2.txt");
                File.Delete("SaveData\\Profile\\username.txt");
                File.Delete("SaveData\\Profile\\level.txt");
                File.Delete("SaveData\\Profile\\userid.txt");
                File.Delete("SaveData\\myrooms.txt");
                File.Delete("SaveData\\settings.txt");
                File.Delete("SaveData\\App\\privaterooms.txt");
                File.Delete("SaveData\\App\\facefeaturesadd.txt");
                File.Delete("SaveData\\profileimage.png");
                File.Delete("SaveData\\App\\firsttime.txt");

                File.Delete("SaveData\\avataritems2.txt");

                File.Delete("SaveData\\Rooms\\Downloaded\\roomname.txt");
                File.Delete("SaveData\\Rooms\\Downloaded\\roomid.txt");
                File.Delete("SaveData\\Rooms\\Downloaded\\datablob.txt");
                File.Delete("SaveData\\Rooms\\Downloaded\\roomsceneid.txt");
                File.Delete("SaveData\\Rooms\\Downloaded\\imagename.txt");
                File.Delete("SaveData\\Rooms\\Downloaded\\cheercount.txt");
                File.Delete("SaveData\\Rooms\\Downloaded\\favcount.txt");
                File.Delete("SaveData\\Rooms\\Downloaded\\visitcount.txt");
                Console.WriteLine("Success!");
                Setup.setup();
                goto Settings;
            }
            else if (readline4 == "Go Back")
            {
                Console.Clear();
                return;
            }
            goto Settings;
        }
    }
}*/