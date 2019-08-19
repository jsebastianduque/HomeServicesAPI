using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Interfaces
{
    interface ITimeStamp
    {
        DateTime FechaCreacion { get; set; }
        DateTime FechaModificacion { get; set; }
    }
}
