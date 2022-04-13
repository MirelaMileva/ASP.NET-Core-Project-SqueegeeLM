using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqueegeeLM.Data.Migrations
{
    public partial class AddCustomerIdToServiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Appoitments");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Services");

            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "Appoitments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
