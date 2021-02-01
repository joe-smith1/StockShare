using Microsoft.EntityFrameworkCore.Migrations;

namespace DataMigrations
{
    public partial class FavoriteStockTicker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Stocks_FavoriteStockId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavoriteStockId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "FavoriteStockId",
                table: "AspNetUsers",
                newName: "FavoriteStockTicker");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FavoriteStockTicker",
                table: "AspNetUsers",
                newName: "FavoriteStockId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavoriteStockId",
                table: "AspNetUsers",
                column: "FavoriteStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Stocks_FavoriteStockId",
                table: "AspNetUsers",
                column: "FavoriteStockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
