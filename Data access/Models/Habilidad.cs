﻿using Data_access.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Models
{
    [Table("Habilidades")]
    class Habilidad : ITimeStamp
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string Descripcion { get; set; }
        public IEnumerable<HabilidadEspecifica> HabilidadesEspecificas { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMoficiacion { get; set; }
    }
}
