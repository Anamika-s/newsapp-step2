using News_WebApp.Models;
using System.Linq;
namespace News_WebApp.Repository
{
    //Inherit IUserRepository and implement the function declared in the interface
    public class UserRepository : IUserRepository
    {   NewsDbContext dbContext;
       public UserRepository(NewsDbContext db)
        {
            dbContext = db;
        }
        
        /* use 'IsAuthenticated function which accepts two agruments i.e userId and password to reuturn 
         * true or false value depending on the user credentials are correct or not
        */
        public bool IsAuthenticated(string userId, string password)
        {
          var user=  dbContext.Users.FirstOrDefault(x => x.UserId == userId && x.Password == password);
            if (user != null)
                return true;
            else
                return false;
        }
    }
}
