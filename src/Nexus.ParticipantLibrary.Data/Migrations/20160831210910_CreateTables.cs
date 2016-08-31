using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexus.ParticipantLibrary.Data.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParticipantLibraryItemTypes",
                columns: table => new
                {
                    NexusKey = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantLibraryItemTypes", x => x.NexusKey);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantLibraryItems",
                columns: table => new
                {
                    NexusKey = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: true),
                    TypeKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantLibraryItems", x => x.NexusKey);
                    table.ForeignKey(
                        name: "FK_ParticipantLibraryItems_ParticipantLibraryItemTypes_TypeKey",
                        column: x => x.TypeKey,
                        principalTable: "ParticipantLibraryItemTypes",
                        principalColumn: "NexusKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantLibraryItems_TypeKey",
                table: "ParticipantLibraryItems",
                column: "TypeKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipantLibraryItems");

            migrationBuilder.DropTable(
                name: "ParticipantLibraryItemTypes");
        }
    }
}
