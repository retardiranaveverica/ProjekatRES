using Common;
using DumpingBufferComponent;
using System;
using System.Collections.Generic;
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
        private void PackAddData()
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
                }

              //  description.Id = item.CollectionDescriptionAdd.Id;
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
        }

        //data from CDUpdate
        private void PackUpdateData() { }

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
