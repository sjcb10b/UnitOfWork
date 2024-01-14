using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class totalamountorders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "orderedItems");

            migrationBuilder.AddColumn<int>(
                name: "TotalAmount",
                table: "orders",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "orders");

            migrationBuilder.AddColumn<int>(
                name: "TotalAmount",
                table: "orderedItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
