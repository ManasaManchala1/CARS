using CARS.Entities;
using CARS.Exceptions;
using CARS.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Repository
{
    internal class ReportsRepository : IReportsRepository
    {
        string connectionstring;
        SqlCommand cmd = null;
        public ReportsRepository()
        {
            connectionstring = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }
        public Reports generateIncidentReport(Incidents incident)
        {
            Reports report = new Reports();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    cmd.CommandText = "select * from Reports where IncidentID=@id";
                    cmd.Parameters.AddWithValue("@id", incident.IncidentID);
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        report.ReportID = (int)reader["ReportID"];
                        report.IncidentID = (int)reader["IncidentID"];
                        report.ReportingOfficer = (int)reader["ReportingOfficer"];
                        report.Status = (string)reader["Status"];
                        report.ReportDate = ((DateTime)reader["ReportDate"]).Date;
                        report.ReportDetails = (string)reader["ReportDetails"];
                    }
                    if(report==null) throw new ReportNotFoundException("Report not found.");

                }
                        
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return report;
        }
        //public Reports generateIncidentReport(Incidents incident)
        //{
        //    Reports report=reports.Find(i=>i.IncidentID==incident.IncidentID);
        //    if(report!=null) { return report; }
        //    else
        //    {
        //        throw new ReportNotFoundException("Report Not Found");
        //    }
        //}
    }
}
