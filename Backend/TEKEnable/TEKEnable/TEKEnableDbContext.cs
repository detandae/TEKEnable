using Microsoft.EntityFrameworkCore;
using TEKEnable.Models;

namespace TEKEnable
{
    public class TEKEnableDbContext: DbContext
    {
        public TEKEnableDbContext(DbContextOptions<TEKEnableDbContext> options) : base(options)
        {
        }

        public DbSet<SignUpDetails> SignUpDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SignUpDetails>(entity =>
            {
                entity.ToTable("SignUpDetails");

                entity.HasKey(e => e.Email); // Set Email as primary key

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SourceOfInformation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Other)
                    .HasMaxLength(100);

                entity.Property(e => e.Reason)
                    .HasMaxLength(200);
            });

        }
    }
}
