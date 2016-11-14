using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Nexus.ParticipantLibrary.Data.Context;

namespace Nexus.ParticipantLibrary.Data.Migrations
{
    [DbContext(typeof(ParticipantLibraryContext))]
    [Migration("20161114140645_SeedTheData")]
    partial class SeedTheData
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

                    b.Property<string>("DisplayCode");

                    b.Property<string>("DisplayName")
                        .IsRequired();

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Iso2Code");

                    b.Property<string>("Iso3Code");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid>("TypeKey");

                    b.HasKey("NexusKey");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("TypeKey");

                    b.ToTable("ParticipantLibraryItem");
                });

            modelBuilder.Entity("Nexus.ParticipantLibrary.Data.Domain.ParticipantLibraryItemType", b =>
                {
                    b.Property<Guid>("NexusKey")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName")
                        .IsRequired();

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("NexusKey");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ParticipantLibraryItemType");
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
