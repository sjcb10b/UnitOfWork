using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class productsOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Option1",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option2",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option3",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option4",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option5",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option6",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Option1",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Option2",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Option3",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Option4",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Option5",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Option6",
                table: "products");
        }
    }
}
