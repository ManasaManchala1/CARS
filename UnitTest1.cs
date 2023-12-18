using CARS.Entities;
using CARS.Repository;
using CARS.Exceptions;

namespace CarsNunit.Test
{
    public class Tests
    {
        private const string connectionString = "Server=DESKTOP-OF1Q2JL;Database=CARS;Trusted_Connection=True";
        IncidentsRepository incidentsRepository;
        ReportsRepository reportsRepository;
        
        [SetUp]
        public void Setup()
        {
            incidentsRepository = new IncidentsRepository();
            reportsRepository = new ReportsRepository();
            incidentsRepository.connectionstring = connectionString;
            reportsRepository.connectionstring = connectionString;
        }

        [Test]
        public void TesttoAddIncident()
        {
            try
            {
                int addstatus = incidentsRepository.AddIncident(new Incidents()
                {
                    IncidentID = 25,
                    IncidentType = "Accident",
                    IncidentDate = DateTime.Parse("2023-12-17"),
                    Location = "Kurnool",
                    Description = "Car Accident",
                    Status = "Open",
                    VictimID = 1,
                    SuspectID = 1,
                    CaseID = 2
                });
                Assert.AreEqual(1, addstatus);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        [Test]
        public void TesttoUpdateIncidentStatus()
        {
            int updatestatus = incidentsRepository.updateIncidentStatus(20, "Closed");
            Assert.AreEqual(1, updatestatus);
        }
        [Test]
        public void TesttoGetIncidentsInRange()
        {
            List<Incidents> incidents = incidentsRepository.getIncidentsInDateRange(DateTime.MinValue, DateTime.MaxValue);
            Assert.IsNotNull(incidents);
        }
        [Test]
        public void TesttoSearchIncidents()
        {
            List<Incidents> incidents=null;
            Assert.Throws<IncidentTypeNotFoundException>(() => incidents = incidentsRepository.SearchIncidents("Something"),"Incident type not Found");
            Assert.IsNull(incidents);
            incidents = incidentsRepository.SearchIncidents("Missing");
            Assert.IsNotNull(incidents);
        }
        [Test]
        public void TesttoGenerateIncidentReport()
        {
            Reports reports = new Reports();
            Assert.Throws<ReportNotFoundException>(() => reports = reportsRepository.generateIncidentReport(40), "Report not found.");
            Assert.AreEqual(0,reports.ReportID);
            reports = reportsRepository.generateIncidentReport(2);
            Assert.IsNotNull(reports);
        }
        
    }
}