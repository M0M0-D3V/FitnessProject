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
        public DbSet<Class> classes { get; set; }
    }
}