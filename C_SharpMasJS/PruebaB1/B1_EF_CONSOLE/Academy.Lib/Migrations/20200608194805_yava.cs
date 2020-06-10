using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Academy.Lib.Migrations
{
    public partial class yava : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListaStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Dni = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaStudents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListaSubjets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Teacher = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaSubjets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListaExams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StudentGuid = table.Column<Guid>(nullable: false),
                    SubjectGuid = table.Column<Guid>(nullable: false),
                    DateTimeExam = table.Column<DateTime>(nullable: false),
                    Score = table.Column<double>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListaExams_ListaStudents_StudentId",
                        column: x => x.StudentId,
                        principalTable: "ListaStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListaExams_StudentId",
                table: "ListaExams",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaExams");

            migrationBuilder.DropTable(
                name: "ListaSubjets");

            migrationBuilder.DropTable(
                name: "ListaStudents");
        }
    }
}
