using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_Dealership.Migrations
{
    /// <inheritdoc />
    public partial class ContactTblUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankAccountId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BankAccountId1",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_BankAccountId1",
                table: "Contacts",
                column: "BankAccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_BankAccounts_BankAccountId1",
                table: "Contacts",
                column: "BankAccountId1",
                principalTable: "BankAccounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_BankAccounts_BankAccountId1",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_BankAccountId1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "BankAccountId1",
                table: "Contacts");
        }
    }
}
