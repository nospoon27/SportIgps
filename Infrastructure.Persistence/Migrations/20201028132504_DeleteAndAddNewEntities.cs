using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Persistence.Migrations
{
    public partial class DeleteAndAddNewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainerSpecializations_Users_TrainerId",
                table: "TrainerSpecializations");

            migrationBuilder.DropTable(
                name: "AbonementAgeCategory");

            migrationBuilder.DropTable(
                name: "AbonementLimitType");

            migrationBuilder.DropTable(
                name: "AccessCardType");

            migrationBuilder.DropTable(
                name: "GroupWorkoutClients");

            migrationBuilder.DropTable(
                name: "GroupWorkoutTrainers");

            migrationBuilder.DropTable(
                name: "PersonalWorkouts");

            migrationBuilder.DropTable(
                name: "GroupWorkouts");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutGroupId",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AbonementLimits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VisitAmount = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonementLimits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    CanBePersonal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainer_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false),
                    SportId = table.Column<int>(nullable: false),
                    WorkoutGroupId = table.Column<int>(nullable: false),
                    TrainerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workout_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workout_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workout_Trainer_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workout_WorkoutGroups_WorkoutGroupId",
                        column: x => x.WorkoutGroupId,
                        principalTable: "WorkoutGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutGroupClients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    WorkoutGroupId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutGroupClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutGroupClients_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutGroupClients_WorkoutGroups_WorkoutGroupId",
                        column: x => x.WorkoutGroupId,
                        principalTable: "WorkoutGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutGroupTrainers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    WorkoutGroupId = table.Column<int>(nullable: false),
                    TrainerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutGroupTrainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutGroupTrainers_Trainer_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutGroupTrainers_WorkoutGroups_WorkoutGroupId",
                        column: x => x.WorkoutGroupId,
                        principalTable: "WorkoutGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abonements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    IsChild = table.Column<bool>(nullable: false),
                    AbonementLimitId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    WorkoutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abonements_AbonementLimits_AbonementLimitId",
                        column: x => x.AbonementLimitId,
                        principalTable: "AbonementLimits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Abonements_Workout_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_WorkoutGroupId",
                table: "Schedules",
                column: "WorkoutGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Abonements_AbonementLimitId",
                table: "Abonements",
                column: "AbonementLimitId");

            migrationBuilder.CreateIndex(
                name: "IX_Abonements_WorkoutId",
                table: "Abonements",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_UserId",
                table: "Trainer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_LocationId",
                table: "Workout",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_SportId",
                table: "Workout",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_TrainerId",
                table: "Workout",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_WorkoutGroupId",
                table: "Workout",
                column: "WorkoutGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutGroupClients_ClientId",
                table: "WorkoutGroupClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutGroupClients_WorkoutGroupId",
                table: "WorkoutGroupClients",
                column: "WorkoutGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutGroupTrainers_TrainerId",
                table: "WorkoutGroupTrainers",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutGroupTrainers_WorkoutGroupId",
                table: "WorkoutGroupTrainers",
                column: "WorkoutGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_WorkoutGroups_WorkoutGroupId",
                table: "Schedules",
                column: "WorkoutGroupId",
                principalTable: "WorkoutGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerSpecializations_Trainer_TrainerId",
                table: "TrainerSpecializations",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_WorkoutGroups_WorkoutGroupId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerSpecializations_Trainer_TrainerId",
                table: "TrainerSpecializations");

            migrationBuilder.DropTable(
                name: "Abonements");

            migrationBuilder.DropTable(
                name: "WorkoutGroupClients");

            migrationBuilder.DropTable(
                name: "WorkoutGroupTrainers");

            migrationBuilder.DropTable(
                name: "AbonementLimits");

            migrationBuilder.DropTable(
                name: "Workout");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropTable(
                name: "WorkoutGroups");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_WorkoutGroupId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "WorkoutGroupId",
                table: "Schedules");

            migrationBuilder.CreateTable(
                name: "AbonementAgeCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonementAgeCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbonementLimitType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonementLimitType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessCardType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessCardType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "integer", nullable: true),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalWorkouts_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SportId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    Duration = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "integer", nullable: true),
                    PeopleAmount = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    SectionId = table.Column<int>(type: "integer", nullable: false),
                    TrainerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupWorkouts_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupWorkouts_Users_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupWorkoutClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    GroupWorkoutId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupWorkoutClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupWorkoutClients_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupWorkoutClients_GroupWorkouts_GroupWorkoutId",
                        column: x => x.GroupWorkoutId,
                        principalTable: "GroupWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupWorkoutTrainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupWorkoutId = table.Column<int>(type: "integer", nullable: false),
                    TrainerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupWorkoutTrainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupWorkoutTrainers_GroupWorkouts_GroupWorkoutId",
                        column: x => x.GroupWorkoutId,
                        principalTable: "GroupWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupWorkoutTrainers_Users_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupWorkoutClients_ClientId",
                table: "GroupWorkoutClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupWorkoutClients_GroupWorkoutId",
                table: "GroupWorkoutClients",
                column: "GroupWorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupWorkouts_SectionId",
                table: "GroupWorkouts",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupWorkouts_TrainerId",
                table: "GroupWorkouts",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupWorkoutTrainers_GroupWorkoutId",
                table: "GroupWorkoutTrainers",
                column: "GroupWorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupWorkoutTrainers_TrainerId",
                table: "GroupWorkoutTrainers",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalWorkouts_LocationId",
                table: "PersonalWorkouts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SportId",
                table: "Sections",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerSpecializations_Users_TrainerId",
                table: "TrainerSpecializations",
                column: "TrainerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
