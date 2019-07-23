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
    [Table("Personas")]
    class Persona : ITimeStamp
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nombres { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Apellidos { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string Cedula { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 7)]
        public string Telefono { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        public Cuenta Cuenta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMoficiacion { get; set; }
    }
}
