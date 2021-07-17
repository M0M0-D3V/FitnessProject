// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//Other usings
namespace FitnessProject.Models
{
    public class MyContext : IdentityDbContext
    {
        //Setup Context as normal
        public MyContext(DbContextOptions options) : base(options){}
        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
    }
}