using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WriterComponent;

namespace HistoricalComponent
{
    public class WriterToHistorical
    {
        IWriter writer = new Writer();
        HistoricalProperty historicalProperty;
        Description description;
        DescriptionList descriptionList;

        //lista svih vrednosti dobijenih od Writtera
        public static List<DescriptionList> descriptionLists = new List<DescriptionList>();

        public void SettingValues()
        {
            string code = writer.ManualWriteToHistory().code;
            int value = writer.ManualWriteToHistory().value;
            Console.WriteLine("******************");
            Console.WriteLine("Historical value:" + value);
            Console.WriteLine("Historical code:" + code);
            Console.WriteLine("******************");


            int indeks = ChechForUpdate(code);

            if (indeks < 0)
            {

                historicalProperty = new HistoricalProperty();
                historicalProperty.Code = code;
                historicalProperty.HistoricalValue = value;

                description = new Description();
                description.HistoricalProperties.Add(historicalProperty);



                #region dataset and id
                if (code == "CODE_ANALOG")
                {
                    description.Dataset = 1;
                    description.Id = 1;
                }
                else if (code == "CODE_DIGITAL")
                {
                    description.Dataset = 1;
                    description.Id = 2;
                }
                else if (code == "CODE_CUSTOM")
                {
                    description.Dataset = 2;
                    description.Id = 3;
                }
                else if (code == "CODE_LIMITSET")
                {
                    description.Dataset = 2;
                    description.Id = 4;
                }
                else if (code == "CODE_SINGLENODE ")
                {
                    description.Dataset = 3;
                    description.Id = 5;
                }
                else if (code == "CODE_MULTIPLENODE")
                {
                    description.Dataset = 3;
                    description.Id = 6;
                }
                else if (code == "CODE_CONSUMER")
                {
                    description.Dataset = 4;
                    description.Id = 7;
                }
                else if (code == "CODE_SOURCE")
                {
                    description.Dataset = 4;
                    description.Id = 8;
                }
                else if (code == "CODE_MOTION")
                {
                    description.Dataset = 5;
                    description.Id = 9;
                }
                else if (code == "CODE_SENSOR")
                {
                    description.Dataset = 5;
                    description.Id = 10;
                }
                #endregion

                descriptionList = new DescriptionList();
                descriptionList.descriptions.Add(description);

                descriptionLists.Add(descriptionList);
            } else
            {
                foreach (var item in descriptionLists)
                {
                    foreach (var item2 in item.descriptions)
                    {
                        foreach (var item3 in item2.HistoricalProperties)
                        {
                            if (indeks == item2.Id)
                                item3.HistoricalValue = value;
                        }

                    }

                }
            }
            Read();
            
            Thread.Sleep(2000);
        } 


        private void Read()
        {
            foreach(var item in descriptionLists)
            {
                foreach(var item2 in item.descriptions)
                {
                    Console.WriteLine("Dataset: " + item2.Dataset);
                    Console.WriteLine("ID: " + item2.Id);
                    foreach(var item3 in item2.HistoricalProperties)
                    {
                        Console.WriteLine("Code: " + item3.Code);
                        Console.WriteLine("Value: " + item3.HistoricalValue); ;
                    }
                }
            }
        }

        private int ChechForUpdate(string code)
        {
            int found = -1;
            foreach(var item in descriptionLists)
            {
                foreach(var item2 in item.descriptions)
                {
                    foreach(var item3 in item2.HistoricalProperties)
                    {
                        if (item3.Code == code)
                            found = item2.Id;
                    }
                    
                }
                
            }
            return found;
        }
    }
}
