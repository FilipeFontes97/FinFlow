using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedExpenseschangepaymentdayfieldtoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "FixedExpenses");

            migrationBuilder.AddColumn<int>(
                name: "PaymentDay",
                table: "FixedExpenses",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentDay",
                table: "FixedExpenses");

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "FixedExpenses",
                type: "datetime2",
                nullable: true);
        }
    }
}
