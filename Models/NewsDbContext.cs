using Microsoft.EntityFrameworkCore;
namespace News_WebApp.Models
{
    //Inherit DbContext class and use Entity Framework Code First Approach
    public class NewsDbContext:DbContext
    {

        public NewsDbContext(DbContextOptions<NewsDbContext> options) 
            : base(options)
        { }
        /*
        This class should be used as DbContext to speak to database and should make the use of 
        Code First Approach. It should autogenerate the database based upon the model class in 
        your application
        */
        public DbSet<User> Users { get; set; }
        public DbSet<News> News { get; set; }
        //Create a Dbset for News class and User class

        /*Override OnModelCreating function to configure relationship between entities and initialize 
         * with seed data 
         *  UserId:Jack Password:password@123
         *  UserId:John Password:password@123
         * So that user can login by using the above credentials
        */
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<User>()
            //   .HasKey("UserId");

            builder.Entity<News>()
           .HasOne<User>(x => x.User)
           .WithMany(y => y.News)
           .HasForeignKey(x => x.UserId);



   
            builder.Entity<User>()
                .HasData(
               new User() {  UserId ="Jack" , Password="password@123"},

            new User() { UserId = "John", Password = "password@123" }
                       );
        }

    }
}
