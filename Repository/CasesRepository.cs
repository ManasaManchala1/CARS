using CARS.Entities;
using CARS.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //public Cases createCase(string caseDescription, List<Incidents> relatedIncidents)
        //{
        //    Cases cases = new Cases();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionstring))
        //        {
                    

        //        }
        //    }

        //}

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
                        cases.Status = (string)reader["Status"];
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
                        cases.Status = (string)reader["Status"];
                        cases.Description = (string)reader["Description"];
                    }
                }
            }catch(Exception ex) { Console.WriteLine(ex.Message); }
            return cases;
        }
        public int updateCaseDetails(int caseID,string status)
        {
            int updatestatus = 0;
            try
            {
                using(SqlConnection conn=new SqlConnection(connectionstring))
                {
                    cmd.CommandText = "update Cases set Status=@sts where CaseID=@cid";
                    cmd.Parameters.AddWithValue("@sts", status);
                    cmd.Parameters.AddWithValue("@cid", caseID);
                    cmd.Connection = conn;
                    conn.Open();
                    updatestatus= cmd.ExecuteNonQuery();
                }
            }catch (Exception ex) { Console.WriteLine(ex.Message); }
            return updatestatus;
        }

        //public Cases getCaseDetails(int caseId)
        //{
        //    Cases casedetails=cases.Find(c=>c.CaseID==caseId);
        //    return casedetails;
        //}

        //public void updateCaseDetails(Cases caseToUpdate)
        //{
        //    caseToUpdate.Status = "Closed";
        //}
    }
}
