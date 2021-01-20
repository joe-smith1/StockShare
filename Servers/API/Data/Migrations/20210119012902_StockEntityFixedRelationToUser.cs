using Microsoft.EntityFrameworkCore.Migrations;

namespace DataMigrations
{
    public partial class StockEntityFixedRelationToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_AspNetRoles_ApplicationRoleId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_ApplicationRoleId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "ApplicationRoleId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "FavoriteStock",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ExchangeMarket",
                table: "Stock",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavoriteStockId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavoriteStockId",
                table: "AspNetUsers",
                column: "FavoriteStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Stock_FavoriteStockId",
                table: "AspNetUsers",
                column: "FavoriteStockId",
                principalTable: "Stock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Stock_FavoriteStockId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavoriteStockId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ExchangeMarket",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "FavoriteStockId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationRoleId",
                table: "Stock",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavoriteStock",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ApplicationRoleId",
                table: "Stock",
                column: "ApplicationRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_AspNetRoles_ApplicationRoleId",
                table: "Stock",
                column: "ApplicationRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
