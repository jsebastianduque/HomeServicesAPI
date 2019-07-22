using Data_access.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Models
{
    [Table("PSHabilidadesEspecificas")]
    class PSHabilidadEspecifica : ITimeStamp
    {
        public int Id { get; set; }
        [Required]
        [Range(10000, 99999999999)]
        public decimal PrecioHora { get; set; }
        [Required]
        [Range(0, 99)]
        public int AniosExperiencia { get; set; }
        public int PrestadorServicioId { get; set; }
        public PrestadorServicio PrestadorServicio { get; set; }
        public int HabilidadEspecificaId { get; set; }
        public HabilidadEspecifica HabilidadEspecifica { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMoficiacion { get; set; }
    }
}
