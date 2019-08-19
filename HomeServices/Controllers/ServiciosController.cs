using Business_logic.Services;
using Data_access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeServices.Controllers
{
    public class ServiciosController : ApiController
    {
        readonly ServiciosServicio servicioControl = new ServiciosServicio();

        [HttpPost]
        public PrestadorServicio Post(Servicio servicio, int habilidadEspecificaId)
        {
            return servicioControl.AssignService(servicio, habilidadEspecificaId);
        }

        [HttpGet]
        public IList<Servicio> Get(int idCliente)
        {
            return servicioControl.GetClientServices(idCliente);
        }
    }
}
