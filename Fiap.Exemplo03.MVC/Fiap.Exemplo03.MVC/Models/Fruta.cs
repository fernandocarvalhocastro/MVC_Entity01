using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fiap.Exemplo03.MVC.Models
{
    public class Fruta
    {
        [Key]
        public int Id { get; set; }

        [Required]

        [Display(Name ="Nome: ")]
        public int Nome { get; set; }

        [Column("Valor_Calorico")]
        [Display(Name = "Valor Calórico: ")]
        public float ValorCalorico { get; set; }

        [Display(Name = "Orgânico: ")]
        public bool Organico { get; set; }

        [Display(Name = "Semente: ")]
        public bool Semente { get; set; }

        public DateTime DataCadastro { get; set; }

    }
}