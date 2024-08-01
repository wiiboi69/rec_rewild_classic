﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace server
{
    internal class APIServer_Base
    {
        public static ulong CachedPlayerID = ulong.Parse(File.ReadAllText("SaveData\\Profile\\userid.txt"));
        public static ulong CachedPlatformID = 10000;
        public static int CachedVersionMonth = 01;

        public static string PlayerEventsResponse = "{\"Created\":[],\"Responses\":[]}";
        public static string VersionCheckResponse2 = "{\"VersionStatus\":0}";
        public static string VersionCheckResponse = "{\"ValidVersion\":true}";
        public static string ModerationBlockDetails = "{\"ReportCategory\":0,\"Duration\":0,\"GameSessionId\":0,\"Message\":\"\"}";
        public static string ImagesV2Named = "[{\"FriendlyImageName\":\"DormRoomBucket\",\"ImageName\":\"DormRoomBucket\",\"StartTime\":\"2021-12-27T21:27:38.1880175-08:00\",\"EndTime\":\"2025-12-27T21:27:38.1880399-08:00\"}";
        public static string ChallengesV1GetCurrent = "{\"Success\":true,\"Message\":\"rec_rewild_classic\"}";
        public static string ChecklistV1Current = "[{\"Order\":0,\"Objective\":3000,\"Count\":3,\"CreditAmount\":100},{\"Order\":1,\"Objective\":3001,\"Count\":3,\"CreditAmount\":100},{\"Order\":2,\"Objective\":3002,\"Count\":3,\"CreditAmount\":100}]";

        public static string Banned = "{\"ReportCategory\":1,\"Duration\":10000000000000000,\"GameSessionId\":100,\"Message\":\"You have been banned. You are probably a little kid and are now whining at your VR headset. If you aren't a little kid, DM me to appeal.\"}";

    }
}