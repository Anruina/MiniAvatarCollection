using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniAvatarCollectionLibrary;

namespace MiniAvatarCollection.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Collectable> collectables {  get; set; }
        public DbSet<Collector> collectors { get; set; }
        public DbSet<MyCollection> myCollections { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}