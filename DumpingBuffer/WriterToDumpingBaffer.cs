using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WriterComponent;

namespace DumpingBuffer
{
    public class WriterToDumpingBaffer
    {
        IWriter writer = new Writer();

        DumpingProperty dumpingProperty;
        DumpingPropertyCollection propertyCollection;
        CollectionDescription collectionDescription;
        List<CollectionDescription> collectionDescriptions = new List<CollectionDescription>();
        public static List<DeltaCD> deltaCDs = new List<DeltaCD>();

        //list for datasets
        #region
        List<CollectionDescription> dataset1_1 = new List<CollectionDescription>();
        List<CollectionDescription> dataset1_2 = new List<CollectionDescription>();
        List<CollectionDescription> dataset2_1 = new List<CollectionDescription>();
        List<CollectionDescription> dataset2_2 = new List<CollectionDescription>();
        List<CollectionDescription> dataset3_1 = new List<CollectionDescription>();
        List<CollectionDescription> dataset3_2 = new List<CollectionDescription>();
        List<CollectionDescription> dataset4_1 = new List<CollectionDescription>();
        List<CollectionDescription> dataset4_2 = new List<CollectionDescription>();
        List<CollectionDescription> dataset5_1 = new List<CollectionDescription>();
        List<CollectionDescription> dataset5_2 = new List<CollectionDescription>();
        #endregion

        //int for count the number of codes
        #region
        int CODE_ANALOG, CODE_DIGITAL;
        int CODE_CUSTOM, CODE_LIMITSET;
        int CODE_SINGLENOE, CODE_MULTIPLENODE;
        int CODE_CONSUMER, CODE_SOURCE;
        int CODE_MOTION, CODE_SENSOR;
        #endregion

        int id = 0;
        string code;
        int value;
        int numberOfRecivedData = 0;
        int cdID = 0;

        public void SetDataToDumpingBuffer()
        {
            for (int i = 0; i < 10; i++)
            {
               
                code = writer.WriteToDumpinBuffer().code;
                value = writer.WriteToDumpinBuffer().value;

                Console.WriteLine("******************");
                Console.WriteLine("DumpingBuffer code: " + code);
                Console.WriteLine("DumpingBuffer value:" + value);

                dumpingProperty = new DumpingProperty();

                //ako postoji da ga promeni
                foreach (var item in collectionDescriptions)
                {
                    foreach (var item2 in item.PropertyCollection.DumpingProperties)
                    {
                        if (item2.Code == code)
                        {
                            item2.DumpingValue = value;
                            break;
                        }
                    }
                }

                dumpingProperty.Code = code;
                dumpingProperty.DumpingValue = value;

                propertyCollection = new DumpingPropertyCollection();
                propertyCollection.DumpingProperties.Add(dumpingProperty);


                collectionDescription = new CollectionDescription();

                collectionDescription.Id = ++id;

                //setting dataset and adding in list 
                #region DATASET
                if (code == "CODE_ANALOG")
                {
                    collectionDescription.Dataset = 1;
                    CODE_ANALOG++;

                }
                else if (code == "CODE_DIGITAL")
                {
                    collectionDescription.Dataset = 1;
                    CODE_DIGITAL++;
                }
                else if (code == "CODE_CUSTOM")
                {
                    collectionDescription.Dataset = 2;
                    CODE_CUSTOM++;

                }
                else if (code == "CODE_LIMITSET")
                {
                    collectionDescription.Dataset = 2;
                    CODE_LIMITSET++;
                }
                else if (code == "CODE_SINGLENOE")
                {
                    collectionDescription.Dataset = 3;
                    CODE_SINGLENOE++;

                }
                else if (code == "CODE_MULTIPLENODE")
                {
                    collectionDescription.Dataset = 3;
                    CODE_MULTIPLENODE++;
                }
                else if (code == "CODE_CONSUMER")
                {
                    collectionDescription.Dataset = 4;
                    CODE_CONSUMER++;

                }
                else if (code == "CODE_SOURCE")
                {
                    collectionDescription.Dataset = 4;
                    CODE_SOURCE++;
                }
                else if (code == "CODE_MOTION")
                {
                    collectionDescription.Dataset = 5;
                    CODE_MOTION++;

                }
                else if (code == "CODE_SENSOR")
                {
                    collectionDescription.Dataset = 5;
                    CODE_SENSOR++;
                }
                #endregion

                collectionDescription.PropertyCollection = propertyCollection;
                collectionDescriptions.Add(collectionDescription);
                AddElementToDatasetList();

                numberOfRecivedData++;
                CheckDatasetMember();

                Read();
                Thread.Sleep(2000);
            }
        }

