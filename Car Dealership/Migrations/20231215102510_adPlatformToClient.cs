using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_Dealership.Migrations
{
    /// <inheritdoc />
    public partial class adPlatformToClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SawAdvert",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "AdvertisingPlatformId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AdvertisingPlatformId",
                table: "Clients",
                column: "AdvertisingPlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AdvertisingPlatforms_AdvertisingPlatformId",
                table: "Clients",
                column: "AdvertisingPlatformId",
                principalTable: "AdvertisingPlatforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AdvertisingPlatforms_AdvertisingPlatformId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_AdvertisingPlatformId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "AdvertisingPlatformId",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "SawAdvert",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
