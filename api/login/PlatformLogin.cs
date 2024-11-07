using System;
using Newtonsoft.Json;

namespace api2017
{
	internal class PlatformLogin
	{
		public string Token { get; set; }
		public ulong PlayerId { get; set; }
		public string Error { get; set; }
		public static string v4(ulong userid)
		{
			PlatformLogin value = new PlatformLogin
			{
				Token = "j3923mHJG032jew",
				PlayerId = userid,
				Error = ""
			};
			return JsonConvert.SerializeObject(value);
		}
	}
}
