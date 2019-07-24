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

        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            if(habilidades.Get().Count() == 0)
            {
                return request.CreateResponse(HttpStatusCode.OK, habilidades.Get());
            }

                return request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
