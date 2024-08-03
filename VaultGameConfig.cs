using System;
using System.IO;

namespace vaultgamesesh
{ 
    // Token: 0x02000002 RID: 2
    internal sealed class c000004
    {
        public static string m000007()
        {
            string text = "SaveData\\" + "Rooms\\";
            bool flag = !Directory.Exists(text);
            bool flag2 = flag;
            if (flag2)
            {
                Directory.CreateDirectory(text);
            }
            return text;
        }
        // Token: 0x04000001 RID: 1
        public static ulong f000001 = 0UL;

        // Token: 0x04000002 RID: 2
        public static string Region = "us";

        // Token: 0x04000003 RID: 3
        public static string room_name_Region = "rec_rewild_classic_v0.0.1";

    }
}