using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBuffer
{
    public class DumpingProperty
    {
        private string code;
        private int dumpingValue;

        public DumpingProperty(string code, int dumpingValue)
        {
            this.Code = code;
            this.DumpingValue = dumpingValue;
        }
        public DumpingProperty() { }

        public string Code { get => code; set => code = value; }
        public int DumpingValue { get => dumpingValue; set => dumpingValue = value; }
    }
}
