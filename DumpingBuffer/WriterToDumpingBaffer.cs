using Common;
using System;
using System.Collections.Generic;
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
        List<CollectionDescription> collectionDescriptions = new List<CollectionDescription>();
        public static List<DeltaCD> deltaCDs = new List<DeltaCD>();
        List<DeltaCD> deltaCDsPom = new List<DeltaCD>();


        int dataset = 0;
        int trId = 0;
        string code;
        int value;
        int count = 0;
        bool isDatasetExist = false;
        bool isEqualsCode = false;

        public void SetDataToDumpingBuffer()
        {
            propertyCollection = new DumpingPropertyCollection();
            collectionDescription = new CollectionDescription();
        
            while (count < 10)
            {
                code = writer.WriteToDumpinBuffer().code;
                value = writer.WriteToDumpinBuffer().value;

                Console.WriteLine("******************");
                Console.WriteLine("DumpingBuffer code: " + code);
                Console.WriteLine("DumpingBuffer value:" + value);
                DumpingProperty dumpingProperty = new DumpingProperty();
                dumpingProperty.Code = code;
                dumpingProperty.DumpingValue = value;//мапирати....

                dataset = GetDataset(code);
                //ako ne postoji nijedan cd
                if (collectionDescriptions.Count == 0)
                {
                    CreateCD(dumpingProperty);//kreiramo
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
                                }
                                
                            }
                            if(!isEqualsCode)
                            {
                                cd.PropertyCollection.DumpingProperties.Add(dumpingProperty);//ako ne, dodajemo
                                if (deltaCDs.Count()==0)
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
            Console.WriteLine("delta" + deltaCDs.Count);
            Console.WriteLine("coll" + collectionDescriptions.Count);
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
