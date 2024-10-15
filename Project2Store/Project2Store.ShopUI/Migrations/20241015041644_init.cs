using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2Store.ShopUI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Mobile", "Ram 8 Hard 254", "Samsung A54", 12000000 },
                    { 2L, "Mobile", "Ram 4 Hard 254", "Samsung A52", 10000000 },
                    { 3L, "Mobile", "Ram 2 Hard 254", "Samsung A50", 8000000 },
                    { 4L, "Mobile", "Ram 2 Hard 54", "Samsung A32", 5000000 },
                    { 5L, "Laptop", "ram 18 254gb", "Asus vivabook515", 40000000 },
                    { 6L, "Laptop", "ram 32 254gb", "Asus vivabook515xf", 45000000 },
                    { 7L, "Laptop", "ram 32 128gb", "Asus vivabook400xf", 35000000 },
                    { 8L, "PC", "1056 * 1000 HZ", "Monitor Apple", 10000000 },
                    { 9L, "PC", "5056 * 3000 HZ", "Monitor Dc", 20000000 },
                    { 10L, "PC", "2056 * 3000 HZ", "Monitor Samsung", 15000000 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
