using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_Dealership.Migrations
{
    /// <inheritdoc />
    public partial class AuditableIncluded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedById",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddedById",
                table: "UserRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "UserRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "UserRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "UserRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserRoles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "UserRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddedById",
                table: "CarModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "CarModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "CarModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "CarModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CarModels",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "CarModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddedById",
                table: "CarMakes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "CarMakes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "CarMakes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "CarMakes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CarMakes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "CarMakes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddedById",
                table: "Users",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedById",
                table: "Users",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_AddedById",
                table: "UserRoles",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_DeletedById",
                table: "UserRoles",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_AddedById",
                table: "CarModels",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_DeletedById",
                table: "CarModels",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CarMakes_AddedById",
                table: "CarMakes",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_CarMakes_DeletedById",
                table: "CarMakes",
                column: "DeletedById");

            migrationBuilder.AddForeignKey(
                name: "FK_CarMakes_Users_AddedById",
                table: "CarMakes",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarMakes_Users_DeletedById",
                table: "CarMakes",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Users_AddedById",
                table: "CarModels",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Users_DeletedById",
                table: "CarModels",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_AddedById",
                table: "UserRoles",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_DeletedById",
                table: "UserRoles",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_AddedById",
                table: "Users",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_DeletedById",
                table: "Users",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarMakes_Users_AddedById",
                table: "CarMakes");

            migrationBuilder.DropForeignKey(
                name: "FK_CarMakes_Users_DeletedById",
                table: "CarMakes");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Users_AddedById",
                table: "CarModels");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Users_DeletedById",
                table: "CarModels");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_AddedById",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_DeletedById",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_AddedById",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_DeletedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DeletedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_AddedById",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_DeletedById",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_AddedById",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_DeletedById",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarMakes_AddedById",
                table: "CarMakes");

            migrationBuilder.DropIndex(
                name: "IX_CarMakes_DeletedById",
                table: "CarMakes");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "CarMakes");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "CarMakes");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "CarMakes");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "CarMakes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CarMakes");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "CarMakes");
        }
    }
}
