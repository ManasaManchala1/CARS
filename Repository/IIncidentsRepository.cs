using CARS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Repository
{
    internal interface IIncidentsRepository
    {
        public List<Incidents> ViewIncidents();
        public int AddIncident(Incidents incident);
        public int updateIncidentStatus(int incidentId, String status);
        public List<Incidents> SearchIncidents(string incidentType);

        //List<Incidents> getIncidentsInDateRange(string startDate, string endDate);

    }
}
