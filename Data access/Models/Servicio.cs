using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Models
{
    [Table("Servicios")]
    class Servicio
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        [Required]
        [Range(1, 24)]
        public int HorasEstimadas { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        public string DireccionServicio { get; set; }
        public double LimiteInferiorPrecio { get; set; }
        public double LimiteSuperiorPrecio { get; set; }
        public bool PSPersonal { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int PrestadorServicioId { get; set; }
        public PrestadorServicio PrestadorServicio { get; set; }
        public IEnumerable<Pago> Pagos { get; set; }
        public Calificacion Calificacion { get; set; }
    }
}
