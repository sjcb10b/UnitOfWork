using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class orderscartsupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ccc_name",
                table: "ordersCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ccc_number",
                table: "ordersCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cvv",
                table: "ordersCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "expiration",
                table: "ordersCarts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ccc_name",
                table: "ordersCarts");

            migrationBuilder.DropColumn(
                name: "ccc_number",
                table: "ordersCarts");

            migrationBuilder.DropColumn(
                name: "cvv",
                table: "ordersCarts");

            migrationBuilder.DropColumn(
                name: "expiration",
                table: "ordersCarts");
        }
    }
}
