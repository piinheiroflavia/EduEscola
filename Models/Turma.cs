using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduEscola.Models
{
    public enum Turno
    {
        Manha,
        Tarde,
        Noite
    }
    public class Turma
    {
            

            [Key]
            public int TurmaId { get; set; }

            [Required(ErrorMessage = "Preenchimento Obrigatório")]
            public int CodigoTurma { get; set; }


            [Required(ErrorMessage = "Preenchimento Obrigatório")]
            public int UnidadeId { get; set; }

            
            [Required(ErrorMessage = "Selecione um Turno")]
            public Turno Turno { get; set; }

          
            // Propriedade de navegação
            public virtual Unidade Unidades { get; set; }
           
            
            public IEnumerable<Unidade> Unidadess { get; set; }

       
    }
}

