using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class newcolumn6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_orderedItems_nordersId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_nordersId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "nordersId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "ordersf",
                table: "orderedItems",
                newName: "forders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "forders",
                table: "orderedItems",
                newName: "ordersf");

            migrationBuilder.AddColumn<int>(
                name: "nordersId",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orders_nordersId",
                table: "orders",
                column: "nordersId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_orderedItems_nordersId",
                table: "orders",
                column: "nordersId",
                principalTable: "orderedItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
