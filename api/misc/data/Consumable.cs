using System;
using System.Collections.Generic;
using System.Text;

namespace api
{
    class Consumable
    {
		public class Consumable_item
        {
			public long Id {  get; set; }
			public string ConsumableItemDesc { get; set; }
            public DateTime CreatedAt { get; set; }
            public int Count { get; set; }
            public int InitialCount { get; set; }
            public int UnlockedLevel { get; set; }
            public bool IsActive { get; set; }
            public int? ActiveDurationMinutes { get; set; }
        }
	}
}
