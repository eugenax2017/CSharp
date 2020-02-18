using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication_New.Migrations
{
    public partial class Subjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject_Name",
                table: "Entity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Teacher",
                table: "Entity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject_Name",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Teacher",
                table: "Entity");
        }
    }
}
