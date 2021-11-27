using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTATrilogyRadioHandler
{
    public class Config
    {
        public static string Version = "v1.3";

        private static Config _instance;
        private static readonly string configPath = Path.Combine(Directory.GetCurrentDirectory(), "config.cfg");

        // Config options
        public List<string> Programs = new List<string>();

        public static Config Instance()
        {
            if (_instance == null)
            {
                _instance = new Config();
            }
            return _instance;
        }

        public static void SetInstance(Config instance)
        {
            _instance = instance;
        }

        public static Config TryLoadConfig()
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();

                using (StreamReader streamReader = new StreamReader(configPath))
                using (JsonReader reader = new JsonTextReader(streamReader))
                {
                    SetInstance(serializer.Deserialize<Config>(reader));
                }
            }
            catch (Exception) { }

            return Instance();
        }

        public static void SaveConfig()
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();

                using (StreamWriter sw = new StreamWriter(configPath))
                using (JsonTextWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, Instance());
                }
            }
            catch (Exception) { }
        }
    }
}
