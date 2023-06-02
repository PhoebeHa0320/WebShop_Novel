using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShopNovel.Migrations
{
    public partial class PublisherModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Cart1",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Cart",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CartID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Account_CartID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "CartID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CartID",
                table: "Account");

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.PublisherId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_PublisherId",
                table: "Product",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Publisher",
                table: "Product",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Publisher",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_Product_PublisherId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "CartID",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartID",
                table: "Account",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CartID",
                table: "Customers",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_Account_CartID",
                table: "Account",
                column: "CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Cart1",
                table: "Account",
                column: "CartID",
                principalTable: "Cart",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Cart",
                table: "Customers",
                column: "CartID",
                principalTable: "Cart",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
