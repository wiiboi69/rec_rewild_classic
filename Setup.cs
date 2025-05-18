using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace rec_rewild_classic
{
	class Setup
	{
		public static bool firsttime = false;
        public static void setup()
		{
			//sets up all the important files so rec_rewild_classic doesnt crash
			Console.WriteLine("Setting up... (May take a minute to download everything.)");
            Directory.CreateDirectory("SaveData/App/");
            Directory.CreateDirectory("SaveData/Profile/");
            Directory.CreateDirectory("SaveData/Images/");
            Directory.CreateDirectory("SaveData/Rooms/");
            Directory.CreateDirectory("SaveData/Rooms/custom/");
            Directory.CreateDirectory("SaveData/Rooms/cdn/");
            Directory.CreateDirectory("SaveData/Images/items/");
            Directory.CreateDirectory("SaveData/video/");
            Directory.CreateDirectory("SaveData/Rooms/Downloaded/");
            Directory.CreateDirectory("SaveData/custom/");
            Directory.CreateDirectory("SaveData/custom/items/");
            Directory.CreateDirectory("SaveData/custom/avatar items/");
            Directory.CreateDirectory("SaveData/custom/skins/");

            if (!(File.Exists("SaveData/App/firsttime.txt")))
			{
				File.WriteAllText("SaveData/App/firsttime.txt", "this text file has no use other than to tell the program whether to bring up the intro or not.");
				firsttime = true;
			}
			if (!(File.Exists("SaveData/Profile/avatar.json")))
			{
				File.WriteAllText("SaveData/Profile/avatar.json", new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Download/avatar.txt"));
                try
                {
                    File.Move("SaveData/avatar.txt", "SaveData/Profile/avatar.json", true);
                }
                catch
                {

                }
            }
			else if (File.ReadAllText("SaveData/Profile/avatar.json") == "")
            {
				File.WriteAllText("SaveData/Profile/avatar.json", new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Download/avatar.txt"));
                try
                {
                    File.Move("SaveData/avatar.txt", "SaveData/Profile/avatar.json", true);
                }
                catch
                {

                }
            }
			if (!(File.Exists("SaveData/avataritems.txt")))
			{
				File.WriteAllText("SaveData/avataritems.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Download/avataritems.txt"));
			}
			if (!(File.Exists("SaveData/avataritems2.txt")))
			{
				File.WriteAllText("SaveData/avataritems2.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Download/avataritems2.txt"));
			}
			if (!(File.Exists("SaveData/equipment.txt")))
			{
				File.WriteAllText("SaveData/equipment.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Download/equipment.txt"));
			}
			if (!(File.Exists("SaveData/consumables.txt")))
			{
				File.WriteAllText("SaveData/consumables.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Download/consumables.txt"));
			}
			if (!(File.Exists("SaveData/gameconfigs.txt")))
			{
				File.WriteAllText("SaveData/gameconfigs.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Download/gameconfigs.txt"));
			}
			if (!(File.Exists("SaveData/storefronts2.txt")))
			{
				File.WriteAllText("SaveData/storefronts2.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Download/storefront2.txt"));
			}
			if (!(File.Exists("SaveData/baserooms.txt")))
			{
				File.WriteAllText("SaveData/baserooms.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Download/baserooms.txt"));
			}
			if (!(File.Exists("SaveData/Profile/username.txt")))
			{
				File.WriteAllText("SaveData/Profile/username.txt", "rec_rewild_classic User#" + new Random().Next(0, 1000000));
			}
            if (!(File.Exists("SaveData/Profile/displayName.txt")))
            {
                File.WriteAllText("SaveData/Profile/displayName.txt", File.ReadAllText("SaveData/Profile/username.txt"));
            }
            if (!(File.Exists("SaveData/Profile/bio.txt")))
            {
				File.WriteAllText("SaveData/Profile/bio.txt", "Default bio");
            }
            if (!(File.Exists("SaveData/Profile/level.txt")))
			{
				File.WriteAllText("SaveData/Profile/level.txt", "30");
			}
            if (!(File.Exists("SaveData/Profile/xp.txt")))
            {
                File.WriteAllText("SaveData/Profile/xp.txt", "0");
            }
            if (!(File.Exists("SaveData/Profile/userid.txt")))
			{
				File.WriteAllText("SaveData/Profile/userid.txt", "10000000");
			}
			if (!(File.Exists("SaveData/Profile/settings.json")))
			{
				File.WriteAllText("SaveData/Profile/settings.json", Newtonsoft.Json.JsonConvert.SerializeObject(api.Settings.CreateDefaultSettings()));
                try
                {
                    File.Move("SaveData/settings.txt", "SaveData/Profile/settings.json", true);
                }
                catch
                {

                }
			}
			if (!(File.Exists("SaveData/profileimage.png")))
			{
				File.WriteAllBytes("SaveData/profileimage.png", new WebClient().DownloadData("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Download/profileimage.png"));
			}
			if (!(File.Exists("SaveData/Profile/facefeaturesadd.txt")))
			{
				File.WriteAllText("SaveData/Profile/facefeaturesadd.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Download/facefeaturesadd.txt"));
                try
                {
                    File.Move("SaveData/App/facefeaturesadd.txt", "SaveData/Profile/facefeaturesadd.txt", true);
                }
                catch
                {

                }
            }
            if (!File.Exists(api.server.Server_Setting.SettingsPath))
            {
                api.server.Server_Setting.load_setting();
                api.server.Server_Setting.Update_server_setting();
            }
            /*
            if (!(File.Exists("SaveData/App/privaterooms.txt")))
			{
				File.WriteAllText("SaveData/App/privaterooms.txt", "Disabled");
			}
            if (!(File.Exists("SaveData/App/show_rec_rewild_classic_info.txt")))
            {
                File.WriteAllText("SaveData/App/show_rec_rewild_classic_info.txt", "Enabled");
            }
            */
            /*
            goto tryagain;

            tryagain:
                if (!File.Exists("SaveData/Rooms/Downloaded/roomname.txt"))
                {
                    try
                    {
                        api.CustomRooms.RoomGet("gogo9");
                    }
                    catch
                    {
                        goto tryagain;
                    }

                }*/

            Console.WriteLine("Done!");
			Console.Clear();
		}
	}
}
