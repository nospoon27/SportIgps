using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class Edit_UserPhotos_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPhotos_Users_UserId",
                table: "UserPhotos");

            migrationBuilder.RenameColumn(
                name: "Small",
                table: "UserPhotos",
                newName: "SmallUrl");

            migrationBuilder.RenameColumn(
                name: "Default",
                table: "UserPhotos",
                newName: "SmallPath");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserPhotos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultPath",
                table: "UserPhotos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultUrl",
                table: "UserPhotos",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhotos_Users_UserId",
                table: "UserPhotos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPhotos_Users_UserId",
                table: "UserPhotos");

            migrationBuilder.DropColumn(
                name: "DefaultPath",
                table: "UserPhotos");

            migrationBuilder.DropColumn(
                name: "DefaultUrl",
                table: "UserPhotos");

            migrationBuilder.RenameColumn(
                name: "SmallUrl",
                table: "UserPhotos",
                newName: "Small");

            migrationBuilder.RenameColumn(
                name: "SmallPath",
                table: "UserPhotos",
                newName: "Default");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserPhotos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhotos_Users_UserId",
                table: "UserPhotos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
