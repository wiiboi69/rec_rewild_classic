using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rec_rewild_classic.api.player
{
    class PlayerReputation
    {
        public enum Cheer_Type
        {
            none = -1,
            General = 0,
            Helpful = 10,
            Sportmanship = 20,
            GreatHost = 30,
            Creative = 40
        }
        public float Noteriety { get; set; }
        public int CheerGeneral { get; set; }
        public int CheerHelpful { get; set; }
        public int CheerGreatHost { get; set; }
        public int CheerSportsman { get; set; }
        public int CheerCreative { get; set; }
        public int CheerCredit { get; set; }
        public int SubscriberCount { get; set; }
        public int SubscribedCount { get; set; }
        public Cheer_Type SelectedCheer { get; set; }
    }
}
