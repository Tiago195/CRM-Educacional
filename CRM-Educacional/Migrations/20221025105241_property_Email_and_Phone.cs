using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Educacional.Migrations
{
    public partial class property_Email_and_Phone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Password");
        }
    }
}
