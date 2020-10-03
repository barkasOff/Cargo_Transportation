using Microsoft.EntityFrameworkCore.Migrations;

namespace Cargo_Transportation.Migrations
{
    public partial class ApplicationDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Employees_DriverId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Products_ProductId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ProductId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Cars_DriverId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Routes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentProductId",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentDriverId",
                table: "Cars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_CarId",
                table: "Routes",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ClientId",
                table: "Products",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CarId",
                table: "Employees",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CurrentProductId",
                table: "Clients",
                column: "CurrentProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CurrentDriverId",
                table: "Cars",
                column: "CurrentDriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Employees_CurrentDriverId",
                table: "Cars",
                column: "CurrentDriverId",
                principalTable: "Employees",
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
                name: "FK_Employees_Cars_CarId",
                table: "Employees",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Clients_ClientId",
                table: "Products",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Cars_CarId",
                table: "Routes",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Employees_CurrentDriverId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Products_CurrentProductId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Cars_CarId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Clients_ClientId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Cars_CarId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_CarId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Products_ClientId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CarId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CurrentProductId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CurrentDriverId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CurrentProductId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CurrentDriverId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ProductId",
                table: "Clients",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DriverId",
                table: "Cars",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Employees_DriverId",
                table: "Cars",
                column: "DriverId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Products_ProductId",
                table: "Clients",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
