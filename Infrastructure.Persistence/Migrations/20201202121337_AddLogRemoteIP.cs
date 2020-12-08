using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddLogRemoteIP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "WorkoutGroupTrainers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedIp",
                table: "WorkoutGroupTrainers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "WorkoutGroups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedIp",
                table: "WorkoutGroups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "WorkoutGroupClients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedIp",
                table: "WorkoutGroupClients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "Workout",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedIp",
                table: "Workout",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedIp",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "UserRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedIp",
                table: "UserRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "TrainerSpecializations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedIp",
                table: "TrainerSpecializations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "Trainer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedIp",
                table: "Trainer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "Sports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedIp",
                table: "Sports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedIp",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedIp",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedIp",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "CountryCodes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedIp",
                table: "CountryCodes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "Abonements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedIp",
                table: "Abonements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkoutDescription",
                table: "Abonements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkoutName",
                table: "Abonements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "WorkoutGroupTrainers");

            migrationBuilder.DropColumn(
                name: "LastModifiedIp",
                table: "WorkoutGroupTrainers");

            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "WorkoutGroups");

            migrationBuilder.DropColumn(
                name: "LastModifiedIp",
                table: "WorkoutGroups");

            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "WorkoutGroupClients");

            migrationBuilder.DropColumn(
                name: "LastModifiedIp",
                table: "WorkoutGroupClients");

            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "LastModifiedIp",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastModifiedIp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "LastModifiedIp",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "TrainerSpecializations");

            migrationBuilder.DropColumn(
                name: "LastModifiedIp",
                table: "TrainerSpecializations");

            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "Trainer");

            migrationBuilder.DropColumn(
                name: "LastModifiedIp",
                table: "Trainer");

            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "LastModifiedIp",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "LastModifiedIp",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LastModifiedIp",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LastModifiedIp",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "CountryCodes");

            migrationBuilder.DropColumn(
                name: "LastModifiedIp",
                table: "CountryCodes");

            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "Abonements");

            migrationBuilder.DropColumn(
                name: "LastModifiedIp",
                table: "Abonements");

            migrationBuilder.DropColumn(
                name: "WorkoutDescription",
                table: "Abonements");

            migrationBuilder.DropColumn(
                name: "WorkoutName",
                table: "Abonements");
        }
    }
}
