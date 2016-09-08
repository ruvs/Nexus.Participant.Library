using Microsoft.EntityFrameworkCore;
using Nexus.ParticipantLibrary.Data.Domain;
using Nexus.ParticipantLibrary.Data.Helpers;

namespace Nexus.ParticipantLibrary.Data.Context
{
    public class ParticipantLibraryContext : DbContext
    {
        public ParticipantLibraryContext(DbContextOptions<ParticipantLibraryContext> options) : base(options)
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

            modelBuilder.RemovePluralizingTableNameConvention();

            modelBuilder.Entity<ParticipantLibraryItem>().Property(p => p.NexusKey).IsRequired();
            modelBuilder.Entity<ParticipantLibraryItem>().Property(p => p.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<ParticipantLibraryItem>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<ParticipantLibraryItemType>().Property(p => p.NexusKey).IsRequired();
            modelBuilder.Entity<ParticipantLibraryItemType>().Property(p => p.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<ParticipantLibraryItemType>().Property(p => p.Name).IsRequired();
        }
    }
}
