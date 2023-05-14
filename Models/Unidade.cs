using EduEscola.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EduEscola.Models
{
    public class Unidade
    {
        [Key]
        public int UnidadeId { get; set; }

        [Required(ErrorMessage = "Preenchimento Obrigatório")]
        public string Nome_Unidade { get; set; }


        [Required(ErrorMessage = "Preenchimento Obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Preenchimento Obrigatório")]
        public string Nome_Diretor { get; set; }

        public string Genero { get; set; }



        // Propriedade de navegação
        public IEnumerable<Materia> NomeCurso { get; set; }

        //PRECISA ADICIONAR DUAS COLUNAS DIRETOR E BAIRRO











        //public void Salvar()
        //{
        //    var db = new TabEduEscola();
        //    object value = db.Unidades.Add(this);
        //    db.SaveChanges();
        //}


        public List<Unidade> Todos()
        {
            var db = new TabEduEscola();
            return db.Unidades.ToList();
        }
    }
}
