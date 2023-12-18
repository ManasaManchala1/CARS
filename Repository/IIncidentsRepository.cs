using CARS.Entities;

namespace CARS.Repository
{
    public interface IIncidentsRepository
    {
        public List<Incidents> ViewIncidents();
        public int AddIncident(Incidents incident);
        public int updateIncidentStatus(int incidentId, String status);
        public List<Incidents> SearchIncidents(string incidentType);

        List<Incidents> getIncidentsInDateRange(DateTime startDate, DateTime endDate);

    }
}
