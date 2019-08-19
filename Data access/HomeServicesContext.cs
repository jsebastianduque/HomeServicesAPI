using Data_access.Interfaces;
using Data_access.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access
{
    public class HomeServicesContext : DbContext
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servicio>().Property(atributo => atributo.PrecioMaximo).HasPrecision(11, 2);
            modelBuilder.Entity<Servicio>().Property(atributo => atributo.PrecioMinimo).HasPrecision(11, 2);
            modelBuilder.Entity<PSHabilidadEspecifica>().Property(atributo => atributo.PrecioHora).HasPrecision(11, 2);
            modelBuilder.Entity<Pago>().Property(atributo => atributo.Monto).HasPrecision(11, 2);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is ITimeStamp && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((ITimeStamp)entity.Entity).FechaCreacion = DateTime.Now;
                }

                ((ITimeStamp)entity.Entity).FechaModificacion = DateTime.Now;
            }
        }
    }
}
