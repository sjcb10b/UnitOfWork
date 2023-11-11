using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class ordereditems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productsoId = table.Column<int>(name: "products_oId", type: "int", nullable: false),
                    Amounto = table.Column<int>(name: "Amount_o", type: "int", nullable: false),
                    Qtyo = table.Column<int>(name: "Qty_o", type: "int", nullable: false),
                    ShoppingCartIdo = table.Column<string>(name: "ShoppingCartId_o", type: "nvarchar(max)", nullable: false),
                    options1o = table.Column<string>(name: "options1_o", type: "nvarchar(max)", nullable: true),
                    options2o = table.Column<string>(name: "options2_o", type: "nvarchar(max)", nullable: true),
                    options3o = table.Column<string>(name: "options3_o", type: "nvarchar(max)", nullable: true),
                    options4o = table.Column<string>(name: "options4_o", type: "nvarchar(max)", nullable: true),
                    options5o = table.Column<string>(name: "options5_o", type: "nvarchar(max)", nullable: true),
                    options6o = table.Column<string>(name: "options6_o", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderedItems_products_products_oId",
                        column: x => x.productsoId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderedItems_products_oId",
                table: "orderedItems",
                column: "products_oId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderedItems");
        }
    }
}
