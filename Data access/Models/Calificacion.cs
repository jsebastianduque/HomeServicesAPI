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
    class Calificacion
    {   
        [ForeignKey("Servicio")]
        public int Id { get; set; }
        [Required]
        public int Puntuacion { get; set; }
        public string Comentario { get; set; }
        public Servicio Servicio { get; set; }
    }
}
