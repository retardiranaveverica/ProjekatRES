using Common;
using DumpingBuffer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WriterComponent;

namespace DumpingBufferComponent
{
    public class WriterToDumpingBaffer
    {
        IWriter writer = new Writer();

        DumpingPropertyCollection propertyCollection = new DumpingPropertyCollection();
        CollectionDescription collectionDescription = new CollectionDescription();
        public static List<CollectionDescription> collectionDescriptions = new List<CollectionDescription>();
        public static List<DeltaCD> deltaCDs = new List<DeltaCD>();
        DatabaseDB databaseDB = new DatabaseDB();

        int dataset = 0;
        int trId = 0;
        string code;
        int value;
        int count = 0;
        bool isDatasetExist = false;
        bool isEqualsCode = false;
        StreamWriter sw = new StreamWriter("WToDB.txt");

        public void SetDataToDumpingBuffer()
        {
            databaseDB.Create();
            databaseDB.Connect();
            using (sw)
            {
                propertyCollection = new DumpingPropertyCollection();
                collectionDescription = new CollectionDescription();

                while (count < 10)
                {

                    sw.WriteLine("******************************************");


                    code = writer.WriteToDumpinBuffer().code;
                    value = writer.WriteToDumpinBuffer().value;

                    sw.WriteLine("CODE: " + code);
                    sw.WriteLine("VALUE:" + value);
                    
                    Console.WriteLine("******************");
                    Console.WriteLine("DumpingBuffer code: " + code);
                    Console.WriteLine("DumpingBuffer value:" + value);
                    DumpingProperty dumpingProperty = new DumpingProperty();
                    dumpingProperty.Code = code;
                    dumpingProperty.DumpingValue = value;
                    
                    dataset = GetDataset(code);
                    //ako ne postoji nijedan cd
                    if (collectionDescriptions.Count == 0)
                    {
                        CreateCD(dumpingProperty);//kreiramo
                        databaseDB.WriteToDatabase();

                    }
                    else
                    {
                        foreach (CollectionDescription cd in collectionDescriptions.ToList())
                        {
                            //da li u CDs postoji CD sa tim dataset-om
                            if (cd.Dataset == dataset)//ako postoji
                            {
                                isDatasetExist = true;
                                foreach (DumpingProperty dp in cd.PropertyCollection.DumpingProperties.ToList())
                                {
                                    if (dp.Code == code)//provera da li postoji taj code
                                    {
                                        isEqualsCode = true;
                                        dp.DumpingValue = value;//ako postoji, azuruiranje vrednosti
                                        databaseDB.WriteToDatabase();
                                    }

                                }
                                if (!isEqualsCode)
                                {
                                    cd.PropertyCollection.DumpingProperties.Add(dumpingProperty);//ako ne, dodajemo
                                    databaseDB.WriteToDatabase();
                                    if (deltaCDs.Count() == 0)
                                    {
                                        DeltaCD deltaCD = new DeltaCD();
                                        deltaCD.TranscationID = ++trId;
                                        deltaCD.CollectionDescriptionAdd = cd;
                                        collectionDescriptions.Remove(cd);
                                        deltaCDs.Add(deltaCD);
                                    }
                                }
                            }


                        }
                        //ako ne postoji CD, napravimo ga
                        if (!isDatasetExist)
                        {
                            CreateCD(dumpingProperty);
                            databaseDB.WriteToDatabase();
                        }
                        isDatasetExist = false;
                        isEqualsCode = false;
                        
                    }
                    count++;

                    Read();

                    if (count == 10)
                    {
                        if (deltaCDs.Count == 0)
                        {
                            count = 0;
                        }
                    }
                    Thread.Sleep(2000);
                }

                count = 0;
            }

       //     databaseDB.sqlConnection.Close();

        }

        private void Read()
        {
            foreach (var item in collectionDescriptions)
            {
                Console.WriteLine("ID: " + item.Id.ToString());
                Console.WriteLine("Dataset" + item.Dataset);
                foreach (var item2 in item.PropertyCollection.DumpingProperties)
                {
                    Console.WriteLine("Code: " + item2.Code);
                    Console.WriteLine("Value: " + item2.DumpingValue);
                }
            }
            Console.WriteLine("----------------------------------");
        }

        private int GetDataset(string c)
        {
            int ds = 0;
            if (c == "CODE_ANALOG" || c == "CODE_DIGITAL")
            {
                ds = 1;
            }
            else if (c == "CODE_CUSTOM" || c == "CODE_LIMITSET")
            {
                ds = 2;
            }
            else if (c == "CODE_SINGLENOE" || c == "CODE_MULTIPLENODE")
            {
                ds = 3;
            }

            else if (c == "CODE_CONSUMER" || c == "CODE_SOURCE")
            {
                ds = 4;
            }
            else if (c == "CODE_MOTION" || c == "CODE_SENSOR")
            {
                ds = 5;
            }

            return ds;
        }

        private void CreateCD(DumpingProperty dumpingProperty)
        {
            CollectionDescription collectionDescription = new CollectionDescription();
            Guid g = Guid.NewGuid();
            collectionDescription.Id = g.ToString();
            collectionDescription.Dataset = dataset;
            DumpingPropertyCollection propertyCollection = new DumpingPropertyCollection();
            collectionDescription.PropertyCollection = propertyCollection;
            collectionDescription.PropertyCollection.DumpingProperties.Add(dumpingProperty);
            collectionDescriptions.Add(collectionDescription);
        }

    }
}
