namespace CARS.Service
{
    internal interface ICrimeAnalysisService
    {
        void ViewIncidents();
        void AddIncident();
        void SearchIncidents();
        void generateIncidentReport();
        void getCaseDetails();
        void updateCaseDetails();
        void getAllCases();
        void createCase();
    }
}
