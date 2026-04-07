using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addedinvestmenttransactionacount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "FinancialAccounts");

            migrationBuilder.CreateTable(
                name: "InvestmentTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvestmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentTransactions_FinancialAccounts_FinancialAccountId",
                        column: x => x.FinancialAccountId,
                        principalTable: "FinancialAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentTransactions_FinancialAccountId",
                table: "InvestmentTransactions",
                column: "FinancialAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentTransactions");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "FinancialAccounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
