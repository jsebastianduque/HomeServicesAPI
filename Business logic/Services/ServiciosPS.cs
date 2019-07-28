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
        public IList<PrestadorServicio> FilterByHour(DateTime inicio, int cantidadHoras,
            DateTime fechaServicio, IList<PrestadorServicio> prestadores)
        {
            IList<PrestadorServicio> prestadoresResultado = new List<PrestadorServicio>() { };
            bool estaDisponible = true;

            if (ValidarFechaServicio(fechaServicio) &&
                ValidarHorasServicio(cantidadHoras, inicio.Hour, inicio.Hour + cantidadHoras))
            {
                foreach (PrestadorServicio prestador in prestadores)
                {
                    IList<Servicio> servicios = prestador.Servicios.ToList();

                    foreach (Servicio servicio in servicios)
                    {
                        if (SonFechasIguales(fechaServicio, servicio.FechaServicio))
                        {
                            DateTime horaInicio = servicio.HoraServicio;

                            if (!SeCruzanHoras(horaInicio.Hour, 
                                horaInicio.Hour + servicio.HorasEstimadas, inicio.Hour,
                                inicio.Hour + cantidadHoras, horaInicio.Minute, horaInicio.Minute,
                                inicio.Minute, inicio.Minute))
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
            return prestadores.Where(p => p.Habilidades.Count(h => h.HabilidadEspecifica == habilidadEspecifica) == 1).ToList();
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
                    precioPS = prestador.Habilidades.First(h => h.HabilidadEspecifica == habilidadEspecifica).PrecioHora;

                    if (precioPS <= maximo && precioPS >= minimo)
                    {
                        prestadoresResultado.Add(prestador);
                    }
                }
            }

            return prestadoresResultado;
        }

        private bool ValidarFechaServicio(DateTime fechaServicio)
        {
            if (DateTime.Compare(fechaServicio, DateTime.Now) > 0)
            {
                return true;
            }

            return false;
        }

        private bool ValidarHorasServicio(int duracion, int horaInicio, int horaFin)
        {
            if (duracion <= 12 && horaInicio >= 7 && horaFin <= 20)
            {
                return true;
            }

            return false;
        }

        private bool SonFechasIguales(DateTime fecha1, DateTime fecha2)
        {
            if (fecha1.Year == fecha2.Year && fecha1.Month == fecha2.Month &&
            fecha1.Day == fecha2.Day)
            {
                return true;
            }

            return false;
        }

        private bool SeCruzanHoras(int horaInicio1, int horaFin1, int horaInicio2, int horaFin2,
            int minInicial1, int minFinal1, int minInicial2, int minFinal2)
        {
            if ((horaInicio1 >= horaInicio2 && horaInicio1 < horaFin2) || 
                (horaFin1 > horaInicio2 && horaFin1 <= horaFin2) ||
                (horaInicio1 == horaFin2 && minInicial1 < minFinal2) ||
                (horaFin1 == horaInicio2 && minFinal1 > minInicial2))
            {
                return false;
            }

            return true;
        }
    }
}