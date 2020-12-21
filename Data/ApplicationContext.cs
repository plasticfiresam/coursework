using coursework.Entities;
using Microsoft.EntityFrameworkCore;

namespace coursework.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Announce> Announces { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category[]
                {
                new Category { 
                    Id = 1, 
                    Name = "Ноутбуки",
                    Slug = "noutbuki",
                    CanBeDeleted = false,
                },
                });

            modelBuilder.Entity<Announce>().HasOne(a => a.Owner).WithMany(o => o.Announces).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Announce>().HasOne(a => a.Category).WithMany(t => t.Announcements).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Category>().HasMany(c => c.Announcements).WithOne(a => a.Category).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Owner>().HasMany(o => o.Announces).WithOne(a => a.Owner).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
