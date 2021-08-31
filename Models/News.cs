using System;

namespace News_WebApp.Models
{
    public class News
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedAt { get; set; }
        public string UrlToImage { get; set; }

        public string UserId { get; set; }
        // Add this User 
        public User User { get; set; }
    }
}
