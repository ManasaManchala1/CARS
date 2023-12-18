using CARS.Entities;

namespace CARS.Repository
{
    internal interface ICasesRepository
    {
        Cases createCase(string caseDescription, List<Incidents> relatedIncidents,int caseID);
        Cases getCaseDetails(int caseId);
        int updateCaseDetails(int caseID,string description);
        List<Cases> getAllCases();
    }
}
