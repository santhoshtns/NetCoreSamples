using Microsoft.Data.SqlClient;
using System.Data;

namespace DatabaseSync
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
        }

        public static void CopyTable(string sourceConnectionString, string destinationConnectionString, string tableName)
        {
            // Create a connection to the source database
            using (SqlConnection sourceConnection = new SqlConnection(sourceConnectionString))
            {
                sourceConnection.Open();

                // Retrieve data from the source table
                string selectSql = $"SELECT * FROM {tableName}";
                SqlCommand selectCommand = new SqlCommand(selectSql, sourceConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Create a connection to the destination database
                using (SqlConnection destinationConnection = new SqlConnection(destinationConnectionString))
                {
                    destinationConnection.Open();

                    // Check if the table exists in the destination database
                    string checkTableSql = $"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}') BEGIN CREATE TABLE {tableName} (...column definitions...) END";
                    SqlCommand checkTableCommand = new SqlCommand(checkTableSql, destinationConnection);
                    checkTableCommand.ExecuteNonQuery();

                    // Use SqlBulkCopy to insert the data into the destination table
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                    {
                        bulkCopy.DestinationTableName = tableName;
                        bulkCopy.WriteToServer(dataTable);
                    }
                }
            }
        }
    }
}
