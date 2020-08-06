using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelegramPostingBot.Post.Type;

namespace TelegramPostingBot.Post.Model
{
    class BasePostModel :IPostModel
    {
        public PostType Type { get; }
        public string Text { get; set; }
        public string[] Attachments { get; set; }

        public BasePostModel(PostType type, string text, IEnumerable<string> attachments)
        {
            Type = type;
            Text = text;
            Attachments = attachments?.Take(10).ToArray();
        }

        public static BasePostModel CreateTextPost(string text)
        {
            return new BasePostModel(PostType.Text, text, null);
        }

        public static BasePostModel CreateImagePost(string imageUrl, string text = null)
        {
            return new BasePostModel(PostType.Image, text, new []{ imageUrl });
        }

        public static BasePostModel CreateVideoPost(string videoUrl, string text = null)
        {
            return new BasePostModel(PostType.Video, text, new[] { videoUrl });
        }

        public static BasePostModel CreateImagesPost(IEnumerable<string> imageUrls)
        {
            return new BasePostModel(PostType.Images, null, imageUrls);
        }

        public static BasePostModel CreateVideosPost(IEnumerable<string> videoUrls)
        {
            return new BasePostModel(PostType.Videos, null, videoUrls);
        }

        public static BasePostModel CreateAudioPost(string audioUrl, string text = null)
        {
            return new BasePostModel(PostType.Audio, text, new []{ audioUrl });
        }

        public static BasePostModel CreateContactPost(string text, IEnumerable<string> info)
        {
            return new BasePostModel(PostType.Contact, text, info);
        }
    }
}
