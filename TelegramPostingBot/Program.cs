using System;
using TelegramPostingBot.Bot;
using TelegramPostingBot.Config;
using TelegramPostingBot.Config.Model;
using TelegramPostingBot.Config.Reader;
using TelegramPostingBot.Post.Model;

namespace TelegramPostingBot
{
    class Program
    {
        private static IBotConfigModel config;
        private static IBot bot;

        static void Main(string[] args)
        {
            Init();

            bot.SendPost(
                BasePostModel.CreateTextPost("[GOOGLE](https://google.com)")
                );

            bot.SendPost(
                BasePostModel.CreateImagePost("https://sun9-54.userapi.com/c841531/v841531527/6a856/ESROVuWr_UI.jpg", "NICE")
                );

            bot.SendPost(
                BasePostModel.CreateVideoPost(
                    "https://cs1-75v4.vkuservideo.net/p10/e3ac25c61e16.720.mp4?extra=fVvjBcovUIDjVjEaqHlVb3utjnYN4NUbOozrNq_vHItg2_BkBDUiQ-JnPzcQcP76_kxBW8NKIQJKvKq1I2lYzQeI1Yf-dlA1lsE72z1g4xx7N0mQelPEYJpV9TpLjr7aOz9xo5fw-76AUL-UzeHc8QVqcw&c_uniq_tag=o8Z7JapMAaEbZdzu9ncxGejFZfSZIcfKjc5VWYozGPQ#FILENAME/Yes%20I%20am%20(JoJo)_720p_alt.mp4",
                    "YES! I AM!"
                    )
                );

            bot.SendPost(
                BasePostModel.CreateImagesPost(new []
                    {
                        @"https://sun9-25.userapi.com/c858220/v858220692/19783e/97oqUWl896s.jpg",
                        @"https://sun9-7.userapi.com/c856132/v856132913/17dddc/uBYjk965js8.jpg",
                        @"https://sun9-8.userapi.com/c841426/v841426921/722da/j0CCeYfYu6w.jpg"
                    })
                );

            bot.SendPost(
                BasePostModel.CreateVideosPost(
                    new []
                    {
                        "https://cs1-75v4.vkuservideo.net/p10/e3ac25c61e16.720.mp4?extra=fVvjBcovUIDjVjEaqHlVb3utjnYN4NUbOozrNq_vHItg2_BkBDUiQ-JnPzcQcP76_kxBW8NKIQJKvKq1I2lYzQeI1Yf-dlA1lsE72z1g4xx7N0mQelPEYJpV9TpLjr7aOz9xo5fw-76AUL-UzeHc8QVqcw&c_uniq_tag=o8Z7JapMAaEbZdzu9ncxGejFZfSZIcfKjc5VWYozGPQ#FILENAME/Yes%20I%20am%20(JoJo)_720p_alt.mp4",
                        "https://cs1-75v4.vkuservideo.net/p10/e3ac25c61e16.720.mp4?extra=fVvjBcovUIDjVjEaqHlVb3utjnYN4NUbOozrNq_vHItg2_BkBDUiQ-JnPzcQcP76_kxBW8NKIQJKvKq1I2lYzQeI1Yf-dlA1lsE72z1g4xx7N0mQelPEYJpV9TpLjr7aOz9xo5fw-76AUL-UzeHc8QVqcw&c_uniq_tag=o8Z7JapMAaEbZdzu9ncxGejFZfSZIcfKjc5VWYozGPQ#FILENAME/Yes%20I%20am%20(JoJo)_720p_alt.mp4",
                        "https://cs1-75v4.vkuservideo.net/p10/e3ac25c61e16.720.mp4?extra=fVvjBcovUIDjVjEaqHlVb3utjnYN4NUbOozrNq_vHItg2_BkBDUiQ-JnPzcQcP76_kxBW8NKIQJKvKq1I2lYzQeI1Yf-dlA1lsE72z1g4xx7N0mQelPEYJpV9TpLjr7aOz9xo5fw-76AUL-UzeHc8QVqcw&c_uniq_tag=o8Z7JapMAaEbZdzu9ncxGejFZfSZIcfKjc5VWYozGPQ#FILENAME/Yes%20I%20am%20(JoJo)_720p_alt.mp4",
                        "https://cs1-75v4.vkuservideo.net/p10/e3ac25c61e16.720.mp4?extra=fVvjBcovUIDjVjEaqHlVb3utjnYN4NUbOozrNq_vHItg2_BkBDUiQ-JnPzcQcP76_kxBW8NKIQJKvKq1I2lYzQeI1Yf-dlA1lsE72z1g4xx7N0mQelPEYJpV9TpLjr7aOz9xo5fw-76AUL-UzeHc8QVqcw&c_uniq_tag=o8Z7JapMAaEbZdzu9ncxGejFZfSZIcfKjc5VWYozGPQ#FILENAME/Yes%20I%20am%20(JoJo)_720p_alt.mp4"
                    })
                );

            bot.SendPost(
                BasePostModel.CreateAudioPost(
                    @"https://storage.lightaudio.ru/39922428/2b5fe049/JoJo%27s%20%E2%80%94%20JoJo%27s%20OP.mp3",
                    "JOJO")
                );

            bot.SendPost(
                BasePostModel.CreateContactPost("JOJO", new []{ "+000000000000" })
                );

            Console.ReadLine();
        }

        static void Init()
        {
            config = new BasicConfigReader<BasicBotConfigModel>("D:/jsong").ParseConfig();
            bot = new BasicBot(config.BotToken, config.TelegramChannels[0]);
        }
    }
}
