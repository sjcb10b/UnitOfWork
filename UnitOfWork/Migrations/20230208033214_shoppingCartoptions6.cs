using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class shoppingCartoptions6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "options",
                table: "shoppingCartItems",
                newName: "options6");

            migrationBuilder.AddColumn<string>(
                name: "options1",
                table: "shoppingCartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "options2",
                table: "shoppingCartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "options3",
                table: "shoppingCartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "options4",
                table: "shoppingCartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "options5",
                table: "shoppingCartItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "options1",
                table: "shoppingCartItems");

            migrationBuilder.DropColumn(
                name: "options2",
                table: "shoppingCartItems");

            migrationBuilder.DropColumn(
                name: "options3",
                table: "shoppingCartItems");

            migrationBuilder.DropColumn(
                name: "options4",
                table: "shoppingCartItems");

            migrationBuilder.DropColumn(
                name: "options5",
                table: "shoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "options6",
                table: "shoppingCartItems",
                newName: "options");
        }
    }
}
