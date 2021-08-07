using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//Other usings
namespace FitnessProject.Models
{
    public class MyContext : IdentityDbContext<User>
    {
        //Setup Context as normal
        public MyContext(DbContextOptions options) : base(options){}
        public DbSet<User> users { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<RSVP> RSVPs { get; set; }
        public DbSet<Message> Messages {get; set; }
        public DbSet<ReviewClass> ReviewClasses { get; set; }
        public DbSet<ReviewInstructor> ReviewInstructors { get; set; }
        public DbSet<LikeClass> LikeClasses { get; set; }
        public DbSet<LikeReview> LikeReviews { get; set; }
        public DbSet<FavoriteClass> FavoriteClasses { get; set; }
        public DbSet<FavoriteInstructor> FavoriteInstructors { get; set; }
    }
}