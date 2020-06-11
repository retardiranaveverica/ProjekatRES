using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalComponent
{
    public class DescriptionList
    {
        public List<Description> descriptions = new List<Description>();

        public List<Description> Descriptions { get => descriptions; set => descriptions = value; }

    }
}