        private void Read()
        {
            foreach(var item in collectionDescriptions)
            {
                Console.WriteLine("ID: " + item.Id);
                Console.WriteLine("Dataset" + item.Dataset);
                foreach(var item2 in item.PropertyCollection.DumpingProperties)
                {
                    Console.WriteLine("Code: " + item2.Code);
                    Console.WriteLine("Value: " + item2.DumpingValue);
                }
            }
            Console.WriteLine("----------------------------------");
        }

        private bool CheckCodeValue()
        {
            bool change = false;
            foreach (var item in collectionDescriptions)
            {
                foreach (var item2 in item.PropertyCollection.DumpingProperties)
                {
                    if (writer.WriteToDumpinBuffer().code == item2.Code)
                    {
                        change = true;
                    }
                    else
                       change = false;
                }
            }

           return change;
        }

        private void CheckDatasetMember()
        {
            DeltaCD deltaCD_1 = new DeltaCD();
            DeltaCD deltaCD_2 = new DeltaCD();

            CollectionDescription collection = new CollectionDescription();

            if (CODE_ANALOG >= 1 && CODE_DIGITAL >= 1)
            {
                //bool first = false;
                collection = dataset1_1.First();

                deltaCD_1.TranscationID = ++cdID;
                deltaCD_1.CollectionDescriptionAdd.Dataset = collection.Dataset;
                deltaCD_1.CollectionDescriptionAdd.Id = collection.Id;
                deltaCD_1.CollectionDescriptionAdd.PropertyCollection = collection.PropertyCollection;
                deltaCDs.Add(deltaCD_1);

                collection = dataset1_2.First();

                deltaCD_2.TranscationID = ++cdID;
                deltaCD_2.CollectionDescriptionAdd.Dataset = collection.Dataset;
                deltaCD_2.CollectionDescriptionAdd.Id = collection.Id;
                deltaCD_2.CollectionDescriptionAdd.PropertyCollection = collection.PropertyCollection;
                deltaCDs.Add(deltaCD_2);
                //first = true;

                //if (first)
                //{
                //    dataset1_1.Clear();
                //    dataset1_2.Clear();
                //}


            }
            if(CODE_CUSTOM >= 1 && CODE_LIMITSET >= 1)
            {
               // bool first = false;

                collection = dataset2_1.First();

                deltaCD_1.TranscationID = ++cdID;
                deltaCD_1.CollectionDescriptionAdd.Dataset = collection.Dataset;
                deltaCD_1.CollectionDescriptionAdd.Id = collection.Id;
                deltaCD_1.CollectionDescriptionAdd.PropertyCollection = collection.PropertyCollection;
                deltaCDs.Add(deltaCD_1);

                collection = dataset2_2.First();
                deltaCD_2.TranscationID = ++cdID;
                deltaCD_2.CollectionDescriptionAdd.Dataset = collection.Dataset;
                deltaCD_2.CollectionDescriptionAdd.Id = collection.Id;
                deltaCD_2.CollectionDescriptionAdd.PropertyCollection = collection.PropertyCollection;
                deltaCDs.Add(deltaCD_2);


                //first = true;

                //if (first)
                //{
                //    dataset2_1.Clear();
                //    dataset2_2.Clear();
                //}


            }
            if (CODE_SINGLENOE >= 1 && CODE_MULTIPLENODE >= 1)
            {
                //bool first = false;
                collection = dataset3_1.First();

                deltaCD_1.TranscationID = ++cdID;
                deltaCD_1.CollectionDescriptionAdd.Dataset = collection.Dataset;
                deltaCD_1.CollectionDescriptionAdd.Id = collection.Id;
                deltaCD_1.CollectionDescriptionAdd.PropertyCollection = collection.PropertyCollection;
                deltaCDs.Add(deltaCD_1);

                collection = dataset3_2.First();
                deltaCD_2.TranscationID = ++cdID;
                deltaCD_2.CollectionDescriptionAdd.Dataset = collection.Dataset;
                deltaCD_2.CollectionDescriptionAdd.Id = collection.Id;
                deltaCD_2.CollectionDescriptionAdd.PropertyCollection = collection.PropertyCollection;
                deltaCDs.Add(deltaCD_2);

                //first = true;

                //if (first)
                //{
                //    dataset3_1.Clear();
                //    dataset3_2.Clear();
                //}


            }
            if (CODE_CONSUMER >= 1 && CODE_SOURCE >= 1)
            {
                //bool first = false;
                collection = dataset4_1.First();

                deltaCD_1.TranscationID = ++cdID;
                deltaCD_1.CollectionDescriptionAdd.Dataset = collection.Dataset;
                deltaCD_1.CollectionDescriptionAdd.Id = collection.Id;
                deltaCD_1.CollectionDescriptionAdd.PropertyCollection = collection.PropertyCollection;
                deltaCDs.Add(deltaCD_1);

                collection = dataset4_2.First();
                deltaCD_2.TranscationID = ++cdID;
                deltaCD_2.CollectionDescriptionAdd.Dataset = collection.Dataset;
                deltaCD_2.CollectionDescriptionAdd.Id = collection.Id;
                deltaCD_2.CollectionDescriptionAdd.PropertyCollection = collection.PropertyCollection;
                deltaCDs.Add(deltaCD_2);

                //first = true;

                //if (first)
                //{
                //    dataset4_1.Clear();
                //    dataset4_2.Clear();
                //}


            }
            if (CODE_MOTION >= 1 && CODE_SENSOR >= 1)
            {

                //bool first = false;
                collection = dataset5_1.First();

                deltaCD_1.TranscationID = ++cdID;
                deltaCD_1.CollectionDescriptionAdd.Dataset = collection.Dataset;
                deltaCD_1.CollectionDescriptionAdd.Id = collection.Id;
                deltaCD_1.CollectionDescriptionAdd.PropertyCollection = collection.PropertyCollection;
                deltaCDs.Add(deltaCD_1);

                collection = dataset5_2.First();
                deltaCD_2.TranscationID = ++cdID;
                deltaCD_2.CollectionDescriptionAdd.Dataset = collection.Dataset;
                deltaCD_2.CollectionDescriptionAdd.Id = collection.Id;
                deltaCD_2.CollectionDescriptionAdd.PropertyCollection = collection.PropertyCollection;
                deltaCDs.Add(deltaCD_2);

                //first = true;

                //if (first)
                //{
                //    dataset5_1.Clear();
                //    dataset5_2.Clear();
                //}


            }

        }

        private void AddElementToDatasetList()
        {
            if (code == "CODE_ANALOG")
            {
                dataset1_1.Add(collectionDescription);
            }
            else if (code == "CODE_DIGITAL")
            {
                dataset1_2.Add(collectionDescription);
            }
            else if (code == "CODE_CUSTOM")
            {
                dataset2_1.Add(collectionDescription);
            }
            else if (code == "CODE_LIMITSET")
            {
                dataset2_2.Add(collectionDescription);
            }
            else if (code == "CODE_SINGLENOE")
            {
                dataset3_1.Add(collectionDescription);
            }
            else if (code == "CODE_MULTIPLENODE")
            {
                dataset3_2.Add(collectionDescription);
            }
            else if (code == "CODE_CONSUMER")
            {
                dataset4_1.Add(collectionDescription);
            }
            else if (code == "CODE_SOURCE")
            {
                dataset4_2.Add(collectionDescription);
            }
            else if (code == "CODE_MOTION")
            {
                dataset5_1.Add(collectionDescription);
            }
            else if (code == "CODE_SENSOR")
            {
                dataset5_2.Add(collectionDescription);
            }
        }
    }
}
