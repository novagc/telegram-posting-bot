using System.IO;
using Newtonsoft.Json;

namespace TelegramPostingBot.Config.Reader
{
    class BasicConfigReader<T> : IConfigReader<T>
    {
        public string ConfigPath { get; set; }

        public BasicConfigReader(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Config {path} not found");
            }

            ConfigPath = path;
        }

        public T ParseConfig()
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(ConfigPath));
        }
    }
}
