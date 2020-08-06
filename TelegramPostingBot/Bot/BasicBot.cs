using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        public string BotToken { get; private set; }
        public string ChannelID { get; private set; }

        private ITelegramBotClient bot;

        public BasicBot(string token, string channelID)
        {
            BotToken = token;
            ChannelID = channelID;

            bot = new TelegramBotClient(BotToken);
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

                case PostType.Sticker:
                    SendStickerPost(post);
                    break;
            }
        }

        private void SendTextPost(IPostModel post)
        {
            if (post.Text == null)
                throw new ArgumentException("Text Post: post.text = null");

            bot.SendTextMessageAsync(ChannelID, post.Text, ParseMode.MarkdownV2);
        }

        private void SendImagePost(IPostModel post)
        {
            if (post.Attachments == null)
                throw new ArgumentException("Images Post: post.attachments = null");

            if (post.Attachments.Length == 0)
                throw new ArgumentException("Images Post: post.attachments.length = 0");

            if (post.Attachments[0] == null)
                throw new ArgumentException("Images Post: post.attachments[0] = null");

            bot.SendPhotoAsync(
                ChannelID, 
                new InputMedia(post.Attachments[0]), 
                post.Text, 
                ParseMode.MarkdownV2
                );
        }

        private void SendVideoPost(IPostModel post)
        {
            if (post.Attachments == null)
                throw new ArgumentException("Images Post: post.attachments = null");

            if (post.Attachments.Length == 0)
                throw new ArgumentException("Images Post: post.attachments.length = 0");

            if (post.Attachments[0] == null)
                throw new ArgumentException("Images Post: post.attachments[0] = null");

            bot.SendVideoAsync(
                ChannelID, 
                new InputMedia(post.Attachments[0]), 
                caption: post.Text, 
                parseMode: ParseMode.MarkdownV2
                );
        }

        private void SendImagesPost(IPostModel post)
        {
            if (post.Attachments == null)
                throw new ArgumentException("Images Post: post.attachments = null");

            if (post.Attachments.Length < 2)
                throw new ArgumentException("Images Post: post.attachments.length < 2");

            bot.SendMediaGroupAsync(
                post.Attachments
                    .Select(x => new InputMediaPhoto(new InputMedia(x))),
                ChannelID
            );
        }

        private void SendVideosPost(IPostModel post)
        {
            if (post.Attachments == null)
                throw new ArgumentException("Images Post: post.attachments = null");

            if (post.Attachments.Length < 2)
                throw new ArgumentException("Images Post: post.attachments.length < 2");

            bot.SendMediaGroupAsync(
                post.Attachments
                    .Select(x => new InputMediaVideo(new InputMedia(x))),
                ChannelID
            );
        }

        private void SendAudioPost(IPostModel post)
        {
            if (post.Attachments == null)
                throw new ArgumentException("Images Post: post.attachments = null");

            if (post.Attachments.Length == 0)
                throw new ArgumentException("Images Post: post.attachments.length = 0");

            bot.SendAudioAsync(ChannelID, new InputMedia(post.Attachments[0]), post.Text);
        }

        private void SendContactPost(IPostModel post)
        {
            if (post.Text == null)
                throw new ArgumentException("Images Post: post.text = null");

            if (post.Attachments == null)
                throw new ArgumentException("Images Post: post.attachments = null");

            if (post.Attachments.Length == 0)
                throw new ArgumentException("Images Post: post.attachments.length = 0");

            bot.SendContactAsync(
                ChannelID, 
                post.Attachments[0], 
                post.Text);
        }

        private void SendStickerPost(IPostModel post)
        {
            if (post.Attachments == null)
                throw new ArgumentException("Images Post: post.attachments = null");

            if (post.Attachments.Length == 0)
                throw new ArgumentException("Images Post: post.attachments.length = 0");

            if (post.Attachments[0] == null)
                throw new ArgumentException("Images Post: post.attachments[0] = null");

            bot.SendStickerAsync(
                ChannelID,
                new InputMedia(post.Attachments[0])
            );
        }
    }
}
