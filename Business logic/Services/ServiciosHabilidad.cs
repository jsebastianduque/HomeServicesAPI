using Business_logic.Interfaces;
using System;
using Data_access;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_access.Models;
using System.Data.Entity;

namespace Business_logic.Services
{

    public class ServiciosHabilidad 
    {

        HomeServicesContext BD = new HomeServicesContext();

        public IList<Habilidad> Get()                 
        {
            return BD.Habilidades.ToList();
               

        }

    }
}
