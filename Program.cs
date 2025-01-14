using System;
using server;
using System.IO;
using ws;
using api;
using System.Net;
using System.Diagnostics;
using rewild_room_sesh;
using System.Collections.Generic;
using Newtonsoft.Json;
using Spectre.Console;
using System.Linq;
using System.Runtime.InteropServices;

namespace start
{
    class Program
    {
        static void Main()
        {
            Setup.setup();
            goto Tutorial;

        Tutorial:
            if (Setup.firsttime == true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Title = "rec_rewild_classic Intro";
                Console.WriteLine("Welcome to rec_rewild_classic " + appversion + "!");
                Console.WriteLine("Is this your first time using rec_rewild_classic?");
                Console.WriteLine("Yes or No (Y, N)");
                string readline22 = Console.ReadLine();
                if (readline22 == "y" || readline22 == "Y")
                {
                    Console.Clear();
                    Console.Title = "rec_rewild_classic Tutorial";
                    Console.WriteLine("In that case, welcome to rec_rewild_classic!");
                    Console.WriteLine("rec_rewild_classic is server software that emulates the old servers of previous RecRoom versions.");
                    Console.WriteLine("To use rec_rewild_classic, you'll need to have builds aswell!");
                    Console.WriteLine("To download builds, either go to the builds channel or use the links below: (these links are also available from the #builds channel)" + Environment.NewLine);
                    Console.WriteLine(new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Update/builds.txt"));
                    Console.WriteLine("Download a build and press any key to continue:");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Now that you have a build, what you're going to do is as follows:" + Environment.NewLine);
                    Console.WriteLine("1. Unzip the build");
                    Console.WriteLine("2. Start the server by pressing 5 on the main menu and selecting your version as follows");
                    Console.WriteLine("3. Run Recroom_Release.exe from the folder of the build you downloaded." + Environment.NewLine);
                    Console.WriteLine("And that's it! Press any key to go to the main menu, where you will be able to start the server:");
                    Console.ReadKey();
                    Console.Clear();
                    goto Start;
                }

                else
                {
                    Console.Clear();
                    goto Start;
                }
            }
            else
            {
                goto Start;
            }

        Start:
            Console.Title = "rec_rewild_classic Startup Menu";
            Console.WriteLine("rec_rewild_classic - A fork of OpenRec for Rec Room 2016 to 2018. (Version: " + appversion + ")");
            Console.WriteLine("Download source code here: https://github.com/wiiboi69/Rec_rewild_classic");

           // Console.WriteLine("Discord: https://discord.gg/daC8QUhnFP" + Environment.NewLine);
            if (!(new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Download/version.txt").Contains(appversion)))
            {
                Console.WriteLine("This version of rec_rewild_classic is outdated. We recommend you install the latest version, rec_rewild_classic " + new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Download/version.txt"));
            }            
            //Console.WriteLine("//Custom Room Downloader has been moved to the settings tab!" + Environment.NewLine);
            //Console.WriteLine("(1) What's New" + Environment.NewLine +"(2) Change Settings" + Environment.NewLine + "(3) Modify Profile" + Environment.NewLine + "(4) Build Download Links" + Environment.NewLine + "(5) Start Server");

            string readline = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .EnableSearch()
                    .Title("")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
                    .AddChoices(new[] {
                        "What's New",
                        "Change Settings",
                        "Modify Profile",
                        "Build Download Links",
                        "Start Server",
                    }));

            if (readline == "What's New")
            {
                Console.Title = "rec_rewild_classic Changelog";
                Console.Clear();
                var panel = new Panel(new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Download/changelog.txt"));
                panel.Header = new PanelHeader("Changelog");
                panel.Border = BoxBorder.Rounded;
                AnsiConsole.Write(panel);
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
                Console.Clear();
                goto Start;
            }
            if (readline == "Change Settings")
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
                            "Private Rooms: " + File.ReadAllText("SaveData/App/privaterooms.txt"),
                            "Custom Room Downloader",
                            "Reset SaveData",
                            "Go Back",
                        }));
                if (readline4.StartsWith("Private Rooms"))
                {
                    if (File.ReadAllText("SaveData/App/privaterooms.txt") == "Disabled")
                    {
                        File.WriteAllText("SaveData/App/privaterooms.txt", "Enabled");
                    }
                    else
                    {
                        File.WriteAllText("SaveData/App/privaterooms.txt", "Disabled");
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
                    Directory.Delete("SaveData", true);
                    Console.WriteLine("Success!");
                    Setup.setup();
                    goto Settings;
                }
                else if (readline4 == "Go Back")
                {
                    Console.Clear();
                    goto Start;
                }
            }
            if (readline == "Modify Profile")
            {
                Console.Clear();
                goto Profile;

            Profile:
                Console.Title = "rec_rewild_classic Profile Menu";
                string readline3 = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .EnableSearch()
                        .Title("")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
                        .AddChoices(new[] {
                            "Change Username:    " + File.ReadAllText("SaveData/Profile/username.txt"),
                            "Change Display Name: " + File.ReadAllText("SaveData/Profile/displayName.txt"),
                            "Change User ID:      " + File.ReadAllText("SaveData/Profile/userid.txt"),
                            "Change Profile Image",
                            "Change Level:       " + File.ReadAllText("SaveData/Profile/level.txt"),
                            "Change Bio:         " + File.ReadAllText("SaveData/Profile/bio.txt"),
                            "Profile Downloader",
                            "Go Back",
                        }));

                if (readline3.StartsWith("Change Username"))
                {
                    Console.WriteLine("Current Username: " + File.ReadAllText("SaveData/Profile/username.txt"));
                    Console.WriteLine("New Username: ");
                    string newusername = Console.ReadLine();
                    File.WriteAllText("SaveData/Profile/username.txt", newusername);
                    Console.Clear();
                    Console.WriteLine("Success!");
                    goto Profile;
                }
                else if (readline3.StartsWith("Change Display Name"))
                {
                    Console.WriteLine("Current displayName: " + File.ReadAllText("SaveData/Profile/displayName.txt"));
                    Console.WriteLine("New displayName: ");
                    string newlevel = Console.ReadLine();
                    File.WriteAllText("SaveData/Profile/displayName.txt", newlevel);
                    Console.Clear();
                    Console.WriteLine("Success!");
                    goto Profile;
                }
                else if (readline3.StartsWith("Change User ID"))
                {

                    Console.WriteLine("Current userid: " + File.ReadAllText("SaveData/Profile/userid.txt"));
                    Console.WriteLine("New userid: ");
                    string newlevel = Console.ReadLine();
                    int temp = 0;
                    if (int.TryParse(newlevel, out temp))
                    {
                        File.WriteAllText("SaveData/Profile/userid.txt", temp.ToString());
                        Console.Clear();
                        Console.WriteLine("Success!");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("failed to set playerid!");
                    }
                    goto Profile;
                }
                else if (readline3.StartsWith("Change Level"))
                {

                    Console.WriteLine("Current Level: " + File.ReadAllText("SaveData/Profile/Level.txt"));
                    Console.WriteLine("New Level: ");
                    string newlevel = Console.ReadLine();
                    int temp = 0;
                    if (int.TryParse(newlevel, out temp))
                    {
                        File.WriteAllText("SaveData/Profile/Level.txt", temp.ToString());
                        Console.Clear();
                        Console.WriteLine("Success!");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("failed to set Level!");
                    }
                    goto Profile;
                }
                else if (readline3.StartsWith("Change Bio"))
                {
                    Console.WriteLine("Current bio: " + File.ReadAllText("SaveData/Profile/bio.txt"));
                    Console.WriteLine("New bio: ");
                    string newlevel = Console.ReadLine();
                    File.WriteAllText("SaveData/Profile/bio.txt", newlevel);
                    Console.Clear();
                    Console.WriteLine("Success!");
                    goto Profile;
                }
                else if (readline3 == "Change Profile Image")
                {
                    Console.Clear();
                    Console.WriteLine("1) Upload Media Link" + Environment.NewLine + "2) Drag Image onto this window" + Environment.NewLine + "3) Download Rec.Net Profile Image" + Environment.NewLine + "4) Go Back");
                    string readline4 = Console.ReadLine();
                    if (readline4 == "1")
                    {
                        Console.WriteLine("Paste Media Link: ");
                        string medialink = Console.ReadLine();
                        try
                        {
                            File.WriteAllBytes("SaveData/profileimage.png", new WebClient().DownloadData(medialink));
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Media Link");
                            goto Profile;
                        }
                        Console.Clear();
                        Console.WriteLine("Success!");
                        goto Profile;
                    }
                    else if (readline4 == "2")
                    {
                        Console.WriteLine("Drag any image onto this window and press enter: ");
                        string imagedir = ShowDialog();
                        try
                        {
                            byte[] imagefile = File.ReadAllBytes(imagedir);

                            File.WriteAllBytes(maindir + "/SaveData/profileimage.png", imagefile);

                        }
                        catch (Exception ex4)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Image");
                            Console.WriteLine(ex4);
                            Console.WriteLine("image file path: " + imagedir);
                            Directory.SetCurrentDirectory(maindir);
                            goto Profile;
                        }
                        Console.Clear();
                        Console.WriteLine("Success!");
                        Directory.SetCurrentDirectory(maindir);
                        goto Profile;
                    }
                    else if (readline4 == "3")
                    {
                        Console.WriteLine("Type a RecRoom @ username and press enter: ");
                        string username = Console.ReadLine();
                        if (username.StartsWith("@"))
                        {
                            username = username.Remove(0, 1);
                        }
                        try
                        {
                            string data = "";
                            try
                            {
                                data = new WebClient().DownloadString("https://accounts.rec.net/account/search?name=" + username);
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("Failed to download profile...");
                                goto Profile;
                            }
                        
                            List<ProfieStealer.Root> profile = JsonConvert.DeserializeObject<List<ProfieStealer.Root>>(data);
                            byte[] profileimage = new WebClient().DownloadData("https://img.rec.net/" + profile[0].profileImage + "?cropSquare=true&width=192&height=192");
                            File.WriteAllBytes("SaveData/profileimage.png", profileimage);
                            
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Unable to download image...");
                            goto Profile;
                        }
                        Console.Clear();
                        Console.WriteLine("Success!");
                        goto Profile;
                    }
                    else if (readline4 == "4")
                    {
                        Console.Clear();
                        goto Profile;
                    }
                }
                else if (readline3 == "Profile Downloader")
                {
                    download_profile:
                    Console.Title = "rec_rewild_classic Profile Downloader";
                    Console.Clear();
                    Console.WriteLine("Profile Downloader: This tool takes the username and profile image of any username you type in and imports it to rec_rewild_classic.");
                    Console.WriteLine("Please type the username of the profile you would like: ");
                    string readusername = Console.ReadLine();
                    string data2 = "";
                    try
                    {
                        data2 = new WebClient().DownloadString("https://apim.rec.net/accounts/account/search?name=" + readusername + "&take=5");
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Failed to download profile...");
                        goto Profile;
                    }

                    if (!ProfieStealer.Profilefind(data2, take_int: 12))
                    {
                        goto download_profile;
                    }

                    Console.Clear();
                    goto Profile;
                }
                else if (readline3 == "Go Back")
                {
                    Console.Clear();
                    goto Start;
                }
            }
            if (readline == "Build Download Links")
            {
                Console.Title = "rec_rewild_classic Build Downloads";
                Console.Clear();
                Console.WriteLine("To download builds, either go to the builds channel or use the links below: (these links are also available from the #builds channel)" + Environment.NewLine);
                Console.WriteLine(new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/rec_rewild_classic/main/Update/builds.txt"));
                Console.WriteLine("Download a build and press any key to continue:");
                Console.ReadKey();
                Console.Clear();
                goto Start;
            }
            if (readline == "Start Server")
            {
                Console.Title = "rec_rewild_classic Version Select";
                string readline2 = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .EnableSearch()
                        .Title("Please select the version of RecRoom the server should host")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
                        .AddChoices(new[] {
                            "2016", "2017",
                        })
                        .AddChoiceGroup("2018", new[]
                        {
                            "May", "July", "September"
                        })
                        .AddChoices(new[] {
                            "back",
                        }));
                if (readline2 == "2016")
                {
                    Console.Title = "rec_rewild_classic December 25th, 2016";
                    version = "2016";
                    Console.Clear();
                    Console.WriteLine("Version Selected: December 25th, 2016.");
                    new APIServer2016();
                    new WebSocket();
                }
                else if (readline2 == "2017")
                {
                    Console.Title = "rec_rewild_classic October 19th 2017";
                    version = "2017";
                    Console.Clear();
                    Console.WriteLine("Version Selected: October 19th, 2017.");
                    new APIServer2017();
                    new WebSocket();
                }
                else if (readline2 == "May")
                {
                    Console.Title = "rec_rewild_classic May 30th 2018";
                    version = "2018";
                    start.Program.api_port = int.Parse(start.Program.version + "0");
                    Console.Clear();
                    Console.WriteLine("Version Selected: May 30th, 2018.");
                    new NameServer();
                    new ImageServer();
                    new APIServer2018();
                    new WebSocket();
                }
                else if (readline2 == "September")
                {
                    Console.Title = "rec_rewild_classic September 27th 2018";
                    version = "2018";
                    start.Program.api_port = int.Parse(start.Program.version + "0");
                    Console.Clear();
                    Console.WriteLine("Version Selected: September 27th, 2018.");
                    new NameServer();
                    new ImageServer();
                    new APIServer2018();
                    new WebSocketHTTP();
                    new Late2018WebSock();
                }
                else if (readline2 == "July")
                {
                    Console.Title = "rec_rewild_classic July 20th 2018";
                    version = "2018";
                    start.Program.api_port = int.Parse(start.Program.version + "0");
                    Console.Clear();
                    Console.WriteLine("Version Selected: July 20th, 2018");
                    new NameServer();
                    new ImageServer();
                    new APIServer2018();
                    new WebSocket();
                }
                else if (readline2 == "back")
                {
                    Console.Clear();
                    goto Start;
                }

                Console.WriteLine(msg);
            }
        }
        public static string msg = "//This is the server sending and recieving data from recroom.\n" + 
                                   "//Ignore this if you don't know what this means.zn" + 
                                   "//Please start up the build now.";
        public static string version = "";
        public static int api_port = 0;
        public static string appversion = "0.0.2";
        public static string maindir = Directory.GetCurrentDirectory();



