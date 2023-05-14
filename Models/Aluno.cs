using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace EduEscola.Models
{
    public class Aluno
    {
        [Key]
        public int IdAluno { get; set; }

        [Required(ErrorMessage = "Preenchimento Obrigatório")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Preenchimento Obrigatório")]
        public string Cpf { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Preenchimento Obrigatório")]
        public int MatriculaAluno { get; set; }

        [Required(ErrorMessage = "Preenchimento Obrigatório")]
        public string Genero_Aluno { get; set; }

        [Required(ErrorMessage = "Preenchimento Obrigatório")]
        public int TurmaId { get; set; }

        [Required(ErrorMessage = "Preenchimento Obrigatório")]
        public string Status_Matricula { get; set; }

        public virtual Turma Turmas { get; set; }

        //public virtual Unidade Unidades { get; set; }

        public IEnumerable<Turma> Turmass { get; set; }
        //public IEnumerable<Unidade> NomeUnidades { get; set; }

    }
}
