using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBufferComponent
{
    public class CollectionDescription
    {
        private int id;
        private int dataset;
        private DumpingPropertyCollection propertyCollection;

        public CollectionDescription()
        {
            this.id = Id;
            this.dataset = Dataset;
            this.propertyCollection = PropertyCollection;
        }

        public int Id { get => id; set => id = value; }
        public int Dataset { get => dataset; set => dataset = value; }
        public DumpingPropertyCollection PropertyCollection { get => propertyCollection; set => propertyCollection = value; }
        public string GenerateId()
        {
            string returnValue;

            Guid g1 = Guid.NewGuid();
            Guid g2 = Guid.NewGuid();
            return g1.ToString() + g2.ToString();
/*            
            Random rand = new Random();
            returnValue = rand.Next(0, 1000000);
            */
            //mora se proveriti da li postoji vec ovaj id u bazi 
            //ako ne postoji 
            return returnValue;

            //ako nije GenerateId();
        }
    }

    
}
