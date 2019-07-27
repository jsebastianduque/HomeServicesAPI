using Data_access;
using Data_access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic.Services
{
    public class ServiciosPS
    {
        HomeServicesContext databaseContext = new HomeServicesContext();

        public IList<PrestadorServicio> FilterByHour(DateTime inicio, int cantidadHoras,
            DateTime fechaServicio, IList<PrestadorServicio> prestadores)
        {
            IList<PrestadorServicio> prestadoresResultado = new List<PrestadorServicio>() { };
            bool estaDisponible = true;
            DateTime fin = new DateTime(inicio.Year,
                                            inicio.Month,
                                            inicio.Day,
                                            inicio.Hour + cantidadHoras,
                                            inicio.Minute,
                                            inicio.Second);

            if (DateTime.Compare(fechaServicio, DateTime.Now) > 0 &&
                 cantidadHoras <= 12 &&
                 inicio.Hour >= 7 &&
                 fin.Hour <= 20)
            {
                foreach (PrestadorServicio prestador in prestadores)
                {
                    IList<Servicio> servicios = prestador.Servicios.ToList();

                    foreach (Servicio servicio in servicios)
                    {
                        if (fechaServicio.Year == servicio.FechaServicio.Year && 
                            fechaServicio.Month == servicio.FechaServicio.Month &&
                            fechaServicio.Day == servicio.FechaServicio.Day)
                        {
                            DateTime horaInicio = servicio.HoraServicio;
                            DateTime horaFin = new DateTime(horaInicio.Year,
                                                            horaInicio.Month,
                                                            horaInicio.Day,
                                                            horaInicio.Hour + servicio.HorasEstimadas,
                                                            horaInicio.Minute,
                                                            horaInicio.Second);

                            if ((inicio.Hour >= horaInicio.Hour &&
                            inicio.Hour <= horaFin.Hour) ||
                            (fin.Hour <= horaFin.Hour &&
                            fin.Hour >= horaInicio.Hour))
                            {
                                estaDisponible = false;
                                break;
                            }
                        }
                    }

                    if (estaDisponible)
                    {
                        prestadoresResultado.Add(prestador);
                    }
                }
            }

            return prestadoresResultado;
        }

        public IList<PrestadorServicio> FilterByConcreteSkill(HabilidadEspecifica habilidadEspecifica,
            IList<PrestadorServicio> prestadores)
        {
            return prestadores.Where(p => p.Habilidades.Where(h => h.HabilidadEspecifica == habilidadEspecifica).Count() == 1).ToList();
        }

        public IList<PrestadorServicio> FilterByCost(decimal minimo, decimal maximo, 
            HabilidadEspecifica habilidadEspecifica, IList<PrestadorServicio> prestadores)
        {
            IList<PrestadorServicio> prestadoresResultado = new List<PrestadorServicio>() { };
            decimal precioPS = 0;

            if (minimo > 0 && maximo > 0)
            {
                foreach (PrestadorServicio prestador in prestadores)
                {
                    precioPS = prestador.Habilidades.Where(h => h.HabilidadEspecifica == habilidadEspecifica).First().PrecioHora;

                    if (precioPS <= maximo && precioPS >= minimo)
                    {
                        prestadoresResultado.Add(prestador);
                    }
                }
            }

            return prestadoresResultado;
        }

        private DateTime CleanDateTime(DateTime dateTime)
        {
            return new DateTime(2010, 1, 1, dateTime.Hour, dateTime.Minute, 0, 0, dateTime.Kind);
        }
    }
}