using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using gamesesh;

namespace ws
{
	public class Notification
	{
		public static string ProcessRequest(string jsonData)
		{
			Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
			string result;
			Console.WriteLine(jsonData);
			if (dictionary.ContainsKey("api"))
			{
				string text = (string)dictionary["api"];
				string text2 = text;
				if (text2 != null)
				{
					if (text2 == "playerSubscriptions/v1/update")
					{
						Console.WriteLine("[WSS] Game client sent presence update.");
						return JsonConvert.SerializeObject(Notification.Reponse.createResponse(ResponseResults.SubscriptionUpdatePresence, GameSessions.StatusSessionInstance()));
					}
					if (text2 == "heartbeat2")
					{
						Console.WriteLine("[WSS] Heartbeat 2 sent by game client.");
						return JsonConvert.SerializeObject(Notification.Reponse.createResponse(ResponseResults.PresenceHeartbeatResponse, GameSessions.StatusSessionInstance()));
					}
				}
				Console.WriteLine("[WSS] Unknown API call: " + text);
				result = "";
			}
			else
			{
				result = jsonData;
				result = "{\"SessionId\":1}";

            }
			return result;
		}

		public enum ResponseResults
		{
			RelationshipChanged = 1,
			MessageReceived,
			MessageDeleted,
			PresenceHeartbeatResponse,
			SubscriptionListUpdated = 9,
			SubscriptionUpdateProfile = 11,
			SubscriptionUpdatePresence,
			SubscriptionUpdateGameSession,
			SubscriptionUpdateunkon,
            SubscriptionUpdateRoom = 15,
			ModerationQuitGame = 20,
			ModerationUpdateRequired,
			ModerationKick,
			ModerationKickAttemptFailed,
			ServerMaintenance = 25,
			GiftPackageReceived = 30,
			ProfileJuniorStatusUpdate = 40,
			RelationshipsInvalid = 50,
			StorefrontBalanceAdd = 60,
			ConsumableMappingAdded = 70,
			ConsumableMappingRemoved,
			PlayerEventCreated = 80,
			PlayerEventUpdated,
			PlayerEventDeleted,
			PlayerEventResponseChanged,
			PlayerEventResponseDeleted,
			PlayerEventStateChanged,
			ChatMessageReceived = 90
		}

		public class Reponse
		{
			public ResponseResults Id { get; set; }

			public object Msg { get; set; }
			
			public static Notification.Reponse createResponse(ResponseResults id, object msg)
			{
				return new Notification.Reponse
				{
					Id = id,
					Msg = msg
				};
			}
		}
	}
}
