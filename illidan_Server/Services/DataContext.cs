using illidan_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace illidan_Server.Services
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration configuration_;

        public DataContext(IConfiguration configuration)
        {
            configuration_ = configuration;
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(configuration_.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Role).HasDefaultValue("User");

            //Users.AddRange(
            //    new User("Sardor", "Safarov", "+79773864255", "admin"),
            //    new User("Leonid", null, "+71234567890", "user")
            //    );
            //SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<QueueToken> Queues { get; set; }
    }
}