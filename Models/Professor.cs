using EduEscola.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EduEscola.Models
{
    public class Professor
    {
        [Key]
        public int ProfessorId { get; set; }

        [Required(ErrorMessage = "Preenchimento Obrigatório")]
        public string Nome_Professor { get; set; }

        [Required(ErrorMessage = "Preenchimento Obrigatório")]
        public string Email_Professor { get; set; }

        [Required(ErrorMessage = "Preenchimento Obrigatório")]
        public string Genero_Professor { get; set; }


        [Required(ErrorMessage = "Preenchimento Obrigatório")]
        public int Matricula_Professor { get; set; }


        [NotMapped]
        public string DescricaoMaterias { get; set; }

        // Propriedade de navegação para o professor
        public IEnumerable<Professor> Professors { get; set; }


        //PRECISA ADICIONAR DUAS COLUNAS email E data de nascimento






        //public void Salvar()
        //{
        //    var db = new TabEduEscola();
        //    object value = db.Professors.Add(this);
        //    db.SaveChanges();
        //}

        //public List<Professor> Todos()
        //{
        //    var db = new TabEduEscola();
        //    return db.Professors.ToList();
        //}
    }
}
