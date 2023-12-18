using CARS.Entities;
using CARS.Exceptions;
using CARS.Repository;

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
                Console.WriteLine("Enter incidentype");
                newincident1.IncidentType = Console.ReadLine();
                Console.WriteLine("Enter incidentdate");
                newincident1.IncidentDate = DateTime.Parse(Console.ReadLine());
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
                Console.WriteLine("CaseID");
                newincident1.CaseID = int.Parse(Console.ReadLine());
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
            try
            {
                Console.WriteLine("IncidentID");
                int incidentid = int.Parse(Console.ReadLine());
                Reports report = reportsRepository.generateIncidentReport(incidentid);
                Console.WriteLine(report);

            }catch(ReportNotFoundException ex) { Console.WriteLine(ex.Message); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void getAllCases()
        {
            List<Cases> allcases = casesRepository.getAllCases();
            foreach (Cases c in allcases) { Console.WriteLine(c); }
        }

        public void getCaseDetails()
        {
            Console.WriteLine("CaseID");
            int caseid = int.Parse(Console.ReadLine());
            Cases details = casesRepository.getCaseDetails(caseid);
            if (details.CaseID != 0) Console.WriteLine(details); 
            else Console.WriteLine($"CaseID {caseid} not found"); 
        }


        public void updateCaseDetails()
        {
            Console.WriteLine("CaseId");
            int caseid = int.Parse(Console.ReadLine());
            Console.WriteLine("Description");
            string description = Console.ReadLine();
            int status1 = casesRepository.updateCaseDetails(caseid, description);
            if (status1 == 1) Console.WriteLine($"updated successfully");
            else Console.WriteLine($"CaseID {caseid} not found"); 
        }

        public void createCase()
        {
            Console.WriteLine("CaseID");
            int caseid = int.Parse(Console.ReadLine());
            Console.WriteLine("Description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter number of incidents");
            int count=int.Parse(Console.ReadLine());
            List<Incidents> relatedincidents = new List<Incidents>();
            while(count > 0)
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
                newincident1.CaseID = 1;
                int check = incidentsRepository.AddIncident(newincident1);
                try { 
                    if (check == 1) Console.WriteLine("Incident Added Successfully"); 
                }catch(Exception ex) {  Console.WriteLine(ex.Message); }
                relatedincidents.Add(newincident1 );
                count--;

            }
            Cases cases = casesRepository.createCase(description,relatedincidents,caseid);
            Console.WriteLine($"CaseID:{cases.CaseID},Description:{cases.Description}");

        }

        
    }
}
