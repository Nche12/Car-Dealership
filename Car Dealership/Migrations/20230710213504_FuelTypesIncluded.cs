using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_Dealership.Migrations
{
    /// <inheritdoc />
    public partial class FuelTypesIncluded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddedById = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuelTypes_Users_AddedById",
                        column: x => x.AddedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FuelTypes_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuelTypes_AddedById",
                table: "FuelTypes",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_FuelTypes_DeletedById",
                table: "FuelTypes",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_FuelTypes_Name",
                table: "FuelTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelTypes");
        }
    }
}
