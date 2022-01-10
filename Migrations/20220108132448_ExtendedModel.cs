using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApp.Migrations
{
    public partial class ExtendedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodProf = table.Column<int>(type: "int", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNasterii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CNP = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Specializare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireSpecializare = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Domeniu = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializare", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodStud = table.Column<int>(type: "int", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNasterii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CNP = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Curs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    CodCurs = table.Column<int>(type: "int", nullable: false),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Curs_Profesor_ProfesorID",
                        column: x => x.ProfesorID,
                        principalTable: "Profesor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curs_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecializareStudenti",
                columns: table => new
                {
                    SpecializareID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializareStudenti", x => new { x.StudentID, x.SpecializareID });
                    table.ForeignKey(
                        name: "FK_SpecializareStudenti_Specializare_SpecializareID",
                        column: x => x.SpecializareID,
                        principalTable: "Specializare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecializareStudenti_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curs_ProfesorID",
                table: "Curs",
                column: "ProfesorID");

            migrationBuilder.CreateIndex(
                name: "IX_Curs_StudentID",
                table: "Curs",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializareStudenti_SpecializareID",
                table: "SpecializareStudenti",
                column: "SpecializareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curs");

            migrationBuilder.DropTable(
                name: "SpecializareStudenti");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Specializare");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
