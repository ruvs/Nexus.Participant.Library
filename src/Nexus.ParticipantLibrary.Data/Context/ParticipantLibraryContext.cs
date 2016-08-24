using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Nexus.ParticipantLibrary.Data.Domain;

namespace Nexus.ParticipantLibrary.Data.Context
{
    public class ParticipantLibraryContext : DbContext
    {
        public ParticipantLibraryContext() : base()
        {
        }

        public ParticipantLibraryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ParticipantLibraryItem> ParticipantLibraryItems { get; set; }

        public DbSet<ParticipantLibraryItemType> ParticipantLibraryItemTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //foreach (var entity in modelBuilder.Model.GetEntityTypes())
            //{
            //    modelBuilder.Entity(entity.Name).Property("NexusKey").IsRequired();
            //}

            modelBuilder.Entity<ParticipantLibraryItem>().Property(p => p.NexusKey).IsRequired();
            modelBuilder.Entity<ParticipantLibraryItem>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<ParticipantLibraryItemType>().Property(p => p.NexusKey).IsRequired();
            modelBuilder.Entity<ParticipantLibraryItemType>().Property(p => p.Name).IsRequired();
        }
    }
}
