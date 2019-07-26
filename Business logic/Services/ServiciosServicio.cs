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
        HomeServicesContext databaseContext = new HomeServicesContext();
        
        public Servicio Get(int id)
        {
            return databaseContext.Servicios.Find(id);
        }

        public IEnumerable<Servicio> Get()
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

        public PrestadorServicio AssignService(Servicio servicio)
        {
            servicio.PrestadorServicio = databaseContext.PrestadoresServicio.First();
            Add(servicio);
            return servicio.PrestadorServicio;
        }
    }
}
