using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            // builder.Property(r => r.Score)
            //     .HasColumnType("decimal(18,2)");

            builder
                .HasOne(r => r.Book)
                .WithMany(b => b.Ratings)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}