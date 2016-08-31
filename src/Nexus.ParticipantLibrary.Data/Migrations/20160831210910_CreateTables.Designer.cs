using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Nexus.ParticipantLibrary.Data.Context;

namespace Nexus.ParticipantLibrary.Data.Migrations
{
    [DbContext(typeof(ParticipantLibraryContext))]
    [Migration("20160831210910_CreateTables")]
    partial class CreateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nexus.ParticipantLibrary.Data.Domain.ParticipantLibraryItem", b =>
                {
                    b.Property<Guid>("NexusKey")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("ShortName");

                    b.Property<Guid>("TypeKey");

                    b.HasKey("NexusKey");

                    b.HasIndex("TypeKey");

                    b.ToTable("ParticipantLibraryItems");
                });

            modelBuilder.Entity("Nexus.ParticipantLibrary.Data.Domain.ParticipantLibraryItemType", b =>
                {
                    b.Property<Guid>("NexusKey")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("NexusKey");

                    b.ToTable("ParticipantLibraryItemTypes");
                });

            modelBuilder.Entity("Nexus.ParticipantLibrary.Data.Domain.ParticipantLibraryItem", b =>
                {
                    b.HasOne("Nexus.ParticipantLibrary.Data.Domain.ParticipantLibraryItemType", "Type")
                        .WithMany("ParticipantLibraryItems")
                        .HasForeignKey("TypeKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
