using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddScheduleEvent_EditWorkoutGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "WorkoutGroups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleEventId",
                table: "Trainer",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ScheduleEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WorkoutGroupId = table.Column<int>(type: "integer", nullable: false),
                    TrainerMembershipIsChanged = table.Column<bool>(type: "boolean", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedIp = table.Column<string>(type: "text", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "integer", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedIp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleEventTrainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScheduleEventId = table.Column<int>(type: "integer", nullable: false),
                    TrainerId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedIp = table.Column<string>(type: "text", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "integer", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedIp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleEventTrainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleEventTrainers_ScheduleEvents_ScheduleEventId",
                        column: x => x.ScheduleEventId,
                        principalTable: "ScheduleEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleEventTrainers_Trainer_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutGroups_LocationId",
                table: "WorkoutGroups",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_ScheduleEventId",
                table: "Trainer",
                column: "ScheduleEventId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEventTrainers_ScheduleEventId",
                table: "ScheduleEventTrainers",
                column: "ScheduleEventId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEventTrainers_TrainerId",
                table: "ScheduleEventTrainers",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainer_ScheduleEvents_ScheduleEventId",
                table: "Trainer",
                column: "ScheduleEventId",
                principalTable: "ScheduleEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutGroups_Locations_LocationId",
                table: "WorkoutGroups",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_ScheduleEvents_ScheduleEventId",
                table: "Trainer");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutGroups_Locations_LocationId",
                table: "WorkoutGroups");

            migrationBuilder.DropTable(
                name: "ScheduleEventTrainers");

            migrationBuilder.DropTable(
                name: "ScheduleEvents");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutGroups_LocationId",
                table: "WorkoutGroups");

            migrationBuilder.DropIndex(
                name: "IX_Trainer_ScheduleEventId",
                table: "Trainer");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "WorkoutGroups");

            migrationBuilder.DropColumn(
                name: "ScheduleEventId",
                table: "Trainer");
        }
    }
}
