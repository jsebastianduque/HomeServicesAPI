using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Models
{
    [Table("HabilidadesEspecificas")]
    class HabilidadEspecifica
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public int HabilidadId { get; set; }
        public Habilidad Habilidad { get; set; }
        public IEnumerable<PSHabilidadEspecifica> PrestadoresServicio { get; set; }
    }
}
