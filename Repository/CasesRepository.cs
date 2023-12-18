using CARS.Entities;
using CARS.Utility;
using System.Data.SqlClient;

namespace CARS.Repository
{
    internal class CasesRepository : ICasesRepository
    {
        string connectionstring;
        SqlCommand cmd = null;
        public CasesRepository() {
            connectionstring = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public Cases createCase(string caseDescription, List<Incidents> relatedIncidents, int caseID)
        {
            Cases cases = new Cases();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    cmd.CommandText = "insert into Cases(CaseID,Description) values(@id,@des)";
                    cmd.Parameters.AddWithValue("@des", caseDescription);
                    cmd.Parameters.AddWithValue("@id", caseID);
                    cmd.Connection = conn;
                    conn.Open();
                    cases.Description = caseDescription;
                    cases.CaseID = caseID;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    conn.Close();
                    foreach(Incidents inc in relatedIncidents)
                    {
                        cmd.CommandText = "update Incidents set CaseID=@cid where IncidentID=@iid";
                        cmd.Connection.Open() ;
                        cmd.Parameters.AddWithValue("@cid", caseID);
                        cmd.Parameters.AddWithValue("@iid", inc.IncidentID);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        conn.Close();
                    }

                }
            }catch (Exception ex) { Console.WriteLine(ex.Message); }
            return cases;

        }

        public List<Cases> getAllCases()
        {
            List<Cases> list = new List<Cases>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionstring))
                {
                    cmd.CommandText = "select * from Cases";
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Cases cases= new Cases();
                        cases.CaseID = (int)reader["CaseID"];
                        cases.Description = (string)reader["Description"];
                        list.Add(cases);
                    }
                   
                }
            }catch (Exception ex) { Console.WriteLine(ex.Message); }
            return list;
        }
        public Cases getCaseDetails(int caseID)
        {
            Cases cases=new Cases();
            try
            {
                using(SqlConnection conn=new SqlConnection(connectionstring))
                {
                    cmd.CommandText = "select * from Cases where CaseID=@caseid";
                    cmd.Parameters.AddWithValue("@CaseID", caseID);
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cases.CaseID = (int)reader["CaseID"];
                        cases.Description = (string)reader["Description"];
                    }
                    cmd.Parameters.Clear();
                }
            }catch(Exception ex) { Console.WriteLine(ex.Message); }
            return cases;
        }
        public int updateCaseDetails(int caseID,string description)
        {
            int updatestatus = 0;
            try
            {
                using(SqlConnection conn=new SqlConnection(connectionstring))
                {
                    cmd.CommandText = "update Cases set Description=@dd where CaseID=@cid";
                    cmd.Parameters.AddWithValue("@cid", caseID);
                    cmd.Parameters.AddWithValue("@dd", description);
                    cmd.Connection = conn;
                    conn.Open();
                    updatestatus= cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }catch (Exception ex) { Console.WriteLine(ex.Message); }
            return updatestatus;
        }

    }
}
