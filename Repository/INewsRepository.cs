using News_WebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News_WebApp.Repository
{
    /*
    * Should not modify this interface. You have to implement these methods of interface 
    * in corresponding Implementation classes
    */
    public interface INewsRepository
    {

        Task<News> AddNews(News news);
        Task<News> GetNewsById(int newsId);
        Task<List<News>> GetAllNews(string userId);
        Task<bool> RemoveNews(int newsId);
    }
}
