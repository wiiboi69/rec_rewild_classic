using System;
using System.IO;

namespace rewild_room_sesh
{ 
    internal sealed class room_util
    {
        public static string check_room_dir()
        {
            if (!Directory.Exists(text))
            {
                Directory.CreateDirectory(text);
            }
            return text;
        }

        public static string text = "SaveData\\Rooms\\custom\\";

        public static string Region = "us";

        public static string room_name_Region = "rec_rewild_classic_v0.0.1";
    }
}