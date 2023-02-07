using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class productsOptionsA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductOptions",
                columns: table => new
                {
                    OID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    option11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    option22 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    option33 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    option44 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    option55 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    option66 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptions", x => x.OID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOptions");
        }
    }
}
