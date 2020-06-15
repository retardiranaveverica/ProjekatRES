using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalComponent
{
    public class Database : IDatabase
    {
        #region connectionString and commands for making tables
        //sneza 
        //string connectionString = "Data Source=localhost;Initial Catalog=Database;Integrated Security=True";
        //maja
        string connectionString = "Data Source=localhost;Initial Catalog=HistoricalDatabase;Integrated Security=True";
        string command_1 = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Dataset1') BEGIN  CREATE TABLE[dbo].[Dataset1] ( [Idd] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, [Dataset] INT NOT NULL, [Value] INT NOT NULL, [Code] NVARCHAR(MAX) NOT NULL , [TIMESTAMP] datetime NOT NULL); END;";
        string command_2 = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Dataset2') BEGIN  CREATE TABLE[dbo].[Dataset2] ( [Idd] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, [Dataset] INT NOT NULL, [Value] INT NOT NULL, [Code] NVARCHAR(MAX) NOT NULL , [TIMESTAMP] datetime NOT NULL); END;";
        string command_3 = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Dataset3') BEGIN  CREATE TABLE[dbo].[Dataset3] ( [Idd] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, [Dataset] INT NOT NULL, [Value] INT NOT NULL, [Code] NVARCHAR(MAX) NOT NULL , [TIMESTAMP] datetime NOT NULL); END;";
        string command_4 = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Dataset4') BEGIN  CREATE TABLE[dbo].[Dataset4] ( [Idd] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, [Dataset] INT NOT NULL, [Value] INT NOT NULL, [Code] NVARCHAR(MAX) NOT NULL , [TIMESTAMP] datetime NOT NULL); END;";
        string command_5 = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Dataset5') BEGIN  CREATE TABLE[dbo].[Dataset5] ( [Idd] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, [Dataset] INT NOT NULL, [Value] INT NOT NULL, [Code] NVARCHAR(MAX) NOT NULL , [TIMESTAMP] datetime NOT NULL); END;";
        #endregion 

        public struct Data
        {
            public string code;
            public int id;
            public int value;
            public int dataset;
        }
        public struct UpdateData
        {
            public bool ima;
            public int value;
        }
        public SqlConnection sqlConnection { get; set; }
        
        #region ListOfDatasets
        List<Data> datas = new List<Data>();
        List<Data> dataset1 = new List<Data>();
        List<Data> dataset2 = new List<Data>();
        List<Data> dataset3 = new List<Data>();
        List<Data> dataset4 = new List<Data>();
        List<Data> dataset5 = new List<Data>();
        #endregion

      //  List<Data> listOfData = new List<Data>();
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

        public void Create()
        {
            CreateTable_1();
            CreateTable_2();
            CreateTable_3();
            CreateTable_4();
            CreateTable_5();
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
        
        public void WriteToDatabase()
        {
            
            ReplaceData();
            ReplaceDataDB();
            Create();
            Connect();
            Write();
            sqlConnection.Close();
        }

        private void Write()
        {
                WriteToDataset1();
                WriteToDataset2();
                WriteToDataset3();
                WriteToDataset4();
                WriteToDataset5();
        }

        private void WriteToDataset1()
        {
            if(Update_1_1().ima == false || Update_1_2().ima == false)
            {
                InsertInTable_1();

            }
            else if(Update_1_2().ima == true)
            {

                foreach (var item in datas)
                {
                    if (item.code == "CODE_DIGITAL")
                    {
                        //if (item.value > (Update_1_1().value + Update_1_1().value * 0.02))
                        //{
                        //    U1_1();
                        //}
                        //else
                        //    break;
                        U1_2();
                    }
                    //else
                    //    break;
                }

            }
            else if(Update_1_1().ima == true)
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_ANALOG")
                    {
                        //if (item.value > (Update_1_2().value + Update_1_2().value * 0.02))
                        //{
                        //    U1_2();
                        //}
                        //else
                        //    break;
                        U1_1();
                    }
                    //else
                    //    break;
                }

                
            }
        }
        private void WriteToDataset2()
        {
            if (Update_2_1().ima == false || Update_2_2().ima == false)
            {
                InsertInTable_2();

            }
            else if (Update_2_1().ima == true)
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_CUSTOM")
                    {
                        //if (item.value > (Update_2_1().value + Update_2_1().value * 0.02))
                        //{
                        //    U2_2();
                        //}
                        //else
                        //    break;
                        U2_2();
                    }
                    //else
                    //    break;
                    
                    
                }
                
            }
            else if (Update_2_2().ima == true)
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_LIMITSET")
                    {
                        //if (item.value > (Update_2_2().value + Update_2_2().value * 0.02))
                        //{
                        //    U2_1();
                        //}
                        //else
                        //    break;
                        U2_1();
                    }
                    //else
                    //    break;
                }
                
            }
        }
        private void WriteToDataset3()
        {

            if (Update_3_1().ima == false || Update_3_2().ima == false)
            {
                InsertInTable_3();

            }
            else if (Update_3_1().ima == true)
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_SINGLENOE")
                    {
                        //if (item.value > (Update_3_1().value + Update_3_1().value * 0.02))
                        //{
                        //    U3_1();
                        //}
                        //else
                        //    break;
                        U3_1();
                    }
                    //else break;
                }
            }
            else if (Update_3_2().ima == true)
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_MULTIPLENODE")
                    {
                        //if (item.value > (Update_3_2().value + Update_3_2().value * 0.02))
                        //{
                        //    U3_2();
                        //}
                        //else
                        //    break;
                        U3_2();
                    }
                    //else break;
                }

                
            }
        }
        private void WriteToDataset4()
        {

            if (Update_4_1().ima == false || Update_4_2().ima == false)
            {
                InsertInTable_4();

            }
            else if (Update_4_1().ima == true)
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_CONSUMER")
                    {
                        //if (item.value > (Update_4_1().value + Update_4_1().value * 0.02))
                        //{
                        //    U4_1();
                        //}
                        //else
                        //    break;
                        U4_1();
                    }
                    //else
                    //    break;
                }
                

            }
            else if (Update_4_2().ima == true)
            {

                foreach (var item in datas)
                {
                    if (item.code == "CODE_SOURCE")
                    {
                        //if (item.value > (Update_4_2().value + Update_4_2().value * 0.02))
                        //{
                        //    U4_2();
                        //}
                        //else
                        //    break;
                        U4_2();
                    }
                    //else break;
                    
                }
                
            }
        }
        private void WriteToDataset5()
        {
            if (Update_5_1().ima == false || Update_5_2().ima == false)
            {
                InsertInTable_5();

            }
            else if (Update_5_1().ima == true)
            {

                
                foreach (var item in datas)
                {
                    if (item.code == "CODE_MOTION")
                    {
                        //if (item.value > (Update_5_1().value + Update_5_1().value * 0.02))
                        //{
                        //    U5_1();
                        //}
                        //else
                        //    break;
                        U5_1();
                    }
                    //else
                    //    break;

                }

            }
            else if (Update_5_2().ima == true)
            {
                
                foreach (var item in datas)
                {
                    if (item.code == "CODE_SENSOR")
                    {
                        //if (item.value > (Update_5_2().value + Update_5_2().value * 0.02))
                        //{
                        //    U5_2();
                        //}
                        //else
                        //    break;
                        U5_2();
                    }
                    //else
                    //    break;

                }
            }
        }


        //pravljenje liste
        private void ReplaceData()
        {
            Data data = new Data();
            using (StreamWriter sw = new StreamWriter("Database.txt", true))
            {

                foreach (var item in WriterToHistorical.descriptionLists)
                {
                    foreach (var item2 in item.descriptions)
                    {
                        foreach (var item3 in item2.HistoricalProperties)
                        {
                            if (item2.Dataset == 1)
                            {
                                data.code = item3.Code;
                                data.value = item3.HistoricalValue;

                                data.id = item2.Id;
                                data.dataset = item2.Dataset;

                                sw.WriteLine(item3.Code);
                                sw.WriteLine(item3.HistoricalValue);
                                sw.WriteLine(item2.Id);
                                sw.WriteLine(item2.Dataset);

                                dataset1.Add(data);
                            }
                            else if (item2.Dataset == 2)
                            {
                                data.code = item3.Code;
                                data.value = item3.HistoricalValue;

                                data.id = item2.Id;
                                data.dataset = item2.Dataset;

                                sw.WriteLine(item3.Code);
                                sw.WriteLine(item3.HistoricalValue);
                                sw.WriteLine(item2.Id);
                                sw.WriteLine(item2.Dataset);

                                dataset2.Add(data);
                            }
                            else if (item2.Dataset == 3)
                            {
                                data.code = item3.Code;
                                data.value = item3.HistoricalValue;

                                data.id = item2.Id;
                                data.dataset = item2.Dataset;

                                sw.WriteLine(item3.Code);
                                sw.WriteLine(item3.HistoricalValue);
                                sw.WriteLine(item2.Id);
                                sw.WriteLine(item2.Dataset);

                                dataset3.Add(data);
                            }
                            else if (item2.Dataset == 4)
                            {
                                data.code = item3.Code;
                                data.value = item3.HistoricalValue;

                                data.id = item2.Id;
                                data.dataset = item2.Dataset;

                                sw.WriteLine(item3.Code);
                                sw.WriteLine(item3.HistoricalValue);
                                sw.WriteLine(item2.Id);
                                sw.WriteLine(item2.Dataset);

                                dataset4.Add(data);
                            }
                            else if (item2.Dataset == 5)
                            {
                                data.code = item3.Code;
                                data.value = item3.HistoricalValue;

                                data.id = item2.Id;
                                data.dataset = item2.Dataset;

                                
                                sw.WriteLine(item3.Code);
                                sw.WriteLine(item3.HistoricalValue);
                                sw.WriteLine(item2.Id);
                                sw.WriteLine(item2.Dataset);
                                dataset5.Add(data);
                            }
                        }

                        datas.Add(data);
                    }
                }
            }
        }

        
        private void ReplaceDataDB()
        {
            Data data = new Data();
            using (StreamWriter sw = new StreamWriter("LogDB.txt", true))
            {

                foreach (var item in DataFromDB.descriptionLists)
                {
                    foreach (var item2 in item.descriptions)
                    {
                        foreach (var item3 in item2.HistoricalProperties)
                        {
                            if (item2.Dataset == 1)
                            {
                                data.code = item3.Code;
                                data.value = item3.HistoricalValue;

                                data.id = item2.Id;
                                data.dataset = item2.Dataset;

                                sw.WriteLine(item3.Code);
                                sw.WriteLine(item3.HistoricalValue);
                                sw.WriteLine(item2.Id);
                                sw.WriteLine(item2.Dataset);
                                dataset1.Add(data);
                            }
                            else if (item2.Dataset == 2)
                            {
                                data.code = item3.Code;
                                data.value = item3.HistoricalValue;

                                data.id = item2.Id;
                                data.dataset = item2.Dataset;

                                sw.WriteLine(item3.Code);
                                sw.WriteLine(item3.HistoricalValue);
                                sw.WriteLine(item2.Id);
                                sw.WriteLine(item2.Dataset);

                                dataset2.Add(data);
                            }
                            else if (item2.Dataset == 3)
                            {
                                data.code = item3.Code;
                                data.value = item3.HistoricalValue;

                                data.id = item2.Id;
                                data.dataset = item2.Dataset;

                                sw.WriteLine(item3.Code);
                                sw.WriteLine(item3.HistoricalValue);
                                sw.WriteLine(item2.Id);
                                sw.WriteLine(item2.Dataset);

                                dataset3.Add(data);
                            }
                            else if (item2.Dataset == 4)
                            {
                                data.code = item3.Code;
                                data.value = item3.HistoricalValue;

                                data.id = item2.Id;
                                data.dataset = item2.Dataset;

                                sw.WriteLine(item3.Code);
                                sw.WriteLine(item3.HistoricalValue);
                                sw.WriteLine(item2.Id);
                                sw.WriteLine(item2.Dataset);

                                dataset4.Add(data);
                            }
                            else if (item2.Dataset == 5)
                            {
                                data.code = item3.Code;
                                data.value = item3.HistoricalValue;

                                data.id = item2.Id;
                                data.dataset = item2.Dataset;


                                sw.WriteLine(item3.Code);
                                sw.WriteLine(item3.HistoricalValue);
                                sw.WriteLine(item2.Id);
                                sw.WriteLine(item2.Dataset);
                                dataset5.Add(data);
                            }
                        }

                        datas.Add(data);
                    }
                }
            }
        }
        private void U1_1()
        {



            string command_delete = "DELETE FROM Dataset1 WHERE Idd=1";

            using (SqlCommand sqlCommand = new SqlCommand(command_delete, sqlConnection))
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_ANALOG")
                    {

                        sqlCommand.Parameters.Clear();
                        
                        sqlCommand.ExecuteNonQuery();

                        break;
                    }
                }
            }

            InsertInTable_1();
            

        }
        private void U1_2()
        {
            string command_delete = "DELETE FROM Dataset1 WHERE Idd=2";

            using (SqlCommand sqlCommand = new SqlCommand(command_delete, sqlConnection))
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_DIGITAL")
                    {

                        sqlCommand.Parameters.Clear();

                        sqlCommand.ExecuteNonQuery();

                        break;
                    }
                }
            }

            InsertInTable_1();
        }
        private void U2_2()
        {
            string command_delete = "DELETE FROM Dataset2 WHERE Idd=3";

            using (SqlCommand sqlCommand = new SqlCommand(command_delete, sqlConnection))
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_CUSTOM")
                    {

                        sqlCommand.Parameters.Clear();

                        sqlCommand.ExecuteNonQuery();

                        break;
                    }
                }
            }
            InsertInTable_2();
        }
        private void U2_1()
        {

            string command_delete = "DELETE FROM Dataset2 WHERE Idd=4";

            using (SqlCommand sqlCommand = new SqlCommand(command_delete, sqlConnection))
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_LIMITSET")
                    {

                        sqlCommand.Parameters.Clear();

                        sqlCommand.ExecuteNonQuery();

                        break;
                    }
                }
            }
            InsertInTable_2();
        }
        private void U3_1()
        {

            string command_delete = "DELETE FROM Dataset3 WHERE Idd=5";

            using (SqlCommand sqlCommand = new SqlCommand(command_delete, sqlConnection))
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_SINGLENOE")
                    {

                        sqlCommand.Parameters.Clear();

                        sqlCommand.ExecuteNonQuery();

                        break;
                    }
                }
            }
            InsertInTable_3();
        }
        private void U3_2()
        {
           

            string command_delete = "DELETE FROM Dataset3 WHERE Idd=6";

            using (SqlCommand sqlCommand = new SqlCommand(command_delete, sqlConnection))
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_MULTIPLENODE")
                    {

                        sqlCommand.Parameters.Clear();

                        sqlCommand.ExecuteNonQuery();

                        break;
                    }
                }
            }
            InsertInTable_3();
        }
        private void U4_1()
        {


            string command_delete = "DELETE FROM Dataset4 WHERE Idd=7";

            using (SqlCommand sqlCommand = new SqlCommand(command_delete, sqlConnection))
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_CONSUMER")
                    {

                        sqlCommand.Parameters.Clear();

                        sqlCommand.ExecuteNonQuery();

                        break;
                    }
                }
            }
            InsertInTable_4();
        }
        private void U4_2()
        {
            string command_delete = "DELETE FROM Dataset4 WHERE Idd=8";

            using (SqlCommand sqlCommand = new SqlCommand(command_delete, sqlConnection))
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_SOURCE")
                    {

                        sqlCommand.Parameters.Clear();

                        sqlCommand.ExecuteNonQuery();

                        break;
                    }
                }
            }
            InsertInTable_4();
        }
        private void U5_1()
        {
            string command_delete = "DELETE FROM Dataset5 WHERE Idd=9";

            using (SqlCommand sqlCommand = new SqlCommand(command_delete, sqlConnection))
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_MOTION")
                    {

                        sqlCommand.Parameters.Clear();

                        sqlCommand.ExecuteNonQuery();

                        break;
                    }
                }
            }
            InsertInTable_5();

        }
        private void U5_2()
        {
            string command_delete = "DELETE FROM Dataset5 WHERE Idd=10";

            using (SqlCommand sqlCommand = new SqlCommand(command_delete, sqlConnection))
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_SENSOR")
                    {

                        sqlCommand.Parameters.Clear();

                        sqlCommand.ExecuteNonQuery();

                        break;
                    }
                }
            }
            InsertInTable_5();
        }
        //upisi
        #region WrittingDataInTable
        private void InsertInTable_1()
        {

            string command1 = "SET IDENTITY_INSERT Dataset1 ON INSERT INTO Dataset1 (Idd, Dataset, Value, Code, Timestamp) VALUES (@id, @dataset, @value, @code, @timestamp)";


            using (SqlCommand sqlCommand = new SqlCommand(command1, sqlConnection))
            {
                
                foreach (var item in dataset1)
                {
                    try
                    {
                        sqlCommand.Parameters.Clear();
                        sqlCommand.Parameters.AddWithValue("@id", item.id);
                        sqlCommand.Parameters.AddWithValue("@dataset", item.dataset);
                        sqlCommand.Parameters.AddWithValue("@code", item.code);
                        sqlCommand.Parameters.AddWithValue("@value", item.value);
                        sqlCommand.Parameters.AddWithValue("@timestamp", DateTime.Now);

                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                    }

                }


                dataset1.Clear();
            }
        }
        private void InsertInTable_2()
        {

            string command1 = "SET IDENTITY_INSERT Dataset2 ON INSERT INTO Dataset2 (Idd, Dataset, Value, Code, Timestamp) VALUES (@id, @dataset, @value, @code, @timestamp)";


            using (SqlCommand sqlCommand = new SqlCommand(command1, sqlConnection))
            {
                foreach (var item in dataset2)
                {
                    try
                    {
                        sqlCommand.Parameters.Clear();
                        sqlCommand.Parameters.AddWithValue("@id", item.id);
                        sqlCommand.Parameters.AddWithValue("@dataset", item.dataset);
                        sqlCommand.Parameters.AddWithValue("@code", item.code);
                        sqlCommand.Parameters.AddWithValue("@value", item.value);
                        sqlCommand.Parameters.AddWithValue("@timestamp", DateTime.Now);

                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                    }

                }


                dataset2.Clear();
            }
        }
        private void InsertInTable_3()
        {


            string command1 = "SET IDENTITY_INSERT Dataset3 ON INSERT INTO Dataset3 (Idd, Dataset, Value, Code, Timestamp) VALUES (@id, @dataset, @value, @code, @timestamp)";


            using (SqlCommand sqlCommand = new SqlCommand(command1, sqlConnection))
            {



                foreach (var item in dataset3)
                {
                    try
                    {
                        sqlCommand.Parameters.Clear();
                        sqlCommand.Parameters.AddWithValue("@id", item.id);
                        sqlCommand.Parameters.AddWithValue("@dataset", item.dataset);
                        sqlCommand.Parameters.AddWithValue("@code", item.code);
                        sqlCommand.Parameters.AddWithValue("@value", item.value);
                        sqlCommand.Parameters.AddWithValue("@timestamp", DateTime.Now);

                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                    }

                }


                dataset3.Clear();
            }
            
        }
        private void InsertInTable_4()
        {

            string command1 = "SET IDENTITY_INSERT Dataset4 ON INSERT INTO Dataset4 (Idd, Dataset, Value, Code, Timestamp) VALUES (@id, @dataset, @value, @code, @timestamp)";


            using (SqlCommand sqlCommand = new SqlCommand(command1, sqlConnection))
            {
                foreach (var item in dataset4)
                {
                    try
                    {
                        sqlCommand.Parameters.Clear();
                        sqlCommand.Parameters.AddWithValue("@id", item.id);
                        sqlCommand.Parameters.AddWithValue("@dataset", item.dataset);
                        sqlCommand.Parameters.AddWithValue("@code", item.code);
                        sqlCommand.Parameters.AddWithValue("@value", item.value);
                        sqlCommand.Parameters.AddWithValue("@timestamp", DateTime.Now);

                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                    }

                }


                dataset4.Clear();
            }
        }
        private void InsertInTable_5()
        {

            string command1 = "SET IDENTITY_INSERT Dataset5 ON INSERT INTO Dataset5 (Idd, Dataset, Value, Code, Timestamp) VALUES (@id, @dataset, @value, @code, @timestamp)";


            using (SqlCommand sqlCommand = new SqlCommand(command1, sqlConnection))
            {
                foreach (var item in dataset5)
                {
                    try
                    {
                        sqlCommand.Parameters.Clear();
                        sqlCommand.Parameters.AddWithValue("@id", item.id);
                        sqlCommand.Parameters.AddWithValue("@dataset", item.dataset);
                        sqlCommand.Parameters.AddWithValue("@code", item.code);
                        sqlCommand.Parameters.AddWithValue("@value", item.value);
                        sqlCommand.Parameters.AddWithValue("@timestamp", DateTime.Now);

                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                    }

                }


                dataset5.Clear();
            }
        }
        #endregion
        #region CheckForUpdate
        //1 CODE_ANALOG
        private UpdateData Update_1_1()
        {
            UpdateData data = new UpdateData();
           // bool ima = false;
                // Read specific values in the table.
            using (SqlCommand com = new SqlCommand("SELECT Idd, Dataset, Value, Code  FROM Dataset1 WHERE Idd = 1", sqlConnection))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    //reader.Read();
                    //data.value = Convert.ToInt32(reader.GetValue(2));

                    data.ima = true;
                }
                else
                {
                    data.ima = false;
                }

                reader.Close();
            }
            return data;
        }

        //2 CODE_DIGITAL
        private UpdateData Update_1_2()
        {
            UpdateData data = new UpdateData();
            //bool ima = false;
            // Read specific values in the table.
            using (SqlCommand com = new SqlCommand("SELECT Idd, Dataset, Value, Code  FROM Dataset1 WHERE Idd = 2", sqlConnection))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    //reader.Read();
                    //data.value = Convert.ToInt32(reader.GetValue(2));
                    data.ima = true;
                }
                else
                {
                    data.ima = false;
                }

                reader.Close();
            }
            return data;
        }

        //3 CODE_CUSTOM
        private UpdateData Update_2_1()
        {
            UpdateData data = new UpdateData();
            //bool ima = false;
            // Read specific values in the table.
            using (SqlCommand com = new SqlCommand("SELECT Idd FROM Dataset2 WHERE Idd = 3", sqlConnection))
            {

                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    //reader.Read();
                    //data.value = Convert.ToInt32(reader.GetValue(2));

                    data.ima = true;
                }
                else
                {
                    data.ima = false;
                }

                reader.Close();
            }
            return data;
        }
        //4 CODE_LIMITSET
        private UpdateData Update_2_2()
        {
            UpdateData data = new UpdateData();
          //  bool ima = false;
            // Read specific values in the table.
            using (SqlCommand com = new SqlCommand("SELECT Idd FROM Dataset2 WHERE Idd = 4", sqlConnection))
            {

                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    //reader.Read();
                    //data.value = Convert.ToInt32(reader.GetValue(2));
                    data.ima = true;
                }
                else
                {
                    data.ima = false;
                }

                reader.Close();
            }
            return data;
        }

        //5 CODE_SINGLENOE 
        private UpdateData Update_3_1()
        {
            UpdateData data = new UpdateData();
           // bool ima = false;
            // Read specific values in the table.
            using (SqlCommand com = new SqlCommand("SELECT Idd, Dataset, Value, Code  FROM Dataset3 WHERE Idd = 5", sqlConnection))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    //reader.Read();
                    //data.value = Convert.ToInt32(reader.GetValue(2));
                    data.ima = true;
                }
                else
                {
                    data.ima = false;
                }

                reader.Close();
            }
            return data;
        }

        //6 CODE_MULTIPLENODE
        private UpdateData Update_3_2()
        {
            UpdateData data = new UpdateData();
            //bool ima = false;
            // Read specific values in the table.
            using (SqlCommand com = new SqlCommand("SELECT Idd, Dataset, Value, Code  FROM Dataset3 WHERE Idd = 6", sqlConnection))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    //reader.Read();
                    //data.value = Convert.ToInt32(reader.GetValue(2));

                    data.ima = true;
                }
                else
                {
                    data.ima = false;
                }

                reader.Close();
            }
            return data;
        }

        //7 CODE_CONSUMER 
        private UpdateData Update_4_1()
        {
            UpdateData data = new UpdateData();
            //bool ima = false;
            // Read specific values in the table.
            using (SqlCommand com = new SqlCommand("SELECT Idd FROM Dataset4 WHERE Idd = 7", sqlConnection))
            {

                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    //reader.Read();
                    //data.value = Convert.ToInt32(reader.GetValue(2));
                    
                    data.ima = true;
                }
                else
                {
                    data.ima = false;
                }

                reader.Close();
            }
            return data;

        }

        //8 CODE_SOURCE 
        private UpdateData Update_4_2()
        {
            UpdateData data = new UpdateData();
           // bool ima = false;
            // Read specific values in the table.
            using (SqlCommand com = new SqlCommand("SELECT Idd FROM Dataset4 WHERE Idd = 8", sqlConnection))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    //reader.Read();
                    //data.value = Convert.ToInt32(reader.GetValue(2));

                    data.ima = true;
                }
                else
                {
                    data.ima = false;
                }

                reader.Close();
            }
            return data;
        }

        //9 CODE_MOTION 
        private UpdateData Update_5_1()
        {
            UpdateData data = new UpdateData();
          //  bool ima = false;
            // Read specific values in the table.
            using (SqlCommand com = new SqlCommand("SELECT Idd FROM Dataset5 WHERE Idd = 9", sqlConnection))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    //reader.Read();
                    //data.value = Convert.ToInt32(reader.GetValue(2));
                    data.ima = true;
                }
                else
                {
                    data.ima = false;
                }

                reader.Close();
            }
            return data;
        }

        //10 CODE_SENSOR 
        private UpdateData Update_5_2()
        {
            UpdateData data = new UpdateData();
           // bool ima = false;
            // Read specific values in the table.
            using (SqlCommand com = new SqlCommand("SELECT Idd FROM Dataset5 WHERE Idd = 10", sqlConnection))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    //reader.Read();
                    //data.value = Convert.ToInt32(reader.GetValue(2));
                    data.ima = true;
                }
                else
                {
                    data.ima = false;
                }

                reader.Close();
            }
            return data;

        }
        #endregion
    }
}
