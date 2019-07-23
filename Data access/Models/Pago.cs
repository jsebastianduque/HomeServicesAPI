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
    [Table("Pagos")]
    public class Pago : ITimeStamp
    {
        public int Id { get; set; }
        [Required]
        [Range(10000, 99999999999)]
        public decimal Monto { get; set; }
        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMoficiacion { get; set; }
    }
}
