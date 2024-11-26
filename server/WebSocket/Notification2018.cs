using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ws;

namespace rewild_room_sesh
{
	// Token: 0x02000005 RID: 5
	public class Notification2018
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00002A18 File Offset: 0x00000C18
		public static string ProcessRequest(string jsonData)
		{
			Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
			Console.WriteLine("{ws} " + jsonData);
			bool flag = dictionary.ContainsKey("api");
			string result;
			if (flag)
			{
				string text = (string)dictionary["api"];
				string text2 = text;
				bool flag2 = text2 != null;
				if (flag2)
				{
					bool flag3 = text2 == "playerSubscriptions/v1/update";
					if (flag3)
					{
						Console.WriteLine("[18CWS] Game client sent presence update.");
						return JsonConvert.SerializeObject(Notification.Reponse.createResponse(Notification.ResponseResults.SubscriptionUpdatePresence, heartbeat.get_heartbeat()));
					}
					bool flag4 = text2 == "heartbeat2";
					if (flag4)
					{
						Console.WriteLine("[18CWS] Heartbeat 2 sent by game client.");
						return JsonConvert.SerializeObject(Notification.Reponse.createResponse(Notification.ResponseResults.PresenceHeartbeatResponse, heartbeat.get_heartbeat()));
					}
				}
				Console.WriteLine("[18CWS] Unknown CWS call: " + text);
				result = "";
			}
			else
			{
				result = jsonData;
			}
			return result;
		}
	}
}
