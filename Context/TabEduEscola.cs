using EduEscola.Models;
using Microsoft.EntityFrameworkCore;

namespace EduEscola.Context
{
    public class TabEduEscola : DbContext
    {
        
        //public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Professor> Professors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"server=(localdb)\mssqllocaldb;Database=TabelaEduEscola;Integrated Security=True");
        }

        public DbSet<EduEscola.Models.Aluno> Aluno { get; set; }
        public object Materia { get; internal set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Curso>()
        //        .HasRequired(c => c.Professors)
        //        .WithMany()
        //        .HasForeignKey(c => c.Professor)
        //        .WillCascadeOnDelete(false); // aqui você adiciona a opção ON DELETE NO ACTION
        //}
    }
}
