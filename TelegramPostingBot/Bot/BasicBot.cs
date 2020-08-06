using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using TelegramPostingBot.Post.Model;
using TelegramPostingBot.Post.Type;

namespace TelegramPostingBot.Bot
{
    class BasicBot :IBot
    {
        public string BotToken { get; }
        public string ChannelID { get; }

        private ITelegramBotClient bot;

        public BasicBot(string token, string channelID)
        {
            BotToken = token;
            ChannelID = channelID;

            bot = new TelegramBotClient(BotToken, new HttpClient());
        }

        public void SendPost(IEnumerable<IPostModel> posts)
        {
            foreach (var post in posts)
            {
                SendPost(post);
            }
        }

        public void SendPost(IPostModel post)
        {
            if (post == null)
                throw new ArgumentNullException("post");

            try
            {
                switch (post.Type)
                {
                    case PostType.Text:
                        SendTextPost(post);
                        break;

                    case PostType.Image:
                        SendImagePost(post);
                        break;

                    case PostType.Video:
                        SendVideoPost(post);
                        break;

                    case PostType.Images:
                        SendImagesPost(post);
                        break;

                    case PostType.Videos:
                        SendVideosPost(post);
                        break;

                    case PostType.Audio:
                        SendAudioPost(post);
                        break;

                    case PostType.Contact:
                        SendContactPost(post);
                        break;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void SendTextPost(IPostModel post)
        {
            if (post.Text == null)
                throw new ArgumentException("Text Post: post.text = null");

            var temp = bot.SendTextMessageAsync(
                ChannelID, 
                post.Text, 
                ParseMode.Markdown);

            temp.Wait();
            Console.WriteLine(temp.Result);
        }

        private void SendImagePost(IPostModel post)
        {
            if (post.Attachments == null)
                throw new ArgumentException("Images Post: post.attachments = null");

            if (post.Attachments.Length == 0)
                throw new ArgumentException("Images Post: post.attachments.length = 0");

            if (post.Attachments[0] == null)
                throw new ArgumentException("Images Post: post.attachments[0] = null");

            var temp = bot.SendPhotoAsync(
                ChannelID, 
                new InputMedia(post.Attachments[0]), 
                post.Text, 
                ParseMode.Markdown);

            temp.Wait();
            Console.WriteLine(temp.Result);
        }

        private void SendVideoPost(IPostModel post)
        {
            if (post.Attachments == null)
                throw new ArgumentException("Images Post: post.attachments = null");

            if (post.Attachments.Length == 0)
                throw new ArgumentException("Images Post: post.attachments.length = 0");

            if (post.Attachments[0] == null)
                throw new ArgumentException("Images Post: post.attachments[0] = null");

            var temp = bot.SendVideoAsync(
                ChannelID, 
                new InputMedia(post.Attachments[0]), 
                caption: post.Text, 
                parseMode: ParseMode.Markdown);

            temp.Wait();
            Console.WriteLine(temp.Result.Text);
        }

        private void SendImagesPost(IPostModel post)
        {
            if (post.Attachments == null)
                throw new ArgumentException("Images Post: post.attachments = null");

            if (post.Attachments.Length < 2)
                throw new ArgumentException("Images Post: post.attachments.length < 2");

            var temp = bot.SendMediaGroupAsync(
                post.Attachments.Select(x => new InputMediaPhoto(new InputMedia(x))),
                ChannelID);

            temp.Wait();
            Console.WriteLine(temp.Result);
        }

        private void SendVideosPost(IPostModel post)
        {
            if (post.Attachments == null)
                throw new ArgumentException("Images Post: post.attachments = null");

            if (post.Attachments.Length < 2)
                throw new ArgumentException("Images Post: post.attachments.length < 2");

            var temp = bot.SendMediaGroupAsync(
                post.Attachments.Select(x => new InputMediaVideo(new InputMedia(x))),
                ChannelID);

            temp.Wait();
            Console.WriteLine(temp.Result);
        }

        private void SendAudioPost(IPostModel post)
        {
            if (post.Attachments == null)
                throw new ArgumentException("Images Post: post.attachments = null");

            if (post.Attachments.Length == 0)
                throw new ArgumentException("Images Post: post.attachments.length = 0");

            var temp = bot.SendAudioAsync(
                ChannelID, 
                new InputMedia(post.Attachments[0]),
                post.Text);

            temp.Wait();
            Console.WriteLine(temp.Result.Text);
        }

        private void SendContactPost(IPostModel post)
        {
            if (post.Text == null)
                throw new ArgumentException("Images Post: post.text = null");

            if (post.Attachments == null)
                throw new ArgumentException("Images Post: post.attachments = null");

            if (post.Attachments.Length == 0)
                throw new ArgumentException("Images Post: post.attachments.length = 0");

            var temp = bot.SendContactAsync(
                ChannelID, 
                post.Attachments[0], 
                post.Text);

            temp.Wait();
            Console.WriteLine(temp.Result);
        }

        private void SendStickerPost(IPostModel post)
        {
            if (post.Attachments == null)
                throw new ArgumentException("Images Post: post.attachments = null");

            if (post.Attachments.Length == 0)
                throw new ArgumentException("Images Post: post.attachments.length = 0");

            if (post.Attachments[0] == null)
                throw new ArgumentException("Images Post: post.attachments[0] = null");

            var temp = bot.SendStickerAsync(
                ChannelID,
                new InputMedia(post.Attachments[0]));

            temp.Wait();
            Console.WriteLine(temp.Result.Text);
        }
    }
}
