using api;
using Spectre.Console;
using System;
using System.IO;
using System.Net;

namespace start.Program_menu
{
    internal class cdn_setting_menu
    {

        public static void cdn_setting()
        {
            Console.Clear();
        Settings:
            Console.Title = "rec_rewild_classic cdn setting Menu";
            string[] strings = new[] {
                            "add a cdn room server url",
                            "add a cdn image server url",
                            "add a cdn data server url",
                            "add a cdn server url",
                            "list all of cdn server urls",
                            "Go Back",
                    };
            string readline4 = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .EnableSearch()
                    .Title("")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
                    .AddChoices(strings));

            if (readline4 == "list all of cdn server urls")
            {

                Console.Clear();
                Console.WriteLine("Success!");
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