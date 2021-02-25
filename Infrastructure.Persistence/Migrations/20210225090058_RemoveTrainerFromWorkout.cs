using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class RemoveTrainerFromWorkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workout_Trainer_TrainerId",
                table: "Workout");

            migrationBuilder.DropIndex(
                name: "IX_Workout_TrainerId",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Workout");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Workout",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workout_TrainerId",
                table: "Workout",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_Trainer_TrainerId",
                table: "Workout",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
