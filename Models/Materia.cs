using EduEscola.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EduEscola.Models
{
    public class Materia
    {
            [Key]
            public int MateriaId { get; set; }

            [Required(ErrorMessage = "Preenchimento Obrigatório")]
            public int ProfessorId { get; set; }
            
            [Required(ErrorMessage = "Preenchimento Obrigatório")]
            public int TurmaId { get; set; }

            [Required(ErrorMessage = "Preenchimento Obrigatório")]
            public string Nome_Materia { get; set; }

            
        
            // Propriedade de navegação para o professor
            public virtual Professor Professors { get; set; }
            // Propriedade de navegação 
            public virtual Turma Turmas { get; set; }
            

            public IEnumerable<Professor> Professorss { get; set; }    

            public IEnumerable<Turma> Turmass { get; set; }
            //public IEnumerable<Unidade> Unidadess { get; set; }
        //public IEnumerable<Unidade> NoUnidade { get; set; }






        //public void Salvar()
        //{
        //    var db = new TabEduEscola();
        //    object value = db.Materias.Add(this);
        //    db.SaveChanges();
        //}

        //public List<Curso> Todos()
        //    {
        //        var db = new TabEduEscola();
        //        return db.Materias.ToList();
        //    }
    }
}