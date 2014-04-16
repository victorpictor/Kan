using System;
using System.Collections.Generic;

namespace Projections.Subscribers.Collection.Views
{
    public class CollectionHistoryView
    {
        public Guid CollectionId { get; set; }

        public List<Modification> History { get; set; }
    }

    public struct Modification
    {
        public Guid CollectionId;

        public DateTime RecordedOn;

        public string Text;

        public string By;
    }

}