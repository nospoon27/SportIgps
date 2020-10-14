using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryCode",
                table: "CountryCode");

            migrationBuilder.RenameTable(
                name: "CountryCode",
                newName: "CountryCodes");

            migrationBuilder.AddColumn<int>(
                name: "CountryCodeId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryCodes",
                table: "CountryCodes",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryCodeId",
                table: "Users",
                column: "CountryCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CountryCodes_CountryCodeId",
                table: "Users",
                column: "CountryCodeId",
                principalTable: "CountryCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CountryCodes_CountryCodeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AbonementAgeCategory");

            migrationBuilder.DropTable(
                name: "AbonementLimitType");

            migrationBuilder.DropTable(
                name: "AccessCardType");

            migrationBuilder.DropIndex(
                name: "IX_Users_CountryCodeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryCodes",
                table: "CountryCodes");

            migrationBuilder.DropColumn(
                name: "CountryCodeId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "CountryCodes",
                newName: "CountryCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryCode",
                table: "CountryCode",
                column: "Id");
        }
    }
}
