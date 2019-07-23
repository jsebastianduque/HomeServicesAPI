using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic.Interfaces
{
    interface IServicios
    {
        void crear(Object objeto);
        void actualizar(Object objecto);
        void eliminar(Object objecto);

        void obtener(Object objeto); 
    }
}
