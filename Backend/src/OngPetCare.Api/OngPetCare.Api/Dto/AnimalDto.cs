using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngPetCare.Api.Dto
{
    public class AnimalDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Observacoes { get; set; }
        public DateTime? DataChegada { get; set; }
    }
}
