using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using rec_rewild_classic.api.Objective;

namespace server
{
    internal class APIServer_Base
    {
        public static ulong CachedPlayerID = ulong.Parse(File.ReadAllText("SaveData\\Profile\\userid.txt"));
        public static ulong CachedPlatformID = 10000;
        public static int CachedVersionMonth = 01;
        public static string FiltersResponse = JsonConvert.SerializeObject(new
        {
            PinnedFilters = new List<string>()
            {
                "recroomoriginal",
                "community",
                "Rewild_studio_room"
            },
            PopularFilters = new List<string>()
            {
                "rro",
                "Rewild_studio_room"
            },
            TrendingFilters = new List<string>()
            {
                "rro",
                "Rewild_studio_room"
            },
        });
        public static string PlayerEventsResponse = "{\"Created\":[],\"Responses\":[]}";
        public static string VersionCheckResponse2 = "{\"VersionStatus\":0}";
        public static string VersionCheckResponse = "{\"ValidVersion\":true}";
        public static string ModerationBlockDetails = "{\"ReportCategory\":0,\"Duration\":0,\"GameSessionId\":0,\"Message\":\"\"}";
        public static string ImagesV2Named = "[{\"FriendlyImageName\":\"DormRoomBucket\",\"ImageName\":\"DormRoomBucket\",\"StartTime\":\"2021-12-27T21:27:38.1880175-08:00\",\"EndTime\":\"9999-12-27T21:27:38.1880399-08:00\"}";
        public static string ChallengesV1GetCurrent = "{\"Success\":true,\"Message\":\"rec_rewild_classic\"}";
        public static string ChecklistV1Current = JsonConvert.SerializeObject(new List<ChecklistV1>
        {
            new ChecklistV1
            {
                Order = 0,
                Objective = 3000,
                Count = 3,
                CreditAmount = 100
            },
            new ChecklistV1
            {
                Order=1,
                Objective=3001,
                Count=3,
                CreditAmount=100
            },
            new ChecklistV1
            {
                Order=2,
                Objective=3002,
                Count=3,
                CreditAmount=100
            }
        });
    }
}
