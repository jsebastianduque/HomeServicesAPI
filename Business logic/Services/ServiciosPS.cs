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

        public IEnumerable<PrestadorServicio> FilterByHour(int cantidadHoras, DateTime inicio, DateTime fin,
            DateTime fechaServicio, IEnumerable<PrestadorServicio> prestadores)
        {
            IList<PrestadorServicio> prestadoresResultado = new List<PrestadorServicio>() { };
            IList<Servicio> serviciosEnElDia = new List<Servicio>() { };
            bool estaDisponible = true;

            if (DateTime.Compare(inicio, fin) < 0 &&
                (inicio.Hour + cantidadHoras) == fin.Hour &&
                 fin.Minute == inicio.Minute)
            {
                foreach (PrestadorServicio prestador in prestadores)
                {
                    IEnumerable<Servicio> servicios = prestador.Servicios.ToList();

                    foreach (Servicio servicio in servicios)
                    {

                        if (fechaServicio.Year == servicio.FechaServicio.Year && 
                            fechaServicio.Month == servicio.FechaServicio.Month &&
                            fechaServicio.Day == servicio.FechaServicio.Day)
                        {
                            if (inicio.Hour == servicio.HoraServicio.Hour)
                            {
                                if(inicio.Minute == servicio.HoraServicio.Minute)
                                {
                                    estaDisponible = false;
                                    break;
                                }else if (true)
                                {

                                }
                            }
                        }
                    }
                }
            }

            return prestadoresResultado;
        }

        private DateTime cleanDateTime(DateTime dateTime)
        {
            return new DateTime(2010, 1, 1, dateTime.Hour, dateTime.Minute, 0, 0, dateTime.Kind);
        }
    }
}
