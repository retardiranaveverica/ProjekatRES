using Common;
using DumpingBufferComponent;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBuffer
{
    public class DatabaseDB : IDatabase
    {
        #region connectionString and commands for making tables
        //sneza
        //
        //maja
        //string connectionString = "Data Source=localhost;Initial Catalog=Database;Integrated Security=True";
        string connectionString = "Data Source=localhost;Initial Catalog=Database;Integrated Security=True";
        string command_1 = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DatasetDB1') BEGIN  CREATE TABLE[dbo].[DatasetDB1] ( [Idd] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, [Dataset] INT NOT NULL, [Value] INT NOT NULL, [Code] NVARCHAR(MAX) NOT NULL ); END;";
        string command_2 = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DatasetDB2') BEGIN  CREATE TABLE[dbo].[DatasetDB2] ( [Idd] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, [Dataset] INT NOT NULL, [Value] INT NOT NULL, [Code] NVARCHAR(MAX) NOT NULL ); END;";
        string command_3 = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DatasetDB3') BEGIN  CREATE TABLE[dbo].[DatasetDB3] ( [Idd] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, [Dataset] INT NOT NULL, [Value] INT NOT NULL, [Code] NVARCHAR(MAX) NOT NULL ); END;";
        string command_4 = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DatasetDB4') BEGIN  CREATE TABLE[dbo].[DatasetDB4] ( [Idd] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, [Dataset] INT NOT NULL, [Value] INT NOT NULL, [Code] NVARCHAR(MAX) NOT NULL ); END;";
        string command_5 = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DatasetDB5') BEGIN  CREATE TABLE[dbo].[DatasetDB5] ( [Idd] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, [Dataset] INT NOT NULL, [Value] INT NOT NULL, [Code] NVARCHAR(MAX) NOT NULL ); END;";

        public struct Data
        {
            public string code;
            public string id;
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

        List<Data> listOfData = new List<Data>();
        public void Connect()
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
            }
            catch (Exception e)
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
            Write();
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
            if (Update_1_1().ima == false && Update_1_2().ima == false)
            {
                InsertInTable_1();

            }
            else if (Update_1_1().ima == true)
            {

                foreach (var item in datas)
                {
                    if (item.code == "CODE_ANALOG")
                    {
                       U1_1();
           
                    }
                    else
                        break;
                }

            }
            else if (Update_1_2().ima == true)
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_DIGITAL")
                    {
                        U1_2();
                        }
                    else
                        break;
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
                            U2_2();
                     }
                    else
                        break;
                }

            }
            else if (Update_2_2().ima == true)
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_LIMITSET")
                    {
                            U2_1();
                     }
                    else
                        break;
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
                          U3_1();
                         }
                    else
                        break;
                }
            }
            else if (Update_3_2().ima == true)
            {
                foreach (var item in datas)
                {
                    if (item.code == "CODE_MULTIPLENODE")
                    {
                            U3_2();
                     }
                    else
                        break;
                }

                // U3_2();
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
                         U4_1();
                         }
                    else
                        break;
                }


            }
            else if (Update_4_2().ima == true)
            {

                foreach (var item in datas)
                {
                    if (item.code == "CODE_SOURCE")
                    {
                        
                            U4_2();
                        }
                    else
                        break;
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
                        
                            U5_1();
                        }
                    else
                        break;
                }

            }
            else if (Update_5_2().ima == true)
            {

                foreach (var item in datas)
                {
                    if (item.code == "CODE_SENSOR")
                    {
                         U5_2();
                        }
                    else
                        break;
                }
            }
        }


        //pravljenje liste
        private void ReplaceData()
        {
            Data data = new Data();
            using (StreamWriter sw = new StreamWriter("LogDumpingBaffer.txt"))
            {
                sw.WriteLine("Database");

                foreach (var item in WriterToDumpingBaffer.collectionDescriptions)
                {
                    foreach (var item2 in item.PropertyCollection.DumpingProperties)
                    {

                        if (item.Dataset == 1)
                        {
                            data.code = item2.Code;
                            data.value = item2.DumpingValue;

                            data.id = item.Id;
                            data.dataset = item.Dataset;

                            sw.WriteLine(item2.Code.ToString());
                            sw.WriteLine(item2.DumpingValue.ToString());
                            sw.WriteLine(item.Id.ToString());
                            sw.WriteLine(item.Dataset.ToString());
                            dataset1.Add(data);
                        }
                        else if (item.Dataset == 2)
                        {
                            data.code = item2.Code;
                            data.value = item2.DumpingValue;

                            data.id = item.Id;
                            data.dataset = item.Dataset;

                            sw.WriteLine(item2.Code.ToString());
                            sw.WriteLine(item2.DumpingValue.ToString());
                            sw.WriteLine(item.Id.ToString());
                            sw.WriteLine(item.Dataset.ToString());

                            dataset2.Add(data);
                        }
                        else if (item.Dataset == 3)
                        {
                            data.code = item2.Code;
                            data.value = item2.DumpingValue;

                            data.id = item.Id;
                            data.dataset = item.Dataset;

                            sw.WriteLine(item2.Code.ToString());
                            sw.WriteLine(item2.DumpingValue.ToString());
                            sw.WriteLine(item.Id.ToString());
                            sw.WriteLine(item.Dataset.ToString());

                            dataset3.Add(data);
                        }
                        else if (item.Dataset == 4)
                        {
                            data.code = item2.Code;
                            data.value = item2.DumpingValue;

                            data.id = item.Id;
                            data.dataset = item.Dataset;

                            sw.WriteLine(item2.Code.ToString());
                            sw.WriteLine(item2.DumpingValue.ToString());
                            sw.WriteLine(item.Id.ToString());
                            sw.WriteLine(item.Dataset.ToString());

                            dataset4.Add(data);
                        }
                        else if (item.Dataset == 5)
                        {
                            data.code = item2.Code;
                            data.value = item2.DumpingValue;

                            data.id = item.Id;
                            data.dataset = item.Dataset;


                            sw.WriteLine(item2.Code.ToString());
                            sw.WriteLine(item2.DumpingValue.ToString());
                            sw.WriteLine(item.Id.ToString());
                            sw.WriteLine(item.Dataset.ToString());
                            dataset5.Add(data);
                        }


                        datas.Add(data);
                    }
                }
            }
        }
        private void U1_1()
        {



            string command_delete = "DELETE FROM DatasetDB1 WHERE Code='CODE_ANALOG'";

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
            string command_delete = "DELETE FROM DatasetDB1 WHERE Code='CODE_DIGITAL'";

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
            string command_delete = "DELETE FROM DatasetDB2 WHERE Code='CODE_CUSTOM'";

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

            string command_delete = "DELETE FROM DatasetDB2 WHERE Code='CODE_LIMITSET'";

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

            string command_delete = "DELETE FROM DatasetDB3 WHERE Code='CODE_SINGLENOE'";

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


            string command_delete = "DELETE FROM DatasetDB3 WHERE Code='CODE_MULTIPLENODE'";

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


            string command_delete = "DELETE FROM DatasetDB4 WHERE Code='CODE_CONSUMER'";

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
            string command_delete = "DELETE FROM DatasetDB4 WHERE Code='CODE_SOURCE'";

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
            string command_delete = "DELETE FROM DatasetDB5 WHERE Code='CODE_MOTION'";

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
            string command_delete = "DELETE FROM DatasetDB5 WHERE Code='CODE_SENSOR'";

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

            string command1 = "SET IDENTITY_INSERT DatasetDB1 ON INSERT INTO DatasetDB1 (Idd, Dataset, Value, Code) VALUES (@id, @dataset, @value, @code)";


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

                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                    }

                }


   //           dataset1.Clear();
            }
        }
        private void InsertInTable_2()
        {

            string command1 = "SET IDENTITY_INSERT DatasetDB2 ON INSERT INTO DatasetDB2 (Idd, Dataset, Value, Code) VALUES (@id, @dataset, @value, @code)";


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


            string command1 = "SET IDENTITY_INSERT DatasetDB3 ON INSERT INTO DatasetDB3 (Idd, Dataset, Value, Code) VALUES (@id, @dataset, @value, @code)";


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

            string command1 = "SET IDENTITY_INSERT DatasetDB4 ON INSERT INTO DatasetDB4 (Idd, Dataset, Value, Code) VALUES (@id, @dataset, @value, @code)";


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

            string command1 = "SET IDENTITY_INSERT DatasetDB5 ON INSERT INTO DatasetDB5 (Idd, Dataset, Value, Code) VALUES (@id, @dataset, @value, @code)";


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
            using (SqlCommand com = new SqlCommand("SELECT Idd, Dataset, Value, Code  FROM DatasetDB1 WHERE Code='CODE_ANALOG'", sqlConnection))
            {
                
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {

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
            using (SqlCommand com = new SqlCommand("SELECT Idd, Dataset, Value, Code  FROM DatasetDB1 WHERE Code='CODE_DIGITAL'", sqlConnection))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
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
            using (SqlCommand com = new SqlCommand("SELECT Idd FROM DatasetDB2 WHERE Code='CODE_CUSTOM'", sqlConnection))
            {

                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {

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
            using (SqlCommand com = new SqlCommand("SELECT Idd FROM DatasetDB2 WHERE Code='CODE_LIMITSET'", sqlConnection))
            {

                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
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
            using (SqlCommand com = new SqlCommand("SELECT Idd, Dataset, Value, Code  FROM DatasetDB3 WHERE Code='CODE_SINGLENOE'", sqlConnection))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
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
            using (SqlCommand com = new SqlCommand("SELECT Idd, Dataset, Value, Code  FROM DatasetDB3 WHERE Code='CODE_MULTIPLENODE'", sqlConnection))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {

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
            using (SqlCommand com = new SqlCommand("SELECT Idd FROM DatasetDB4 WHERE Code='CONSUMER'", sqlConnection))
            {

                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {

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
            using (SqlCommand com = new SqlCommand("SELECT Idd FROM DatasetDB4 WHERE Code='CODE_SOURCE'", sqlConnection))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {

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
            using (SqlCommand com = new SqlCommand("SELECT Idd FROM DatasetDB5 WHERE Code='CODE_MOTION'", sqlConnection))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
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
            using (SqlCommand com = new SqlCommand("SELECT Idd FROM DatasetDB5 WHERE Code='CODE_SENSOR'", sqlConnection))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
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
    #endregion
}