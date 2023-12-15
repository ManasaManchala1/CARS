using CARS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Repository
{
    internal interface ICasesRepository
    {
        //Cases createCase(string caseDescription, List<Incidents> relatedIncidents);
        Cases getCaseDetails(int caseId);
        int updateCaseDetails(int caseID,string status);
        List<Cases> getAllCases();
    }
}
