using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<Rating>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Ratings)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}