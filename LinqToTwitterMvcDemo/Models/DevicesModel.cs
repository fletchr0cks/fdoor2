using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToTwitterMvcDemo.Models
{
    /// <summary>
    /// Info on friend tweets
    /// </summary>
    public class DevicesModel
    {
        /// <summary>
        /// User's avatar
        /// </summary>
        public string Kindle { get; set; }

        public string Chrome { get; set; }

        /// <summary>
        /// User's Twitter name
        /// </summary>
        public string ScreenName { get; set; }

        /// <summary>
        /// Text containing user's tweet
        /// </summary>
        public string Tweet { get; set; }

        /// <summary>
        /// Text containing user's tweet
        /// </summary>
        public string TimeStamp { get; set; }

        public string ID { get; set; }

        public string MediaUrl { get; set; }

        public string BannerText { get; set; }

        public string BannerTime { get; set; }

        public ulong SinceID { get; set; }

        //public List<MediaMention> MediaMentions { get; set; }

        //public List<UrlMention> UrlMentions { get; set; }

        public int dayssince(DateTime tdate)
        {
            TimeSpan diff = DateTime.Now.Subtract(tdate);
            int days = Convert.ToInt32(diff.TotalDays);

            return days;

        }
    }
}