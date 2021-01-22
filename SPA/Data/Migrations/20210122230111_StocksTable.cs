using Microsoft.EntityFrameworkCore.Migrations;

namespace DataMigrations
{
    public partial class StocksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Stock_FavoriteStockId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_AspNetUsers_UserId",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.RenameTable(
                name: "Stock",
                newName: "Stocks");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_UserId",
                table: "Stocks",
                newName: "IX_Stocks_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Stocks_FavoriteStockId",
                table: "AspNetUsers",
                column: "FavoriteStockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_AspNetUsers_UserId",
                table: "Stocks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Stocks_FavoriteStockId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_AspNetUsers_UserId",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "Stock");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_UserId",
                table: "Stock",
                newName: "IX_Stock_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Stock_FavoriteStockId",
                table: "AspNetUsers",
                column: "FavoriteStockId",
                principalTable: "Stock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_AspNetUsers_UserId",
                table: "Stock",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
