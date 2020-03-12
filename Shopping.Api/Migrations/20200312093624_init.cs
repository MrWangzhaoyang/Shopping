using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    ProductImage = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    OrgPrice = table.Column<decimal>(nullable: false),
                    Decoration = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    ClickTimes = table.Column<double>(nullable: false),
                    SaleTimes = table.Column<double>(nullable: false),
                    IsDel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Propertys = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    ProductImage = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    IsDel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");
        }
    }
}
