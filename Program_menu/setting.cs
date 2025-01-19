using api;
using Spectre.Console;
using System;
using System.IO;
using System.Net;

namespace start.Program_menu
{
    internal class setting_menu
    {

        public static void setting()
        {
            Console.Clear();
            goto Settings;

        Settings:
            Console.Title = "rec_rewild_classic Settings Menu";

            string readline4 = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .EnableSearch()
                    .Title("")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
                    .AddChoices(new[] {
                            "Private Rooms: " + File.ReadAllText("SaveData\\App\\privaterooms.txt"),
                            "Custom Room Downloader",
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
            else if (readline4 == "Custom Room Downloader")
            {
                Console.Title = "rec_rewild_classic Custom Room Downloader";
                Console.Clear();
                Console.WriteLine("Custom Room Downloader: This tool takes the room data of any room you type in and imports it into ^CustomRoom in September 27th 2018.");
                Console.WriteLine("Please type in the name of the room you would like to download: (Case sensitive)");
                string roomname = Console.ReadLine();
                string text = "";
                try
                {
                    text = new WebClient().DownloadString("https://rooms.rec.net/rooms?name=" + roomname + "&include=297");
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Failed to download room...");
                    goto Settings;
                }
                CustomRooms.RoomDecode(text);
                Console.Clear();
                Console.WriteLine("Success!");
                goto Settings;
            }
            else if (readline4 == "Reset SaveData")
            {

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
}