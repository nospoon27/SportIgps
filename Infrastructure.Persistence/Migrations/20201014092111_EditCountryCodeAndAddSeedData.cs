using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Persistence.Migrations
{
    public partial class EditCountryCodeAndAddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbonementAgeCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonementAgeCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbonementLimitType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonementLimitType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessCardType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessCardType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AbonementAgeCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Взрослый" },
                    { 2, "Детский" }
                });

            migrationBuilder.InsertData(
                table: "AbonementLimitType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ограниченный" },
                    { 2, "Безлимитный" }
                });

            migrationBuilder.InsertData(
                table: "AccessCardType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ограниченный" },
                    { 2, "Свободный" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbonementAgeCategory");

            migrationBuilder.DropTable(
                name: "AbonementLimitType");

            migrationBuilder.DropTable(
                name: "AccessCardType");
        }
    }
}
