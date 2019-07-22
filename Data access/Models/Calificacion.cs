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
    [Table("Calificaciones")]
    class Calificacion : ITimeStamp
    {   
        [ForeignKey("Servicio")]
        public int Id { get; set; }
        [Required]
        [Range(0,5)]
        public int Puntuacion { get; set; }
        [StringLength(300, MinimumLength = 4)]
        public string Comentario { get; set; }
        public Servicio Servicio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMoficiacion { get; set; }
    }
}
