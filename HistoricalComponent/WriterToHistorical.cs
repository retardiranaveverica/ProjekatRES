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
        int id = 0;
        List<DescriptionList> descriptionLists = new List<DescriptionList>();

       public void SettingValues()
       {
            string code = writer.ManualWriteToHistory().code;
            int value = writer.ManualWriteToHistory().value;
            Console.WriteLine("******************");
            Console.WriteLine("Historical value:" + value);
            Console.WriteLine("historical code:" + code);

            historicalProperty = new HistoricalProperty();
            historicalProperty.Code = code;
            historicalProperty.HistoricalValue = value;

            description = new Description();
            description.HistoricalProperties.Add(historicalProperty);
            
            description.Id = ++id;

            if (code == "CODE_ANALOG" || code == "CODE_DIGITAL")
                description.Dataset = 1;
            else if (code == "CODE_CUSTOM" || code == "CODE_LIMITSET")
                description.Dataset = 2;
            else if (code == "CODE_SINGLENOE" || code == "CODE_MULTIPLENODE")
                description.Dataset = 3;
            else if (code == "CODE_CONSUMER" || code == "CODE_SOURCE")
                description.Dataset = 4;
            else if (code == "CODE_MOTION" || code == "CODE_SENSOR")
                description.Dataset = 5;

            descriptionList = new DescriptionList();
            descriptionList.descriptions.Add(description);
            descriptionLists.Add(descriptionList);
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
    }
}
