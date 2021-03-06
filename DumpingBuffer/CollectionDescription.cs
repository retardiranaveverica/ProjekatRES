﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBufferComponent
{
    public class CollectionDescription
    {
        private string id;
        private int dataset;
        private DumpingPropertyCollection propertyCollection;

        public CollectionDescription()
        {
            this.id = Id;
            this.dataset = Dataset;
            this.propertyCollection = PropertyCollection;
        }

        public string Id { get => id; set => id = value; }
        public int Dataset { get => dataset; set => dataset = value; }
        public DumpingPropertyCollection PropertyCollection { get => propertyCollection; set => propertyCollection = value; }
    }
}
