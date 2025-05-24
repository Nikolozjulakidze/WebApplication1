using FilmsApi.Core;
using FilmsApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet <Director> Directors { get; set; }
        public DbSet <Film> Films { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Director>(entity =>
            {
                entity.Property(d => d.Name)
                .IsRequired()
                 .HasMaxLength(255);

                entity.Property(d => d.Star)
                .IsRequired()
                .HasMaxLength(5);
                
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.Property(f => f.Name)
                .IsRequired()
                 .HasMaxLength(255);

                entity.Property(d => d.Star)
                .IsRequired()
                .HasMaxLength(5);

                entity.Property(f => f.Time)
                .IsRequired()
                .HasMaxLength(50000);

            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(500);

                entity.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(64);
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
