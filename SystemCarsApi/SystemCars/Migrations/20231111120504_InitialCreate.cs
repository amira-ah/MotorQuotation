using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemCars.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleQuotation",
                columns: table => new
                {
                    QuotationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PolicyOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarMake = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfMake = table.Column<int>(type: "int", nullable: false),
                    QuotationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleQuotation", x => x.QuotationNumber);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleQuotation");
        }
    }
}
