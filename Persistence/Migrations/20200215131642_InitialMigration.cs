using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShortUrl = table.Column<string>(nullable: true),
                    FullUrl = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "FullUrl", "IsPublic", "ShortUrl" },
                values: new object[] { new Guid("00b9e2b3-2486-4e37-a51a-21df39ca03a9"), "http://www.google.com", true, "/1" });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "FullUrl", "IsPublic", "ShortUrl" },
                values: new object[] { new Guid("f569cde1-4c52-4c48-8860-5119a51d2e2c"), "http://www.facebook.com", true, "/2" });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "FullUrl", "IsPublic", "ShortUrl" },
                values: new object[] { new Guid("870d738a-1a4c-4e7c-ab83-091b9428d186"), "http://www.microsoft.com", false, "/3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");
        }
    }
}
