using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Exceptions
{
    internal class IncidentAlreadyExistException : ApplicationException
    {
        public string Mssg { get; set; }
        public IncidentAlreadyExistException(string mssg) : base(mssg)
        {
            Mssg = mssg;
        }
    }
}
