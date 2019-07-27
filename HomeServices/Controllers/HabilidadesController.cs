using System;
using System.Collections.Generic;
using Business_logic.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace HomeServices.Controllers
{

    /// <summary>Permite obtener y envíar los web services relacionados con el 
    /// recurso Habilidades (generales), haciendo uso de arquitectura REST
    /// </summary>
    public class HabilidadesController : ApiController
    {

        ServiciosHabilidad habilidades = new ServiciosHabilidad();


        /// <summary>Permite 
        /// </summary>
        [HttpGet]
        public IEnumerable<Object> Get(HttpRequestMessage request)
        {
            return habilidades.Get().ToList();
        }
    }
}
