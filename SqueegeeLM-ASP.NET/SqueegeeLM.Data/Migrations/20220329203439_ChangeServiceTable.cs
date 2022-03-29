using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqueegeeLM.Web.Data.Migrations
{
    public partial class ChangeServiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CleaningType",
                table: "CleaningCategories");

            migrationBuilder.AddColumn<int>(
                name: "CleaningType",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CleaningType",
                table: "Services");

            migrationBuilder.AddColumn<int>(
                name: "CleaningType",
                table: "CleaningCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
