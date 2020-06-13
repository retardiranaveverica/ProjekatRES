using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpingBufferComponent
{
    public class DeltaCD
    {
        private int transcationID;
        private CollectionDescription collectionDescriptionAdd = new CollectionDescription();
        private CollectionDescription collectionDescriptionUpdate = new CollectionDescription();

        public DeltaCD(int transcationID, CollectionDescription collectionDescriptionAdd, CollectionDescription collectionDescriptionUpdate)
        {
            this.TranscationID = transcationID;
            this.CollectionDescriptionAdd = collectionDescriptionAdd;
            this.CollectionDescriptionUpdate = collectionDescriptionUpdate;
        }

        public DeltaCD() { }

        public int TranscationID { get => transcationID; set => transcationID = value; }
        public CollectionDescription CollectionDescriptionAdd { get => collectionDescriptionAdd; set => collectionDescriptionAdd = value; }
        public CollectionDescription CollectionDescriptionUpdate { get => collectionDescriptionUpdate; set => collectionDescriptionUpdate = value; }
    }
}
