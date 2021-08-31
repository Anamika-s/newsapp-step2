namespace News_WebApp.Repository
{
    /*
	 * Should not modify this interface. You have to implement these methods of interface 
     * in corresponding Implementation classes
	 */
    public interface IUserRepository
    {
        bool IsAuthenticated(string userId, string password);
    }
}
