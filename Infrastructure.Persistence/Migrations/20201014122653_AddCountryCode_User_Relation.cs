using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddCountryCode_User_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CountryCodes_CountryCodeId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "CountryCodeId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CountryCodes_CountryCodeId",
                table: "Users",
                column: "CountryCodeId",
                principalTable: "CountryCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CountryCodes_CountryCodeId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "CountryCodeId",
                table: "Users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CountryCodes_CountryCodeId",
                table: "Users",
                column: "CountryCodeId",
                principalTable: "CountryCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
