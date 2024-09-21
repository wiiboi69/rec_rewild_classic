using System;
using Newtonsoft.Json;

namespace api
{
	public class Sanitize
	{
		public static Sanitize.m001 GetSanitize()
        {
			return new m001
			{
				IsPure = true
			};
        }
		
		public sealed class m001
        {
			public bool IsPure { get; set; }
		}
		
	}
}
