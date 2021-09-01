using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News_WebApp.Models
{
    public class User
    {
        [Required(ErrorMessage ="User Id is must")]
        [DisplayName("User Name")]
        public string UserId { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is must")]
        public string Password { get; set; }
        // Add this in User Class  
        public ICollection<News> News { get; set; }
    }
}
