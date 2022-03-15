using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqueegeeLM.Web.Data.Migrations
{
    public partial class CleaningCategoryPropertyCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "PropertyType",
                table: "Services",
                newName: "PropertyCategoryId");

            migrationBuilder.RenameColumn(
                name: "CleaningType",
                table: "Services",
                newName: "CleaningCategoryId");

            migrationBuilder.CreateTable(
                name: "CleaningCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CleaningType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BedroomCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_CleaningCategoryId",
                table: "Services",
                column: "CleaningCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_PropertyCategoryId",
                table: "Services",
                column: "PropertyCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_CleaningCategories_CleaningCategoryId",
                table: "Services",
                column: "CleaningCategoryId",
                principalTable: "CleaningCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_PropertyCategories_PropertyCategoryId",
                table: "Services",
                column: "PropertyCategoryId",
                principalTable: "PropertyCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_CleaningCategories_CleaningCategoryId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_PropertyCategories_PropertyCategoryId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "CleaningCategories");

            migrationBuilder.DropTable(
                name: "PropertyCategories");

            migrationBuilder.DropIndex(
                name: "IX_Services_CleaningCategoryId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_PropertyCategoryId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "PropertyCategoryId",
                table: "Services",
                newName: "PropertyType");

            migrationBuilder.RenameColumn(
                name: "CleaningCategoryId",
                table: "Services",
                newName: "CleaningType");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Services",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
