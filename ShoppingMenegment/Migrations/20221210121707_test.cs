using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingMenegment.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
