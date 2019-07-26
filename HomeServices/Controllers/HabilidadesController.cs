using System;
using System.Collections.Generic;
using Business_logic.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace HomeServices.Controllers
{
    public class HabilidadesController : ApiController
    {

        ServiciosHabilidad habilidades = new ServiciosHabilidad();

        [HttpGet]
        public IEnumerable<Object> Get(HttpRequestMessage request)
        {
            return habilidades.Get().ToList();
        }
    }
}
