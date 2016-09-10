using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Nexus.ParticipantLibrary.Data.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParticipantLibraryItemType",
                columns: table => new
                {
                    NexusKey = table.Column<Guid>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantLibraryItemType", x => x.NexusKey);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantLibraryItem",
                columns: table => new
                {
                    NexusKey = table.Column<Guid>(nullable: false),
                    DisplayCode = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Iso2Code = table.Column<string>(nullable: true),
                    Iso3Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    TypeKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantLibraryItem", x => x.NexusKey);
                    table.ForeignKey(
                        name: "FK_ParticipantLibraryItem_ParticipantLibraryItemType_TypeKey",
                        column: x => x.TypeKey,
                        principalTable: "ParticipantLibraryItemType",
                        principalColumn: "NexusKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantLibraryItem_Name",
                table: "ParticipantLibraryItem",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantLibraryItem_TypeKey",
                table: "ParticipantLibraryItem",
                column: "TypeKey");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantLibraryItemType_Name",
                table: "ParticipantLibraryItemType",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipantLibraryItem");

            migrationBuilder.DropTable(
                name: "ParticipantLibraryItemType");
        }
    }
}
