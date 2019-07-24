using Business_logic.Interfaces;
using System;
using Data_access;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_access.Models;

namespace Business_logic.Services
{

    public class ServiciosHabilidad 
    {

        HomeServicesContext BD = new HomeServicesContext();

        public IEnumerable<Habilidad> Get()
        {
            return this.BD.Habilidades.ToList();

        }

    }
}
