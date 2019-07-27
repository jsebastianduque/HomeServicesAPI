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
    [Table("PrestadoresServicio")]
    public class PrestadorServicio : Persona
    {
        public DateTime FechaAfiliacion { get; set; }
        public virtual IList<Servicio> Servicios { get; set; }
        public virtual IList<PSHabilidadEspecifica> Habilidades { get; set; }
    }
}
