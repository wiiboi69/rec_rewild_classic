using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace api
{
    public class CommunityBoard
    {
        public FeaturedPlayer FeaturedPlayer { get; set; }
        public FeaturedRoomGroup FeaturedRoomGroup { get; set; }
        public CurrentAnnouncement CurrentAnnouncement { get; set; }
        public object InstagramImages { get; set; }
        public object Videos { get; set; }

        public static ulong CachedPlayerID = ulong.Parse(System.IO.File.ReadAllText("SaveData\\Profile\\userid.txt"));

        public static string Community_Board()
        {
            var board = new CommunityBoard
            {
                FeaturedPlayer = new FeaturedPlayer
                {
                    Id = CachedPlayerID,
                    TitleOverride = "Featured Player",
                    UrlOverride = null
                },
                CurrentAnnouncement = new CurrentAnnouncement
                {
                    Message = "hello, and welcome to rec_rewild_classic",
                    MoreInfoUrl = "https://recrewild.oldrec.net/"
                },
                FeaturedRoomGroup = new FeaturedRoomGroup
                {
                    FeaturedRoomGroupId = 0,
                    Name = "Featured Rooms",
                    Rooms = new List<Room> {
                        new Room { RoomName = "DormRoom", RoomId = 1, ImageName = "" }
                    },
                    FeaturedRooms = new List<Room> {
                        new Room { RoomName = "DormRoom", RoomId = 1, ImageName = "" }
                    }
                }
            };

            return JsonConvert.SerializeObject(board, Formatting.Indented);
        }
    }

    public class FeaturedPlayer
    {
        public ulong Id { get; set; }
        public string TitleOverride { get; set; }
        public object UrlOverride { get; set; }
    }

    public class FeaturedRoomGroup
    {
        public int FeaturedRoomGroupId { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Room> FeaturedRooms { get; set; }
    }

    public class Room
    {
        public string RoomName { get; set; }
        public int RoomId { get; set; }
        public string ImageName { get; set; }
    }

    public class CurrentAnnouncement
    {
        public string Message { get; set; }
        public string MoreInfoUrl { get; set; }
    }
}
