using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Models
{
    [Table("Pagos")]
    class Pago
    {
        public int Id { get; set; }
        public double Monto { get; set; }
        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }
    }
}
