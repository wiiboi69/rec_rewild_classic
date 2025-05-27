using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static rec_rewild_classic.server.rewild_route_system;
using rec_rewild_classic.api.config;
using rec_rewild_classic.api;
using static rec_rewild_classic.api.Login_System;
using Newtonsoft.Json;

namespace rec_rewild_classic.server.rewild_route
{
    class misc_api_route
    {
        [Route("/api/platformlogin/v2/createaccount")]
        public static string Api_platformlogin_createaccount(Create_Player_Account_dto player_Account_Dto)
        {
            Console.WriteLine($"APIServer: creating account with Platform " + player_Account_Dto.Platform + ", PlatformId: " + player_Account_Dto.PlatformId);

            return JsonConvert.SerializeObject(Login_System.Create_Player_Account_Login(player_Account_Dto));
        }
    }
}
