using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Persistence.Migrations
{
    public partial class RemoveEntities_Trainer_SportType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWorkouts_Trainers_TrainerId",
                table: "GroupWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Sports_SportTypes_SportTypeId",
                table: "Sports");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerSpecializations_Trainers_TrainerId",
                table: "TrainerSpecializations");

            migrationBuilder.DropTable(
                name: "SportTypes");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Sports_SportTypeId",
                table: "Sports");

            migrationBuilder.DeleteData(
                table: "CountryCodes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CountryCodes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CountryCodes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CountryCodes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CountryCodes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CountryCodes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CountryCodes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CountryCodes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CountryCodes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CountryCodes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "SportTypeId",
                table: "Sports");

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PeopleAmount",
                table: "GroupWorkouts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "GroupWorkoutClients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(nullable: false),
                    GroupWorkoutId = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrainerId = table.Column<int>(nullable: false),
                    GroupWorkoutId = table.Column<int>(nullable: false)
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
                name: "IX_GroupWorkoutTrainers_GroupWorkoutId",
                table: "GroupWorkoutTrainers",
                column: "GroupWorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupWorkoutTrainers_TrainerId",
                table: "GroupWorkoutTrainers",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWorkouts_Users_TrainerId",
                table: "GroupWorkouts",
                column: "TrainerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerSpecializations_Users_TrainerId",
                table: "TrainerSpecializations",
                column: "TrainerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWorkouts_Users_TrainerId",
                table: "GroupWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerSpecializations_Users_TrainerId",
                table: "TrainerSpecializations");

            migrationBuilder.DropTable(
                name: "GroupWorkoutClients");

            migrationBuilder.DropTable(
                name: "GroupWorkoutTrainers");

            migrationBuilder.DropColumn(
                name: "Biography",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "SportTypeId",
                table: "Sports",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PeopleAmount",
                table: "GroupWorkouts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SportTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Biography = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CountryCodes",
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

            migrationBuilder.CreateIndex(
                name: "IX_Sports_SportTypeId",
                table: "Sports",
                column: "SportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_UserId",
                table: "Trainers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWorkouts_Trainers_TrainerId",
                table: "GroupWorkouts",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sports_SportTypes_SportTypeId",
                table: "Sports",
                column: "SportTypeId",
                principalTable: "SportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerSpecializations_Trainers_TrainerId",
                table: "TrainerSpecializations",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
