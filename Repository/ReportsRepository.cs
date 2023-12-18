using CARS.Entities;
using CARS.Exceptions;
using CARS.Utility;
using System.Data.SqlClient;

namespace CARS.Repository
{
    public class ReportsRepository : IReportsRepository
    {
        public string connectionstring;
        SqlCommand cmd = null;
        public ReportsRepository()
        {
            connectionstring = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }
        public Reports generateIncidentReport(int incidentID)
        {
            Reports report = new Reports();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    cmd.CommandText = "select * from Reports where IncidentID=@id";
                    cmd.Parameters.AddWithValue("@id",incidentID);
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
                    cmd.Parameters.Clear();
                    if (report.ReportID==0)
                    {
                        throw new ReportNotFoundException("Report not found.");
                    }

                }
                        
            }finally { cmd.Dispose(); }
            return report;
        }
    }
}
