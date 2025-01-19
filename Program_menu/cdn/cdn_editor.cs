using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace start.Program_menu
{
    class cdn_editor
    {
        public static bool cdn_list(int skip_int = 0, int take_int = 0)
        {
            if (!File.Exists("SaveData\\app\\server_cdn.json"))
                File.WriteAllText("SaveData\\app\\server_cdn.json", "[]");
            string temp_str = File.ReadAllText("SaveData\\app\\server_cdn.json");
            List<Root> profile = JsonConvert.DeserializeObject<List<Root>>(temp_str);
            if (take_int == 0)
            {
                take_int = profile.Count;
            }
            take_int = profile.Count;

            string input = "";
            int skip = 0;
            int take = 9;
            string data_1 = "";
            string data_2 = "";
            int skippage = 0;
            int maxpage = (int)Math.Floor((float)take_int / 10f);
        Refreshpage:
            Console.Clear();
        Refreshpage_2:
            Console.WriteLine($"┌──────────────────────────┤ cdn server ├──────────────────────────┐");

            skippage = (int)Math.Floor((float)(take + 1) / 10f);
            if (take > take_int)
                take = take_int;
            string temp = "";
            string temp2 = "";
            for (int i = skip; i < take; i++)
            {
                temp = "";
                temp2 = "";

                Root root = profile[i];
                temp = $"│ [{i}]  {root.base_url}  {root.cdn_type.ToString()}";
                for (int j = $"│ [{i}]  {root.base_url}  {root.cdn_type.ToString()}".Length; j < 67; j++)
                {
                    temp2 = temp2 + " ";
                }
                temp = temp + temp2 + "│";

                Console.WriteLine(temp);

            }
            if (skippage > 1)
            {
                data_1 = "│ Prev ├";
            }
            else
            {
                data_1 = "├───────";
            }

            if (skippage < maxpage)
            {
                data_2 = "┤ Next │";
            }
            else
            {
                data_2 = "───────┤";
            }
            Console.WriteLine($"{data_1}──────────────────────┤ Exit ├──────────────────────{data_2}");
            Console.WriteLine($"└─────────────────────────────┘ Page {skippage} / {maxpage}");
            while (true)
            {
                input = Console.ReadLine();
                if (input == "E")
                {
                    return false;
                }
                else if (input == "P")
                {
                    if (skippage > 1)
                    {
                        skip -= 10;
                        take -= 10;
                        goto Refreshpage;
                    }

                }
                else if (input == "N")
                {
                    if (skippage < maxpage)
                    {
                        skip += 10;
                        take += 10;
                        goto Refreshpage;
                    }
                }
                else
                {
                    if (int.TryParse(input, out int value))
                    {
                        if (value >= 0 || value < take_int)
                        {
                            //ProfileSteal(data, value);
                            return true;
                        }
                        else
                        {
                            goto error;
                        }
                    }
                    else
                    {
                        goto error;
                    }
                }
            }

        error:
            Console.Clear();
            Console.WriteLine($"{input} was not a valued int or out of range");
            goto Refreshpage_2;
        }
        [Flags]
        public enum server_url
        {
            None = 0,
            data = 1,
            room = 2,
            image = 4,
            all = room | image | data 
        }


        public class Root
        {
            public bool built_in;
            public server_url cdn_type { get; set; }
            public string base_url { get; set; }
            public string? data_url { get; set; }
            public string? image_url { get; set; }
            public string? room_url { get; set; }
        }
    }
}