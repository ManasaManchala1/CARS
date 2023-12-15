using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Exceptions
{
    internal class IncidentTypeNotFoundException:ApplicationException
    {
        public string Mssg {  get; set; }

        public IncidentTypeNotFoundException(string mssg):base(mssg){
            Mssg=mssg;
        }
    }
}
