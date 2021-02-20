using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class EditScheduleEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "ScheduleEvents");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "ScheduleEvents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEvents_LocationId",
                table: "ScheduleEvents",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEvents_WorkoutGroupId",
                table: "ScheduleEvents",
                column: "WorkoutGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEvents_Locations_LocationId",
                table: "ScheduleEvents",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEvents_WorkoutGroups_WorkoutGroupId",
                table: "ScheduleEvents",
                column: "WorkoutGroupId",
                principalTable: "WorkoutGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEvents_Locations_LocationId",
                table: "ScheduleEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEvents_WorkoutGroups_WorkoutGroupId",
                table: "ScheduleEvents");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleEvents_LocationId",
                table: "ScheduleEvents");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleEvents_WorkoutGroupId",
                table: "ScheduleEvents");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "ScheduleEvents");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ScheduleEvents",
                type: "text",
                nullable: true);
        }
    }
}
