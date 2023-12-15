using CARS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
