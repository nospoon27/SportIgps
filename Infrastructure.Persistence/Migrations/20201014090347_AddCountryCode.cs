using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddCountryCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryCode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(nullable: true),
                    ISOName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCode", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CountryCode",
                columns: new[] { "Id", "Code", "ISOName" },
                values: new object[,]
                {
                    { 1, "+7", "RUS" },
                    { 2, "+380", "UKR" },
                    { 3, "+374", "ARM" },
                    { 4, "+994", "AZE" },
                    { 5, "+375", "BLR" },
                    { 6, "+359", "BGR" },
                    { 7, "+7", "KAZ" },
                    { 8, "+996", "KGZ" },
                    { 9, "+381", "SRB" },
                    { 10, "+82", "KOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryCode");
        }
    }
}
