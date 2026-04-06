using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedcolumntofixedFixedExpenses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "FixedExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "FixedExpenses");
        }
    }
}
