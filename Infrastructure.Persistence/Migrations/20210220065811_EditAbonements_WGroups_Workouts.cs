using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class EditAbonements_WGroups_Workouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abonements_Workout_WorkoutId",
                table: "Abonements");

            migrationBuilder.DropForeignKey(
                name: "FK_Workout_WorkoutGroups_WorkoutGroupId",
                table: "Workout");

            migrationBuilder.DropIndex(
                name: "IX_Workout_WorkoutGroupId",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "WorkoutGroupId",
                table: "Workout");

            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "WorkoutGroups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "Abonements",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutGroupId",
                table: "Abonements",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutGroups_SportId",
                table: "WorkoutGroups",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Abonements_WorkoutGroupId",
                table: "Abonements",
                column: "WorkoutGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abonements_Workout_WorkoutId",
                table: "Abonements",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Abonements_WorkoutGroups_WorkoutGroupId",
                table: "Abonements",
                column: "WorkoutGroupId",
                principalTable: "WorkoutGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutGroups_Sports_SportId",
                table: "WorkoutGroups",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abonements_Workout_WorkoutId",
                table: "Abonements");

            migrationBuilder.DropForeignKey(
                name: "FK_Abonements_WorkoutGroups_WorkoutGroupId",
                table: "Abonements");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutGroups_Sports_SportId",
                table: "WorkoutGroups");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutGroups_SportId",
                table: "WorkoutGroups");

            migrationBuilder.DropIndex(
                name: "IX_Abonements_WorkoutGroupId",
                table: "Abonements");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "WorkoutGroups");

            migrationBuilder.DropColumn(
                name: "WorkoutGroupId",
                table: "Abonements");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutGroupId",
                table: "Workout",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "Abonements",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workout_WorkoutGroupId",
                table: "Workout",
                column: "WorkoutGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abonements_Workout_WorkoutId",
                table: "Abonements",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_WorkoutGroups_WorkoutGroupId",
                table: "Workout",
                column: "WorkoutGroupId",
                principalTable: "WorkoutGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
