using Data_access.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Models
{
    [Table("Servicios")]
    public class Servicio : ITimeStamp
    {
        public int Id { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string Descripcion { get; set; }
        [Required]
        public DateTime HoraServicio { get; set; }
        [Required]
        [Range(1, 24)]
        public int HorasEstimadas { get; set; }
        [Required]
        public DateTime FechaServicio { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string DireccionServicio { get; set; }
        [Required]
        [Range(10000, 99999999999)]
        public decimal PrecioMinimo { get; set; }
        [Required]
        [Range(10000, 99999999999)]
        public decimal PrecioMaximo { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool PSPersonal { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int PrestadorServicioId { get; set; }
        public PrestadorServicio PrestadorServicio { get; set; }
        public IEnumerable<Pago> Pagos { get; set; }
        public Calificacion Calificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMoficiacion { get; set; }
    }
}
