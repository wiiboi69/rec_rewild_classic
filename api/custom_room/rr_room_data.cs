using server;
using System;
using System.Collections.Generic;
using static rewild_room_sesh.room_data_base;

namespace rewild_room_sesh
{
    public class rr_room_data
    {

        public static Dictionary<string, room> Base_cloneable_room = new Dictionary<string, room>
        {
            {
                "MakerRoom",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 24UL,
                        Name = "MakerRoom",
                        Description = "This room is a blank canvas. Make it into whatever you like!",
                        CreatorPlayerId = 1UL,
                        ImageName = string.Empty,
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 24UL,
                            RoomSceneLocationId = "a75f7547-79eb-47c6-8986-6767abcb4f92",
                            Name = "Home",
                            IsSandbox = true,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        }
                    }
                }
            },
            {
                "Park",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 25UL,
                        Name = "Park",
                        Description = "A sprawling park with amphitheater, play fields, and a cave.",
                        CreatorPlayerId = 782441001UL,
                        ImageName = string.Empty,
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 25UL,
                            RoomSceneLocationId = "0a864c86-5a71-4e18-8041-8124e4dc9d98",
                            Name = "Home",
                            IsSandbox = true,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        }
                    }
                }
            },
            {
                "Lounge",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 22UL,
                        Name = "Lounge",
                        Description = "A low-key lounge to chill with your friends. Great for private parties!",
                        CreatorPlayerId = 782441001UL,
                        ImageName = string.Empty,
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 22UL,
                            RoomSceneLocationId = "a067557f-ca32-43e6-b6e5-daaec60b4f5a",
                            Name = "Home",
                            IsSandbox = true,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "recroomoriginal",
                            Type = 2
                        }
                    }
                }
            },
            {
                "PerformanceHall",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 23UL,
                        Name = "PerformanceHall",
                        Description = "A theater for plays, music, comedy and other performances.",
                        CreatorPlayerId = 1UL,
                        ImageName = string.Empty,
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 23UL,
                            RoomSceneLocationId = "9932f88f-3929-43a0-a012-a40b5128e346",
                            Name = "Home",
                            IsSandbox = true,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        }
                    }
                }
            },
            {
                "Hangar",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 18UL,
                        Name = "Hangar",
                        Description = "Teams battle each other and waves of robots.",
                        CreatorPlayerId = 782441001UL,
                        ImageName = "ActivityLaserTag.png",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 18UL,
                            RoomSceneLocationId = "239e676c-f12f-489f-bf3a-d4c383d692c3",
                            Name = "Hangar",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        },
                        new Tags
                        {
                            Tag = "pvp",
                            Type = 0
                        }
                    }
                }
            }
        };

        public static Dictionary<string, room> main_room = new Dictionary<string, room>
        {
            {
                "rewild_studio_hub",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 30UL,
                        Name = "rewild_studio_hub",
                        Description = "A rewild studio hub room.",
                        ReleaseStatus = 1,
                        ReplicationId = "rewild_studio_hub",
                        CreatorPlayerId = APIServer_Base.CachedPlayerID,
                        ImageName = "DefaultRoomImage.jpg",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = false,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 30L,
                            RoomId = 30UL,
                            RoomSceneLocationId = "74c62a36-4362-468b-81ec-65c45bfe0e5f",
                            rewild_studio_data = new rewild_studio_subroom()
                            {
                                AssetBundleName = "rrs_hub_data",
                                DataSceneName = "rrs_hub"
                            },
							Name = "rrs_hub",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now,
                            ReplicationId = "",
                            SupportsJoinInProgress = true,
                            ReleaseStatus = 1,
                            UseAgeBasedMatchmaking = true,
                            UseLevelBasedMatchmaking = false,
                            UseRecRoyaleMatchmaking = false
                        }
                    },
                    CoOwners = new List<ulong>(),
                    InvitedCoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    InvitedHosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        }
                    }
                }
            },
            {
                "DormRoom",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 1UL,
                        Name = "DormRoom",
                        Description = "A private room.",
                        ReleaseStatus = 2,
                        ReplicationId = "DormRoom",
                        CreatorPlayerId = APIServer_Base.CachedPlayerID,
                        ImageName = "DefaultRoomImage.jpg",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 0UL,
							//rrs_hub_data","rrs_hub
							RoomSceneLocationId = "76d98498-60a1-430c-ab76-b54a29b7a163",
                            //RoomSceneLocationId = "rrs_hub_data-rrs_hub",
							Name = "dormroom2",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now,
                            ReplicationId = "your mom still gae",
                            SupportsJoinInProgress = true,
                            ReleaseStatus = 2,
                            UseAgeBasedMatchmaking = true,
                            UseLevelBasedMatchmaking = true,
                            UseRecRoyaleMatchmaking = false
                        }
                    },
                    CoOwners = new List<ulong>(),
                    InvitedCoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    InvitedHosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        }
                    }
                }
            },
            {
                "CrimsonTrophy",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 32UL,
                        Name = "CrimsonTrophy",
                        Description = "a Golden Trophy and Crimson Cauldron into one room",
                        ReleaseStatus = 2,
                        ReplicationId = "DormRoom",
                        CreatorPlayerId = APIServer_Base.CachedPlayerID,
                        ImageName = "DefaultRoomImage.jpg",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 32L,
                            RoomId = 32UL,
							RoomSceneLocationId = "83d06153-5164-43e6-b222-b6f949786131",
							Name = "home",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now,
                            ReplicationId = "",
                            SupportsJoinInProgress = true,
                            ReleaseStatus = 2,
                            UseAgeBasedMatchmaking = true,
                            UseLevelBasedMatchmaking = true,
                            UseRecRoyaleMatchmaking = false
                        }
                    },
                    CoOwners = new List<ulong>(),
                    InvitedCoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    InvitedHosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        }
                    }
                }
            },
            {
                "RecCenter",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 2UL,
                        Name = "RecCenter",
                        Description = "A social hub to meet and mingle with friends new and old.",
                        CreatorPlayerId = APIServer_Base.CachedPlayerID,
                        ImageName = "22eefa3219f046fd9e2090814650ede3",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 2UL,
							RoomSceneLocationId = "cbad71af-0831-44d8-b8ef-69edafa841f6",
							Name = "RecCenter",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 4,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>
                    {
                        126231667
                    },
                    Hosts = new List<ulong>
                    {
                        126231667
                    },
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        }
                    }
                }
            },
            {
                "3DCharades",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 3UL,
                        Name = "3DCharades",
                        Description = "Take turns drawing, acting, and guessing funny phrases with your friends!",
                        CreatorPlayerId = 782441001UL,
                        ImageName = "a446d5808ed14401a27f53e631c31b93.png",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 3L,
                            RoomId = 4UL,
                            RoomSceneLocationId = "4078dfed-24bb-4db7-863f-578ba48d726b",
                            Name = "charades",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        }
                    }
                }
            },
            {
                "DiscGolfLake",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 4UL,
                        Name = "DiscGolfLake",
                        Description = "Throw your disc into the goal. Sounds easy, right?",
                        CreatorPlayerId = 782441001UL,
                        ImageName = "52cf6c3271894ecd95fb0c9b2d2209a7",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 4UL,
                            RoomSceneLocationId = "f6f7256c-e438-4299-b99e-d20bef8cf7e0",
                            Name = "Lake",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 4,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        },
                        new Tags
                        {
                            Tag = "sport",
                            Type = 0
                        }
                    }
                }
            },
            {
                "DiscGolfPropulsion",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 5UL,
                        Name = "DiscGolfPropulsion",
                        Description = "Throw your disc through hazards and around wind machines on this challenging course!",
                        CreatorPlayerId = 782441001UL,
                        ImageName = "fc9a1acc47514b64a30d199d5ccdeca9",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 5UL,
                            RoomSceneLocationId = "d9378c9f-80bc-46fb-ad1e-1bed8a674f55",
                            Name = "Propulsion",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        },
                        new Tags
                        {
                            Tag = "sport",
                            Type = 0
                        }
                    }
                }
            },
            {
                "Dodgeball",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 6UL,
                        Name = "Dodgeball",
                        Description = "Throw dodgeballs to knock out your friends in this gym classic!",
                        CreatorPlayerId = 782441001UL,
                        ImageName = "6d5c494668784816bbc41d9b870e5003",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 6UL,
                            RoomSceneLocationId = "3d474b26-26f7-45e9-9a36-9b02847d5e6f",
                            Name = "dodgeball",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        },
                        new Tags
                        {
                            Tag = "sport",
                            Type = 0
                        }
                    }
                }
            },
            {
                "Paddleball",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 7UL,
                        Name = "Paddleball",
                        Description = "A simple rally game between two players in a plexiglass tube with a zero-g ball.",
                        CreatorPlayerId = 782441001UL,
                        ImageName = "ffdca6ed8bd94631ac15e3e894acb6c6",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 7UL,
                            RoomSceneLocationId = "d89f74fa-d51e-477a-a425-025a891dd499",
                            Name = "paddleball",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        },
                        new Tags
                        {
                            Tag = "sport",
                            Type = 0
                        }
                    }
                }
            },
            {
                "Paintball",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 8UL,
                        Name = "Paintball",
                        Description = "Red and Blue teams splat each other in capture the flag and team battle.",
                        CreatorPlayerId = 782441001UL,
                        ImageName = "93a53ced93a04f658795a87f4a4aab85",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = true,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 8UL,
                            RoomSceneLocationId = "e122fe98-e7db-49e8-a1b1-105424b6e1f0",
                            Name = "River",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        },
                        new subrooms
                        {
                            RoomSceneId = 2L,
                            RoomId = 9UL,
                            RoomSceneLocationId = "a785267d-c579-42ea-be43-fec1992d1ca7",
                            Name = "Homestead",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        },
                        new subrooms
                        {
                            RoomSceneId = 3L,
                            RoomId = 10UL,
                            RoomSceneLocationId = "ff4c6427-7079-4f59-b22a-69b089420827",
                            Name = "Quarry",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        },
                        new subrooms
                        {
                            RoomSceneId = 4L,
                            RoomId = 11UL,
                            RoomSceneLocationId = "380d18b5-de9c-49f3-80f7-f4a95c1de161",
                            Name = "Clearcut",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        },
                        new subrooms
                        {
                            RoomSceneId = 5L,
                            RoomId = 12UL,
                            RoomSceneLocationId = "58763055-2dfb-4814-80b8-16fac5c85709",
                            Name = "Spillway",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        },
                        new Tags
                        {
                            Tag = "pvp",
                            Type = 0
                        }
                    }
                }
            },
            {
                "GoldenTrophy",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 13UL,
                        Name = "GoldenTrophy",
                        Description = "The goblin king stole Coach's Golden Trophy. Team up and embark on an epic quest to recover it!",
                        CreatorPlayerId = 782441001UL,
                        ImageName = "GT.png",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 13UL,
                            RoomSceneLocationId = "91e16e35-f48f-4700-ab8a-a1b79e50e51b",
                            Name = "Home",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        },
                        new Tags
                        {
                            Tag = "quest",
                            Type = 0
                        }
                    }
                }
            },
            {
                "TheRiseofJumbotron",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 14UL,
                        Name = "TheRiseofJumbotron",
                        Description = "Robot invaders threaten the galaxy! Team up with your friends and bring the laser heat!",
                        CreatorPlayerId = 782441001UL,
                        ImageName = "51296f28105b48178708e389b6daf057",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 14UL,
                            RoomSceneLocationId = "acc06e66-c2d0-4361-b0cd-46246a4c455c",
                            Name = "Home",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        },
                        new Tags
                        {
                            Tag = "quest",
                            Type = 0
                        }
                    }
                }
            },
            {
                "CrimsonCauldron",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 15UL,
                        Name = "CrimsonCauldron",
                        Description = "Can your band of adventurers brave the enchanted wilds, and lift the curse of the crimson cauldron?",
                        CreatorPlayerId = 782441001UL,
                        ImageName = "3ab82779dff94d11920ebf38df249395",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 15UL,
                            RoomSceneLocationId = "949fa41f-4347-45c0-b7ac-489129174045",
                            Name = "Home",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        },
                        new Tags
                        {
                            Tag = "quest",
                            Type = 0
                        }
                    }
                }
            },
            {
                "IsleOfLostSkulls",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 16UL,
                        Name = "IsleOfLostSkulls",
                        Description = "Can your pirate crew get to the Isle, defeat its fearsome guardian, and escape with the gold?",
                        CreatorPlayerId = 782441001UL,
                        ImageName = "45ad53aa002646d0ab3eb509b9f260ef",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 16UL,
                            RoomSceneLocationId = "7e01cfe0-820a-406f-b1b3-0a5bf575235c",
                            Name = "Home",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        },
                        new Tags
                        {
                            Tag = "quest",
                            Type = 0
                        }
                    }
                }
            },
            {
                "Soccer",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 17UL,
                        Name = "Soccer",
                        Description = "Teams of three run around slamming themselves into an over-sized soccer ball. Goal!",
                        CreatorPlayerId = 782441001UL,
                        ImageName = "51c6f5ac5e6f4777b573e7e43f8a85ea",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 17UL,
                            RoomSceneLocationId = "6d5eea4b-f069-4ed0-9916-0e2f07df0d03",
                            Name = "Home",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        },
                        new Tags
                        {
                            Tag = "sport",
                            Type = 0
                        }
                    }
                }
            },
            {
                "LaserTag",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 18UL,
                        Name = "LaserTag",
                        Description = "Teams battle each other and waves of robots.",
                        CreatorPlayerId = 782441001UL,
                        ImageName = "c5a72193d6904811b2d0195a6deb3125",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 18UL,
                            RoomSceneLocationId = "239e676c-f12f-489f-bf3a-d4c383d692c3",
                            Name = "Hangar",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        },
                        new subrooms
                        {
                            RoomSceneId = 2L,
                            RoomId = 19UL,
                            RoomSceneLocationId = "9d6456ce-6264-48b4-808d-2d96b3d91038",
                            Name = "CyberJunkCity",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        },
                        new Tags
                        {
                            Tag = "pvp",
                            Type = 0
                        }
                    }
                }
            },
            {
                "RecRoyaleSquads",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 20UL,
                        Name = "RecRoyaleSquads",
                        Description = "Squads of three battle it out on Frontier Island. Last squad standing wins!",
                        CreatorPlayerId = APIServer_Base.CachedPlayerID,
                        ImageName = "69fc525056014e39a435c4d2fdf2b887",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 0L,
                            RoomId = 20UL,
                            RoomSceneLocationId = "253fa009-6e65-4c90-91a1-7137a56a267f",
                            Name = "Home",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        },
                        new Tags
                        {
                            Tag = "pvp",
                            Type = 0
                        }
                    }
                }
            },
            {
                "RecRoyaleSolos",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 21UL,
                        Name = "RecRoyaleSolos",
                        Description = "Battle it out on Frontier Island. Last person standing wins!",
                        CreatorPlayerId = APIServer_Base.CachedPlayerID,
                        ImageName = "f9e112bb67fb430d979e5ad6c2c116d4",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 0L,
                            RoomId = 21UL,
                            RoomSceneLocationId = "b010171f-4875-4e89-baba-61e878cd41e1",
                            Name = "Home",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        },
                        new Tags
                        {
                            Tag = "pvp",
                            Type = 0
                        }
                    }
                }
            },
            {
                "Lounge",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 22UL,
                        Name = "Lounge",
                        Description = "A low-key lounge to chill with your friends. Great for private parties!",
                        CreatorPlayerId = APIServer_Base.CachedPlayerID,
                        ImageName = "3e8c2458f1e542ab8aa275e4083ee47a",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 0L,
                            RoomId = 22UL,
                            RoomSceneLocationId = "a067557f-ca32-43e6-b6e5-daaec60b4f5a",
                            Name = "Home",
                            IsSandbox = true,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        }
                    }
                }
            },
            {
                "Park",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 25UL,
                        Name = "Park",
                        Description = "A sprawling park with amphitheater, play fields, and a cave.",
                        CreatorPlayerId = 782441001UL,
                        ImageName = "79ee7af2532247f397867e48daa9d264.png",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 0L,
                            RoomId = 25UL,
                            RoomSceneLocationId = "0a864c86-5a71-4e18-8041-8124e4dc9d98",
                            Name = "Home",
                            IsSandbox = true,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        }
                    }
                }
            },
            {
                "QuestForDraucula",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 27UL,
                        Name = "QuestForDraucula",
                        Description = "Embark on a quest to murder some goblins and skeletons, then jump through an empty doorway to the voidlands in this beta quest!",
                        CreatorPlayerId = 782441001UL,
                        ImageName = "d0df003353914adfaecdd23f428208b6",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 0L,
                            RoomId = 27UL,
                            RoomSceneLocationId = "49cb8993-a956-43e2-86f4-1318f279b22a",
                            Name = "Home",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        }
                    }
                }
            },
            {
                "Bowling",
                new room
                {
                    Room = new room_data_base.room_data
                    {
                        RoomId = 28UL,
                        Name = "Bowling",
                        Description = "wii sport bolling",
                        CreatorPlayerId = 782441001UL,
                        ImageName = "4d143a3359e8483e8d48116ab6cacecb",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<subrooms>
                    {
                        new subrooms
                        {
                            RoomSceneId = 1L,
                            RoomId = 28UL,
                            RoomSceneLocationId = "ae929543-9a07-41d5-8ee9-dbbee8c36800",
                            Name = "Home",
                            IsSandbox = false,
                            DataBlobName = string.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                    },
                    CoOwners = new List<ulong>(),
                    Hosts = new List<ulong>(),
                    CheerCount = 1,
                    FavoriteCount = 1,
                    VisitCount = 1,
                    Tags = new List<Tags>
                    {
                        new Tags
                        {
                            Tag = "rro",
                            Type = 2
                        },
                        new Tags
                        {
                            Tag = "sport",
                            Type = 0
                        }
                    }
                }
            }
		};
    }
}