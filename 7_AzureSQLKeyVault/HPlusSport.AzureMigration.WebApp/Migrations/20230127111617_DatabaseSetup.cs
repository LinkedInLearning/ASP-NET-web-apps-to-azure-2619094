using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HPlusSport.AzureMigration.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Active Wear - Men" },
                    { 2, "Active Wear - Women" },
                    { 3, "Mineral Water" },
                    { 4, "Publications" },
                    { 5, "Supplements" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "IsAvailable", "Name", "Price", "Sku" },
                values: new object[,]
                {
                    { 1, 1, "", true, "Grunge Skater Jeans", 68m, "AWMGSJ" },
                    { 2, 1, "", true, "Polo Shirt", 35m, "AWMPS" },
                    { 3, 1, "", true, "Skater Graphic T-Shirt", 33m, "AWMSGT" },
                    { 4, 1, "", true, "Slicker Jacket", 125m, "AWMSJ" },
                    { 5, 1, "", true, "Thermal Fleece Jacket", 60m, "AWMTFJ" },
                    { 6, 1, "", true, "Unisex Thermal Vest", 95m, "AWMUTV" },
                    { 7, 1, "", true, "V-Neck Pullover", 65m, "AWMVNP" },
                    { 8, 1, "", true, "V-Neck Sweater", 65m, "AWMVNS" },
                    { 9, 1, "", true, "V-Neck T-Shirt", 17m, "AWMVNT" },
                    { 10, 2, "", true, "Bamboo Thermal Ski Coat", 99m, "AWWBTSC" },
                    { 11, 2, "", false, "Cross-Back Training Tank", 0m, "AWWCTT" },
                    { 12, 2, "", true, "Grunge Skater Jeans", 68m, "AWWGSJ" },
                    { 13, 2, "", true, "Slicker Jacket", 125m, "AWWSJ" },
                    { 14, 2, "", true, "Stretchy Dance Pants", 55m, "AWWSDP" },
                    { 15, 2, "", true, "Ultra-Soft Tank Top", 22m, "AWWUTT" },
                    { 16, 2, "", true, "Unisex Thermal Vest", 95m, "AWWUTV" },
                    { 17, 2, "", true, "V-Next T-Shirt", 17m, "AWWVNT" },
                    { 18, 3, "", true, "Blueberry Mineral Water", 2.8m, "MWB" },
                    { 19, 3, "", true, "Lemon-Lime Mineral Water", 2.8m, "MWLL" },
                    { 20, 3, "", true, "Orange Mineral Water", 2.8m, "MWO" },
                    { 21, 3, "", true, "Peach Mineral Water", 2.8m, "MWP" },
                    { 22, 3, "", true, "Raspberry Mineral Water", 2.8m, "MWR" },
                    { 23, 3, "", true, "Strawberry Mineral Water", 2.8m, "MWS" },
                    { 24, 4, "", true, "In the Kitchen with H+ Sport", 24.99m, "PITK" },
                    { 25, 5, "", true, "Calcium 400 IU (150 tablets)", 9.99m, "SC400" },
                    { 26, 5, "", true, "Flaxseed Oil 100 mg (90 capsules)", 12.49m, "SFO100" },
                    { 27, 5, "", true, "Iron 65 mg (150 caplets)", 13.99m, "SI65" },
                    { 28, 5, "", true, "Magnesium 250 mg (100 tablets)", 12.49m, "SM250" },
                    { 29, 5, "", true, "Multi-Vitamin (90 capsules)", 9.99m, "SMV" },
                    { 30, 5, "", true, "Vitamin A 10,000 IU (125 caplets)", 11.99m, "SVA" },
                    { 31, 5, "", true, "Vitamin B-Complex (100 caplets)", 12.99m, "SVB" },
                    { 32, 5, "", true, "Vitamin C 1000 mg (100 tablets)", 9.99m, "SVC" },
                    { 33, 5, "", true, "Vitamin D3 1000 IU (100 tablets)", 12.49m, "SVD3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
