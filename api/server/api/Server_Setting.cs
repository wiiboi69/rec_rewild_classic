using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace rec_rewild_classic.api.server
{
    public class Server_Setting
    {
        public class App_Setting
        {
            public int Server_version;
            public bool Private_Room;
            public bool build_detection;
            public bool Private_Dorm;
            public string Private_Photon_Code;
        }
        public static void save_setting()
        {
            File.WriteAllText(SettingsPath, JsonConvert.SerializeObject(_setting));
        }
        public static void Update_server_setting()
        {
            load_setting();
            if (File.Exists("SaveData/App/privaterooms.txt"))
            {
                bool newState = File.ReadAllText("SaveData/App/privaterooms.txt") == "Enabled";
                Setting.Private_Room = newState;
            }
            if (File.Exists("SaveData/App/show_rec_rewild_classic_info.txt"))
            {
                //File.WriteAllText("SaveData/App/show_rec_rewild_classic_info.txt", "Enabled");
            }
        }
        public static void load_setting()
        {
            try
            {
                if (File.Exists(SettingsPath))
                {
                    _setting = JsonConvert.DeserializeObject<App_Setting>(File.ReadAllText(SettingsPath));
                }
                else
                {
                    File.WriteAllText(SettingsPath, JsonConvert.SerializeObject(new App_Setting
                    {
                        Server_version = 1,
                        Private_Room = false,
                        Private_Dorm = true,
                        Private_Photon_Code = ""
                    }));
                    _setting = JsonConvert.DeserializeObject<App_Setting>(File.ReadAllText(SettingsPath));

                }
            }
            catch
            {
                File.WriteAllText(SettingsPath, JsonConvert.SerializeObject(new App_Setting
                {
                    Server_version = 1,
                    Private_Room = false,
                    Private_Dorm = true,
                    Private_Photon_Code = ""
                }));
                _setting = JsonConvert.DeserializeObject<App_Setting>(File.ReadAllText(SettingsPath));
            }
        }

        public static string SettingsPath = "SaveData/App/server_setting.json";

        private static App_Setting _setting;

        internal static App_Setting Setting
        {
            set
            {
                _setting = value;
                save_setting();
            }
            get
            {
                if (_setting == null)
                    load_setting();
                return _setting;
            }
        }
    }
}
