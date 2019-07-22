using Data_access.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access
{
    class HomeServicesContext : DbContext
    {
        public HomeServicesContext() : base("HomeServicesAPIDB") { }

        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Habilidad> Habilidades { get; set; }
        public DbSet<HabilidadEspecifica> HabilidadesEspecificas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<PrestadorServicio> PrestadoresServicio { get; set; }
        public DbSet<PSHabilidadEspecifica> PSHabilidadesEspecificas { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
    }
}
