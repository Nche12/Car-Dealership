using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_Dealership.Migrations
{
    /// <inheritdoc />
    public partial class colourToCarModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AdvertisingPlatforms_AdvertisingPlatformId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdvertisingPlatformId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CarColourId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarColourId",
                table: "Cars",
                column: "CarColourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AdvertisingPlatforms_AdvertisingPlatformId",
                table: "Cars",
                column: "AdvertisingPlatformId",
                principalTable: "AdvertisingPlatforms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarColours_CarColourId",
                table: "Cars",
                column: "CarColourId",
                principalTable: "CarColours",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AdvertisingPlatforms_AdvertisingPlatformId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarColours_CarColourId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarColourId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarColourId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdvertisingPlatformId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AdvertisingPlatforms_AdvertisingPlatformId",
                table: "Cars",
                column: "AdvertisingPlatformId",
                principalTable: "AdvertisingPlatforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
