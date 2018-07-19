using Microsoft.EntityFrameworkCore.Migrations;

namespace FabioWebProject.Migrations
{
  public partial class userstuff : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<string>(
          name: "Email",
          table: "Users",
          nullable: true);

      migrationBuilder.AddColumn<string>(
          name: "Password",
          table: "Users",
          nullable: true);

      migrationBuilder.AddColumn<string>(
          name: "UserName",
          table: "Users",
          nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "Email",
          table: "Users");

      migrationBuilder.DropColumn(
          name: "Password",
          table: "Users");

      migrationBuilder.DropColumn(
          name: "UserName",
          table: "Users");
    }
  }
}
