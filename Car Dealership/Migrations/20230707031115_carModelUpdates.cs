using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_Dealership.Migrations
{
    /// <inheritdoc />
    public partial class carModelUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_CarMakeGetDto_CarMakeId",
                table: "CarModels");

            migrationBuilder.DropTable(
                name: "CarMakeGetDto");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_CarMakes_CarMakeId",
                table: "CarModels",
                column: "CarMakeId",
                principalTable: "CarMakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_CarMakes_CarMakeId",
                table: "CarModels");

            migrationBuilder.CreateTable(
                name: "CarMakeGetDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMakeGetDto", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_CarMakeGetDto_CarMakeId",
                table: "CarModels",
                column: "CarMakeId",
                principalTable: "CarMakeGetDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
