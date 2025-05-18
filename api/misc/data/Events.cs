using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace api2018
{
	internal class Events
	{
		public long EventId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string PosterImageName { get; set; }
		public long CreatorPlayerId { get; set; }
		public static string list()
		{
			List<Events> value = new List<Events>();
			return JsonConvert.SerializeObject(value);
		}
	}
}
