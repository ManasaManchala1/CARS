using CARS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Repository
{
    public interface IReportsRepository
    {
        Reports generateIncidentReport(int incidentID);
    }
}
