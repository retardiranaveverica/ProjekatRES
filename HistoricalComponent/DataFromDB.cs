using Common;
using DumpingBufferComponent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalComponent
{
    public class DataFromDB
    {
        IDumpingBufferToHistorical dumpingBufferToHistorical = new DumpingBufferToHistorical();

        //lista koju dobijamo od DB
        List<DeltaCD> list;
        //lista koja treba da se upise u bazu
        public static List<DescriptionList> descriptionLists = new List<DescriptionList>();

        //klase koje nam trebaju za mapiranje
        HistoricalProperty historicalProperty;
        Description description;
        DescriptionList descriptionList;
        string code;
        int dataset;

        //data from CDAdd
        public void PackAddData()
        {
            Array array = dumpingBufferToHistorical.SendToHistorical();
            
            list = array.Cast<DeltaCD>().ToList();

            historicalProperty = new HistoricalProperty();
            description = new Description();
            descriptionList = new DescriptionList();

            foreach(var item in list)
            {
                foreach(var item2 in item.CollectionDescriptionAdd.PropertyCollection.DumpingProperties)
                {
                    historicalProperty.Code = item2.Code;
                    code = item2.Code;
                    historicalProperty.HistoricalValue = item2.DumpingValue;

                    if (code == "CODE_ANALOG")
                        description.Id = 1;
                    else if (code == "CODE_DIGITAL")
                        description.Id = 2;
                    else if (code == "CODE_CUSTOM")
                        description.Id = 3;
                    else if (code == "CODE_LIMITSET")
                        description.Id = 4;
                    else if (code == "CODE_SINGLENOE")
                        description.Id = 5;
                    else if (code == "CODE_MULTIPLENODE")
                        description.Id = 6;
                    else if (code == "CODE_CONSUMER")
                        description.Id = 7;
                    else if (code == "CODE_SOURCE")
                        description.Id = 8;
                    else if (code == "CODE_MOTION")
                        description.Id = 9;
                    else if (code == "CODE_SENSOR")
                        description.Id = 10;
                }
                
                description.Dataset = item.CollectionDescriptionAdd.Dataset;
                dataset = item.CollectionDescriptionAdd.Dataset;

                if (CheckCodeAndDataset())
                {
                    description.HistoricalProperties.Add(historicalProperty);

                    descriptionList.Descriptions.Add(description);
                    descriptionLists.Add(descriptionList);
                } else
                {
                    Console.WriteLine("Error with code and dataset!");
                }
                
            }

            Read();
        }

        private void Read()
        {
           using(StreamWriter writer = new StreamWriter("DumpingBufferValues.txt"))
                foreach(var item in descriptionLists)
                {
                    foreach(var item2 in item.descriptions)
                    {
                        foreach(var item3 in item2.HistoricalProperties)
                        {
                            
                            Console.WriteLine(item3.Code);
                            Console.WriteLine(item3.HistoricalValue);
                            Console.WriteLine(item2.Id);
                            Console.WriteLine(item2.Dataset);
                            writer.WriteLine("Code: " + item3.Code);
                            writer.WriteLine("Value" + item3.HistoricalValue);
                            writer.WriteLine("Id: " +item2.Id);
                            writer.WriteLine("Dataset: " +item2.Dataset);
                        }
                    }
                }
            
        }
        //data from CDUpdate
        private void PackUpdateData() {
            Array array = dumpingBufferToHistorical.SendToHistorical();
            list = array.Cast<DeltaCD>().ToList();

            historicalProperty = new HistoricalProperty();
            description = new Description();
            descriptionList = new DescriptionList();

            foreach (var item in list)
            {
                foreach (var item2 in item.CollectionDescriptionUpdate.PropertyCollection.DumpingProperties)
                {
                    historicalProperty.Code = item2.Code;
                    code = item2.Code;
                    historicalProperty.HistoricalValue = item2.DumpingValue;
                }

                //  description.Id = item.CollectionDescriptionAdd.Id;
                description.Dataset = item.CollectionDescriptionUpdate.Dataset;
                dataset = item.CollectionDescriptionAdd.Dataset;

                if (CheckCodeAndDataset())
                {
                    description.HistoricalProperties.Add(historicalProperty);

                    descriptionList.Descriptions.Add(description);
                    descriptionLists.Add(descriptionList);
                }
                else
                {
                    Console.WriteLine("Error with code and dataset!");
                }

            }

        }

        //Check the code and database it is correct
        private bool CheckCodeAndDataset()
        {
            bool succesfull = true;

            if (code == "CODE_ANALOG")
            {
                if (dataset == 1)
                    succesfull = true;
                else
                    succesfull = false;
            } else if (code == "CODE_DIGITAL")
            {
                if (dataset == 1)
                    succesfull = true;
                else
                    succesfull = false;
            }
            else if (code == "CODE_CUSTOM")
            {
                if (dataset == 2)
                    succesfull = true;
                else
                    succesfull = false;
            }
            else if (code == "CODE_LIMITSET")
            {
                if (dataset == 2)
                    succesfull = true;
                else
                    succesfull = false;
            }
            else if (code == "CODE_SINGLENODE ")
            {
                if (dataset == 3)
                    succesfull = true;
                else
                    succesfull = false;
            }
            else if (code == "CODE_MULTIPLENODE")
            {
                if (dataset == 3)
                    succesfull = true;
                else
                    succesfull = false;
            }
            else if (code == "CODE_CONSUMER")
            {
                if (dataset == 4)
                    succesfull = true;
                else
                    succesfull = false;
            }
            else if (code == "CODE_SOURCE")
            {
                if (dataset == 4)
                    succesfull = true;
                else
                    succesfull = false;
            }
            else if (code == "CODE_MOTION")
            {
                if (dataset == 5)
                    succesfull = true;
                else
                    succesfull = false;
            }
            else if (code == "CODE_SENSOR")
            {
                if (dataset == 5)
                    succesfull = true;
                else
                    succesfull = false;
            }

            return succesfull;
        }
    }
}
