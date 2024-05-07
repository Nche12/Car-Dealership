using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_Dealership.Migrations
{
    /// <inheritdoc />
    public partial class NullableColourId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarColours_CarColourId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "CarColourId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarColours_CarColourId",
                table: "Cars",
                column: "CarColourId",
                principalTable: "CarColours",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarColours_CarColourId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "CarColourId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarColours_CarColourId",
                table: "Cars",
                column: "CarColourId",
                principalTable: "CarColours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
