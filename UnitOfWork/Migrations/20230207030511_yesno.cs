using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class yesno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "yesno",
                table: "displayYesNo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "yesno",
                table: "displayYesNo");
        }
    }
}
