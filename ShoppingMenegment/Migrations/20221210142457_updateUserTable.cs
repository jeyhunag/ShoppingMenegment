using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingMenegment.Migrations
{
    public partial class updateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_userId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_userId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_userId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Customers_userId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                schema: "Membership",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                schema: "Membership",
                table: "Users",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "Membership",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_userId",
                table: "Employees",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_userId",
                table: "Customers",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_userId",
                table: "Customers",
                column: "userId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_userId",
                table: "Employees",
                column: "userId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
