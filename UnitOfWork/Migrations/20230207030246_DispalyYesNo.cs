using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class DispalyYesNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YesNo",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "displayYesNo",
                columns: table => new
                {
                    Iyn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    optionsyesno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_displayYesNo", x => x.Iyn);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "displayYesNo");

            migrationBuilder.DropColumn(
                name: "YesNo",
                table: "products");
        }
    }
}
