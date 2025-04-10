﻿using Newtonsoft.Json;
using server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using static rewild_room_sesh.room_data_base;

namespace rewild_room_sesh
{

    internal sealed class rewild_custom_room_2018
	{
		
		public static List<room_data_base.room_data> room_find(string name)
		{
			Console.WriteLine("Finding room");
            name = Uri.UnescapeDataString(name);
            string[] array = name.Split(new char[]
			{
				' '
			});
			List<room_data_base.room_data> list = new List<room_data_base.room_data>();
            Console.WriteLine("Searching through room");
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

		public static room Get_cloneable_room(ulong p0)
		{
			foreach (KeyValuePair<string, room> keyValuePair in room_data_base.Base_cloneable_room)
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
            room clonable_room = new room();
            clonable_room = Get_cloneable_room(clone_data.RoomId);
			if (clonable_room == null)
			{
				room_data.Result = error_code.RoomDoesNotExist;
				room_data.RoomDetails = null;
                return room_data;
            }

            foreach (var room in room_data_base.get_all_custom_rooms())
            {
                if (room.Value.Room.Name == clone_data.Name)
                {
                    room_data.Result = error_code.DuplicateName;
                    room_data.RoomDetails = null;
                    return room_data;
                }
            }

            foreach (var room in room_data_base.get_all_rooms())
            {
                if (room.Room.Name == clone_data.Name)
                {
                    room_data.Result = error_code.ReservedName;
                    room_data.RoomDetails = null;
                    return room_data;
                }
            }

            foreach (var room in room_data_base.get_all_base_rooms())
            {
                if (room.Room.Name == clone_data.Name)
                {
                    room_data.Result = error_code.ReservedName;
                    room_data.RoomDetails = null;
                    return room_data;
                }
            }

            room_data.Result = 0;
			room_data.RoomDetails = clonable_room;
			room_data.RoomDetails.Room.Name = clone_data.Name;

			ulong roomId = (ulong)new Random().NextInt64(500, 99999999);

			room_data.RoomDetails.Room.RoomId = roomId;
			room_data.RoomDetails.Room.IsAGRoom = false;
			room_data.RoomDetails.Room.CreatorPlayerId = APIServer_Base.CachedPlayerID;

            ulong subroom_idx = roomId;

            foreach (var room in room_data.RoomDetails.Scenes)
            {
                room.RoomId = subroom_idx;
                room.IsSandbox = true;
                room.DataModifiedAt = DateTime.UtcNow;
                subroom_idx += 1;
            }

            //get_all_custom_rooms().Add(clone_data.Name, clonable_room);

			string text = Path.Combine(room_util.check_room_dir(), room_data.RoomDetails.Room.Name);

			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			    File.WriteAllText(Path.Combine(text, "RoomDetails.json"), JsonConvert.SerializeObject(room_data.RoomDetails, Formatting.Indented));
			    return room_data;
			}

            room_data.Result = error_code.DuplicateName;
            room_data.RoomDetails = null;
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
            public room RoomDetails { get;set; }

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