        private static string ShowDialog()
        {
            var ofn = new OpenFileName();
            ofn.lStructSize = Marshal.SizeOf(ofn);
            // Define Filter for your extensions (Excel, ...)
            ofn.lpstrFilter = "image Files (*.png)\0*.png\0All Files (*.*)\0*.*\0";
            ofn.lpstrFile = new string(new char[256]);
            ofn.nMaxFile = ofn.lpstrFile.Length;
            ofn.lpstrFileTitle = new string(new char[64]);
            ofn.nMaxFileTitle = ofn.lpstrFileTitle.Length;
            ofn.lpstrTitle = "Open File Dialog...";
            if (GetOpenFileName(ref ofn))

                return ofn.lpstrFile;
            return string.Empty;
        }

        [DllImport("comdlg32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool GetOpenFileName(ref OpenFileName ofn);



        // From https://www.pinvoke.net/default.aspx/Structures/OPENFILENAME.html
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct OpenFileName
        {
            public int lStructSize;
            public IntPtr hwndOwner;
            public IntPtr hInstance;
            public string lpstrFilter;
            public string lpstrCustomFilter;
            public int nMaxCustFilter;
            public int nFilterIndex;
            public string lpstrFile;
            public int nMaxFile;
            public string lpstrFileTitle;
            public int nMaxFileTitle;
            public string lpstrInitialDir;
            public string lpstrTitle;
            public int Flags;
            public short nFileOffset;
            public short nFileExtension;
            public string lpstrDefExt;
            public IntPtr lCustData;
            public IntPtr lpfnHook;
            public string lpTemplateName;
            public IntPtr pvReserved;
            public int dwReserved;
            public int flagsEx;
        }


    }

}
