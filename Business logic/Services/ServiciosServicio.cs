using Business_logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_access;
using Data_access.Models;

namespace Business_logic.Services
{
    public class ServiciosServicio
    {
        readonly HomeServicesContext databaseContext = new HomeServicesContext();
        readonly ServiciosPS serviciosPS = new ServiciosPS();

        public IList<Servicio> GetClientServices(int idCliente)
        {
            return databaseContext.Servicios.Where(servico => servico.ClienteId == idCliente).ToList();
        }

        public Servicio Get(int id)
        {
            return databaseContext.Servicios.Find(id);
        }

        public IList<Servicio> Get()
        {
            return databaseContext.Servicios.ToList();
        }

        public void Update(Servicio servicio)
        {
            var updateServicio = databaseContext.Servicios.Find(servicio.Id);
            updateServicio = servicio;
            databaseContext.SaveChanges();
        }

        public void Add(Servicio servicio)
        {
            databaseContext.Servicios.Add(servicio);
            databaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var servicio = databaseContext.Servicios.Find(id);
            databaseContext.Servicios.Remove(servicio);
            databaseContext.SaveChanges();
        }

        public PrestadorServicio AssignService(Servicio servicio, int habilidadEspecificaId)
        {
            PrestadorServicio prestador = ApplyFilters(servicio,
                databaseContext.HabilidadesEspecificas.Find(habilidadEspecificaId),
                databaseContext.PrestadoresServicio.ToList()).FirstOrDefault();

            servicio.Cliente = databaseContext.Clientes.Find(servicio.ClienteId);

            if (prestador != null)
            {
                servicio.PrestadorServicio = prestador;
                Add(servicio);
                return servicio.PrestadorServicio;
            }
            else
            {
                return null;
            }
        }

        private IList<PrestadorServicio> ApplyFilters(Servicio servicio, 
            HabilidadEspecifica habilidad, IList<PrestadorServicio> prestadores)
        {
            prestadores = serviciosPS.FilterByConcreteSkill(habilidad, prestadores);
            prestadores = serviciosPS.FilterByCost(servicio.PrecioMinimo, servicio.PrecioMaximo, habilidad, prestadores);
            prestadores = serviciosPS.FilterByHour(servicio.HoraServicio, servicio.HorasEstimadas,
                servicio.FechaServicio, prestadores);

            return prestadores;
        }
    }
}
