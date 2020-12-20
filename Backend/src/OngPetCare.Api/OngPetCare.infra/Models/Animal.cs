using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OngPetCare.infra.Models
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Observacoes { get; set; }
        public DateTime? DataChegada { get; set; }
    }
}
