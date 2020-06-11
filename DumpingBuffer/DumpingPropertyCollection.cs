using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBuffer
{
    public class DumpingPropertyCollection
    {

        private List<DumpingProperty> dumpingProperties = new List<DumpingProperty>();

        public DumpingPropertyCollection()
        {
        }

        public List<DumpingProperty> DumpingProperties { get => dumpingProperties; set => dumpingProperties = value; }


    }
}
