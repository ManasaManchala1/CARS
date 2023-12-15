using CARS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Repository
{
    internal interface IReportsRepository
    {
        Reports generateIncidentReport(Incidents incident);
    }
}
