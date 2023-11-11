using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstNameo = table.Column<string>(name: "FirstName_o", type: "nvarchar(max)", nullable: true),
                    LastNameo = table.Column<string>(name: "LastName_o", type: "nvarchar(max)", nullable: true),
                    Companyo = table.Column<string>(name: "Company_o", type: "nvarchar(max)", nullable: true),
                    Streeto = table.Column<string>(name: "Street_o", type: "nvarchar(max)", nullable: true),
                    Cityo = table.Column<string>(name: "City_o", type: "nvarchar(max)", nullable: true),
                    Stateo = table.Column<string>(name: "State_o", type: "nvarchar(max)", nullable: true),
                    ZipCodeo = table.Column<string>(name: "ZipCode_o", type: "nvarchar(max)", nullable: true),
                    Phoneo = table.Column<string>(name: "Phone_o", type: "nvarchar(max)", nullable: true),
                    cccnameo = table.Column<string>(name: "ccc_name_o", type: "nvarchar(max)", nullable: true),
                    cccnumbero = table.Column<string>(name: "ccc_number_o", type: "nvarchar(max)", nullable: true),
                    expirationo = table.Column<string>(name: "expiration_o", type: "nvarchar(max)", nullable: true),
                    cvvo = table.Column<string>(name: "cvv_o", type: "nvarchar(max)", nullable: true),
                    ShoppingCartIdCustomero = table.Column<string>(name: "ShoppingCartIdCustomer_o", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
