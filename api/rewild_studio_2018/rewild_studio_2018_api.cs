using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static rec_rewild_classic.api.rewild_studio_2018.rewild_studio_2018_api;
using static rewild_room_sesh.room_data_base;

namespace rec_rewild_classic.api.rewild_studio_2018
{
    public class rewild_studio_2018_api
    {
        public static rewild_studio_data<rewild_studio_room> get_all_rewild_studio_room()
        {
            return null;
        }

        public class rewild_studio_data<T>
        {
            public ulong count {  get; set; }
            public T data { get; set; }
        }
        public class rewild_studio_room
        {
            public string Name { get; set; }
            public string Size { get; set; }
            public string Description { get; set; }
            public ulong CreatorPlayerId { get; set; }
            public string CreatorName { get; set; }
            public string ImageName { get; set; }
            public List<Tags> Tags { get; set; }
            public bool SupportsScreens { get; set; }
            public bool SupportsWalkVR { get; set; }
            public bool SupportsTeleportVR { get; set; }
            public ulong version { get; set; }
            public object Roomfile { get; set; }
            public Release_Status Accessibility { get; set; }
        }
        public enum Release_Status
        {
            Unknown = -1,
            none,
            DEV,
            alpha,
            beta,
            RC,
            full_release,
        }
    }
}
