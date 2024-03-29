﻿using Data_access.Interfaces;
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
    [Table("Cuentas")]
    public class Cuenta : ITimeStamp
    {
        [ForeignKey("Persona")]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool Activo { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public Persona Persona { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
