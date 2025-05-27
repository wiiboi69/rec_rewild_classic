using System.Collections.Generic;

namespace rec_rewild_classic.api.room
{
    partial class GameSession_Manager
    {
        public enum Photon_Region
        {
            eu,
            us,
            asia,
            jp,
            au = 5,
            usw,
            sa,
            cae,
            kr,
            @in,
            ru,
            rue,
            none = 4
        }
        public class CloudRegionPing
        {
            public CloudRegionPing(Photon_Region region, int ping)
            {
                this.RegionId = region.ToString();
                this.Ping = ping;
            }
            private string RegionId;
            private int Ping;
        }
        public enum Player_Join_Mode
        {
            Invite,
            AutoFollow
        }
        public abstract class BaseJoinRequest
        {
            public long[] ExpectedPlayerIds;

            public List<CloudRegionPing> RegionPings;

            public List<string> RoomTags;
        }
        public class JoinRoomRequest : BaseJoinRequest
        {
            public string RoomName;

            public string SceneName;

            public bool Private;

            public Player_Join_Mode AdditionalPlayerJoinMode;
        }

        public class JoinInstanceRequest : BaseJoinRequest
        {
            public long GameSessionId;
        }

        public class JoinEventRequest : BaseJoinRequest
        {
            public long EventId;
        }
        public class Heartbeat_data
        {
            public long GameSessionId;
            public string PhotonRegionId = Photon_Region.eu.ToString();
            public string PhotonRoomId;
            public string Name;
            public long RoomId;
            public long RoomSceneId;
            public string RoomSceneLocationId;
            public bool IsSandbox;
            public string DataBlobName;
            public long? PlayerEventId = null;
            public bool Private;
            public bool GameInProgress;
            public int MaxCapacity;
            public bool IsFull;
        }
        public class GameSession_DTO
        {
            public GameSession_Result Result;
            public Heartbeat_data GameSession;
            public Room_System.Room_Info_Data RoomDetails;
        }

        public enum GameSession_Result
        {
            Success,
            NoSuchGame,
            PlayerNotOnline,
            InsufficientSpace,
            EventNotStarted,
            EventAlreadyFinished,
            EventCreatorNotReady,
            BlockedFromRoom,
            ProfileLocked,
            NoBirthday,
            MarkedForDelete,
            JuniorNotAllowed,
            Banned,
            AlreadyInBestGameSession,
            ScreenModeNotAllowed,
            VRModeNotAllowed,
            UpdateRequired,
            AlreadyInTargetGameSession,
            NoSuchRoom = 20,
            RoomCreatorNotReady,
            RoomIsNotActive,
            RoomBlockedByCreator,
            RoomBlockingCreator,
            RoomIsPrivate,
            PlayerTypeNotSupported = 30
        }

        private class JoinPlayerRequest : BaseJoinRequest
        {
            public long PlayerId;
        }
    }
}
