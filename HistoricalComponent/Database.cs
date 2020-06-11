using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalComponent
{
    public class Database : IDatabase
    {
        #region connectionString and commands for making tables
        string connectionString = "Data Source=localhost;Initial Catalog=HistoricalDatabase;Integrated Security=True";
        string command_1 = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Dataset1') BEGIN  CREATE TABLE[dbo].[Dataset1] ( [Id] INT NOT NULL IDENTITY PRIMARY KEY, [Dataset] INT NOT NULL, [Value] INT NOT NULL, [Code] NVARCHAR(MAX) NOT NULL , [TIMESTAMP] datetime NOT NULL); END;";
        string command_2 = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Dataset2') BEGIN  CREATE TABLE[dbo].[Dataset2] ( [Id] INT NOT NULL IDENTITY PRIMARY KEY, [Dataset] INT NOT NULL, [Value] INT NOT NULL, [Code] NVARCHAR(MAX) NOT NULL , [TIMESTAMP] datetime NOT NULL); END;";
        string command_3 = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Dataset3') BEGIN  CREATE TABLE[dbo].[Dataset3] ( [Id] INT NOT NULL IDENTITY PRIMARY KEY, [Dataset] INT NOT NULL, [Value] INT NOT NULL, [Code] NVARCHAR(MAX) NOT NULL , [TIMESTAMP] datetime NOT NULL); END;";
        string command_4 = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Dataset4') BEGIN  CREATE TABLE[dbo].[Dataset4] ( [Id] INT NOT NULL IDENTITY PRIMARY KEY, [Dataset] INT NOT NULL, [Value] INT NOT NULL, [Code] NVARCHAR(MAX) NOT NULL , [TIMESTAMP] datetime NOT NULL); END;";
        string command_5 = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Dataset5') BEGIN  CREATE TABLE[dbo].[Dataset5] ( [Id] INT NOT NULL IDENTITY PRIMARY KEY, [Dataset] INT NOT NULL, [Value] INT NOT NULL, [Code] NVARCHAR(MAX) NOT NULL , [TIMESTAMP] datetime NOT NULL); END;";
        #endregion 

        public struct Data
        {
            public string code;
            public int id;
            public int value;
            public int dataset;
        }

        public SqlConnection sqlConnection { get; set; }

        List<Data> listOfData = new List<Data>();
        private void Connect()
        {
            sqlConnection = new SqlConnection(connectionString);
            
            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                sqlConnection.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }
        private void CreateTable_1()
        {
            try
            {
               // sqlConnection.Open();
                Connect();
                using (SqlCommand sqlCommand = new SqlCommand(command_1, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                sqlConnection.Close();
            }
        }
        private void CreateTable_2()
        {
            try
            {
                // sqlConnection.Open();
                Connect();
                using (SqlCommand sqlCommand = new SqlCommand(command_2, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                sqlConnection.Close();
            }
        }
        private void CreateTable_3()
        {
            try
            {
                // sqlConnection.Open();
                Connect();
                using (SqlCommand sqlCommand = new SqlCommand(command_3, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                sqlConnection.Close();
            }
        }
        private void CreateTable_4()
        {
            try
            {
                // sqlConnection.Open();
                Connect();
                using (SqlCommand sqlCommand = new SqlCommand(command_4, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                sqlConnection.Close();
            }
        }
        private void CreateTable_5()
        {
            try
            {
                // sqlConnection.Open();
                Connect();
                using (SqlCommand sqlCommand = new SqlCommand(command_5, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                sqlConnection.Close();
            }
        }

        public void Create()
        {
            CreateTable_1();
            CreateTable_2();
            CreateTable_3();
            CreateTable_4();
            CreateTable_5();
        }

        public void WriteToDatabase()
        {
            Create();
            sqlConnection.Open();
            DataList();
            Read();

            string command = "SET IDENTITY_INSERT Dataset1 ON INSERT INTO Dataset1 (Id, Dataset, Value, Code, Timestamp) VALUES (@id, @dataset, @value, @code, @timestamp)";
            
                    using (SqlCommand sqlCommand = new SqlCommand(command, sqlConnection))
                    {
                        foreach (var item in listOfData)
                        {

                            sqlCommand.Parameters.AddWithValue("@id", item.id);
                            sqlCommand.Parameters.AddWithValue("@dataset", item.dataset);
                            sqlCommand.Parameters.AddWithValue("@code", "CODE_DIGITAL");
                            sqlCommand.Parameters.AddWithValue("@value", item.value);
                            sqlCommand.Parameters.AddWithValue("@timestamp", DateTime.Now);

                            sqlCommand.ExecuteNonQuery();
                        }
                
                    }
           
             sqlConnection.Close();
        }

        private void Read()
        {
            foreach(var item in listOfData)
            {
                Console.WriteLine(item.code);
                Console.WriteLine(item.dataset);
                Console.WriteLine(item.id);
                Console.WriteLine(item.value);
            }
        }

        private void DataList()
        {
            Data data = new Data();

            foreach(var item in DataFromDB.descriptionLists)
            {
                foreach(var item2 in item.descriptions)
                {
                    foreach(var item3 in item2.HistoricalProperties)
                    {
                        data.code = item3.Code;
                        data.value = item3.HistoricalValue;
                        data.id = item2.Id;
                        data.dataset = item2.Dataset;
                        listOfData.Add(data);
                        break;
                    }
                    break;
                }
            }

            
            
        }
    }
}
