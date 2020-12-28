using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AbonementLimit_Is_Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abonements_AbonementLimits_AbonementLimitId",
                table: "Abonements");

            migrationBuilder.AlterColumn<int>(
                name: "AbonementLimitId",
                table: "Abonements",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Abonements_AbonementLimits_AbonementLimitId",
                table: "Abonements",
                column: "AbonementLimitId",
                principalTable: "AbonementLimits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abonements_AbonementLimits_AbonementLimitId",
                table: "Abonements");

            migrationBuilder.AlterColumn<int>(
                name: "AbonementLimitId",
                table: "Abonements",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Abonements_AbonementLimits_AbonementLimitId",
                table: "Abonements",
                column: "AbonementLimitId",
                principalTable: "AbonementLimits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
