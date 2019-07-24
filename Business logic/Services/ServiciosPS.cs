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
            IEnumerable<PrestadorServicio> prestadores)
        {
            IEnumerable<PrestadorServicio> prestadoresResultado = new List<PrestadorServicio>() { };

            if (DateTime.Compare(inicio, fin) < 0 &&
                (inicio.Hour + cantidadHoras) == fin.Hour &&
                 fin.Minute == inicio.Minute)
            {
                
            }

            return prestadoresResultado;
        }

        private DateTime cleanDateTime(DateTime dateTime)
        {
            return new DateTime(2010, 1, 1, dateTime.Hour, dateTime.Minute,
                dateTime.Second, dateTime.Millisecond, dateTime.Kind);
        }
    }
}
