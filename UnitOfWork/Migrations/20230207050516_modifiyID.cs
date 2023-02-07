using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class modifiyID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OID",
                table: "ProductOptions",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductOptions",
                newName: "OID");
        }
    }
}
