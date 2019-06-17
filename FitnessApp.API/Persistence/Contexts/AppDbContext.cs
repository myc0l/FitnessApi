using FitnessApp.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Excercise> Excercises { get; set; }
        public DbSet<User> Users { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Excercise>().ToTable("Exercises");
            builder.Entity<Excercise>().HasKey(p => p.Id);
            builder.Entity<Excercise>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Excercise>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            builder.Entity<Excercise>().Property(p => p.Duration).IsRequired();
            builder.Entity<Excercise>().Property(p => p.Calories).IsRequired();
        }
        
        
    }
}