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
			File.WriteAllText(text + "\\RoomDetails.json", JsonConvert.SerializeObject(room_data.RoomDetails));
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
            // Token: 0x0400729C RID: 29340
            Success,
            // Token: 0x0400729D RID: 29341
            Unknown,
            // Token: 0x0400729E RID: 29342
            PermissionDenied,
            // Token: 0x0400729F RID: 29343
            RoomNotActive,
            // Token: 0x040072A0 RID: 29344
            RoomDoesNotExist,
            // Token: 0x040072A1 RID: 29345
            RoomHasNoDataBlob,
            // Token: 0x040072A2 RID: 29346
            DuplicateName = 10,
            // Token: 0x040072A3 RID: 29347
            ReservedName,
            // Token: 0x040072A4 RID: 29348
            InappropriateName,
            // Token: 0x040072A5 RID: 29349
            InappropriateDescription,
            // Token: 0x040072A6 RID: 29350
            TooManyRooms = 20,
            // Token: 0x040072A7 RID: 29351
            InvalidMaxPlayers = 30,
            // Token: 0x040072A8 RID: 29352
            DataHistoryDoesNotExist = 40,
            // Token: 0x040072A9 RID: 29353
            DataHistoryAlreadyActive,
            // Token: 0x040072AA RID: 29354
            InvalidTags = 50,
            // Token: 0x040072AB RID: 29355
            NoStartingRoomScene = 55,
            // Token: 0x040072AC RID: 29356
            RoomUnderModerationReview = 100,
            // Token: 0x040072AD RID: 29357
            PlayerHasRoomUnderModerationReview,
            // Token: 0x040072AE RID: 29358
            AccessibilityUnderModerationLock,
            // Token: 0x040072AF RID: 29359
            JuniorStatusFail = 200
        }

        public sealed class c00009c
		{
			public string Name { get; set; }
            public List<room_data_base.c000062> FeaturedRooms { get; set; }
		}
	}
}