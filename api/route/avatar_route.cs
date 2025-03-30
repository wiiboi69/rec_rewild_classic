using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace rec_rewild_classic.api.route
{
    class avatar_route
    {
        public static string avatar_route_data(string Url, string text, string s)
        {

            switch (Url)
            {
                case "avatar/v2":
                    s = File.ReadAllText("SaveData/avatar.txt");
                    break;
                case "avatar/v1/saved":
                case "avatar/v2/saved":
                case "avatar/v3/saved":
                    s = BracketResponse;
                    break;
                case "avatar/v2/set":
                    //for later 2018 builds compatibility
                    if (!(text.Contains("FaceFeatures")))
                    {
                        string postdatacache = text;
                        text = postdatacache.Remove(postdatacache.Length - 1, 1) + File.ReadAllText("SaveData/App/facefeaturesadd.txt");
                    }
                    File.WriteAllText("SaveData/avatar.txt", text);
                    break;
                case "avatar/v3/items":
                case "avatar/v4/items":
                    s = File.ReadAllText("SaveData/avataritems2.txt");
                    break;
                case "avatar/v2/gifts":
                    s = BracketResponse;
                    break;
                default:
                    break;
            }

            return s;
        }
        public static string BracketResponse = "[]";
    }
}
