using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Models
{
    [Table("Clientes")]
    class Cliente : Persona
    {
        public int Puntos { get; set; }
        public IEnumerable<Servicio> Servicios { get; set; }
    }
}
