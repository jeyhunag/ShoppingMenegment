using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingMenegment.Migrations
{
    public partial class addUserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserType",
                schema: "Membership",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                schema: "Membership",
                table: "Users");
        }
    }
}
