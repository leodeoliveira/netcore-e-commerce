using Microsoft.EntityFrameworkCore.Migrations;

namespace LeoShop.Migrations
{
    public partial class SeedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "A good category", "Cat 1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "A good category", "Cat 2" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "A good category", "Cat 3" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AllergyInformation", "CategoryId", "HasStock", "ImageThumbnailUrl", "ImageUrl", "IsOnSale", "LongDescription", "Name", "Price", "ShortDescription" },
                values: new object[,]
                {
                    { 1, null, 1, true, "https://images.unsplash.com/photo-1583743814966-8936f5b7be1a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=200&q=80", null, false, null, "Prod 1", 12.949999999999999, "A good product" },
                    { 2, null, 1, true, "https://images.unsplash.com/photo-1583743814966-8936f5b7be1a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=200&q=80", null, false, null, "Prod 2", 17.149999999999999, "A good product" },
                    { 3, null, 2, true, "https://images.unsplash.com/photo-1583743814966-8936f5b7be1a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=200&q=80", null, false, null, "Prod 3", 22.949999999999999, "A good product" },
                    { 4, null, 3, true, "https://images.unsplash.com/photo-1583743814966-8936f5b7be1a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=200&q=80", null, false, null, "Prod 4", 27.75, "A good product" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
