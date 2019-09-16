using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marcos_Vinicius_DR2_TP3.Models {
    public class Usuario {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'Sobrenome' é obrigatório.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo 'Data de Aniversário' é obrigatório.")]
        [Display(Name = "Data de Aniversário")]
        public DateTime DataDeAniversario { get; set; }
    }

}