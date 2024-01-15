using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class newcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "nordersId",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ordersf",
                table: "orderedItems",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ordersf",
                table: "orderedItems");
        }
    }
}
