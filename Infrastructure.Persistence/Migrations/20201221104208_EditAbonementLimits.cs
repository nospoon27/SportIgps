using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class EditAbonementLimits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkoutDescription",
                table: "Abonements");

            migrationBuilder.DropColumn(
                name: "WorkoutName",
                table: "Abonements");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "AbonementLimits",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "AbonementLimits",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedIp",
                table: "AbonementLimits",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "AbonementLimits",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "AbonementLimits",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedIp",
                table: "AbonementLimits",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "AbonementLimits");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AbonementLimits");

            migrationBuilder.DropColumn(
                name: "CreatedIp",
                table: "AbonementLimits");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "AbonementLimits");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "AbonementLimits");

            migrationBuilder.DropColumn(
                name: "LastModifiedIp",
                table: "AbonementLimits");

            migrationBuilder.AddColumn<string>(
                name: "WorkoutDescription",
                table: "Abonements",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkoutName",
                table: "Abonements",
                type: "text",
                nullable: true);
        }
    }
}
