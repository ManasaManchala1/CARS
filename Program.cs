using CARS.Entities;
using CARS.Exceptions;
using CARS.Repository;
using CARS.Service;

ICrimeAnalysisService crimeAnalysisService = new CrimeAnalysisService();
Console.WriteLine("--------------------------------------");
Console.WriteLine("Crime Analysis and Reporting System");
Console.WriteLine("--------------------------------------");
while (true)
{
    MainMenu:
    Console.WriteLine("Main Menu:");
    Console.WriteLine("1.View Incidents");
    Console.WriteLine("2.Add Incident");
    Console.WriteLine("3.Search Incidents");
    Console.WriteLine("4.Generate Reports");
    Console.WriteLine("5.Manage Cases");
    Console.WriteLine("6.Exit");
    Console.WriteLine("Enter your choice");
    int choice=int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            crimeAnalysisService.ViewIncidents();
            break;
        case 2:
            crimeAnalysisService.AddIncident();
            break;
        case 3:
            crimeAnalysisService.SearchIncidents();
            break;
        case 4:
            crimeAnalysisService.generateIncidentReport();
            break;
        case 5:
            Console.WriteLine("1.View Cases");
            Console.WriteLine("2.Update Case Details");
            Console.WriteLine("3.Get Case Details");
            Console.WriteLine("4.Main Menu");
            while (true)
            {
                Console.WriteLine("Enter your case choice");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        crimeAnalysisService.getAllCases();
                        break;
                    case 2:
                        crimeAnalysisService.updateCaseDetails();
                        break;
                    case 3:
                        crimeAnalysisService.getCaseDetails();
                        break;
                    case 4:
                        goto MainMenu;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            }
            break;

        case 6:
            Console.WriteLine("Exiting the program");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;


    }
}


//Console.WriteLine("----------Add Incident------------");
//Incidents newincident = new Incidents(3, "Burglary", DateTime.Parse("2023-03-05"), "Suburb", "Residential break-in", "Under Investigation", 3, 3);
//incidentsRepository.AddIncident(newincident);
//foreach (Incidents inc in view)
//{
//    Console.WriteLine(inc);
//}
//Console.WriteLine();

//Console.WriteLine("----------After updation----------");
//int updated=incidentsRepository.updateIncidentStatus(2, "Closed");
//Console.WriteLine(updated);
//foreach (Incidents inc in view)
//{
//    Console.WriteLine(inc);
//}
//Console.WriteLine();

//Console.WriteLine("----------Searched Incident--------");
//List<Incidents> search = incidentsRepository.SearchIncidents("Assault");
//foreach (Incidents inc in search) { Console.WriteLine(inc); }
//Console.WriteLine();

//Console.WriteLine("------------Get Incidents in date range-------------");
//List<Incidents> incidentsinrange = incidentsRepository.getIncidentsInDateRange("2023-01-09", "2023-03-05");
//foreach (Incidents incident in incidentsinrange) { Console.WriteLine(incident); }
//Console.WriteLine();

//Console.WriteLine("--------------Incident Reports----------------");
//IReportsRepository reportsRepository = new ReportsRepository();
//Reports report = reportsRepository.generateIncidentReport(view.ElementAt(0));
//Console.WriteLine(report);
//Console.WriteLine();

////Exception1
//try
//{
//    List<Incidents> searchedproducts = incidentsRepository.SearchIncidents("Missing");
//if (searchedproducts.Count > 0)
//{
//    foreach (Incidents inc in searchedproducts) { Console.WriteLine(inc); }
//}
//}catch(IncidentTypeNotFoundException ex)
//{
//    Console.WriteLine(ex.Message);
//}

////Exception2
//try
//{
//    Incidents newincident1 = new Incidents(11, "Robbery", DateTime.Parse("2023-01-10"), "Downtown", "Armed robbery at a convenience store", "Open", 1, 1);
//    int check = incidentsRepository.AddIncident(newincident1);
//    if (check==1) { Console.WriteLine("Incident Added Successfully"); }

//}
//catch (IncidentAlreadyExistException ex)
//{
//    Console.WriteLine(ex.Message);
//}
//Exception3
//try
//{
//    Incidents incidentreport = new Incidents(4, "Kidnapping", "2023-04-20", "School", "Child abduction reported", "Open", 4, 4);
//    Reports report1 = reportsRepository.generateIncidentReport(incidentreport);
//    if(report1 != null) Console.WriteLine(report1);
//}catch(ReportNotFoundException ex)
//{
//    Console.WriteLine(ex.Message);
//}

//ICasesRepository casesRepository = new CasesRepository();
////GetAllCases
//Console.WriteLine("----------------GetAllCases-------------------");
//List<Cases> allcases=casesRepository.getAllCases();
//foreach (Cases c in allcases) {  Console.WriteLine(c); }
//Console.WriteLine();

////GetDetails
//Console.WriteLine("-----------------Get Case Details---------------");
//Cases details = casesRepository.getCaseDetails(1);
//Console.WriteLine(details);
//Console.WriteLine();

////UpdateCase
//Console.WriteLine("-------------------Update Case Details------------");
//Cases details1 = casesRepository.getCaseDetails(1);
//casesRepository.updateCaseDetails(details1);

