using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCoffeeData.Migrations
{
    public partial class Seconds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DrinkName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DrinkID",
                table: "Orders",
                column: "DrinkID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Drinks_DrinkID",
                table: "Orders",
                column: "DrinkID",
                principalTable: "Drinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Drinks_DrinkID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DrinkID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DrinkName",
                table: "Orders");
        }
    }
}
