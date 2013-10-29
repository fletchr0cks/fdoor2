﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LinqToTwitterMvcDemo.Models
{
    /// <summary>
    /// Container for mention entities
    /// </summary>
    public class Entities
    {
        public static Entities CreateEntities(XElement element)
        {
            if (element == null || element.Descendants().Count() == 0)
            {
                return null;
            }

            //process user mentions
          //  var userMentions = new List<UserMention>(MentionBase.ProcessMentions<UserMention>(element, "user_mentions", "user_mention", false, UserMention.FromXElement));

            //process urls mentions
            var urlMentions = new List<UrlMention>(MentionBase.ProcessMentions<UrlMention>(element, "urls", "url", true, UrlMention.FromXElement));

            //process hashtags mentions
          //  var hashTagMentions = new List<HashTagMention>(MentionBase.ProcessMentions<HashTagMention>(element, "hashtags", "hashtag", false, HashTagMention.FromXElement));

            //process media mentions
            var mediaMentions = new List<MediaMention>(MentionBase.ProcessMentions<MediaMention>(element, "media", "creative", false, MediaMention.FromXElement));

            return new Entities
            {
            //    UserMentions = userMentions,
            //    HashTagMentions = hashTagMentions,
                UrlMentions = urlMentions,
                MediaMentions = mediaMentions
            };
        }

        /// <summary>
        /// Mentions of the user
        /// </summary>
        //public List<UserMention> UserMentions { get; set; }

        /// <summary>
        /// Url mentions in the tweet
        /// </summary>
        public List<UrlMention> UrlMentions { get; set; }

        /// <summary>
        /// Hash tags mentions in the tweet
        /// </summary>
        //public List<HashTagMention> HashTagMentions { get; set; }

        /// <summary>
        /// Media mentions in the tweet
        /// </summary>
        public List<MediaMention> MediaMentions { get; set; }
    }
}