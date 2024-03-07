using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace labbVG.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyAttempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserProduct",
                columns: table => new
                {
                    ProductsInCartId = table.Column<int>(type: "int", nullable: false),
                    usersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserProduct", x => new { x.ProductsInCartId, x.usersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserProduct_AspNetUsers_usersId",
                        column: x => x.usersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserProduct_Products_ProductsInCartId",
                        column: x => x.ProductsInCartId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserProduct_usersId",
                table: "ApplicationUserProduct",
                column: "usersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserProduct");
        }
    }
}
