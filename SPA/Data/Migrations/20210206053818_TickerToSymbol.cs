using Microsoft.EntityFrameworkCore.Migrations;

namespace DataMigrations
{
    public partial class TickerToSymbol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FavoriteStockTicker",
                table: "AspNetUsers",
                newName: "FavoriteStockSymbol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FavoriteStockSymbol",
                table: "AspNetUsers",
                newName: "FavoriteStockTicker");
        }
    }
}
