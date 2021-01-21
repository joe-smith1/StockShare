using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataMigrations
{
    public partial class ModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavoriteMarket",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FavoriteStockId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvestmentOrientation",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<uint>(
                name: "Points",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<bool>(
                name: "PrivateAccount",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProfileDescription",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProfitLoss",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "SignUpDate",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalInvested",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Ticker = table.Column<string>(type: "TEXT", nullable: false),
                    Shares = table.Column<decimal>(type: "TEXT", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValueAtPurchase = table.Column<decimal>(type: "TEXT", nullable: false),
                    CurrentValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    ExchangeMarket = table.Column<string>(type: "TEXT", nullable: true),
                    DailyGainLoss = table.Column<decimal>(type: "TEXT", nullable: true),
                    WeeklyGainLoss = table.Column<decimal>(type: "TEXT", nullable: true),
                    MonthlyGainLoss = table.Column<decimal>(type: "TEXT", nullable: true),
                    YearlyGainLoss = table.Column<decimal>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavoriteStockId",
                table: "AspNetUsers",
                column: "FavoriteStockId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_UserId",
                table: "Stock",
                column: "UserId");

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

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavoriteStockId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavoriteMarket",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavoriteStockId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InvestmentOrientation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PrivateAccount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileDescription",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfitLoss",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SignUpDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TotalInvested",
                table: "AspNetUsers");
        }
    }
}
