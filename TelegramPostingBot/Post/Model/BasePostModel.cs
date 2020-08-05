using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelegramPostingBot.Post.Type;

namespace TelegramPostingBot.Post.Model
{
    class BasePostModel :IPostModel
    {
        public PostType Type { get; private set; }
        public string Text { get; set; }
        public string[] Attachments { get; set; }

        public BasePostModel(PostType type, string text, IEnumerable<string> attachments)
        {
            Type = type;
            Text = text;
            Attachments = attachments.Take(10).ToArray();
        }

        public BasePostModel GetTextPost(string text)
        {
            return new BasePostModel(PostType.Text, text, null);
        }

        public BasePostModel GetImagesPost(IEnumerable<string> imageUrls, string text = null)
        {
            return new BasePostModel(PostType.Images, text, imageUrls);
        }

        public BasePostModel GetAudioPost(string audioUrl, string text = null)
        {
            return new BasePostModel(PostType.Audio, text, new []{ audioUrl });
        }

        public BasePostModel GetContactPost(string text, IEnumerable<string> info)
        {
            return new BasePostModel(PostType.Contact, text, info);
        }

        public BasePostModel GetStickerPost(string sticker)
        {
            return new BasePostModel(PostType.Sticker, null, new []{ sticker });
        }
    }
}
