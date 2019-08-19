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
    [Table("Roles")]
    public class Rol : ITimeStamp
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength =  4)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 4)]
        public string Descripcion { get; set; }
        public IList<Cuenta> Cuentas { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
