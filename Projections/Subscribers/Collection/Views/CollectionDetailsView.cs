using System;

namespace Projections.Subscribers.Collection.Views
{
    public class CollectionDetailsView
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int WipLimit { get; set; }

        public DateTime Created { get; set; }
    }
}