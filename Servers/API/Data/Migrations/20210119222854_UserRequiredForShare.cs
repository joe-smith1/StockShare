using Microsoft.EntityFrameworkCore.Migrations;

namespace DataMigrations
{
    public partial class UserRequiredForShare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_AspNetUsers_UserId",
                table: "Stock");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Stock",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_AspNetUsers_UserId",
                table: "Stock",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_AspNetUsers_UserId",
                table: "Stock");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Stock",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_AspNetUsers_UserId",
                table: "Stock",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
