using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalComponent
{
    public class Description
    {
        private int id;
        private List<HistoricalProperty> historicalProperties = new List<HistoricalProperty>();
        private int dataset;

        public Description(int id, List<HistoricalProperty> historicalProperties, int dataset)
        {
            this.Id = id;
            this.HistoricalProperties = historicalProperties;
            this.Dataset = dataset;
        }

        public Description() { }

        public int Id { get => id; set => id = value; }
        public List<HistoricalProperty> HistoricalProperties { get => historicalProperties; set => historicalProperties = value; }
        public int Dataset { get => dataset; set => dataset = value; }

    }
}
