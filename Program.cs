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
            while (true)
            {
                Console.WriteLine("1.View Cases");
                Console.WriteLine("2.Create Case");
                Console.WriteLine("3.Update Case Details");
                Console.WriteLine("4.Get Case Details");
                Console.WriteLine("5.Main Menu");
                Console.WriteLine("Enter your case choice");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        crimeAnalysisService.getAllCases();
                        break;
                    case 2:
                        crimeAnalysisService.createCase();
                        break;
                    case 3:
                        crimeAnalysisService.updateCaseDetails();
                        break;
                    case 4:
                        crimeAnalysisService.getCaseDetails();
                        break;
                    case 5:
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


