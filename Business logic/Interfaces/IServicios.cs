using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic.Interfaces
{
    interface IServicios
    {
        void create(Object objeto);
        void update(Object objecto);
        void delete(Object objecto);

        void get(Object objeto); 
    }
}
