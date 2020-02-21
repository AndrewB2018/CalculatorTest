using Data.Context;
using Data.Repository.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Data.Repository.ADO
{
    public class DiagnosticsRepositoryADO : IDiagnosticsRepository
    {
        
        public void CreateLog(string message)
        {
            try
            {
                //Stored procedure call here
                //Connection string - this would normally be in web.config or app.config
                string connectionString = "server=(LocalDb)\\MSSQLLocalDB;database=SampleDatabase;trusted_connection=true;";
                string SQL = "CreateDiagnosticsLog";

                // Create ADO.NET objects.
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter param;
                        param = command.Parameters.Add("@Message", SqlDbType.NVarChar, 200);
                        param.Value = message;

                        // Execute the command.

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error creating a new log", e);
            }

        }

    }
}
