using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Entities
{
    internal class Reports
    {
        int reportID;
        int incidentID;
        int reportingOfficer;
        DateTime reportDate;
        string reportDetails;
        string status;
        public int ReportID {  get { return reportID; } set {  reportID = value; } }
        public int IncidentID { get { return incidentID; } set {  incidentID = value; } }
        public int ReportingOfficer { get {  return reportingOfficer; } set { reportingOfficer = value; } }
        public DateTime ReportDate { get {  return reportDate; } set { reportDate = value; } }
        public string ReportDetails { get {  return reportDetails; } set { reportDetails = value; } }
        public string Status { get { return status; } set { status = value; } }
        public Reports(int reportID,int incidentID,int reportingOfficer,DateTime reportDate,string reportDetails,string status) {
            ReportID = reportID;
            IncidentID = incidentID;
            ReportingOfficer = reportingOfficer;
            ReportDetails = reportDetails;
            ReportDate = reportDate;
            Status = status;
        }
        public Reports() { }
        public override string ToString()
        {
            return $"ReportID:{ReportID},IncidentID:{IncidentID},ReportingOfficer:{ReportingOfficer},ReportDate:{ReportDate},ReportDetails:{ReportDetails},Status:{Status}";
        }
    }
}
