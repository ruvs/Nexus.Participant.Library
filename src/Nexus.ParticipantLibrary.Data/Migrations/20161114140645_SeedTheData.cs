using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexus.ParticipantLibrary.Data.Migrations
{
    public partial class SeedTheData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            MyDataSeeder.SeedTheInitialData(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"TRUNCATE TABLE dbo.ParticipantLibraryItem");

            migrationBuilder.Sql($"TRUNCATE TABLE dbo.ParticipantLibraryItemType");
        }
    }
}
