using System;
using Newtonsoft.Json;

namespace api
{
	public class Sanitize
	{
		public static Sanitize.Ispure GetSanitize()
        {
			return new Ispure
			{
				IsPure = true
			};
        }
		
		public sealed class Ispure
        {
			public bool IsPure { get; set; }
		}
		
	}
}
