using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace rewild_room_sesh
{

    internal sealed class rewild_custom_room_2018
	{
		
		public static List<room_data_base.room_data> room_find(string name)
		{
			string[] array = name.Split(new char[]
			{
				' '
			});
			List<room_data_base.room_data> list = new List<room_data_base.room_data>();
			foreach (KeyValuePair<string, room_data_base.room> keyValuePair in room_data_base.main_room)
			{
				room_data_base.room value = keyValuePair.Value;
				bool flag = true;
				foreach (string text in array)
				{
					if (flag)
					{
						if (text.StartsWith("#"))
						{
							bool flag2 = false;
							foreach (room_data_base.Tags c in value.Tags)
							{
								if ("#" + c.Tag.ToLower() == text.ToLower())
								{
									flag2 = true;
								}
							}
							if (!flag2)
							{
								flag = false;
							}
						}
						else if (!value.Room.Name.ToLower().Contains(text.ToLower()))
						{
							flag = false;
						}
					}
				}
				if (flag)
				{
					list.Add(value.Room);
				}
			}
			return list;
		}

		public static room_data_base.room Get_cloneable_room(ulong p0)
		{
			foreach (KeyValuePair<string, room_data_base.room> keyValuePair in room_data_base.Base_cloneable_room)
			{
				if (keyValuePair.Value.Room.RoomId == p0)
				{
					return keyValuePair.Value;
				}
			}
			return null;
		}

		public static room_dto clone_room(string p0)
		{
			room_dto room_data = new room_dto();
			clone_dto clone_data = JsonConvert.DeserializeObject<clone_dto>(p0);
			room_data_base.room clonable_room = Get_cloneable_room(clone_data.RoomId);
			if (clonable_room == null)
			{
				room_data.Result = error_code.RoomDoesNotExist;
				room_data.RoomDetails = null;
                return room_data;
            }

			room_data.Result = 0;
			room_data.RoomDetails = clonable_room;
			room_data.RoomDetails.Room.Name = clone_data.Name;
			ulong roomId = (ulong)new Random().Next(100, 9999999);
			room_data.RoomDetails.Room.RoomId = roomId;
			room_data.RoomDetails.Room.IsAGRoom = false;
			room_data.RoomDetails.Scenes[0].IsSandbox = true;
			room_data.RoomDetails.Scenes[0].RoomId = roomId;
			room_data.RoomDetails.Scenes[0].DataBlobName = string.Empty;
			room_data.RoomDetails.Scenes[0].DataModifiedAt = DateTime.Now;
			room_data.RoomDetails.Room.CreatorPlayerId = server.APIServer_Base.CachedPlayerID;
			
			foreach (var room in room_data_base.get_all_custom_rooms())
			{
				if (room.Value.Room.Name == clone_data.Name)
				{
                    room_data.Result = error_code.DuplicateName;
                    room_data.RoomDetails = null;
                    return room_data;
                }
            }

            room_data_base.get_all_custom_rooms().Add(clone_data.Name, clonable_room);
			string text = room_util.check_room_dir() + room_data.RoomDetails.Room.Name;
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			File.WriteAllText(text + "/RoomDetails.json", JsonConvert.SerializeObject(room_data.RoomDetails));
			return room_data;
		}

		public sealed class clone_dto
		{
			public string Name { get; set; }
            public ulong RoomId { get; set; }
		}

		public sealed class room_dto
		{
			public error_code Result { get; set; }
            public room_data_base.room RoomDetails { get;set; }

		}

        public enum error_code
        {
            Success,
            Unknown,
            PermissionDenied,
            RoomNotActive,
            RoomDoesNotExist,
            RoomHasNoDataBlob,
            DuplicateName = 10,
            ReservedName,
            InappropriateName,
            InappropriateDescription,
            TooManyRooms = 20,
            InvalidMaxPlayers = 30,
            DataHistoryDoesNotExist = 40,
            DataHistoryAlreadyActive,
            InvalidTags = 50,
            NoStartingRoomScene = 55,
            RoomUnderModerationReview = 100,
            PlayerHasRoomUnderModerationReview,
            AccessibilityUnderModerationLock,
            JuniorStatusFail = 200
        }
	}
}