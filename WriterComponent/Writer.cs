using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriterComponent
{
    
    public enum ListOfCodes { CODE_ANALOG, CODE_DIGITAL, CODE_CUSTOM, CODE_LIMITSET, CODE_SINGLENOE, CODE_MULTIPLENODE, CODE_CONSUMER, CODE_SOURCE, CODE_MOTION, CODE_SENSOR }

    public class Writer : IWriter
    {
        //Writting directly to Historical
        
        public Data ManualWriteToHistory()
        {
            Data data = new Data();
            Array values = Enum.GetValues(typeof(ListOfCodes));
            Random random = new Random();
            ListOfCodes c = (ListOfCodes)values.GetValue(random.Next(values.Length));
            
            data.code = c.ToString();
            data.value = random.Next(50);
            using (StreamWriter stream = new StreamWriter("Writter.txt", true))
            {
                stream.WriteLine("Code: " + data.code);
                stream.WriteLine("Value: " + data.value);
            }

            return data;
        }
        
        //Writting to DumpingBuffer then to Historical
        public Data WriteToDumpinBuffer()
        {
            Data data = new Data();
            Array values = Enum.GetValues(typeof(ListOfCodes));
            Random random = new Random();
            ListOfCodes c = (ListOfCodes)values.GetValue(random.Next(values.Length));
            data.code = c.ToString();
            data.value = random.Next(50);

            using (StreamWriter stream = new StreamWriter("WritterII.txt", true))
            {
                stream.WriteLine("Code: " + data.code);
                
                stream.WriteLine("Value: " + data.value);
            }
            return data;
        }
    }
}
