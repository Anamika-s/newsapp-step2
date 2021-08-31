using Microsoft.EntityFrameworkCore;
using News_WebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace News_WebApp.Repository
{
    /*
     This class contains the code for data storage interactions and methods 
     of this class will be used by other parts of the applications such
     as Controllers and Test Cases
     */
    public class NewsRepository  : INewsRepository
    
    {
        NewsDbContext dbContext;
        public NewsRepository(NewsDbContext db)
        {
            dbContext = db;
        }
        /* Declare a variable of NewsDbContext type to store 
         * all the news
        */

        /*
	        This method should accept News object as argument and add the new news object in
            NewsDbContext Object
	    */

        /*
        Use Async and await calls for AddNews(),GetAllNews(),GetNewsById() and RemoveNews()
        */


        /* Implement all the methods of respective interface asynchronously*/
        /* Implement AddNews method should accept News object as argument and add the new news object into 
              NewsDbContext Object*/

        /* Implement GetAllNews method should return all the news available in the the NewsDbContext Object*/

        /* Implement GetNewsById method should return the matching newsid details present in the 
         * the NewsDbContext Object*/

        /* Implement IsNewsExist method to check the news deatils exist or not*/

        /* Implement RemoveNews method should delete a specified news from the NewsDbContext Object*/
        public  async  Task<News> AddNews(News news)
        {
            if (!IsNewsExist(news.Title))
            {
                dbContext.News.Add(news);
                await dbContext.SaveChangesAsync();
                return news;
            }
            else
                return null;

           
        }

         
        bool IsNewsExist(string title)
        {
            var obj = dbContext.News.FirstOrDefault(x => x.Title == title);
            if (obj != null) return true;
            else
                return false;
        }
        public async Task<List<News>> GetAllNews(string userId)
        {

            var newsList = await dbContext.News.Where(x => x.UserId == userId).ToListAsync();
            return newsList;
            
        }

        public async Task<News> GetNewsById(int newsId)
        {
            var news = await dbContext.News.SingleOrDefaultAsync(x => x.NewsId == newsId);
            return news;
        }

        public async Task<bool> RemoveNews(int newsId)
        {
            var news = GetNewsById(newsId);
            if (news != null)
            {
                dbContext.News.Remove(await news);
                await dbContext.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}
