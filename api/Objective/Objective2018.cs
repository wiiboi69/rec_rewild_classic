using System;
using System.Collections.Generic;

namespace api2018
{
	public class Objective2018
	{
		public List<Objective2018Entry> Objectives { get; set; }
		public List<Objective2018Group> ObjectiveGroups { get; set; }

		public Objective2018()
		{
			this.Objectives = new List<Objective2018Entry>();
			this.ObjectiveGroups = new List<Objective2018Group>();
		}
	}
}
