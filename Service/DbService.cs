using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Service
{
    public class DbService
    {


        private readonly string _connectionString;


        public DbService()
        {
           
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PLANDB"].ConnectionString;
        }




        public DataSet GetDataFromQueryWithOutParam(string query)
        {
            var ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds); 
                }
            }

            return ds;
        }


        public DataSet GetDataFromQueryWithParam(string query, Dictionary<string, object> parameters)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Query cannot be empty", nameof(query));

            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                }
            }

            return ds;
        }


        public string GetDataFromStoredProcedure(string spName, Dictionary<string, object> parameters)
        {
            if (string.IsNullOrWhiteSpace(spName))
                throw new ArgumentException("Stored procedure name cannot be empty", nameof(spName));

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    var result = cmd.ExecuteScalar();
                    return result?.ToString().Trim();
                }
            }
        }


        public void SaveData(string data)
        {
            // Logic to save data
        }

        public bool DeleteData(int id)
        {
            // Logic to delete data by id
            return true;
        }

        public string UpdateData(int id, string newData)
        {
            // Logic to update data by id
            return "Updated Data";
        }

        public int CountDataEntries()
        {
            // Logic to count data entries
            return 42;
        }

        public bool DataExists(int id)
        {
            // Logic to check if data exists by id
            return true;
        }

        public string GetDataById(int id)
        {
            // Logic to get data by id
            return "Data for ID: " + id;
        }





    }
}