using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Piton.Banking.Migrations
{
    /// <inheritdoc />
    public partial class sequence_addded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "AccountNumberSequence",
                startValue: 1000000000L);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "BankingCustomers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "BankingAccounts",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR AccountNumberSequence",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateIndex(
                name: "IX_BankingCustomers_IdentityNumber",
                table: "BankingCustomers",
                column: "IdentityNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BankingCustomers_IdentityNumber",
                table: "BankingCustomers");

            migrationBuilder.DropSequence(
                name: "AccountNumberSequence");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "BankingCustomers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "BankingAccounts",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValueSql: "SELECT NEXT VALUE FOR AccountNumberSequence");
        }
    }
}
