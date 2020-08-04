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
    }
}
