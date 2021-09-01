using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace News_WebApp.Models
{
    public class News
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [DisplayName("Published Date")]
        public DateTime PublishedAt { get; set; }
        [DisplayName("Image")]
        public string UrlToImage { get; set; }

        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile urlImage { get; set; }


        public string UserId { get; set; }
        // Add this User 
        public User User { get; set; }

       

    }
    

        
     
    

}
