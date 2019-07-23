using Data_access.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Models
{
    [Table("PrestadoresServicio")]
    public class PrestadorServicio : Persona
    {
        public DateTime FechaAfiliacion { get; set; }
        public IEnumerable<Servicio> Servicios { get; set; }
        public IEnumerable<PSHabilidadEspecifica> Habilidades { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMoficiacion { get; set; }
    }
}
