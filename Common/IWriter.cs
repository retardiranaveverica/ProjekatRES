using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    //struktura za vracanje
    public struct Data
    {
       public string code { get; set; }
       public int value { get; set; }
    }

    public interface IWriter
    {
        Data ManualWriteToHistory();

        Data WriteToDumpinBuffer();
    }
}
