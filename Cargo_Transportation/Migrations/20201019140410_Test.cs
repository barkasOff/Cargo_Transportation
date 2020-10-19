using Microsoft.EntityFrameworkCore.Migrations;

namespace Cargo_Transportation.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Employees_CurrentDriverId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Routes_CurrentRouteId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Products_CurrentProductId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Products_ProductId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_ProductId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CurrentProductId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CurrentDriverId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CurrentRouteId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "CurrentProductId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CurrentDriverId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CurrentRouteId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryCost",
                table: "Routes",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WarningDangerous",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Products_RouteId",
                table: "Products",
                column: "RouteId",
                unique: true,
                filter: "[RouteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Routes_RouteId",
                table: "Products",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Routes_RouteId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_RouteId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeliveryCost",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WarningDangerous",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Routes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentProductId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentDriverId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentRouteId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ProductId",
                table: "Routes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CurrentProductId",
                table: "Clients",
                column: "CurrentProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CurrentDriverId",
                table: "Cars",
                column: "CurrentDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CurrentRouteId",
                table: "Cars",
                column: "CurrentRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Employees_CurrentDriverId",
                table: "Cars",
                column: "CurrentDriverId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Routes_CurrentRouteId",
                table: "Cars",
                column: "CurrentRouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Products_CurrentProductId",
                table: "Clients",
                column: "CurrentProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Products_ProductId",
                table: "Routes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
