using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace api
{

    public class Charades
    {
        public static string icebreaker()
        {
            List<word> value = new List<word>();
            return JsonConvert.SerializeObject(value);
        }
        public static string words()
        {
            List<word> value = new List<word>
            {
                new word
                {
                    EN_US = "talking ben",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "lemon",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "grape",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "roblox",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "tree",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "cloud",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "iphone",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "your house",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "spaghetti",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "lean",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "bitcoin",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "nft",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "grass",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "recroom2016",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "joker",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "fortnite",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "woman",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "spiderman",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "vr",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "among us",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "coach",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "coach with a gun",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "funny fish",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "skinwalker",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "christmas tree",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "ur mom",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "stick of ram",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "big mac",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "ninetndo switch",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "crescendo",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "boxing",
                    Difficulty = 0
                },
                new word
                {
                    EN_US = "angry birds",
                    Difficulty = 0
                }
            };
            return JsonConvert.SerializeObject(value);
        }

        public class word
        {
            public string EN_US { get; set; }
            public int Difficulty { get; set; }
        }
    }
}
