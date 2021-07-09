using Microsoft.EntityFrameworkCore;

namespace FitnessProject.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        // the "Monsters" table name will come from the DbSet variable name
        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<RSVP> RSVPs { get; set; }
    }
}