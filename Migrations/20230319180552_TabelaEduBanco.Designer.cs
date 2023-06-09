﻿// <auto-generated />
using System;
using EduEscola.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EduEscola.Migrations
{
    [DbContext(typeof(TabEduEscola))]
    [Migration("20230319180552_TabelaEduBanco")]
    partial class TabelaEduBanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EduEscola.Models.Aluno", b =>
                {
                    b.Property<int>("IdAluno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero_Aluno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MatriculaAluno")
                        .HasColumnType("int");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status_Matricula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("IdAluno");

                    b.HasIndex("TurmaId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("EduEscola.Models.Materia", b =>
                {
                    b.Property<int>("MateriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome_Materia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.Property<int?>("UnidadeId")
                        .HasColumnType("int");

                    b.HasKey("MateriaId");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("TurmaId");

                    b.HasIndex("UnidadeId");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("EduEscola.Models.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email_Professor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero_Professor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MateriaId")
                        .HasColumnType("int");

                    b.Property<int>("Matricula_Professor")
                        .HasColumnType("int");

                    b.Property<string>("Nome_Professor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfessorId1")
                        .HasColumnType("int");

                    b.HasKey("ProfessorId");

                    b.HasIndex("MateriaId");

                    b.HasIndex("ProfessorId1");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("EduEscola.Models.Turma", b =>
                {
                    b.Property<int>("TurmaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlunoIdAluno")
                        .HasColumnType("int");

                    b.Property<int>("CodigoTurma")
                        .HasColumnType("int");

                    b.Property<int?>("MateriaId")
                        .HasColumnType("int");

                    b.Property<int>("Turno")
                        .HasColumnType("int");

                    b.Property<int>("UnidadeId")
                        .HasColumnType("int");

                    b.HasKey("TurmaId");

                    b.HasIndex("AlunoIdAluno");

                    b.HasIndex("MateriaId");

                    b.HasIndex("UnidadeId");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("EduEscola.Models.Unidade", b =>
                {
                    b.Property<int>("UnidadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome_Diretor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome_Unidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("UnidadeId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("EduEscola.Models.Aluno", b =>
                {
                    b.HasOne("EduEscola.Models.Turma", "Turmas")
                        .WithMany()
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("EduEscola.Models.Materia", b =>
                {
                    b.HasOne("EduEscola.Models.Professor", "Professors")
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EduEscola.Models.Turma", "Turmas")
                        .WithMany()
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EduEscola.Models.Unidade", null)
                        .WithMany("NomeCurso")
                        .HasForeignKey("UnidadeId");

                    b.Navigation("Professors");

                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("EduEscola.Models.Professor", b =>
                {
                    b.HasOne("EduEscola.Models.Materia", null)
                        .WithMany("Professorss")
                        .HasForeignKey("MateriaId");

                    b.HasOne("EduEscola.Models.Professor", null)
                        .WithMany("Professors")
                        .HasForeignKey("ProfessorId1");
                });

            modelBuilder.Entity("EduEscola.Models.Turma", b =>
                {
                    b.HasOne("EduEscola.Models.Aluno", null)
                        .WithMany("Turmass")
                        .HasForeignKey("AlunoIdAluno");

                    b.HasOne("EduEscola.Models.Materia", null)
                        .WithMany("Turmass")
                        .HasForeignKey("MateriaId");

                    b.HasOne("EduEscola.Models.Unidade", "Unidades")
                        .WithMany()
                        .HasForeignKey("UnidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unidades");
                });

            modelBuilder.Entity("EduEscola.Models.Unidade", b =>
                {
                    b.HasOne("EduEscola.Models.Turma", null)
                        .WithMany("Unidadess")
                        .HasForeignKey("TurmaId");
                });

            modelBuilder.Entity("EduEscola.Models.Aluno", b =>
                {
                    b.Navigation("Turmass");
                });

            modelBuilder.Entity("EduEscola.Models.Materia", b =>
                {
                    b.Navigation("Professorss");

                    b.Navigation("Turmass");
                });

            modelBuilder.Entity("EduEscola.Models.Professor", b =>
                {
                    b.Navigation("Professors");
                });

            modelBuilder.Entity("EduEscola.Models.Turma", b =>
                {
                    b.Navigation("Unidadess");
                });

            modelBuilder.Entity("EduEscola.Models.Unidade", b =>
                {
                    b.Navigation("NomeCurso");
                });
#pragma warning restore 612, 618
        }
    }
}
