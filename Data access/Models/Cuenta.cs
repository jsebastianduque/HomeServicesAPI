using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Models
{
    [Table("Cuentas")]
    class Cuenta
    {
        [ForeignKey("Persona")]
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Activo { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public Persona Persona { get; set; }
    }
}
