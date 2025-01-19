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
using start.Program_menu;

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
                setting_menu.setting();
            }
            if (readline == "Modify Profile")
            {
                profile_menu.player_profile();
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
                                   "//Ignore this if you don't know what this means.\n" + 
                                   "//Please start up the build now.";
        public static string version = "";
        public static int api_port = 0;
        public static string appversion = "0.0.1";
        public static string maindir = Directory.GetCurrentDirectory();

        public static string ShowDialog()
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
