using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalComponent
{
    public class HistoricalProperty
    {
        private string code;
        private int historicalValue;

        public HistoricalProperty(string code, int historicalValue)
        {
            this.Code = code;
            this.HistoricalValue = historicalValue;
        }

        public HistoricalProperty()
        {

        }

        public string Code { get => code; set => code = value; }
        public int HistoricalValue { get => historicalValue; set => historicalValue = value; }

    }
}
