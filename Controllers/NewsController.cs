using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_WebApp.Models;
using News_WebApp.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace News_WebApp.Controllers
{
    public class NewsController : Controller
    {
        INewsRepository _newsRepo;
        public NewsController(INewsRepository repository)
        {
            _newsRepo = repository;
        }
        public IActionResult Index()
        {
            ViewBag.userId = TempData["userId"].ToString();
            return View();
        }
        /*
         * From the problem statement, we can understand that the application
         * requires us to implement the following functionalities.
         * 
         * 1. Display the list of existing news from the collection. Each news 
         *    should contain NewsId, title, content,PublishedAt and UrlToImage.
         * 2. Add a new news which should contain the Newsid, title, content and PublishedAt
         *    and UrlToImage(to upload an Image).
         *    Note:uploaded image strore it in wwwroot/images folder
         *    
         * 3. Delete an existing News.
     */

        /* 
         * Retrieve the NewsRepository object from the dependency Container through constructor Injection.
         */


        /*Define a handler method to read the existing News by calling the GetNews() method 
         * of the NewsRepository class and pass to view. it should map to the default URL i.e. "/" */


        /*Define a handler method which will accept newsid as a parameter 
         * and return the available news details of the newsid by calling the GetNewsById() of News
         * Repository class
        */


        /* Define a handler method to delete an existing News by calling the RemoveNews() method 
         * of the NewsRepository class
        */
    }
}
