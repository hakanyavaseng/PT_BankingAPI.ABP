using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Piton.Banking.Migrations
{
    /// <inheritdoc />
    public partial class sequence_addded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "BankingAccounts",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR AccountNumberSequence",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValueSql: "SELECT NEXT VALUE FOR AccountNumberSequence");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "BankingAccounts",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "SELECT NEXT VALUE FOR AccountNumberSequence",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValueSql: "NEXT VALUE FOR AccountNumberSequence");
        }
    }
}
