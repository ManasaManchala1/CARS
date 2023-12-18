using System.Data.SqlClient;
using CARS.Entities;
using CARS.Exceptions;
using CARS.Utility;

namespace CARS.Repository
{
    public class IncidentsRepository : IIncidentsRepository
    {
        public string connectionstring;
        SqlCommand cmd = null;
        public IncidentsRepository() {
            connectionstring = DbConnUtil.GetConnectionString();
            cmd=new SqlCommand();
        }
        //View Incidents
        public List<Incidents> ViewIncidents() {  
            List<Incidents> incidents=new List<Incidents>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    cmd.CommandText = "select * from Incidents";
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        Incidents incident = new Incidents();
                        incident.IncidentID = (int)data["IncidentID"];
                        incident.IncidentType = (string)data["IncidentType"];
                        incident.IncidentDate = ((DateTime)data["IncidentDate"]).Date;
                        incident.Description = (string)data["Description"];
                        incident.Location = (string)data["Location"];
                        incident.Status = (string)data["Status"];
                        incident.SuspectID = (int)data["SuspectID"];
                        incident.VictimID = (int)data["VictimID"];
                        incident.CaseID = (int)data["CaseID"];
                        incidents.Add(incident);
                    }

                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return incidents;
        }
        //Add Incident
        public int AddIncident(Incidents incident)
        {
            int status = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {

                    cmd.CommandText = "insert into Incidents values(@iid,@itype,@idate,@loc,@description,@status,@vid,@sid,@cid)";
                    cmd.Parameters.AddWithValue("@iid", incident.IncidentID);
                    cmd.Parameters.AddWithValue("@itype", incident.IncidentType);
                    cmd.Parameters.AddWithValue("@idate", incident.IncidentDate);
                    cmd.Parameters.AddWithValue("@description", incident.Description);
                    cmd.Parameters.AddWithValue("@loc", incident.Location);
                    cmd.Parameters.AddWithValue("@status", incident.Status);
                    cmd.Parameters.AddWithValue("@sid", incident.SuspectID);
                    cmd.Parameters.AddWithValue("@vid", incident.VictimID);
                    cmd.Parameters.AddWithValue("cid", incident.CaseID);
                    cmd.Connection = conn;
                    conn.Open();
                    status = cmd.ExecuteNonQuery();
                }
                cmd.Parameters.Clear();
                
            }catch (Exception ex) { throw new IncidentAlreadyExistException("Incident already exists."); }
            return status;
        }
        
        //update incident status
        public int updateIncidentStatus(int incidentID,String status) {
            int updatestatus = 0;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionstring))
                {
                    cmd.CommandText = "update Incidents set Status=@sts where IncidentID=@id";
                    cmd.Parameters.AddWithValue("@sts", status);
                    cmd.Parameters.AddWithValue("@id", incidentID);
                    cmd.Connection = conn;
                    conn.Open();
                    updatestatus=cmd.ExecuteNonQuery();
                }
                cmd.Parameters.Clear();
            }catch(Exception ex) { Console.WriteLine(ex.Message);}
            return updatestatus;
        
        }

        //Search Incidents
        public List<Incidents> SearchIncidents(string incidentType)
        {
            List<Incidents> incidents = new List<Incidents>();
            try
            {
                using(SqlConnection conn=new SqlConnection(connectionstring))
                {
                    cmd.CommandText = "select * from Incidents where IncidentType=@type";
                    cmd.Parameters.AddWithValue("@type", incidentType);
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Incidents incident = new Incidents();
                        incident.IncidentID = (int)reader["IncidentID"];
                        incident.IncidentType = (string)reader["IncidentType"];
                        incident.IncidentDate = ((DateTime)reader["IncidentDate"]).Date;
                        incident.Description = (string)reader["Description"];
                        incident.Location = (string)reader["Location"];
                        incident.Status = (string)reader["Status"];
                        incident.SuspectID = (int)reader["SuspectID"];
                        incident.VictimID = (int)reader["VictimID"];
                        incident.CaseID = (int)reader["CaseID"];
                        incidents.Add(incident);
                    }
                    cmd.Parameters.Clear();
                    if(incidents.Count==0) { throw new IncidentTypeNotFoundException("Incident type not Found"); }
                }
            }finally { cmd.Dispose(); }
            return incidents;
        }


        //Get incidents in date range
        public List<Incidents> getIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {
            List<Incidents> indaterange = new List<Incidents>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionstring))
                {
                    cmd.CommandText = "select IncidentDate from Incidents where IncidentDate between @sdate and @edate";
                    cmd.Parameters.AddWithValue("@sdate", startDate);
                    cmd.Parameters.AddWithValue("@edate", endDate);
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Incidents incident = new Incidents();
                        incident.IncidentID = (int)reader["IncidentID"];
                        incident.IncidentType = (string)reader["IncidentType"];
                        incident.IncidentDate = ((DateTime)reader["IncidentDate"]).Date;
                        incident.Description = (string)reader["Description"];
                        incident.Location = (string)reader["Location"];
                        incident.Status = (string)reader["Status"];
                        incident.SuspectID = (int)reader["SuspectID"];
                        incident.VictimID = (int)reader["VictimID"];
                        incident.CaseID = (int)reader["CaseID"];
                        indaterange.Add(incident);

                    }


                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return indaterange;
        }
    }
}
