using api;
using Newtonsoft.Json;
using rec_rewild_classic.Program_menu;
using Spectre.Console;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace start.Program_menu
{
    internal static class profile_menu
    {
        public static void player_profile()
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
                            "Change Username:    " + File.ReadAllText("SaveData\\Profile\\username.txt"),
                            "Change Display Name: " + File.ReadAllText("SaveData\\Profile\\displayName.txt"),
                            "Change User ID:      " + File.ReadAllText("SaveData\\Profile\\userid.txt"),
                            "Change Profile Image",
                            "Change Level:       " + File.ReadAllText("SaveData\\Profile\\level.txt"),
                            "Change Bio:         " + File.ReadAllText("SaveData\\Profile\\bio.txt"),
                            "Profile Downloader",
                            "Go Back",
                    }));

            if (readline3.StartsWith("Change Username"))
            {
                Console.WriteLine("Current Username: " + File.ReadAllText("SaveData\\Profile\\username.txt"));
                Console.WriteLine("New Username: ");
                string newusername = Console.ReadLine();
                File.WriteAllText("SaveData\\Profile\\username.txt", newusername);
                Console.Clear();
                Console.WriteLine("Success!");
                goto Profile;
            }
            else if (readline3.StartsWith("Change Display Name"))
            {
                Console.WriteLine("Current displayName: " + File.ReadAllText("SaveData\\Profile\\displayName.txt"));
                Console.WriteLine("New displayName: ");
                string newlevel = Console.ReadLine();
                File.WriteAllText("SaveData\\Profile\\displayName.txt", newlevel);
                Console.Clear();
                Console.WriteLine("Success!");
                goto Profile;
            }
            else if (readline3.StartsWith("Change User ID"))
            {

                Console.WriteLine("Current userid: " + File.ReadAllText("SaveData\\Profile\\userid.txt"));
                Console.WriteLine("New userid: ");
                string newlevel = Console.ReadLine();
                int temp = 0;
                if (int.TryParse(newlevel, out temp))
                {
                    File.WriteAllText("SaveData\\Profile\\userid.txt", temp.ToString());
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

                Console.WriteLine("Current Level: " + File.ReadAllText("SaveData\\Profile\\Level.txt"));
                Console.WriteLine("New Level: ");
                string newlevel = Console.ReadLine();
                int temp = 0;
                if (int.TryParse(newlevel, out temp))
                {
                    File.WriteAllText("SaveData\\Profile\\Level.txt", temp.ToString());
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
                Console.WriteLine("Current bio: " + File.ReadAllText("SaveData\\Profile\\bio.txt"));
                Console.WriteLine("New bio: ");
                string newlevel = Console.ReadLine();
                File.WriteAllText("SaveData\\Profile\\bio.txt", newlevel);
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
                        File.WriteAllBytes("SaveData\\profileimage.png", new WebClient().DownloadData(medialink));
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
                    string imagedir = Program.ShowDialog();
                    try
                    {
                        byte[] imagefile = File.ReadAllBytes(imagedir);

                        File.WriteAllBytes(Program.maindir + "\\SaveData\\profileimage.png", imagefile);

                    }
                    catch (Exception ex4)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Image");
                        Console.WriteLine(ex4);
                        Console.WriteLine("image file path: " + imagedir);
                        Directory.SetCurrentDirectory(Program.maindir);
                        goto Profile;
                    }
                    Console.Clear();
                    Console.WriteLine("Success!");
                    Directory.SetCurrentDirectory(Program.maindir);
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
                            WebClient client = new WebClient();
                            client.UseDefaultCredentials = true;
                            client.Headers["Accept"] = "application/json, text/plain, */*";
                            client.Headers["Accept-Language"] = "en-US,en;q=0.5";
                            client.Headers["Accept-Encoding"] = "gzip, deflate, br, zstd";
                            client.Headers["User-Agent"] = "BestHTTP";
                            client.Headers["Origin"] = "https://rec.net";
                            client.Headers["Host"] = "apim.rec.net";
                            client.Headers["Referer"] = "https://rec.net/";

                            data = client.DownloadString("https://apim.rec.net/accounts/account/search?name=" + username);
                        }
                        catch (Exception ex)
                        {
                            Console.Clear();
                            Console.WriteLine("Failed to download profile...");
                            Console.WriteLine(ex);

                            goto Profile;
                        }

                        List<ProfieStealer.Root> profile = JsonConvert.DeserializeObject<List<ProfieStealer.Root>>(data);
                        byte[] profileimage = new WebClient().DownloadData("https://img.rec.net/" + profile[0].profileImage + "?cropSquare=true&width=192&height=192");
                        File.WriteAllBytes("SaveData\\profileimage.png", profileimage);

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
                    data2 = Rec_Net_Client.Get_String("https://apim.rec.net/accounts/account/search?name=" + readusername + "&take=5");
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("Failed to download profile...");
                    Console.WriteLine(ex);

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
                return;
            }
            goto Profile;
        }
    }
}