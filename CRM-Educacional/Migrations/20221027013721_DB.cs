using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Educacional.Migrations
{
  public partial class DB : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Courses",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            Duration = table.Column<string>(type: "nvarchar(max)", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Courses", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Users",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
            Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Users", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "CourseModelUserModel",
          columns: table => new
          {
            CoursesId = table.Column<int>(type: "int", nullable: false),
            UsersId = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_CourseModelUserModel", x => new { x.CoursesId, x.UsersId });
            table.ForeignKey(
                      name: "FK_CourseModelUserModel_Courses_CoursesId",
                      column: x => x.CoursesId,
                      principalTable: "Courses",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_CourseModelUserModel_Users_UsersId",
                      column: x => x.UsersId,
                      principalTable: "Users",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.InsertData(
          table: "Courses",
          columns: new[] { "Id", "Duration", "Name" },
          values: new object[,]
          {
                    { 1, "1200", "C#" },
                    { 2, "800", "JavaScript" },
                    { 3, "1350", "Python" }
          });

      migrationBuilder.InsertData(
          table: "Users",
          columns: new[] { "Id", "CPF", "Email", "Name", "Phone" },
          values: new object[,]
          {
                    { 1, "060.059.321-70", "Fadiga@email.com", "Fadiga", "(32) 89745-6544" },
                    { 2, "321.456.477-70", "Tiago@email.com", "Tiago", "(22) 99748-4850" }
          });

      migrationBuilder.CreateIndex(
          name: "IX_CourseModelUserModel_UsersId",
          table: "CourseModelUserModel",
          column: "UsersId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "CourseModelUserModel");

      migrationBuilder.DropTable(
          name: "Courses");

      migrationBuilder.DropTable(
          name: "Users");
    }
  }
}
