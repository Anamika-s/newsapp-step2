using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News_WebApp.Models
{
    public class User
    {
        public string UserId { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        // Add this in User Class  
        public ICollection<News> News { get; set; }
    }
}
