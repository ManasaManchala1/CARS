using CARS.Entities;
using CARS.Exceptions;
using CARS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Service
{
    internal class CrimeAnalysisService : ICrimeAnalysisService
    {
        IIncidentsRepository incidentsRepository;
        IReportsRepository reportsRepository;
        ICasesRepository casesRepository;
        public CrimeAnalysisService()
        {
            incidentsRepository = new IncidentsRepository();
            reportsRepository = new ReportsRepository();
            casesRepository = new CasesRepository();

        }
        public void ViewIncidents()
        {
            List<Incidents> view = incidentsRepository.ViewIncidents();
            foreach (Incidents inc in view)
            {
                Console.WriteLine(inc);
            }
            Console.WriteLine();
        }
        public void AddIncident()
        {
            try
            {
                Incidents newincident1 = new Incidents();
                Console.WriteLine("Enter incidentid");
                newincident1.IncidentID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter incidentdate");
                newincident1.IncidentDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter incidentype");
                newincident1.IncidentType = Console.ReadLine();
                Console.WriteLine("Enter location");
                newincident1.Location = Console.ReadLine();
                Console.WriteLine("Enter status");
                newincident1.Status = Console.ReadLine();
                Console.WriteLine("Enter description");
                newincident1.Description = Console.ReadLine();
                Console.WriteLine("Enter suspectid");
                newincident1.SuspectID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter victimid");
                newincident1.VictimID = int.Parse(Console.ReadLine());
                int check = incidentsRepository.AddIncident(newincident1);
                if (check == 1) { Console.WriteLine("Incident Added Successfully"); }

            }
            catch (IncidentAlreadyExistException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SearchIncidents()
        {
            try
            {
                Console.WriteLine("Enter incidenttype");
                string type = Console.ReadLine();
                List<Incidents> search = incidentsRepository.SearchIncidents(type);
                foreach (Incidents inc in search) { Console.WriteLine(inc); }
                Console.WriteLine();

            }
            catch (IncidentTypeNotFoundException ex) { Console.WriteLine(ex.Message); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void generateIncidentReport()
        {
            List<Incidents> incid = incidentsRepository.ViewIncidents();
            Reports report = reportsRepository.generateIncidentReport(incid.ElementAt(0));
            Console.WriteLine(report);
        }

        public void getAllCases()
        {
            List<Cases> allcases = casesRepository.getAllCases();
            foreach (Cases c in allcases) { Console.WriteLine(c); }
        }

        public void getCaseDetails()
        {
            Cases details = casesRepository.getCaseDetails(1);
            Console.WriteLine(details);
        }


        public void updateCaseDetails()
        {
            Console.WriteLine("CaseId");
            int caseid = int.Parse(Console.ReadLine());
            Console.WriteLine("Status");
            string status2 = Console.ReadLine();
            int status1 = casesRepository.updateCaseDetails(caseid, status2);
            if (status1 > 1) Console.WriteLine($"{status1} updated successfully");
        }

        
    }
}
