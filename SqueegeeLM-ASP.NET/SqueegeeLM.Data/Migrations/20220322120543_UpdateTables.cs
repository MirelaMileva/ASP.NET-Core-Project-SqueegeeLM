using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqueegeeLM.Web.Data.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appoitments_Customers_CustomerId",
                table: "Appoitments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_CleaningCategories_CleaningCategoryId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Frequencies_FrequencyId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_PropertyCategories_PropertyCategoryId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Appoitments_CustomerId",
                table: "Appoitments");

            migrationBuilder.RenameColumn(
                name: "BedroomCount",
                table: "PropertyCategories",
                newName: "PropertyRooms");

            migrationBuilder.AddForeignKey(
                name: "FK_Appoitments_Customers_AreaId",
                table: "Appoitments",
                column: "AreaId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                table: "Reviews",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_CleaningCategories_CleaningCategoryId",
                table: "Services",
                column: "CleaningCategoryId",
                principalTable: "CleaningCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Frequencies_FrequencyId",
                table: "Services",
                column: "FrequencyId",
                principalTable: "Frequencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_PropertyCategories_PropertyCategoryId",
                table: "Services",
                column: "PropertyCategoryId",
                principalTable: "PropertyCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appoitments_Customers_AreaId",
                table: "Appoitments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_CleaningCategories_CleaningCategoryId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Frequencies_FrequencyId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_PropertyCategories_PropertyCategoryId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "PropertyRooms",
                table: "PropertyCategories",
                newName: "BedroomCount");

            migrationBuilder.CreateIndex(
                name: "IX_Appoitments_CustomerId",
                table: "Appoitments",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appoitments_Customers_CustomerId",
                table: "Appoitments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                table: "Reviews",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_CleaningCategories_CleaningCategoryId",
                table: "Services",
                column: "CleaningCategoryId",
                principalTable: "CleaningCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Frequencies_FrequencyId",
                table: "Services",
                column: "FrequencyId",
                principalTable: "Frequencies",
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
    }
}
