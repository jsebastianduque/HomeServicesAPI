using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Models
{
    [Table("PSHabilidadesEspecificas")]
    class PSHabilidadEspecifica
    {
        public int Id { get; set; }
        public string PrecioHora { get; set; }
        public string AniosExperiencia { get; set; }
        public int PrestadorServicioId { get; set; }
        public PrestadorServicio PrestadorServicio { get; set; }
        public int HabilidadEspecificaId { get; set; }
        public HabilidadEspecifica HabilidadEspecifica { get; set; }
    }
}
