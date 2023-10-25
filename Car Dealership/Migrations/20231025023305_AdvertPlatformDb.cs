using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_Dealership.Migrations
{
    /// <inheritdoc />
    public partial class AdvertPlatformDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Frequencies_Name",
                table: "Frequencies");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Frequencies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "AdvertisingPlatforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentAmount = table.Column<double>(type: "float", nullable: false),
                    FrequencyId = table.Column<int>(type: "int", nullable: false),
                    AddedById = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisingPlatforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertisingPlatforms_Frequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertisingPlatforms_Users_AddedById",
                        column: x => x.AddedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvertisingPlatforms_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisingPlatforms_AddedById",
                table: "AdvertisingPlatforms",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisingPlatforms_DeletedById",
                table: "AdvertisingPlatforms",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisingPlatforms_FrequencyId",
                table: "AdvertisingPlatforms",
                column: "FrequencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisingPlatforms");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Frequencies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Frequencies_Name",
                table: "Frequencies",
                column: "Name",
                unique: true);
        }
    }
}
