using Common;
using DumpingBuffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalComponent
{
    public class DumpingBufferToHistorical : IDumpingBufferToHistorical
    {
        public Array SendToHistorical()
        {
            Array array = WriterToDumpingBaffer.deltaCDs.ToArray();

            return array;
        }
    }
}
