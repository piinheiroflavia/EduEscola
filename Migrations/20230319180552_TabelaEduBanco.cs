using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduEscola.Migrations
{
    public partial class TabelaEduBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    TurmaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoTurma = table.Column<int>(type: "int", nullable: false),
                    UnidadeId = table.Column<int>(type: "int", nullable: false),
                    Turno = table.Column<int>(type: "int", nullable: false),
                    AlunoIdAluno = table.Column<int>(type: "int", nullable: true),
                    MateriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.TurmaId);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    IdAluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatriculaAluno = table.Column<int>(type: "int", nullable: false),
                    Genero_Aluno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false),
                    Status_Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.IdAluno);
                    table.ForeignKey(
                        name: "FK_Aluno_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "TurmaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    UnidadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Unidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome_Diretor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurmaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.UnidadeId);
                    table.ForeignKey(
                        name: "FK_Unidades_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "TurmaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Professor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_Professor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero_Professor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matricula_Professor = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: true),
                    ProfessorId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.ProfessorId);
                    table.ForeignKey(
                        name: "FK_Professors_Professors_ProfessorId1",
                        column: x => x.ProfessorId1,
                        principalTable: "Professors",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false),
                    Nome_Materia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidadeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.MateriaId);
                    table.ForeignKey(
                        name: "FK_Materias_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materias_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "TurmaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materias_Unidades_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "Unidades",
                        principalColumn: "UnidadeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_TurmaId",
                table: "Aluno",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_ProfessorId",
                table: "Materias",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_TurmaId",
                table: "Materias",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_UnidadeId",
                table: "Materias",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_MateriaId",
                table: "Professors",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_ProfessorId1",
                table: "Professors",
                column: "ProfessorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_AlunoIdAluno",
                table: "Turmas",
                column: "AlunoIdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_MateriaId",
                table: "Turmas",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_UnidadeId",
                table: "Turmas",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_TurmaId",
                table: "Unidades",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Aluno_AlunoIdAluno",
                table: "Turmas",
                column: "AlunoIdAluno",
                principalTable: "Aluno",
                principalColumn: "IdAluno",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Materias_MateriaId",
                table: "Turmas",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "MateriaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Unidades_UnidadeId",
                table: "Turmas",
                column: "UnidadeId",
                principalTable: "Unidades",
                principalColumn: "UnidadeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_Materias_MateriaId",
                table: "Professors",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "MateriaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Turmas_TurmaId",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Turmas_TurmaId",
                table: "Materias");

            migrationBuilder.DropForeignKey(
                name: "FK_Unidades_Turmas_TurmaId",
                table: "Unidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Professors_ProfessorId",
                table: "Materias");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Unidades");
        }
    }
}
