using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstadisticaDeAlumnos3_WPF_Core.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Entity",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "Entity",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entity_StudentId",
                table: "Entity",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_SubjectId",
                table: "Entity",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Entity_StudentId",
                table: "Entity",
                column: "StudentId",
                principalTable: "Entity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Entity_SubjectId",
                table: "Entity",
                column: "SubjectId",
                principalTable: "Entity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Entity_StudentId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Entity_SubjectId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_StudentId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_SubjectId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Entity");
        }
    }
}
