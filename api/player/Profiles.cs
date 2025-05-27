using System;
using System.Collections.Generic;
using System.Text;

namespace rec_rewild_classic.api
{
    class Profiles
    {
		public int Id { get; set; }
		public ulong XpRequiredToLevelUp { get; set; } = 0;
        public string Username { get; set; }
        public string Auth { get; set; } = string.Empty;
        public string DisplayName { get; set; }
		public string Bio { get; set; }
        public int XP { get; set; }
		public int Level { get; set; }
		public int Reputation { get; set; }
		public bool Verified { get; set; }
		public bool Developer { get; set; }
		public bool HasEmail { get; set; }
		public bool CanReceiveInvites { get; set; }
		public string ProfileImageName { get; set; }
		public bool JuniorProfile { get; set; }
		public bool ForceJuniorImages { get; set; }
		public bool PendingJunior { get; set; }
		public bool HasBirthday { get; set; }
	}
}
